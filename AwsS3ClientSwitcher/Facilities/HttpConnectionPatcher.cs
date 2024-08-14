using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Reflection;

using Amazon.Runtime;

using HarmonyLib;

namespace System.Net.Http
{
	public static class HttpConnectionPatcher
	{
		#region Fields

		private static PropertyInfo _httpConnectionPoolSettingsAccesor;
		private static FieldInfo _httpConnectionSettingsPropertiesAccessor;

		#endregion

		public static void PatchCtor()
		{
			if (EnvironmentHelper.RunningOnLinux)
			{
				var assembly = typeof(HttpClient).Assembly; // Remember, HttpConnectionWithFinalizer extends HttpConnection.
				var httpConnectionType = assembly.GetType("System.Net.Http.HttpConnection", true);
				var httpConnectionPoolType = assembly.GetType("System.Net.Http.HttpConnectionPool", true);

				_httpConnectionPoolSettingsAccesor = httpConnectionPoolType.GetProperty("Settings");
				_httpConnectionSettingsPropertiesAccessor = assembly.GetType("System.Net.Http.HttpConnectionSettings", true)
					.GetField("_properties", BindingFlags.NonPublic | BindingFlags.Instance);

				// https://github.com/mono/corefx/blob/c4eeab9fc2faa0195a812e552cd73ee298d39386/src/System.Net.Http/src/System/Net/Http/SocketsHttpHandler/HttpConnection.cs#L67
				var ctor = httpConnectionType.GetConstructor(new[]
				{
					httpConnectionPoolType,
					typeof(Socket),
					typeof(Stream),
					typeof(TransportContext)
				});

				var postfix = typeof(HttpConnectionPatcher).GetMethod(nameof(CtorPostfix));
				var harmony = new Harmony($"{nameof(HttpConnectionPatcher)}::{ctor.Name}");
				harmony.Patch(ctor, postfix: new HarmonyMethod(postfix));
			}
		}

		public static void CtorPostfix(object ____pool, Socket ____socket)
		{
			// HttpConnectionPool does not expose a Properties property like HttpClientHandler.. just Settings from pool.
			var settings = _httpConnectionPoolSettingsAccesor.GetValue(____pool);
			var properties = _httpConnectionSettingsPropertiesAccessor.GetValue(settings) as IDictionary<string, object>;

			if (properties?.TryGetValue(HttpRequestMessageFactoryPatcher.TCP_KEEP_ALIVE_KEY, out var boxed) == true)
			{
				// NOTE: We only set this key if TCP KA enabled has value.
				//		 Interval, Timeout, Probes.. are opt-in.
				var tcpKeepAlive = (boxed as TcpKeepAlive).ThrowIfNull(nameof(TcpKeepAlive));
				____socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, tcpKeepAlive.Enabled.Value);

				// https://github.com/luigiberrettini/xplat-socket-options/blob/master/TestSuite.cs#L38
				if (tcpKeepAlive.Timeout != null)
					____socket.SetSocketOption(SocketOptionLevel.Tcp, (SocketOptionName)0x4, tcpKeepAlive.Timeout.Value);

				if (tcpKeepAlive.Interval != null)
					____socket.SetSocketOption(SocketOptionLevel.Tcp, (SocketOptionName)0x5, tcpKeepAlive.Interval.Value);

				if (tcpKeepAlive.Probes != null)
					____socket.SetSocketOption(SocketOptionLevel.Tcp, (SocketOptionName)0x6, tcpKeepAlive.Probes.Value);
			}
		}
	}
}
