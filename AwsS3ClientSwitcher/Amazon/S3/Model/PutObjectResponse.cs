using System.Net;

namespace Amazon.S3.Model
{
	public abstract class PutObjectResponse
	{
		#region Properties

		public abstract HttpStatusCode HttpStatusCode { get; }

		#endregion
	}
}
