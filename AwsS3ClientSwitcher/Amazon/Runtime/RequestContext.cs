extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

using System;

using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	public interface IRequestContext
	{
		string RequestName { get; }

		Guid InvocationId { get; }

		RequestMetrics Metrics { get; }
	}

	internal class RequestContextNetFx : IRequestContext
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.Runtime.IRequestContext _context;

		public string RequestName => _context.RequestName;

		public Guid InvocationId => _context.InvocationId;

		private RequestMetrics _metrics;
		public RequestMetrics Metrics => _metrics ?? (_metrics = new RequestMetricsNetFx(_context.Metrics));

		#endregion

		#region .ctors

		public RequestContextNetFx(AWSSDK_NETFX::Amazon.Runtime.IRequestContext context)
		{
			_context = context.ThrowIfNull(nameof(context));
		}

		#endregion
	}

	internal class RequestContextNetStandard : IRequestContext
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.Runtime.IRequestContext _context;

		public string RequestName => _context.RequestName;

		public Guid InvocationId => _context.InvocationId;

		private RequestMetrics _metrics;
		public RequestMetrics Metrics => _metrics ?? (_metrics = new RequestMetricsNetStandard(_context.Metrics));

		#endregion

		#region .ctors

		public RequestContextNetStandard(AWSSDK_NETSTD::Amazon.Runtime.IRequestContext context)
		{
			_context = context.ThrowIfNull(nameof(context));
		}

		#endregion
	}
}
