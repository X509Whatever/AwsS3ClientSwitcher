extern alias AWSSDK_NETFX;

using System;

namespace Amazon.S3.Model
{
	internal class GetObjectMetadataResponseNetFx : GetObjectMetadataResponse
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.S3.Model.GetObjectMetadataResponse _response;

		private MetadataCollection _metadata;
		public override MetadataCollection Metadata => _metadata ?? (_metadata = new MetadataCollectionNetFx(_response.Metadata));

		#endregion

		#region .ctors

		public GetObjectMetadataResponseNetFx(AWSSDK_NETFX::Amazon.S3.Model.GetObjectMetadataResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion
	}
}
