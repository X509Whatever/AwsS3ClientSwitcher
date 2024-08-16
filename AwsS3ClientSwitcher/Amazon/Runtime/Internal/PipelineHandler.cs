extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

using System;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal
{
	internal class DelegatingPipelineHandlerNetFx : AWSSDK_NETFX::Amazon.Runtime.Internal.PipelineHandler
	{
		#region Fields

		private readonly PipelineHandler _owner;

		#endregion

		#region .ctors

		public DelegatingPipelineHandlerNetFx(PipelineHandler owner)
		{
			_owner = owner.ThrowIfNull(nameof(owner));
		}

		#endregion

		public override void InvokeSync(AWSSDK_NETFX::Amazon.Runtime.IExecutionContext executionContext)
		{
			var ec = new ExecutionContextNetFx(executionContext, () => base.InvokeSync(executionContext));
			_owner.InvokeSync(ec);
		}
	}

	internal class DelegatingPipelineHandlerNetStandard : AWSSDK_NETSTD::Amazon.Runtime.Internal.PipelineHandler
	{
		#region Fields

		private readonly PipelineHandler _owner;

		#endregion

		#region .ctors

		public DelegatingPipelineHandlerNetStandard(PipelineHandler owner)
		{
			_owner = owner.ThrowIfNull(nameof(owner));
		}

		#endregion

		public override void InvokeSync(AWSSDK_NETSTD::Amazon.Runtime.IExecutionContext _) => throw new NotSupportedException("Use async for netstd!");

		public override async Task<T> InvokeAsync<T>(AWSSDK_NETSTD::Amazon.Runtime.IExecutionContext executionContext)
		{
			var ec = new ExecutionContextNetStandard<T>(executionContext, () => base.InvokeAsync<T>(executionContext));
			return await _owner.InvokeAsync<T>(ec);
		}
	}

	public abstract class PipelineHandler
	{
		#region Fields

		private AWSSDK_NETFX::Amazon.Runtime.Internal.PipelineHandler _netfx;
		private AWSSDK_NETSTD::Amazon.Runtime.Internal.PipelineHandler _netstd;

		#endregion

		#region .ctors

		public PipelineHandler()
		{ }

		#endregion

		internal AWSSDK_NETFX::Amazon.Runtime.Internal.PipelineHandler WireForNetFx()
		{
			Guard.Against<InvalidOperationException>(_netfx != null || _netstd != null, "Already wired up?!");
			return _netfx = new DelegatingPipelineHandlerNetFx(this);
		}

		internal AWSSDK_NETSTD::Amazon.Runtime.Internal.PipelineHandler WireForNetStd()
		{
			Guard.Against<InvalidOperationException>(_netstd != null || _netfx != null, "Already wired up?!");
			return _netstd = new DelegatingPipelineHandlerNetStandard(this);
		}

		public virtual void InvokeSync(IExecutionContext executionContext)
		{
			if (!(executionContext is ExecutionContextNetFx netfx))
				throw new ArgumentOutOfRangeException("Unexpected execution context?!");

			netfx.InvokeNext();
		}

		public virtual async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			if (!(executionContext is ExecutionContextNetStandard<T> netstd))
				throw new ArgumentOutOfRangeException("Unexpected execution context?!");

			return await netstd.InvokeNextAsync();
		}
	}
}
