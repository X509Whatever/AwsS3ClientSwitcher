namespace System
{
	internal static class Guard
	{
		public static void Against<TException>(bool assertion, string message, params object[] args)
			where TException : Exception
		{
			if (assertion)
			{
				message = args != null ? string.Format(message, args) : message;
				throw (TException)Activator.CreateInstance(typeof(TException), message);
			}
		}

		public static void IsNotNull(object instance, string message, params object[] args)
		{
			if (instance == null)
			{
				message = args != null ? string.Format(message, args) : message;
				throw new ArgumentNullException(message);
			}
		}

		public static void IsNotNullNorWhitespace(string instance, string message, params object[] args)
		{
			if (string.IsNullOrWhiteSpace(instance))
			{
				message = args != null ? string.Format(message, args) : message;
				throw new ArgumentNullException(message);
			}
		}

		public static void IsNotDefault<T>(T instance, string message, params object[] args)
			where T : struct
		{
			if (Equals(instance, default(T)))
			{
				message = args != null ? string.Format(message, args) : message;
				throw new ArgumentNullException(message);
			}
		}

		public static T ThrowIfNull<T>(this T @this, string message, params object[] args)
			where T : class
		{
			if (@this == null)
				throw new ArgumentNullException(args != null ? string.Format(message, args) : message);

			return @this;
		}

		public static T ThrowIfDefault<T>(this T @this, string message, params object[] args)
			where T : struct
		{
			if (Equals(@this, default))
				throw new ArgumentNullException(args != null ? string.Format(message, args) : message);

			return @this;
		}
	}
}
