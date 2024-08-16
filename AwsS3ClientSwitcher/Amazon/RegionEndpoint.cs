namespace Amazon
{
	/// <summary>
	/// This class contains region information used to lazily compute the service endpoints. The static constants representing the 
	/// regions can be used while constructing the AWS client instead of looking up the exact endpoint URL.
	/// </summary>
	public class RegionEndpoint
	{
		#region Properties

		public string SystemName { get; private set; }

		public string OriginalSystemName { get; internal set; }

		public string DisplayName { get; private set; }

		#endregion

		// XXX: Stuff used by us in order to create "a custom region".

		#region .ctors

		private RegionEndpoint(string systemName, string displayName)
		{
			SystemName = systemName;
			OriginalSystemName = systemName;
			DisplayName = displayName;
		}

		#endregion
	}
}
