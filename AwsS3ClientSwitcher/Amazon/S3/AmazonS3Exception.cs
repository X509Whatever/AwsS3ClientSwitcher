using System;
using System.Net;

using Amazon.Runtime;

namespace Amazon.S3
{
	/// <summary>
	/// Base exception for S3 errors.
	/// </summary>
	public class AmazonS3Exception : AmazonServiceException
	{
		#region Properties

		public virtual HttpStatusCode StatusCode { get; set; }

		public override string ErrorCode { get; }

		#endregion

		#region .ctors

		public AmazonS3Exception(string message)
			: base(message)
		{ }

		public AmazonS3Exception(Exception ex)
			: base(ex)
		{ }

		#endregion
	}
}
