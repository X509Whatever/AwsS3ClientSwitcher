extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

using System;

namespace Amazon.S3.Model
{
	internal static class PutObjectRequestExtensions
	{
		public static AWSSDK_NETFX::Amazon.S3.Model.PutObjectRequest ToNetFx(this PutObjectRequest request)
		{
			Guard.IsNotNull(request, nameof(request));

			var req = new AWSSDK_NETFX::Amazon.S3.Model.PutObjectRequest();

			if (request.BucketName != null)
				req.BucketName = request.BucketName;

			if (request.Key != null)
				req.Key = request.Key;

			if (request.InputStream != null)
				req.InputStream = request.InputStream;

			if (request.AutoCloseStream != null)
				req.AutoCloseStream = request.AutoCloseStream.Value;

			if (request.AutoResetStreamPosition != null)
				req.AutoResetStreamPosition = request.AutoResetStreamPosition.Value;

			if (request.ContentType != null)
				req.ContentType = request.ContentType;

			if (request.Headers.ContentLength != null)
				req.Headers.ContentLength = request.Headers.ContentLength.Value;

			if (request.Metadata.Count > 0)
			{
				foreach (var pair in request.Metadata)
					req.Metadata.Add(pair.Key, pair.Value);
			}

			if (request.ServerSideEncryptionCustomerMethod != null)
			{
				var ssecm = AWSSDK_NETFX::Amazon.S3.ServerSideEncryptionCustomerMethod.FindValue(request.ServerSideEncryptionCustomerMethod.Value);
				req.ServerSideEncryptionCustomerMethod = ssecm;
			}

			if (request.ServerSideEncryptionCustomerProvidedKey != null)
				req.ServerSideEncryptionCustomerProvidedKey = request.ServerSideEncryptionCustomerProvidedKey;

			return req;
		}

		public static AWSSDK_NETSTD::Amazon.S3.Model.PutObjectRequest ToNetStd(this PutObjectRequest request)
		{
			Guard.IsNotNull(request, nameof(request));

			var req = new AWSSDK_NETSTD::Amazon.S3.Model.PutObjectRequest();

			if (request.BucketName != null)
				req.BucketName = request.BucketName;

			if (request.Key != null)
				req.Key = request.Key;

			if (request.InputStream != null)
				req.InputStream = request.InputStream;

			if (request.AutoCloseStream != null)
				req.AutoCloseStream = request.AutoCloseStream.Value;

			if (request.AutoResetStreamPosition != null)
				req.AutoResetStreamPosition = request.AutoResetStreamPosition.Value;

			if (request.ContentType != null)
				req.ContentType = request.ContentType;

			if (request.Headers.ContentLength != null)
				req.Headers.ContentLength = request.Headers.ContentLength.Value;

			if (request.Metadata.Count > 0)
			{
				foreach (var pair in request.Metadata)
					req.Metadata.Add(pair.Key, pair.Value);
			}

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
