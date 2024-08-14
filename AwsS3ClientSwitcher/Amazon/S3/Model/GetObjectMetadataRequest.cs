namespace Amazon.S3.Model
{
	/// <summary>
	/// Container for the parameters to the GetObjectMetadata operation.
	/// The <c>HEAD</c> operation retrieves metadata from an object without returning the
	/// object itself. This operation is useful if you're interested only in an object's metadata.
	/// 
	///  
	/// <para>
	/// A <c>HEAD</c> request has the same options as a <c>GET</c> operation on an object.
	/// The response is identical to the <c>GET</c> response except that there is no response
	/// body. Because of this, if the <c>HEAD</c> request generates an error, it returns a
	/// generic code, such as <c>400 Bad Request</c>, <c>403 Forbidden</c>, <c>404 Not Found</c>,
	/// <c>405 Method Not Allowed</c>, <c>412 Precondition Failed</c>, or <c>304 Not Modified</c>.
	/// It's not possible to retrieve the exact exception of these error codes.
	/// </para>
	///  
	/// <para>
	/// Request headers are limited to 8 KB in size. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/RESTCommonRequestHeaders.html">Common
	/// Request Headers</a>.
	/// </para>
	///  <note> 
	/// <para>
	///  <b>Directory buckets</b> - For directory buckets, you must make requests for this
	/// API operation to the Zonal endpoint. These endpoints support virtual-hosted-style
	/// requests in the format <c>https://<i>bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com/<i>key-name</i>
	/// </c>. Path-style requests are not supported. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-Regions-and-Zones.html">Regional
	/// and Zonal endpoints</a> in the <i>Amazon S3 User Guide</i>.
	/// </para>
	///  </note> <dl> <dt>Permissions</dt> <dd>  <ul> <li> 
	/// <para>
	///  <b>General purpose bucket permissions</b> - To use <c>HEAD</c>, you must have the
	/// <c>s3:GetObject</c> permission. You need the relevant read object (or version) permission
	/// for this operation. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/list_amazons3.html">Actions,
	/// resources, and condition keys for Amazon S3</a> in the <i>Amazon S3 User Guide</i>.
	/// </para>
	///  
	/// <para>
	/// If the object you request doesn't exist, the error that Amazon S3 returns depends
	/// on whether you also have the <c>s3:ListBucket</c> permission.
	/// </para>
	///  <ul> <li> 
	/// <para>
	/// If you have the <c>s3:ListBucket</c> permission on the bucket, Amazon S3 returns an
	/// HTTP status code <c>404 Not Found</c> error.
	/// </para>
	///  </li> <li> 
	/// <para>
	/// If you don’t have the <c>s3:ListBucket</c> permission, Amazon S3 returns an HTTP status
	/// code <c>403 Forbidden</c> error.
	/// </para>
	///  </li> </ul> </li> <li> 
	/// <para>
	///  <b>Directory bucket permissions</b> - To grant access to this API operation on a
	/// directory bucket, we recommend that you use the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html">
	/// <c>CreateSession</c> </a> API operation for session-based authorization. Specifically,
	/// you grant the <c>s3express:CreateSession</c> permission to the directory bucket in
	/// a bucket policy or an IAM identity-based policy. Then, you make the <c>CreateSession</c>
	/// API call on the bucket to obtain a session token. With the session token in your request
	/// header, you can make API requests to this operation. After the session token expires,
	/// you make another <c>CreateSession</c> API call to generate a new session token for
	/// use. Amazon Web Services CLI or SDKs create session and refresh the session token
	/// automatically to avoid service interruptions when a session expires. For more information
	/// about authorization, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html">
	/// <c>CreateSession</c> </a>.
	/// </para>
	///  </li> </ul> </dd> <dt>Encryption</dt> <dd> <note> 
	/// <para>
	/// Encryption request headers, like <c>x-amz-server-side-encryption</c>, should not be
	/// sent for <c>HEAD</c> requests if your object uses server-side encryption with Key
	/// Management Service (KMS) keys (SSE-KMS), dual-layer server-side encryption with Amazon
	/// Web Services KMS keys (DSSE-KMS), or server-side encryption with Amazon S3 managed
	/// encryption keys (SSE-S3). The <c>x-amz-server-side-encryption</c> header is used when
	/// you <c>PUT</c> an object to S3 and want to specify the encryption method. If you include
	/// this header in a <c>HEAD</c> request for an object that uses these types of keys,
	/// you’ll get an HTTP <c>400 Bad Request</c> error. It's because the encryption method
	/// can't be changed when you retrieve the object.
	/// </para>
	///  </note> 
	/// <para>
	/// If you encrypt an object by using server-side encryption with customer-provided encryption
	/// keys (SSE-C) when you store the object in Amazon S3, then when you retrieve the metadata
	/// from the object, you must use the following headers to provide the encryption key
	/// for the server to be able to retrieve the object's metadata. The headers are: 
	/// </para>
	///  <ul> <li> 
	/// <para>
	///  <c>x-amz-server-side-encryption-customer-algorithm</c> 
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <c>x-amz-server-side-encryption-customer-key</c> 
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <c>x-amz-server-side-encryption-customer-key-MD5</c> 
	/// </para>
	///  </li> </ul> 
	/// <para>
	/// For more information about SSE-C, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/ServerSideEncryptionCustomerKeys.html">Server-Side
	/// Encryption (Using Customer-Provided Encryption Keys)</a> in the <i>Amazon S3 User
	/// Guide</i>.
	/// </para>
	///  <note> 
	/// <para>
	///  <b>Directory bucket permissions</b> - For directory buckets, only server-side encryption
	/// with Amazon S3 managed keys (SSE-S3) (<c>AES256</c>) is supported.
	/// </para>
	///  </note> </dd> <dt>Versioning</dt> <dd> <ul> <li> 
	/// <para>
	/// If the current version of the object is a delete marker, Amazon S3 behaves as if the
	/// object was deleted and includes <c>x-amz-delete-marker: true</c> in the response.
	/// </para>
	///  </li> <li> 
	/// <para>
	/// If the specified version is a delete marker, the response returns a <c>405 Method
	/// Not Allowed</c> error and the <c>Last-Modified: timestamp</c> response header.
	/// </para>
	///  </li> </ul> <note> <ul> <li> 
	/// <para>
	///  <b>Directory buckets</b> - Delete marker is not supported by directory buckets.
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <b>Directory buckets</b> - S3 Versioning isn't enabled and supported for directory
	/// buckets. For this API operation, only the <c>null</c> value of the version ID is supported
	/// by directory buckets. You can only specify <c>null</c> to the <c>versionId</c> query
	/// parameter in the request.
	/// </para>
	///  </li> </ul> </note> </dd> <dt>HTTP Host header syntax</dt> <dd> 
	/// <para>
	///  <b>Directory buckets </b> - The HTTP Host header syntax is <c> <i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
	/// </para>
	///  </dd> </dl> 
	/// <para>
	/// The following actions are related to <c>HeadObject</c>:
	/// </para>
	///  <ul> <li> 
	/// <para>
	///  <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a>
	/// 
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectAttributes.html">GetObjectAttributes</a>
	/// 
	/// </para>
	///  </li> </ul>
	/// </summary>
	public class GetObjectMetadataRequest
	{
		#region Properties

		/// <summary>
		/// Gets and sets the property BucketName. 
		/// <para>
		/// The name of the bucket that contains the object.
		/// </para>
		///  
		/// <para>
		///  <b>Directory buckets</b> - When you use this operation with a directory bucket, you
		/// must use virtual-hosted-style requests in the format <c> <i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
		/// Path-style requests are not supported. Directory bucket names must be unique in the
		/// chosen Availability Zone. Bucket names must follow the format <c> <i>bucket_base_name</i>--<i>az-id</i>--x-s3</c>
		/// (for example, <c> <i>DOC-EXAMPLE-BUCKET</i>--<i>usw2-az1</i>--x-s3</c>). For information
		/// about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
		/// bucket naming rules</a> in the <i>Amazon S3 User Guide</i>.
		/// </para>
		///  
		/// <para>
		///  <b>Access points</b> - When you use this action with an access point, you must provide
		/// the alias of the access point in place of the bucket name or specify the access point
		/// ARN. When using the access point ARN, you must direct requests to the access point
		/// hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
		/// When using this action with an access point through the Amazon Web Services SDKs,
		/// you provide the access point ARN in place of the bucket name. For more information
		/// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
		/// access points</a> in the <i>Amazon S3 User Guide</i>.
		/// </para>
		///  <note> 
		/// <para>
		/// Access points and Object Lambda access points are not supported by directory buckets.
		/// </para>
		///  </note> 
		/// <para>
		///  <b>S3 on Outposts</b> - When you use this action with Amazon S3 on Outposts, you
		/// must direct requests to the S3 on Outposts hostname. The S3 on Outposts hostname takes
		/// the form <c> <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</c>.
		/// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
		/// you provide the Outposts access point ARN in place of the bucket name. For more information
		/// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
		/// is S3 on Outposts?</a> in the <i>Amazon S3 User Guide</i>.
		/// </para>
		/// </summary>
		public string BucketName { get; set; }

		/// <summary>
		/// The key of the object.
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
		/// The Server-side encryption algorithm to be used with the customer provided key.
		///  
		///  <note> 
		/// <para>
		/// This functionality is not supported for directory buckets.
		/// </para>
		///  </note>
		/// </summary>
		public ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }

		/// <summary>
		/// The base64-encoded encryption key for Amazon S3 to use to decrypt the object
		/// <para>
		/// Using the encryption key you provide as part of your request Amazon S3 manages both the encryption, as it writes 
		/// to disks, and decryption, when you access your objects. Therefore, you don't need to maintain any data encryption code. The only 
		/// thing you do is manage the encryption keys you provide.
		/// </para>
		/// <para>
		/// When you retrieve an object, you must provide the same encryption key as part of your request. Amazon S3 first verifies 
		/// the encryption key you provided matches, and then decrypts the object before returning the object data to you.
		/// </para>
		/// <para>
		/// Important: Amazon S3 does not store the encryption key you provide.
		/// </para>
		///  <note> 
		/// <para>
		/// This functionality is not supported for directory buckets.
		/// </para>
		///  </note>
		/// </summary>
		public string ServerSideEncryptionCustomerProvidedKey { get; set; }

		#endregion
	}
}
