using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public abstract class ListVersionsResponse
	{
		#region Properties

		public abstract IEnumerable<S3ObjectVersion> Versions { get; }

		#endregion
	}
}
