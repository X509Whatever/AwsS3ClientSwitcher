using System.Runtime.InteropServices;

namespace System.Net.Sockets
{
	internal static class SockOptInterop
	{
		#region Private methods

		[DllImport("libc", EntryPoint = "getsockopt")]
		private static extern unsafe int GetSockOptSysCall(IntPtr socketFileDescriptor, int optionLevel, int optionName, byte* optionValue, int* optionLen);

		[DllImport("libc", EntryPoint = "setsockopt")]
		private static extern unsafe int SetSockOptSysCall(IntPtr socketFileDescriptor, int optionLevel, int optionName, byte* optionValue, int optionLen);

		private static void ThrowOnError(int error)
		{
			if (error != 0)
				throw new ApplicationException($"Socket option syscall error value: '{error}'");
		}

		#endregion

		public static int GetSockOptSysCall(this Socket socket, SocketOptionLevel optionLevel, SocketOptionName optionName)
		{
			int optionValue;
			var optionLength = sizeof(int);

			unsafe
			{
				ThrowOnError(GetSockOptSysCall(socket.Handle, (int)optionLevel, (int)optionName, (byte*)&optionValue, &optionLength));
			}

			return optionValue;
		}

		public static void SetSockOptSysCall(this Socket socket, SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue)
		{
			unsafe
			{
				ThrowOnError(SetSockOptSysCall(socket.Handle, (int)optionLevel, (int)optionName, (byte*)&optionValue, sizeof(int)));
			}
		}
	}
}
