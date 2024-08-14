extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

namespace Amazon.Util
{
	public class LoggingConfig
	{
		internal static readonly LoggingConfig Instance = new LoggingConfig();

		/// <summary>
		/// Whether or not to log SDK metrics.
		/// </summary>
		public bool LogMetrics
		{
			set
			{
				AWSSDK_NETFX::Amazon.AWSConfigs.LoggingConfig.LogMetrics = value;
				AWSSDK_NETSTD::Amazon.AWSConfigs.LoggingConfig.LogMetrics = value;
			}
		}
	}
}
