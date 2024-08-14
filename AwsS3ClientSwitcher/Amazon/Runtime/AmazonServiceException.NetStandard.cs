extern alias AWSSDK_NETSTD;

using System;

namespace Amazon.Runtime
{
	internal class AmazonServiceExceptionNetStandard : AmazonServiceException
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.Runtime.AmazonServiceException _ex;

		public override string ErrorCode => _ex.ErrorCode;

		#endregion

		#region .ctors

		public AmazonServiceExceptionNetStandard(AWSSDK_NETSTD::Amazon.Runtime.AmazonServiceException ex)
			: base(ex)
		{
			_ex = ex.ThrowIfNull(nameof(ex));
		}

		#endregion
	}
}
