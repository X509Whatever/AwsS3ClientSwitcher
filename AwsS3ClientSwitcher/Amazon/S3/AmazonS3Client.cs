using System;

using Amazon.Runtime.Internal;
using Amazon.S3.Model;

namespace Amazon.S3
{
	public class AmazonS3Client : IAmazonS3
	{
		#region Fields

		private readonly IAmazonS3 _inner;

		#endregion

		#region .ctors

		public AmazonS3Client(string awsAccessKeyId, string awsSecretAccessKey, AmazonS3Config config, PipelineHandler handler = null)
		{
			Guard.IsNotNull(config, nameof(config));

			if (config.UseNetStandard == true)
			{
				_inner = new AmazonS3ClientNetStandard(awsAccessKeyId, awsSecretAccessKey, config.ToNetStd(), handler?.WireForNetStd());
			}
			else
			{
				_inner = new AmazonS3ClientNetFx(awsAccessKeyId, awsSecretAccessKey, config.ToNetFx(), handler?.WireForNetFx());
			}
		}

		#endregion

		internal IAmazonS3 GetAwsClient() => _inner;

		public GetObjectResponse GetObject(GetObjectRequest request)
			=> _inner.GetObject(request);

		public GetObjectMetadataResponse GetObjectMetadata(GetObjectMetadataRequest request)
			=> _inner.GetObjectMetadata(request);

		public string GetPreSignedURL(GetPreSignedUrlRequest request)
			=> _inner.GetPreSignedURL(request);

		public PutObjectResponse PutObject(PutObjectRequest request)
			=> _inner.PutObject(request);

		public DeleteObjectResponse DeleteObject(string bucketName, string key)
			=> _inner.DeleteObject(bucketName, key);

		public DeleteObjectsResponse DeleteObjects(DeleteObjectsRequest request)
			=> _inner.DeleteObjects(request);

		public void Dispose() => _inner.Dispose();
	}
}
