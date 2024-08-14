extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

using System;

namespace Amazon.S3.Model
{
	internal static class GetPreSignedUrlRequestExtensions
	{
		public static AWSSDK_NETFX::Amazon.S3.Model.GetPreSignedUrlRequest ToNetFx(this GetPreSignedUrlRequest request)
		{
			Guard.IsNotNull(request, nameof(request));

			var req = new AWSSDK_NETFX::Amazon.S3.Model.GetPreSignedUrlRequest();

			if (request.BucketName != null)
				req.BucketName = request.BucketName;

			if (request.Key != null)
				req.Key = request.Key;

			if (request.Protocol != null)
				req.Protocol = (AWSSDK_NETFX::Amazon.S3.Protocol)request.Protocol.Value;

			if (request.Expires != null)
				req.Expires = request.Expires.Value;

			return req;
		}

		public static AWSSDK_NETSTD::Amazon.S3.Model.GetPreSignedUrlRequest ToNetStd(this GetPreSignedUrlRequest request)
		{
			Guard.IsNotNull(request, nameof(request));

			var req = new AWSSDK_NETSTD::Amazon.S3.Model.GetPreSignedUrlRequest();

			if (request.BucketName != null)
				req.BucketName = request.BucketName;

			if (request.Key != null)
				req.Key = request.Key;

			if (request.Protocol != null)
				req.Protocol = (AWSSDK_NETSTD::Amazon.S3.Protocol)request.Protocol.Value;

			if (request.Expires != null)
				req.Expires = request.Expires.Value;

			return req;
		}
	}
}
