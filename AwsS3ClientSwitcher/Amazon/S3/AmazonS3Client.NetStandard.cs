extern alias AWSSDK_NETSTD;

using System;

using Amazon.Runtime;
using Amazon.S3.Model;

namespace Amazon.S3
{
	internal class AmazonS3ClientNetStandard : IAmazonS3
	{
		#region Inner Types

		internal class CustomClient : AWSSDK_NETSTD::Amazon.S3.AmazonS3Client
		{
			#region Fields

			private AWSSDK_NETSTD::Amazon.Runtime.Internal.RuntimePipeline _pipeline;

			#endregion

			public CustomClient(AmazonS3ClientNetStandard owner)
				: base(owner._awsAccessKeyId, owner._awsSecretAccessKey, owner._config)
			{
				if (owner._handler != null)
					_pipeline.AddHandler(owner._handler);
			}

			protected override void CustomizeRuntimePipeline(AWSSDK_NETSTD::Amazon.Runtime.Internal.RuntimePipeline pipeline)
			{
				base.CustomizeRuntimePipeline(pipeline);

				_pipeline = pipeline; //< Method called on base .ctor; keep pipeline to customize it later.
			}
		}

		#endregion

		#region Fields

		private readonly string _awsAccessKeyId;
		private readonly string _awsSecretAccessKey;
		private readonly AWSSDK_NETSTD::Amazon.S3.AmazonS3Config _config;
		private readonly AWSSDK_NETSTD::Amazon.Runtime.Internal.PipelineHandler _handler;

		private readonly AWSSDK_NETSTD::Amazon.S3.AmazonS3Client _inner;
		private bool _disposed;

		#endregion

		#region .ctors

		public AmazonS3ClientNetStandard(
			string awsAccessKeyId,
			string awsSecretAccessKey,
			AWSSDK_NETSTD::Amazon.S3.AmazonS3Config config,
			AWSSDK_NETSTD::Amazon.Runtime.Internal.PipelineHandler handler)
		{
			_awsAccessKeyId = awsAccessKeyId;
			_awsSecretAccessKey = awsSecretAccessKey;
			_config = config;
			_handler = handler;

			_inner = new CustomClient(this);
		}

		#endregion

		internal AWSSDK_NETSTD::Amazon.S3.AmazonS3Client GetAwsClient() => _inner;

		public GetObjectResponse GetObject(GetObjectRequest request)
		{
			try
			{
				var req = request.ToNetStd();
				var res = AsyncHelpers.RunSync(() => _inner.GetObjectAsync(req));
				return new GetObjectResponseNetStandard(res);
			}
			catch (AWSSDK_NETSTD::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETSTD::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetStandard(ex2);

				throw new AmazonServiceExceptionNetStandard(ex);
			}
		}

		public GetObjectMetadataResponse GetObjectMetadata(GetObjectMetadataRequest request)
		{
			try
			{
				var req = request.ToNetStd();
				var res = AsyncHelpers.RunSync(() => _inner.GetObjectMetadataAsync(req));
				return new GetObjectMetadataResponseNetStandard(res);
			}
			catch (AWSSDK_NETSTD::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETSTD::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetStandard(ex2);

				throw new AmazonServiceExceptionNetStandard(ex);
			}
		}

		public string GetPreSignedURL(GetPreSignedUrlRequest request)
		{
			try
			{
				var req = request.ToNetStd();
				return AsyncHelpers.RunSync(() => _inner.GetPreSignedURLAsync(req));
			}
			catch (AWSSDK_NETSTD::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETSTD::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetStandard(ex2);

				throw new AmazonServiceExceptionNetStandard(ex);
			}
		}

		public PutObjectResponse PutObject(PutObjectRequest request)
		{
			try
			{
				var req = request.ToNetStd();
				var res = AsyncHelpers.RunSync(() => _inner.PutObjectAsync(req));
				return new PutObjectResponseNetStandard(res);
			}
			catch (AWSSDK_NETSTD::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETSTD::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetStandard(ex2);

				throw new AmazonServiceExceptionNetStandard(ex);
			}
		}

		public DeleteObjectResponse DeleteObject(string bucketName, string key)
		{
			try
			{
				var res = AsyncHelpers.RunSync(() => _inner.DeleteObjectAsync(bucketName, key));
				return new DeleteObjectResponseNetStandard(res);
			}
			catch (AWSSDK_NETSTD::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETSTD::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetStandard(ex2);

				throw new AmazonServiceExceptionNetStandard(ex);
			}
		}

		public DeleteObjectsResponse DeleteObjects(DeleteObjectsRequest request)
		{
			try
			{
				var req = request.ToNetStd();
				var res = AsyncHelpers.RunSync(() => _inner.DeleteObjectsAsync(req));
				return new DeleteObjectsResponseNetStandard(res);
			}
			catch (AWSSDK_NETSTD::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETSTD::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetStandard(ex2);

				throw new AmazonServiceExceptionNetStandard(ex);
			}
		}

		public void Dispose()
		{
			if (_disposed)
				return;

			_inner.Dispose();
			_disposed = true;
		}
	}
}
