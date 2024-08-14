extern alias AWSSDK_NETFX;

using System;
using System.Net;

namespace Amazon.S3.Model
{
	internal class PutObjectResponseNetFx : PutObjectResponse
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.S3.Model.PutObjectResponse _response;

		public override HttpStatusCode HttpStatusCode => _response.HttpStatusCode;

		#endregion

		#region .ctors

		public PutObjectResponseNetFx(AWSSDK_NETFX::Amazon.S3.Model.PutObjectResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
