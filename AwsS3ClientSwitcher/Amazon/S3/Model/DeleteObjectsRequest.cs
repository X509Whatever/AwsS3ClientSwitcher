using System.Collections.Generic;
using System.Linq;

namespace Amazon.S3.Model
{
	/// <summary>
	/// Container for the parameters to the DeleteObjects operation.
	/// This operation enables you to delete multiple objects from a bucket using a single
	/// HTTP request. If you know the object keys that you want to delete, then this operation
	/// provides a suitable alternative to sending individual delete requests, reducing per-request
	/// overhead.
	/// 
	///  
	/// <para>
	/// The request can contain a list of up to 1000 keys that you want to delete. In the
	/// XML, you provide the object key names, and optionally, version IDs if you want to
	/// delete a specific version of the object from a versioning-enabled bucket. For each
	/// key, Amazon S3 performs a delete operation and returns the result of that delete,
	/// success or failure, in the response. Note that if the object specified in the request
	/// is not found, Amazon S3 returns the result as deleted.
	/// </para>
	///  <note> <ul> <li> 
	/// <para>
	///  <b>Directory buckets</b> - S3 Versioning isn't enabled and supported for directory
	/// buckets.
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
	/// The operation supports two modes for the response: verbose and quiet. By default,
	/// the operation uses verbose mode in which the response includes the result of deletion
	/// of each key in your request. In quiet mode the response includes only keys where the
	/// delete operation encountered an error. For a successful deletion in a quiet mode,
	/// the operation does not return any information about the delete in the response body.
	/// </para>
	///  
	/// <para>
	/// When performing this action on an MFA Delete enabled bucket, that attempts to delete
	/// any versioned objects, you must include an MFA token. If you do not provide one, the
	/// entire request will fail, even if there are non-versioned objects you are trying to
	/// delete. If you provide an invalid token, whether there are versioned keys in the request
	/// or not, the entire Multi-Object Delete request will fail. For information about MFA
	/// Delete, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/Versioning.html#MultiFactorAuthenticationDelete">MFA
	/// Delete</a> in the <i>Amazon S3 User Guide</i>.
	/// </para>
	///  <note> 
	/// <para>
	///  <b>Directory buckets</b> - MFA delete is not supported by directory buckets.
	/// </para>
	///  </note> <dl> <dt>Permissions</dt> <dd> <ul> <li> 
	/// <para>
	///  <b>General purpose bucket permissions</b> - The following permissions are required
	/// in your policies when your <c>DeleteObjects</c> request includes specific headers.
	/// </para>
	///  <ul> <li> 
	/// <para>
	///  <b> <c>s3:DeleteObject</c> </b> - To delete an object from a bucket, you must always
	/// specify the <c>s3:DeleteObject</c> permission.
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <b> <c>s3:DeleteObjectVersion</c> </b> - To delete a specific version of an object
	/// from a versiong-enabled bucket, you must specify the <c>s3:DeleteObjectVersion</c>
	/// permission.
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
	///  </li> </ul> </dd> <dt>Content-MD5 request header</dt> <dd> <ul> <li> 
	/// <para>
	///  <b>General purpose bucket</b> - The Content-MD5 request header is required for all
	/// Multi-Object Delete requests. Amazon S3 uses the header value to ensure that your
	/// request body has not been altered in transit.
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <b>Directory bucket</b> - The Content-MD5 request header or a additional checksum
	/// request header (including <c>x-amz-checksum-crc32</c>, <c>x-amz-checksum-crc32c</c>,
	/// <c>x-amz-checksum-sha1</c>, or <c>x-amz-checksum-sha256</c>) is required for all Multi-Object
	/// Delete requests.
	/// </para>
	///  </li> </ul> </dd> <dt>HTTP Host header syntax</dt> <dd> 
	/// <para>
	///  <b>Directory buckets </b> - The HTTP Host header syntax is <c> <i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
	/// </para>
	///  </dd> </dl> 
	/// <para>
	/// The following operations are related to <c>DeleteObjects</c>:
	/// </para>
	///  <ul> <li> 
	/// <para>
	///  <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateMultipartUpload.html">CreateMultipartUpload</a>
	/// 
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_UploadPart.html">UploadPart</a>
	/// 
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CompleteMultipartUpload.html">CompleteMultipartUpload</a>
	/// 
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListParts.html">ListParts</a>
	/// 
	/// </para>
	///  </li> <li> 
	/// <para>
	///  <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_AbortMultipartUpload.html">AbortMultipartUpload</a>
	/// 
	/// </para>
	///  </li> </ul>
	/// </summary>
	public class DeleteObjectsRequest
	{
		#region Fields & Properties

		private IList<string> _keys;

		/// <summary>
		/// Gets and sets the property BucketName. 
		/// <para>
		/// The bucket name containing the objects to delete. 
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

		#endregion

		/// <summary>
		/// Add a key to the set of keys of objects to be deleted.
		/// </summary>
		/// <param name="key">Object key</param>
		public void AddKey(string key)
		{
			if (_keys == null)
				_keys = new List<string>();

			_keys.Add(key);
		}

		internal IEnumerable<string> TryGetKeys() => _keys?.ToArray();
	}
}
