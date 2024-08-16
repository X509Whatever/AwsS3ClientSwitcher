extern alias AWSSDK_NETFX;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Amazon.S3.Model
{
	internal class DeleteObjectsResponseNetFx : DeleteObjectsResponse
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.S3.Model.DeleteObjectsResponse _response;

		public override HttpStatusCode HttpStatusCode => _response.HttpStatusCode;

		private IEnumerable<DeleteError> _errors;
		public override IEnumerable<DeleteError> DeleteErrors => _errors ?? (_errors = _response.DeleteErrors.Select(x => new DeleteErrorNetFx(x))).ToArray();

		#endregion

		#region .ctors

		public DeleteObjectsResponseNetFx(AWSSDK_NETFX::Amazon.S3.Model.DeleteObjectsResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
