extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

using System;

namespace Amazon.S3.Model
{
	internal static class GetObjectRequestExtensions
	{
		public static AWSSDK_NETFX::Amazon.S3.Model.GetObjectRequest ToNetFx(this GetObjectRequest request)
		{
			Guard.IsNotNull(request, nameof(request));

			var req = new AWSSDK_NETFX::Amazon.S3.Model.GetObjectRequest();

			if (request.BucketName != null)
				req.BucketName = request.BucketName;

			if (request.Key != null)
				req.Key = request.Key;

			if (request.ServerSideEncryptionCustomerMethod != null)
			{
				var ssecm = AWSSDK_NETFX::Amazon.S3.ServerSideEncryptionCustomerMethod.FindValue(request.ServerSideEncryptionCustomerMethod.Value);
				req.ServerSideEncryptionCustomerMethod = ssecm;
			}

			if (request.ServerSideEncryptionCustomerProvidedKey != null)
				req.ServerSideEncryptionCustomerProvidedKey = request.ServerSideEncryptionCustomerProvidedKey;

			return req;
		}

		public static AWSSDK_NETSTD::Amazon.S3.Model.GetObjectRequest ToNetStd(this GetObjectRequest request)
		{
			Guard.IsNotNull(request, nameof(request));

			var req = new AWSSDK_NETSTD::Amazon.S3.Model.GetObjectRequest();

			if (request.BucketName != null)
				req.BucketName = request.BucketName;

			if (request.Key != null)
				req.Key = request.Key;

			if (request.ServerSideEncryptionCustomerMethod != null)
			{
				var ssecm = AWSSDK_NETSTD::Amazon.S3.ServerSideEncryptionCustomerMethod.FindValue(request.ServerSideEncryptionCustomerMethod.Value);
				req.ServerSideEncryptionCustomerMethod = ssecm;
			}

			if (request.ServerSideEncryptionCustomerProvidedKey != null)
				req.ServerSideEncryptionCustomerProvidedKey = request.ServerSideEncryptionCustomerProvidedKey;

			return req;
		}
	}
}
