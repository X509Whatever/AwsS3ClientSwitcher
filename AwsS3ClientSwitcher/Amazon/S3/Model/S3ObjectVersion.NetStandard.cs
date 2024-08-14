extern alias AWSSDK_NETSTD;

using System;

namespace Amazon.S3.Model
{
	internal class S3ObjectVersionNetStandard : S3ObjectVersion
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.S3.Model.S3ObjectVersion _version;

		public override string VersionId => _version.VersionId;

		#endregion

		#region .ctors

		public S3ObjectVersionNetStandard(AWSSDK_NETSTD::Amazon.S3.Model.S3ObjectVersion version)
		{
			_version = version.ThrowIfNull(nameof(version));
		}

		#endregion
	}
}
