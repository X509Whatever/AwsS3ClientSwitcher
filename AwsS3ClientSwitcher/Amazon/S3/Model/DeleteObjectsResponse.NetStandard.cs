extern alias AWSSDK_NETSTD;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Amazon.S3.Model
{
	internal class DeleteObjectsResponseNetStandard : DeleteObjectsResponse
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.S3.Model.DeleteObjectsResponse _response;

		public override HttpStatusCode HttpStatusCode => _response.HttpStatusCode;

		private IEnumerable<DeleteError> _errors;
		public override IEnumerable<DeleteError> DeleteErrors => _errors ?? (_errors = _response.DeleteErrors.Select(x => new DeleteErrorNetStandard(x))).ToArray();

		#endregion

		#region .ctors

		public DeleteObjectsResponseNetStandard(AWSSDK_NETSTD::Amazon.S3.Model.DeleteObjectsResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
