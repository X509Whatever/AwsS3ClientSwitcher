extern alias AWSSDK_NETFX;

using System;

namespace Amazon.Runtime
{
	internal class ExecutionContextNetFx : IExecutionContext
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.Runtime.IExecutionContext _context;
		private readonly Action _next;

		private IRequestContext _requestContext;
		public IRequestContext RequestContext => _requestContext ?? (_requestContext = new RequestContextNetFx(_context.RequestContext));

		#endregion

		#region .ctors

		public ExecutionContextNetFx(AWSSDK_NETFX::Amazon.Runtime.IExecutionContext context, Action next)
		{
			_context = context.ThrowIfNull(nameof(context));
			_next = next.ThrowIfNull(nameof(next));
		}

		#endregion

		internal void InvokeNext()
		{
			_next();
		}
	}
}
