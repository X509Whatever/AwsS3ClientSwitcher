namespace Amazon.S3.Model
{
	public abstract class DeleteError
	{
		#region Properties

		public abstract string Key { get; }

		public abstract string Code { get; }

		public abstract string Message { get; }

		#endregion
	}
}
