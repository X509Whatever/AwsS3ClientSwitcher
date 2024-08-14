extern alias AWSSDK_NETSTD;

using System;
using System.IO;

namespace Amazon.S3.Model
{
	internal class GetObjectResponseNetStandard : GetObjectResponse
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.S3.Model.GetObjectResponse _response;

		public override Stream ResponseStream
		{
			get => _response.ResponseStream;
			set => _response.ResponseStream = value;
		}

		public override long ContentLength => _response.ContentLength;

		private MetadataCollection _metadata;
		public override MetadataCollection Metadata => _metadata ?? (_metadata = new MetadataCollectionNetStandard(_response.Metadata));

		#endregion

		#region .ctors

		public GetObjectResponseNetStandard(AWSSDK_NETSTD::Amazon.S3.Model.GetObjectResponse response)
		{
			_response = response.ThrowIfNull(nameof(response));
		}

		#endregion

		public override void Dispose() => _response?.Dispose();
	}
}
