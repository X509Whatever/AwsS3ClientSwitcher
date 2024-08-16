extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

using System;

namespace Amazon.S3.Model
{
	internal static class DeleteObjectsRequestExtensions
	{
		public static AWSSDK_NETFX::Amazon.S3.Model.DeleteObjectsRequest ToNetFx(this DeleteObjectsRequest request)
		{
			Guard.IsNotNull(request, nameof(request));

			var req = new AWSSDK_NETFX::Amazon.S3.Model.DeleteObjectsRequest();

			if (request.BucketName != null)
				req.BucketName = request.BucketName;

			var keys = request.TryGetKeys();
			if (keys != null)
			{
				foreach (var key in keys)
					req.AddKey(key);
			}

			return req;
		}

		public static AWSSDK_NETSTD::Amazon.S3.Model.DeleteObjectsRequest ToNetStd(this DeleteObjectsRequest request)
		{
			Guard.IsNotNull(request, nameof(request));

			var req = new AWSSDK_NETSTD::Amazon.S3.Model.DeleteObjectsRequest();

			if (request.BucketName != null)
				req.BucketName = request.BucketName;

			var keys = request.TryGetKeys();
			if (keys != null)
			{
				foreach (var key in keys)
					req.AddKey(key);
			}

			return req;
		}
	}
}
