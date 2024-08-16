using System;

namespace Amazon.Runtime
{
	/// <summary>
	/// TcpKeepAlive class used to group all the different properties used for working with TCP keep-alives.
	/// </summary>
	public class TcpKeepAlive
	{
		/// <summary>
		/// Specifies if TCP keep-alive is enabled or disabled. The default value is false for all services except Lambda.
		/// </summary>
		public bool? Enabled { get; set; }

		/// <summary>
		/// The timeout before a TCP keep-alive packet will be sent. The timeout value must be greater 
		/// than 0 seconds and not null if Enabled is set to true. The default value is 5 minutes.
		/// </summary>
		public TimeSpan? Timeout { get; set; }

		/// <summary>
		/// The interval before retrying a TCP keep-alive packet that did not receive an acknowledgement. The 
		/// interval must be greater than 0 seconds and not null if Enabled is set to true. The default value is 15 seconds.
		/// </summary>
		public TimeSpan? Interval { get; set; }

		public int? Probes { get; set; }
	}
}
