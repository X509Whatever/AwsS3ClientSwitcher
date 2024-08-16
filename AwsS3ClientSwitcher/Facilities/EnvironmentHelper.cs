using System.Runtime.InteropServices;

namespace System
{
	internal class EnvironmentHelper
	{
		#region Inner Types

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct utsname
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string sysname;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string nodename;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string release;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string version;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string machine;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
			public string extraJustInCase;
		}

		#endregion

		#region Fields & Properties

		private static readonly Lazy<bool> __runningOnWindows = new Lazy<bool>(DetectWindows);

		private static readonly object _initLock = new object();
		private static volatile bool _initialized;

		private static bool _runningOnUnix, _runningOnMacOS, _runningOnLinux;

		/// <summary>
		/// Gets a System.Boolean indicating whether running on a Windows platform.
		/// </summary>
		public static bool RunningOnWindows => __runningOnWindows.Value;
		public static bool RunningOnMacOS => _runningOnMacOS;
		public static bool RunningOnLinux => _runningOnLinux;


		#endregion

		#region .ctors

		static EnvironmentHelper()
		{
			Init();
		}

		#endregion

		#region Private methods

		[DllImport("libc")]
		private static extern void uname(out utsname uname_struct);

		/// <summary>
		/// Detects the unix kernel by p/invoking uname (libc).
		/// </summary>
		private static string DetectUnixKernel()
		{
			uname(out utsname uts);
			return uts.sysname;
		}

		private static void DetectUnix(ref bool unix, ref bool linux, ref bool macos)
		{
			switch (DetectUnixKernel())
			{
				case "":
				case null:
					throw new PlatformNotSupportedException("Unknown platform?!");

				case "Linux":
					linux = unix = true;
					break;

				case "Darwin":
					macos = unix = true;
					break;

				default:
					unix = true;
					break;
			}
		}

		private static bool DetectWindows()
		{
			return Environment.OSVersion.Platform == PlatformID.Win32NT
				|| Environment.OSVersion.Platform == PlatformID.Win32S
				|| Environment.OSVersion.Platform == PlatformID.Win32Windows
				|| Environment.OSVersion.Platform == PlatformID.WinCE;
		}

		private static void Init()
		{
			lock (_initLock)
			{
				if (!_initialized)
				{
					_initialized = true;

					if (!RunningOnWindows)
					{
						DetectUnix(ref _runningOnUnix, ref _runningOnLinux, ref _runningOnMacOS);
					}
				}
			}
		}

		#endregion
	}
}
