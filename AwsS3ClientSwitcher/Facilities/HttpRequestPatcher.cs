extern alias AWSSDK_NETFX;

using System;
using System.Net;
using System.Reflection;

using Amazon.S3;

using HarmonyLib;

namespace Amazon.Runtime.Internal
{
	public static class HttpRequestPatcher
	{
		/// <summary>
		/// Patch to override HTTP Keep-Alive for each request if needed for assembly AWSSDK_NETFX.
		/// https://github.com/aws/aws-sdk-net/blob/da9fc5a38ae636805a6c6eeac9443966392e8ca5/sdk/src/Core/Amazon.Runtime/Pipeline/HttpHandler/_bcl/HttpWebRequestFactory.cs#L433
		/// </summary>
		public static void PatchConfigureRequest()
		{
			var original = typeof(AWSSDK_NETFX::Amazon.Runtime.Internal.HttpRequest).GetMethod("ConfigureRequest", BindingFlags.Public | BindingFlags.Instance);
			var postfix = typeof(HttpRequestPatcher).GetMethod(nameof(ConfigureRequestPostfix));
			var harmony = new Harmony($"{nameof(HttpRequestPatcher)}::{original.Name}");
			harmony.Patch(original, postfix: new HarmonyMethod(postfix));
		}

		public static void ConfigureRequestPostfix(AWSSDK_NETFX::Amazon.Runtime.IRequestContext requestContext, HttpWebRequest ____request)
		{
			if (!(requestContext.ClientConfig is CustomAmazonS3ConfigNetFx config))
				throw new ArgumentOutOfRangeException("Unknown client config?!");

			if (config.HttpKeepAlive != null)
				____request.KeepAlive = config.HttpKeepAlive.Value;
		}
	}
}
