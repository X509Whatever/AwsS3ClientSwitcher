using System;
using System.Collections.Generic;
using System.IO;

namespace Amazon.S3.Model
{
	/// <summary>
	/// Container for the parameters to the PutObject operation.
	/// Adds an object to a bucket.
	/// 
	///  <note> <ul> <li> 
	/// <para>
	/// Amazon S3 never adds partial objects; if you receive a success response, Amazon S3
	/// added the entire object to the bucket. You cannot use <c>PutObject</c> to only update
	/// a single piece of metadata for an existing object. You must put the entire object
	/// with updated metadata if you want to update some values.
	/// </para>
	///  </li> <li> 
	/// <para>
	/// If your bucket uses the bucket owner enforced setting for Object Ownership, ACLs are
	/// disabled and no longer affect permissions. All objects written to the bucket by any
	/// account will be owned by the bucket owner.
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <b>Directory buckets</b> - For directory buckets, you must make requests for this
	/// API operation to the Zonal endpoint. These endpoints support virtual-hosted-style
	/// requests in the format <c>https://<i>bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com/<i>key-name</i>
	/// </c>. Path-style requests are not supported. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-Regions-and-Zones.html">Regional
	/// and Zonal endpoints</a> in the <i>Amazon S3 User Guide</i>.
	/// </para>
	///  </li> </ul> </note> 
	/// <para>
	/// Amazon S3 is a distributed system. If it receives multiple write requests for the
	/// same object simultaneously, it overwrites all but the last object written. However,
	/// Amazon S3 provides features that can modify this behavior:
	/// </para>
	///  <ul> <li> 
	/// <para>
	///  <b>S3 Object Lock</b> - To prevent objects from being deleted or overwritten, you
	/// can use <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/object-lock.html">Amazon
	/// S3 Object Lock</a> in the <i>Amazon S3 User Guide</i>.
	/// </para>
	///  <note> 
	/// <para>
	/// This functionality is not supported for directory buckets.
	/// </para>
	///  </note> </li> <li> 
	/// <para>
	///  <b>S3 Versioning</b> - When you enable versioning for a bucket, if Amazon S3 receives
	/// multiple write requests for the same object simultaneously, it stores all versions
	/// of the objects. For each write request that is made to the same object, Amazon S3
	/// automatically generates a unique version ID of that object being stored in Amazon
	/// S3. You can retrieve, replace, or delete any version of the object. For more information
	/// about versioning, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/AddingObjectstoVersioningEnabledBuckets.html">Adding
	/// Objects to Versioning-Enabled Buckets</a> in the <i>Amazon S3 User Guide</i>. For
	/// information about returning the versioning state of a bucket, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketVersioning.html">GetBucketVersioning</a>.
	/// 
	/// </para>
	///  <note> 
	/// <para>
	/// This functionality is not supported for directory buckets.
	/// </para>
	///  </note> </li> </ul> <dl> <dt>Permissions</dt> <dd> <ul> <li> 
	/// <para>
	///  <b>General purpose bucket permissions</b> - The following permissions are required
	/// in your policies when your <c>PutObject</c> request includes specific headers.
	/// </para>
	///  <ul> <li> 
	/// <para>
	///  <b> <c>s3:PutObject</c> </b> - To successfully complete the <c>PutObject</c> request,
	/// you must always have the <c>s3:PutObject</c> permission on a bucket to add an object
	/// to it.
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <b> <c>s3:PutObjectAcl</c> </b> - To successfully change the objects ACL of your
	/// <c>PutObject</c> request, you must have the <c>s3:PutObjectAcl</c>.
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <b> <c>s3:PutObjectTagging</c> </b> - To successfully set the tag-set with your <c>PutObject</c>
	/// request, you must have the <c>s3:PutObjectTagging</c>.
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
	///  </li> </ul> </dd> <dt>Data integrity with Content-MD5</dt> <dd> <ul> <li> 
	/// <para>
	///  <b>General purpose bucket</b> - To ensure that data is not corrupted traversing the
	/// network, use the <c>Content-MD5</c> header. When you use this header, Amazon S3 checks
	/// the object against the provided MD5 value and, if they do not match, Amazon S3 returns
	/// an error. Alternatively, when the object's ETag is its MD5 digest, you can calculate
	/// the MD5 while putting the object to Amazon S3 and compare the returned ETag to the
	/// calculated MD5 value.
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <b>Directory bucket</b> - This functionality is not supported for directory buckets.
	/// </para>
	///  </li> </ul> </dd> <dt>HTTP Host header syntax</dt> <dd> 
	/// <para>
	///  <b>Directory buckets </b> - The HTTP Host header syntax is <c> <i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
	/// </para>
	///  </dd> </dl> 
	/// <para>
	/// For more information about related Amazon S3 APIs, see the following:
	/// </para>
	///  <ul> <li> 
	/// <para>
	///  <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CopyObject.html">CopyObject</a>
	/// 
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteObject.html">DeleteObject</a>
	/// 
	/// </para>
	///  </li> </ul>
	/// </summary>
	public class PutObjectRequest
	{
		#region Fields & Properties

		/// <summary>
		/// Gets and sets the property BucketName. 
		/// <para>
		/// The bucket name to which the PUT action was initiated. 
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
		/// Gets and sets Key property. This key is used to identify the object in S3.
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// Input stream for the request; content for the request will be read from the stream.
		/// </summary>
		public Stream InputStream { get; set; }

		/// <summary>
		/// If this value is set to true then the stream used with this request will be closed when all the content 
		/// is read from the stream.  
		/// Default: true.
		/// </summary>
		public bool? AutoCloseStream { get; set; }

		/// <summary>
		/// If this value is set to true then the stream will be seeked back to the start before being read for upload.
		/// Default: true.
		/// </summary>
		public bool? AutoResetStreamPosition { get; set; }

		/// <summary>
		/// This is a convenience property for Headers.ContentType.
		/// </summary>
		public string ContentType { get; set; }

		private HeadersCollection _headers;

		/// <summary>
		/// The collection of headers for the request.
		/// </summary>
		public HeadersCollection Headers
		{
			get => _headers ?? (_headers = new HeadersCollection());
			internal set => _headers = value;
		}

		private IDictionary<string, string> _metadata;

		/// <summary>
		/// The collection of meta data for the request.
		/// </summary>
		public IDictionary<string, string> Metadata
		{
			get => _metadata ?? (_metadata = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
			internal set => _metadata = value;
		}

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
		/// The base64-encoded encryption key for Amazon S3 to use to encrypt the object
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
