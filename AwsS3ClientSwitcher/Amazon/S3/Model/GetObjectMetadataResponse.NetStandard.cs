extern alias AWSSDK_NETSTD;

using System;

namespace Amazon.S3.Model
{
	internal class GetObjectMetadataResponseNetStandard : GetObjectMetadataResponse
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.S3.Model.GetObjectMetadataResponse _response;

		private MetadataCollection _metadata;
		public override MetadataCollection Metadata => _metadata ?? (_metadata = new MetadataCollectionNetStandard(_response.Metadata));

		#endregion

		#region .ctors

		public GetObjectMetadataResponseNetStandard(AWSSDK_NETSTD::Amazon.S3.Model.GetObjectMetadataResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
