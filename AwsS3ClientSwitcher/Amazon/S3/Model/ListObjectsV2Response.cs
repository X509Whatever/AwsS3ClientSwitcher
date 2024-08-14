using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public abstract class ListObjectsV2Response
	{
		#region Properties

		public abstract IEnumerable<string> CommonPrefixes { get; }

		#endregion
	}
}
