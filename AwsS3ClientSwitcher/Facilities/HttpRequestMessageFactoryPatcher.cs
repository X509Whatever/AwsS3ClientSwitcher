extern alias AWSSDK_NETSTD;

using System;
using System.Net.Http;
using System.Reflection;

using Amazon.S3;

using HarmonyLib;

namespace Amazon.Runtime
{
	public static class HttpRequestMessageFactoryPatcher
	{
		private static readonly FieldInfo _httpClientHandlerAccessor = typeof(HttpMessageInvoker).GetField("_handler", BindingFlags.NonPublic | BindingFlags.Instance);

		internal const string TCP_KEEP_ALIVE_KEY = "CUSTOM::" + nameof(TcpKeepAlive);

		/// <summary>
		/// Patch to override TCP/HTTP Keep-Alive for each request if needed for assembly AWSSDK_NETSTD.
		/// https://github.com/aws/aws-sdk-net/blob/da9fc5a38ae636805a6c6eeac9443966392e8ca5/sdk/src/Core/Amazon.Runtime/Pipeline/HttpHandler/_netstandard/HttpRequestMessageFactory.cs#L228
		/// </summary>
		public static void PatchCreateHttpClient()
		{
			var original = typeof(AWSSDK_NETSTD::Amazon.Runtime.HttpRequestMessageFactory).GetMethod("CreateHttpClient", BindingFlags.NonPublic | BindingFlags.Static);
			var postfix = typeof(HttpRequestMessageFactoryPatcher).GetMethod(nameof(CreateHttpClientPostfix));
			var harmony = new Harmony($"{nameof(HttpRequestMessageFactoryPatcher)}::{original.Name}");
			harmony.Patch(original, postfix: new HarmonyMethod(postfix));
		}

		public static void CreateHttpClientPostfix(ref HttpClient __result, AWSSDK_NETSTD::Amazon.Runtime.IClientConfig clientConfig)
		{
			if (!(clientConfig is CustomAmazonS3ConfigNetStandard config))
				throw new ArgumentOutOfRangeException("Unknown client config?!");

			if (config.HttpKeepAlive != null)
			{
				// NOTE: DefaultRequestHeaders should not be used if we reuse the HttpClient. It is currently created for each request.
				//		 ConnectionClose=true will set HTTP's KA header to false.
				__result.DefaultRequestHeaders.ConnectionClose = !config.HttpKeepAlive.Value;
			}

			// On netstd, TcpKeepAlive should be copied only if tcpKeepAlive.Enabled != null.
			if (config.TcpKeepAlive != null && EnvironmentHelper.RunningOnLinux)
			{
				var handler = _httpClientHandlerAccessor.GetValue(__result) as HttpClientHandler;
				handler.Properties[TCP_KEEP_ALIVE_KEY] = config.TcpKeepAlive;
			}
		}
	}
}
