extern alias AWSSDK_NETFX;

using System;

namespace Amazon.Runtime
{
	internal class AmazonServiceExceptionNetFx : AmazonServiceException
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.Runtime.AmazonServiceException _ex;

		public override string ErrorCode => _ex.ErrorCode;

		#endregion

		#region .ctors

		public AmazonServiceExceptionNetFx(AWSSDK_NETFX::Amazon.Runtime.AmazonServiceException ex)
			: base(ex)
		{
			_ex = ex.ThrowIfNull(nameof(ex));
		}

		#endregion
	}
}
