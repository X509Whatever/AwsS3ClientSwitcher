using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public abstract class MetadataCollection
	{
		#region Properties

		public abstract string this[string name] { get; set; }

		public abstract int Count { get; }

		public abstract ICollection<string> Keys { get; }

		#endregion

		public abstract void Add(string name, string value);

		public abstract void Clear();
	}
}
