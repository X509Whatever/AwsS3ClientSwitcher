extern alias AWSSDK_NETFX;

using System;
using System.Net;

namespace Amazon.S3
{
	internal class AmazonS3ExceptionNetFx : AmazonS3Exception
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.S3.AmazonS3Exception _ex;

		public override string ErrorCode => _ex.ErrorCode;

		public override HttpStatusCode StatusCode => _ex.StatusCode;

		#endregion

		#region .ctors

		public AmazonS3ExceptionNetFx(AWSSDK_NETFX::Amazon.S3.AmazonS3Exception ex)
			: base(ex)
		{
			_ex = ex.ThrowIfNull(nameof(ex));
		}

		#endregion
	}
}
