extern alias AWSSDK_NETFX;

using Amazon.Runtime;
using Amazon.S3.Model;

namespace Amazon.S3
{
	internal class AmazonS3ClientNetFx : IAmazonS3
	{
		#region Inner Types

		internal class CustomClient : AWSSDK_NETFX::Amazon.S3.AmazonS3Client
		{
			#region Fields

			private AWSSDK_NETFX::Amazon.Runtime.Internal.RuntimePipeline _pipeline;

			#endregion

			public CustomClient(AmazonS3ClientNetFx owner)
				: base(owner._awsAccessKeyId, owner._awsSecretAccessKey, owner._config)
			{
				if (owner._handler != null)
					_pipeline.AddHandler(owner._handler);
			}

			protected override void CustomizeRuntimePipeline(AWSSDK_NETFX::Amazon.Runtime.Internal.RuntimePipeline pipeline)
			{
				base.CustomizeRuntimePipeline(pipeline);

				_pipeline = pipeline; //< Method called on base .ctor; keep pipeline to customize it later.
			}
		}

		#endregion

		#region Fields

		private readonly string _awsAccessKeyId;
		private readonly string _awsSecretAccessKey;
		private readonly AWSSDK_NETFX::Amazon.S3.AmazonS3Config _config;
		private readonly AWSSDK_NETFX::Amazon.Runtime.Internal.PipelineHandler _handler;

		private readonly AWSSDK_NETFX::Amazon.S3.AmazonS3Client _inner;
		private bool _disposed;

		#endregion

		#region .ctors

		public AmazonS3ClientNetFx(
			string awsAccessKeyId,
			string awsSecretAccessKey,
			AWSSDK_NETFX::Amazon.S3.AmazonS3Config config,
			AWSSDK_NETFX::Amazon.Runtime.Internal.PipelineHandler handler)
		{
			_awsAccessKeyId = awsAccessKeyId;
			_awsSecretAccessKey = awsSecretAccessKey;
			_config = config;
			_handler = handler;

			_inner = new CustomClient(this);
		}

		#endregion

		internal AWSSDK_NETFX::Amazon.S3.AmazonS3Client GetAwsClient() => _inner;

		public GetObjectResponse GetObject(GetObjectRequest request)
		{
			try
			{
				var req = request.ToNetFx();
				var res = _inner.GetObject(req);
				return new GetObjectResponseNetFx(res);
			}
			catch (AWSSDK_NETFX::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETFX::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetFx(ex2);

				throw new AmazonServiceExceptionNetFx(ex);
			}
		}

		public GetObjectMetadataResponse GetObjectMetadata(GetObjectMetadataRequest request)
		{
			try
			{
				var req = request.ToNetFx();
				var res = _inner.GetObjectMetadata(req);
				return new GetObjectMetadataResponseNetFx(res);
			}
			catch (AWSSDK_NETFX::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETFX::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetFx(ex2);

				throw new AmazonServiceExceptionNetFx(ex);
			}
		}

		public string GetPreSignedURL(GetPreSignedUrlRequest request)
		{
			try
			{
				var req = request.ToNetFx();
				return _inner.GetPreSignedURL(req);
			}
			catch (AWSSDK_NETFX::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETFX::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetFx(ex2);

				throw new AmazonServiceExceptionNetFx(ex);
			}
		}

		public PutObjectResponse PutObject(PutObjectRequest request)
		{
			try
			{
				var req = request.ToNetFx();
				var res = _inner.PutObject(req);
				return new PutObjectResponseNetFx(res);
			}
			catch (AWSSDK_NETFX::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETFX::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetFx(ex2);

				throw new AmazonServiceExceptionNetFx(ex);
			}
		}

		public DeleteObjectResponse DeleteObject(string bucketName, string key)
		{
			try
			{
				var res = _inner.DeleteObject(bucketName, key);
				return new DeleteObjectResponseNetFx(res);
			}
			catch (AWSSDK_NETFX::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETFX::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetFx(ex2);

				throw new AmazonServiceExceptionNetFx(ex);
			}
		}

		public DeleteObjectsResponse DeleteObjects(DeleteObjectsRequest request)
		{
			try
			{
				var req = request.ToNetFx();
				var res = _inner.DeleteObjects(req);
				return new DeleteObjectsResponseNetFx(res);
			}
			catch (AWSSDK_NETFX::Amazon.Runtime.AmazonServiceException ex)
			{
				if (ex is AWSSDK_NETFX::Amazon.S3.AmazonS3Exception ex2)
					throw new AmazonS3ExceptionNetFx(ex2);

				throw new AmazonServiceExceptionNetFx(ex);
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
