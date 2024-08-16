extern alias AWSSDK_NETFX;

using System;

namespace Amazon.S3.Model
{
	internal class DeleteObjectResponseNetFx : DeleteObjectResponse
	{
		#region Fields

		private readonly AWSSDK_NETFX::Amazon.S3.Model.DeleteObjectResponse _response;

		#endregion

		#region .ctors

		public DeleteObjectResponseNetFx(AWSSDK_NETFX::Amazon.S3.Model.DeleteObjectResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
