namespace Amazon.Runtime
{
	public interface IExecutionContext
	{
		IRequestContext RequestContext { get; }
	}
}
