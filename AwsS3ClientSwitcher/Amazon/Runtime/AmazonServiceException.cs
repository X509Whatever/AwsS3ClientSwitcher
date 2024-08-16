using System;

namespace Amazon.Runtime
{
	/// <summary>
	/// A base exception for some Amazon Web Services.
	/// <para>
	/// Most exceptions thrown to client code will be service-specific exceptions, though some services
	/// may throw this exception if there is a problem which is caught in the core client code.
	/// </para>
	/// </summary>
	public abstract class AmazonServiceException : Exception
	{
		#region Properties

		public abstract string ErrorCode { get; }

		#endregion

		#region .ctors

		protected AmazonServiceException(string message)
			: base(message)
		{ }

		protected AmazonServiceException(Exception ex)
			: base(ex.Message, ex)
		{ }

		#endregion
	}
}
