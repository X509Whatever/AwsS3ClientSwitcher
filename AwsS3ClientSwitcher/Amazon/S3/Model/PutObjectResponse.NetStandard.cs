extern alias AWSSDK_NETSTD;

using System;
using System.Net;

namespace Amazon.S3.Model
{
	internal class PutObjectResponseNetStandard : PutObjectResponse
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.S3.Model.PutObjectResponse _response;

		public override HttpStatusCode HttpStatusCode => _response.HttpStatusCode;

		#endregion

		#region .ctors

		public PutObjectResponseNetStandard(AWSSDK_NETSTD::Amazon.S3.Model.PutObjectResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
