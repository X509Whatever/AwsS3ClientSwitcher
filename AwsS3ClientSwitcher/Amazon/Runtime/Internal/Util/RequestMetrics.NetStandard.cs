extern alias AWSSDK_NETSTD;

using System;

namespace Amazon.Runtime.Internal.Util
{
	internal class RequestMetricsNetStandard : RequestMetrics
	{
		#region Fields

		private readonly AWSSDK_NETSTD::Amazon.Runtime.Internal.Util.RequestMetrics _metrics;

		#endregion

		#region .ctors

		public RequestMetricsNetStandard(AWSSDK_NETSTD::Amazon.Runtime.Internal.Util.RequestMetrics metrics)
		{
			_metrics = metrics.ThrowIfNull(nameof(metrics));
		}

		#endregion

		public override string GetErrors() => _metrics.GetErrors();

		public override string ToString() => _metrics.ToString();
	}
}
