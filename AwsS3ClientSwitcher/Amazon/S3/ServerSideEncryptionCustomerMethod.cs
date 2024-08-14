namespace Amazon.S3
{
	/// <summary>
	/// A list of all server-side encryption methods for customer provided encryption keys.
	/// </summary>
	public sealed class ServerSideEncryptionCustomerMethod
	{
		#region Fields

		internal readonly string Value;

		/// <summary>
		/// No server side encryption to be used.
		/// </summary>
		public static readonly ServerSideEncryptionCustomerMethod None = new ServerSideEncryptionCustomerMethod("");

		/// <summary>
		/// Use AES 256 server side encryption.
		/// </summary>
		public static readonly ServerSideEncryptionCustomerMethod AES256 = new ServerSideEncryptionCustomerMethod("AES256");

		#endregion

		#region .ctors

		public ServerSideEncryptionCustomerMethod(string value)
		{
			Value = value;
		}

		#endregion
	}
}
