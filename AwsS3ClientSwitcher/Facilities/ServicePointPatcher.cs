using System.Net.Sockets;
using System.Reflection;

using HarmonyLib;

namespace System.Net
{
	public static class ServicePointPatcher
	{
		/// <summary>
		/// Patch to override TCP Keep-Alive for linux OS if magic detected (probes value packed into interval integer)
		/// https://github.com/mono/mono/blob/c6cdaadb54a1173484f1ada524306ddbf8c2e7d5/mcs/class/System/System.Net/ServicePoint.cs#L196
		/// </summary>
		public static void PatchKeepAliveSetup()
		{
			if (EnvironmentHelper.RunningOnLinux)
			{
				var original = typeof(ServicePoint).GetMethod("KeepAliveSetup", BindingFlags.NonPublic | BindingFlags.Instance);
				var prefix = typeof(ServicePointPatcher).GetMethod(nameof(KeepAliveSetupPrefix));
				var harmony = new Harmony($"{nameof(ServicePointPatcher)}::{original.Name}");
				harmony.Patch(original, new HarmonyMethod(prefix));
			}
		}

		public static bool KeepAliveSetupPrefix(Socket socket, bool ___tcp_keepalive, ref int ___tcp_keepalive_interval)
		{
			if (!___tcp_keepalive)
				return true;

			// 0111_0111 0000_0101 0000_0000 0000_1010
			var magic = (___tcp_keepalive_interval & 0xFF000000) >> 24; //< XXX: We use the lead byte as magic value.
			if (magic == 0x77)
			{
				var count = (___tcp_keepalive_interval & 0x00FF0000) >> 16; //< Let's extract our packed count value.
				___tcp_keepalive_interval &= 0xFFFF; //< And restore 'real' interval value (lower 2 bytes)

				socket.SetSockOptSysCall(SocketOptionLevel.Tcp, (SocketOptionName)0x6, count);
			}

			return true; //< Call original method.
		}

		/// <summary>
		/// Example: 0111_0111 0000_0101 0000_0000 0000_1010
		///     - 0111_0111 => The first byte is our magic value 0x77.
		///     - 0000_0101 => Count (one byte).
		///     - 0000_0000 0000_1010 => Interval (two bytes).
		/// </summary>
		public static int GetPacked(byte count, ushort interval)
		{
			// tcp_keepalive_probes
			// sbyte.MinValue  =>   -128 => 1111 1111 1000 0000
			// sbyte.MaxValue  =>    127 => 0111 1111
			//  byte.MinValue  =>      0 => 0000 0000
			//  byte.MaxValue  =>    255 => 1111 1111
			//
			// tcp_keepalive_intvl
			//	short.MinValue => -32768 => 1000 0000 0000 0000
			//  short.MaxValue =>  32767 => 0111 1111 1111 1111
			// ushort.MinValue =>      0 => 0000 0000 0000 0000
			// ushort.MaxValue =>  65535 => 1111 1111 1111 1111
			return (0x77 << 24) + (count << 16) + (interval); //< ie. c=3, i=5 => 0111_0111 0000_0011 0000_0000 0000_0101
		}
	}
}
