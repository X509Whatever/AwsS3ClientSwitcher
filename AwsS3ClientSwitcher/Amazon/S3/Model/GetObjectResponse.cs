using System;
using System.IO;

namespace Amazon.S3.Model
{
	public abstract class GetObjectResponse : IDisposable
	{
		#region Properties

		public abstract Stream ResponseStream { get; set; } //< XXX: Setter exposed on purpose.

		public abstract long ContentLength { get; }

		public abstract MetadataCollection Metadata { get; }

		#endregion

		public abstract void Dispose();
	}
}
