namespace Amazon.Runtime
{
	/// <summary>
	/// RetryMode determines which request retry mode is used for requests that do 
	/// not complete successfully.
	/// </summary>
	public enum RequestRetryMode
	{
		/// <summary>
		/// Legacy request retry strategy.
		/// </summary>
		Legacy,
		/// <summary>
		/// Standardized request retry strategy that is consistent across all SDKs.
		/// </summary>
		Standard,
		/// <summary>
		/// An experimental request retry strategy that builds on the Standard strategy
		/// and introduces congestion control through client side rate limiting.
		/// </summary>
		Adaptive
	}
}
