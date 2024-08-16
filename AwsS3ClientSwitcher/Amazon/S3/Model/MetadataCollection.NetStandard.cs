extern alias AWSSDK_NETSTD;

using System;
using System.Collections.Generic;

namespace Amazon.S3.Model
{
	internal class MetadataCollectionNetStandard : MetadataCollection
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.S3.Model.MetadataCollection _metadata;

		public override int Count => _metadata.Count;

		public override ICollection<string> Keys => _metadata.Keys;

		#endregion

		#region .ctors

		public MetadataCollectionNetStandard(AWSSDK_NETSTD::Amazon.S3.Model.MetadataCollection metadata)
		{
			_metadata = metadata.ThrowIfNull(nameof(metadata));
		}

		#endregion

		public override string this[string name]
		{
			get => _metadata[name];
			set => _metadata[name] = value;
		}

		public override void Add(string name, string value) => _metadata.Add(name, value);

		public override void Clear() => _metadata.Clear();
	}
}
