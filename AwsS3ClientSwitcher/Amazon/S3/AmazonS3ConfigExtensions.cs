extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

using System;

namespace Amazon.S3
{
	internal static class AmazonS3ConfigExtensions
	{
		public static AWSSDK_NETFX::Amazon.S3.AmazonS3Config ToNetFx(this AmazonS3Config @this)
		{
			Guard.IsNotNull(@this, nameof(@this));

			var cfg = new CustomAmazonS3ConfigNetFx();

			if (@this.HttpKeepAlive != null)
				cfg.HttpKeepAlive = @this.HttpKeepAlive.Value;

			if (@this.AuthenticationRegion != null)
				cfg.AuthenticationRegion = @this.AuthenticationRegion;

			if (@this.RegionEndpoint != null)
				cfg.RegionEndpoint = @this.RegionEndpoint.ToNetFx();

			if (@this.ServiceURL != null)
				cfg.ServiceURL = @this.ServiceURL;

			if (@this.ForcePathStyle != null)
				cfg.ForcePathStyle = @this.ForcePathStyle.Value;

			if (@this.Timeout != null)
				cfg.Timeout = @this.Timeout.Value;

			if (@this.LogMetrics != null)
				cfg.LogMetrics = @this.LogMetrics.Value;

			if (@this.TcpKeepAlive.Enabled != null)
				cfg.TcpKeepAlive.Enabled = @this.TcpKeepAlive.Enabled.Value;

			if (@this.TcpKeepAlive.Timeout != null)
				cfg.TcpKeepAlive.Timeout = @this.TcpKeepAlive.Timeout.Value;

			if (@this.TcpKeepAlive.Interval != null)
				cfg.TcpKeepAlive.Interval = @this.TcpKeepAlive.Interval.Value;

			if (@this.RetryMode != null)
				cfg.RetryMode = (AWSSDK_NETFX::Amazon.Runtime.RequestRetryMode)@this.RetryMode.Value;

			if (@this.MaxErrorRetry != null)
				cfg.MaxErrorRetry = @this.MaxErrorRetry.Value;

			if (@this.MaxIdleTime != null)
				cfg.MaxIdleTime = @this.MaxIdleTime.Value;

			if (@this.ReadWriteTimeout != null)
				cfg.ReadWriteTimeout = @this.ReadWriteTimeout.Value;

			if (@this.ConnectionLimit != null)
				cfg.ConnectionLimit = @this.ConnectionLimit.Value;

			return cfg;
		}

		public static AWSSDK_NETSTD::Amazon.S3.AmazonS3Config ToNetStd(this AmazonS3Config @this)
		{
			Guard.IsNotNull(@this, nameof(@this));

			var cfg = new CustomAmazonS3ConfigNetStandard();

			if (@this.HttpKeepAlive != null)
				cfg.HttpKeepAlive = @this.HttpKeepAlive.Value;

			if (@this.AuthenticationRegion != null)
				cfg.AuthenticationRegion = @this.AuthenticationRegion;

			if (@this.RegionEndpoint != null)
				cfg.RegionEndpoint = @this.RegionEndpoint.ToNetStd();

			if (@this.ServiceURL != null)
				cfg.ServiceURL = @this.ServiceURL;

			if (@this.ForcePathStyle != null)
				cfg.ForcePathStyle = @this.ForcePathStyle.Value;

			if (@this.Timeout != null)
				cfg.Timeout = @this.Timeout.Value;

			if (@this.LogMetrics != null)
				cfg.LogMetrics = @this.LogMetrics.Value;

			if (@this.TcpKeepAlive.Enabled != null) //< Copy only if true or false.
				cfg.TcpKeepAlive = @this.TcpKeepAlive;

			if (@this.RetryMode != null)
				cfg.RetryMode = (AWSSDK_NETSTD::Amazon.Runtime.RequestRetryMode)@this.RetryMode.Value;

			if (@this.MaxErrorRetry != null)
				cfg.MaxErrorRetry = @this.MaxErrorRetry.Value;

			if (@this.ConnectionLimit != null) //< Configures HttpClientHandler.MaxConnectionsPerServer
				cfg.MaxConnectionsPerServer = @this.ConnectionLimit.Value;

			return cfg;
		}
	}
}
