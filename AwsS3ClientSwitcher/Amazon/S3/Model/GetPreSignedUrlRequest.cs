using System;

namespace Amazon.S3.Model
{
	/// <summary>
	/// The parameters to create a pre-signed URL to a bucket or object. 
	/// </summary>
	/// <remarks>
	/// For more information, refer to: <see href="http://docs.amazonwebservices.com/AmazonS3/latest/dev/S3_QSAuth.html"/>.
	/// <br />Required Parameters: BucketName, Expires
	/// <br />Optional Parameters: Key, VersionId, Verb: default is GET
	/// </remarks>
	public class GetPreSignedUrlRequest
	{
		#region Properties

		/// <summary>
		/// The name of the bucket to create a pre-signed url to, or containing the object.
		/// </summary>
		public string BucketName { get; set; }

		/// <summary>
		/// The key to the object for which a pre-signed url should be created.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This property will be used as part of the resource path of the HTTP request. In .NET the System.Uri class
		/// is used to construct the uri for the request. The System.Uri class will canonicalize the uri string by compacting characters like "..". 
		/// For example an object key of "foo/../bar/file.txt" will be transformed into "bar/file.txt" because the ".." 
		/// is interpreted as use parent directory.
		/// </para>
		/// <para>
		/// Starting with .NET 8, the AWS .NET SDK disables System.Uri's feature of canonicalizing the resource path. This allows S3 keys like
		/// "foo/../bar/file.txt" to work correctly with the AWS .NET SDK.
		/// </para>
		/// <para>
		/// For further information view the documentation for the Uri class: https://docs.microsoft.com/en-us/dotnet/api/system.uri
		/// </para>
		/// </remarks>
		public string Key { get; set; }

		/// <summary>
		/// The requested protocol (http/https) for the pre-signed url.
		/// </summary>
		/// <remarks>
		/// Defaults to https.
		/// </remarks>
		public Protocol? Protocol { get; set; }

		/// <summary>
		/// The expiry date and time for the pre-signed url.
		/// </summary>
		public DateTime? Expires { get; set; }

		#endregion
	}
}
