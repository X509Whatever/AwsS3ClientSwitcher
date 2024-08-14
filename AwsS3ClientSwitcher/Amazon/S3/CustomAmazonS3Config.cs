extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

using Amazon.Runtime;

namespace Amazon.S3
{
	internal class CustomAmazonS3ConfigNetFx : AWSSDK_NETFX::Amazon.S3.AmazonS3Config
	{
		public bool? HttpKeepAlive { get; set; }
	}

	internal class CustomAmazonS3ConfigNetStandard : AWSSDK_NETSTD::Amazon.S3.AmazonS3Config
	{
		public bool? HttpKeepAlive { get; set; }

		/// <summary>
		/// Specifies the TCP keep-alive values to use for service requests.
		/// </summary>
		public TcpKeepAlive TcpKeepAlive { get; set; }
	}
}
