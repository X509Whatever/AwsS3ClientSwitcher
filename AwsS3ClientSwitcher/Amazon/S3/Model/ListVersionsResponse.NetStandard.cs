extern alias AWSSDK_NETSTD;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazon.S3.Model
{
	internal class ListVersionsResponseNetStandard : ListVersionsResponse
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.S3.Model.ListVersionsResponse _response;

		private IEnumerable<S3ObjectVersion> _versions;
		public override IEnumerable<S3ObjectVersion> Versions => _versions ?? (_versions = _response.Versions.Select(x => new S3ObjectVersionNetStandard(x))).ToArray();

		#endregion

		#region .ctors

		public ListVersionsResponseNetStandard(AWSSDK_NETSTD::Amazon.S3.Model.ListVersionsResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
