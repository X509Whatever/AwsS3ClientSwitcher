extern alias AWSSDK_NETFX;
extern alias AWSSDK_NETSTD;

using System;
using System.Reflection;

namespace Amazon
{
	internal static class RegionEndpointExtensions
	{
		#region Fields

		private static readonly ConstructorInfo _regionEndpointCtorFx = typeof(AWSSDK_NETFX::Amazon.RegionEndpoint)
			.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(string), typeof(string) }, null);

		private static readonly ConstructorInfo _regionEndpointCtorStd = typeof(AWSSDK_NETSTD::Amazon.RegionEndpoint)
			.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(string), typeof(string) }, null);

		#endregion

		public static AWSSDK_NETFX::Amazon.RegionEndpoint ToNetFx(this RegionEndpoint re)
		{
			Guard.IsNotNull(re, nameof(re));
			return _regionEndpointCtorFx.Invoke(new[] { re.SystemName, re.DisplayName }) as AWSSDK_NETFX::Amazon.RegionEndpoint;
		}

		public static AWSSDK_NETSTD::Amazon.RegionEndpoint ToNetStd(this RegionEndpoint re)
		{
			Guard.IsNotNull(re, nameof(re));
			return _regionEndpointCtorStd.Invoke(new[] { re.SystemName, re.DisplayName }) as AWSSDK_NETSTD::Amazon.RegionEndpoint;
		}
	}
}
