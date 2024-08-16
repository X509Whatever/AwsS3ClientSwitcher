extern alias AWSSDK_NETSTD;

using System;
using System.Collections.Generic;

namespace Amazon.S3.Model
{
	internal class ListObjectsV2ResponseNetStandard : ListObjectsV2Response
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.S3.Model.ListObjectsV2Response _response;

		public override IEnumerable<string> CommonPrefixes => _response.CommonPrefixes;

		#endregion

		#region .ctors

		public ListObjectsV2ResponseNetStandard(AWSSDK_NETSTD::Amazon.S3.Model.ListObjectsV2Response response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
