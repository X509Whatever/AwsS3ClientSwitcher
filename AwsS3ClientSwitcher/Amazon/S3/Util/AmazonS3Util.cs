extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

using System;

using Amazon.Runtime;

namespace Amazon.S3.Util
{
	public static class AmazonS3Util
	{
		public static bool DoesS3BucketExistV2(AmazonS3Client s3Client, string bucketName)
		{
			Guard.IsNotNull(s3Client, nameof(s3Client));

			switch (s3Client.GetAwsClient())
			{
				case AmazonS3ClientNetFx clientFx:
					try
					{
						return AWSSDK_NETFX::Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2(clientFx.GetAwsClient(), bucketName);
					}
					catch (AWSSDK_NETFX::Amazon.Runtime.AmazonServiceException ex)
					{
						if (ex is AWSSDK_NETFX::Amazon.S3.AmazonS3Exception ex2)
							throw new AmazonS3ExceptionNetFx(ex2);

						throw new AmazonServiceExceptionNetFx(ex);
					}

				case AmazonS3ClientNetStandard clientStd:
					try
					{
						return AsyncHelpers.RunSync(() => AWSSDK_NETSTD::Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(clientStd.GetAwsClient(), bucketName));
					}
					catch (AWSSDK_NETSTD::Amazon.Runtime.AmazonServiceException ex)
					{
						if (ex is AWSSDK_NETSTD::Amazon.S3.AmazonS3Exception ex2)
							throw new AmazonS3ExceptionNetStandard(ex2);

						throw new AmazonServiceExceptionNetStandard(ex);
					}

				default:
					throw new NotSupportedException("Unknown s3client");
			}
		}
	}
}
