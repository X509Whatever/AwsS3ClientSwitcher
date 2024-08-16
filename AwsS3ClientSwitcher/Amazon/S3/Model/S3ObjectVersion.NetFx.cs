extern alias AWSSDK_NETFX;

using System;

namespace Amazon.S3.Model
{
	internal class S3ObjectVersionNetFx : S3ObjectVersion
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.S3.Model.S3ObjectVersion _version;

		public override string VersionId => _version.VersionId;

		#endregion

		#region .ctors

		public S3ObjectVersionNetFx(AWSSDK_NETFX::Amazon.S3.Model.S3ObjectVersion version)
		{
			_version = version.ThrowIfNull(nameof(version));
		}

		#endregion
	}
}
