extern alias AWSSDK_NETFX;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazon.S3.Model
{
	internal class ListVersionsResponseNetFx : ListVersionsResponse
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.S3.Model.ListVersionsResponse _response;

		private IEnumerable<S3ObjectVersion> _versions;
		public override IEnumerable<S3ObjectVersion> Versions => _versions ?? (_versions = _response.Versions.Select(x => new S3ObjectVersionNetFx(x))).ToArray();

		#endregion

		#region .ctors

		public ListVersionsResponseNetFx(AWSSDK_NETFX::Amazon.S3.Model.ListVersionsResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
