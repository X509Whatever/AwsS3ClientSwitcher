extern alias AWSSDK_NETSTD;

using System;
using System.Threading.Tasks;

namespace Amazon.Runtime
{
	internal class ExecutionContextNetStandard<T> : IExecutionContext
	{
		#region Fields & Properties

		private readonly AWSSDK_NETSTD::Amazon.Runtime.IExecutionContext _context;
		private readonly Func<Task<T>> _next;

		private IRequestContext _requestContext;
		public IRequestContext RequestContext => _requestContext ?? (_requestContext = new RequestContextNetStandard(_context.RequestContext));

		#endregion

		#region .ctors

		public ExecutionContextNetStandard(AWSSDK_NETSTD::Amazon.Runtime.IExecutionContext context, Func<Task<T>> next)
		{
			_context = context.ThrowIfNull(nameof(context));
			_next = next.ThrowIfNull(nameof(next));
		}

		#endregion

		internal async Task<T> InvokeNextAsync()
		{
			return await _next();
		}
	}
}
