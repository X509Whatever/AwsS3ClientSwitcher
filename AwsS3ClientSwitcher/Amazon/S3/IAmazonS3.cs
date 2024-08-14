using System;

using Amazon.S3.Model;

namespace Amazon.S3
{
	public interface IAmazonS3 : IDisposable
	{
		GetObjectResponse GetObject(GetObjectRequest request);

		GetObjectMetadataResponse GetObjectMetadata(GetObjectMetadataRequest request);

		string GetPreSignedURL(GetPreSignedUrlRequest request);

		PutObjectResponse PutObject(PutObjectRequest request);

		DeleteObjectResponse DeleteObject(string bucketName, string key);

		DeleteObjectsResponse DeleteObjects(DeleteObjectsRequest request);
	}
}
