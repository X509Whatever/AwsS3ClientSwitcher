namespace Amazon.S3.Model
{
	/// <summary>
	/// This class contains the headers for an S3 object.
	/// </summary>
	public sealed class HeadersCollection
	{
		/// <summary>
		/// <para>
		/// Size of the body in bytes. This parameter is useful when the size of the body cannot
		/// be determined automatically. For more information, see <a href="https://www.rfc-editor.org/rfc/rfc9110.html#name-content-length">https://www.rfc-editor.org/rfc/rfc9110.html#name-content-length</a>.
		/// </para>
		/// </summary>
		public long? ContentLength { get; set; }
	}
}
