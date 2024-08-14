extern alias AWSSDK_NETSTD;

using System;

namespace Amazon.S3.Model
{
	internal class DeleteObjectResponseNetStandard : DeleteObjectResponse
	{
		#region Fields

		private readonly AWSSDK_NETSTD::Amazon.S3.Model.DeleteObjectResponse _response;

		#endregion

		#region .ctors

		public DeleteObjectResponseNetStandard(AWSSDK_NETSTD::Amazon.S3.Model.DeleteObjectResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
