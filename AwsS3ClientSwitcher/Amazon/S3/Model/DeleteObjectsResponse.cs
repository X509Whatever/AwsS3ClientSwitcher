using System.Collections.Generic;
using System.Net;

namespace Amazon.S3.Model
{
	public abstract class DeleteObjectsResponse
	{
		#region Properties

		public abstract HttpStatusCode HttpStatusCode { get; }

		public abstract IEnumerable<DeleteError> DeleteErrors { get; }

		#endregion
	}
}
