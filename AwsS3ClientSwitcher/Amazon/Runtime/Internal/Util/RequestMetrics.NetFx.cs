extern alias AWSSDK_NETFX;

using System;

namespace Amazon.Runtime.Internal.Util
{
	internal class RequestMetricsNetFx : RequestMetrics
	{
		#region Fields

		private readonly AWSSDK_NETFX::Amazon.Runtime.Internal.Util.RequestMetrics _metrics;

		#endregion

		#region .ctors

		public RequestMetricsNetFx(AWSSDK_NETFX::Amazon.Runtime.Internal.Util.RequestMetrics metrics)
		{
			_metrics = metrics.ThrowIfNull(nameof(metrics));
		}

		#endregion

		public override string GetErrors() => _metrics.GetErrors();

		public override string ToString() => _metrics.ToString();
	}
}
