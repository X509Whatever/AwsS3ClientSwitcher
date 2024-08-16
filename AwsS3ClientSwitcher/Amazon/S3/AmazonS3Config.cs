using System;

using Amazon.Runtime;

namespace Amazon.S3
{
	/// <summary>
	/// Configuration for accessing AmazonS3 service
	/// </summary>
	public class AmazonS3Config
	{
		#region Properties

		/// <summary>
		/// If true, underhood we'll use AWSSDK for netstandard2.0
		/// where HttpWebRequest is replaced by HttpClient.
		/// </summary>
		public bool UseNetStandard { get; set; }

		public bool? HttpKeepAlive { get; set; }

		/// <summary>
		/// Gets and sets the AuthenticationRegion property.
		/// Used in AWS4 request signing, this is an optional property; 
		/// change it only if the region cannot be determined from the 
		/// service endpoint.
		/// </summary>
		public string AuthenticationRegion { get; set; }

		/// <summary>
		/// <para>
		/// Gets and sets the RegionEndpoint property.  The region constant that 
		/// determines the endpoint to use.
		/// 
		/// Setting this property to null will force the SDK to recalculate the
		/// RegionEndpoint value based on App/WebConfig, environment variables,
		/// profile, etc.
		/// </para>
		/// <para>
		/// RegionEndpoint and ServiceURL are mutually exclusive properties. 
		/// Whichever property is set last will cause the other to automatically 
		/// be reset to null.
		/// </para>
		/// </summary>
		public RegionEndpoint RegionEndpoint { get; set; }

		/// <summary>
		/// <para>
		/// Gets and sets of the ServiceURL property.
		/// This is an optional property; change it
		/// only if you want to try a different service
		/// endpoint.
		/// </para>
		/// <para>
		/// RegionEndpoint and ServiceURL are mutually exclusive properties. 
		/// Whichever property is set last will cause the other to automatically 
		/// be reset to null.
		/// </para>
		/// </summary>
		public string ServiceURL { get; set; }

		/// <summary>
		/// When true, requests will always use path style addressing.
		/// </summary>
		public bool? ForcePathStyle { get; set; }

		/// <summary>
		/// .NET Framework 3.5
		/// ------------------
		/// Overrides the default request timeout value.
		/// This field does not impact Begin*/End* calls. A manual timeout must be implemented.
		/// 
		/// .NET Framework 4.5
		/// ------------------
		/// Overrides the default request timeout value.
		/// This field does not impact *Async calls. A manual timeout (for instance, using CancellationToken) must be implemented.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the value is set, the value is assigned to the Timeout property of the HttpWebRequest/HttpClient object used
		/// to send requests.
		/// </para>
		/// <para>
		/// Please specify a timeout value only if the operation will not complete within the default intervals
		/// specified for an HttpWebRequest/HttpClient.
		/// </para>
		/// </remarks>
		/// <exception cref="System.ArgumentNullException">The timeout specified is null.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The timeout specified is less than or equal to zero and is not Infinite.</exception>
		/// <seealso cref="P:System.Net.HttpWebRequest.Timeout"/>
		/// <seealso cref="P:System.Net.Http.HttpClient.Timeout"/>
		public TimeSpan? Timeout { get; set; }

		/// <summary>
		/// Flag on whether to log metrics for service calls.
		/// 
		/// This can be set in the application's configs, as below:
		/// <code>
		/// &lt;?xml version="1.0" encoding="utf-8" ?&gt;
		/// &lt;configuration&gt;
		///     &lt;appSettings&gt;
		///         &lt;add key="AWSLogMetrics" value"true"/&gt;
		///     &lt;/appSettings&gt;
		/// &lt;/configuration&gt;
		/// </code>
		/// </summary>
		public bool? LogMetrics { get; set; }

		/// <summary>
		/// Specifies the TCP keep-alive values to use for service requests.
		/// </summary>
		public TcpKeepAlive TcpKeepAlive { get; } = new TcpKeepAlive();

		/// <summary>
		/// Returns the flag indicating the current mode in use for request 
		/// retries and influences the value returned from <see cref="MaxErrorRetry"/>.
		/// The default value is RequestRetryMode.Legacy. This flag can be configured
		/// by using the AWS_RETRY_MODE environment variable, retry_mode in the
		/// shared configuration file, or by setting this value directly.
		/// </summary>
		public RequestRetryMode? RetryMode { get; set; }

		/// <summary>
		/// Returns the flag indicating how many retry HTTP requests an SDK should
		/// make for a single SDK operation invocation before giving up. This flag will 
		/// return 4 when the RetryMode is set to "Legacy" which is the default. For
		/// RetryMode values of "Standard" or "Adaptive" this flag will return 2. In 
		/// addition to the values returned that are dependent on the RetryMode, the
		/// value can be set to a specific value by using the AWS_MAX_ATTEMPTS environment
		/// variable, max_attempts in the shared configuration file, or by setting a
		/// value directly on this property. When using AWS_MAX_ATTEMPTS or max_attempts
		/// the value returned from this property will be one less than the value entered
		/// because this flag is the number of retry requests, not total requests. To 
		/// learn more about the RetryMode property that affects the values returned by 
		/// this flag, see <see cref="RetryMode"/>.
		/// </summary>
		public int? MaxErrorRetry { get; set; }

		/// <summary>
		/// Gets and sets the max idle time set on the ServicePoint for the WebRequest.
		/// Default value is 50 seconds (50,000 ms) unless ServicePointManager.MaxServicePointIdleTime is set,
		/// in which case ServicePointManager.MaxServicePointIdleTime will be used as the default.
		/// </summary>
		public int? MaxIdleTime { get; set; }

		/// <summary>
		/// Overrides the default read-write timeout value.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the value is set, the value is assigned to the ReadWriteTimeout property of the HttpWebRequest object used
		/// to send requests.
		/// </para>
		/// <exception cref="System.ArgumentNullException">The timeout specified is null.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">The timeout specified is less than or equal to zero and is not Infinite.</exception>
		/// </remarks>
		/// <seealso cref="P:System.Net.HttpWebRequest.ReadWriteTimeout"/>
		public TimeSpan? ReadWriteTimeout { get; set; }

		/// <summary>
		/// Gets and sets the connection limit set on the ServicePoint for the WebRequest.
		/// Default value is 50 connections unless ServicePointManager.DefaultConnectionLimit is set in 
		/// which case ServicePointManager.DefaultConnectionLimit will be used as the default.
		/// </summary>
		public int? ConnectionLimit { get; set; }

		#endregion
	}
}
