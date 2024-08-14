extern alias AWSSDK_NETFX;

using System;
using System.Collections.Generic;

namespace Amazon.S3.Model
{
	internal class ListObjectsV2ResponseNetFx : ListObjectsV2Response
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.S3.Model.ListObjectsV2Response _response;

		public override IEnumerable<string> CommonPrefixes => _response.CommonPrefixes;

		#endregion

		#region .ctors

		public ListObjectsV2ResponseNetFx(AWSSDK_NETFX::Amazon.S3.Model.ListObjectsV2Response response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
