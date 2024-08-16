namespace Amazon.S3
{
	/// <summary>
	/// An enumeration of all protocols that the pre-signed URL can be created against.
	/// </summary>
	public enum Protocol
	{
		/// <summary>
		/// https protocol will be used in the pre-signed URL.
		/// </summary>
		HTTPS,

		/// <summary>
		/// http protocol will be used in the pre-signed URL.
		/// </summary>
		HTTP
	}
}
