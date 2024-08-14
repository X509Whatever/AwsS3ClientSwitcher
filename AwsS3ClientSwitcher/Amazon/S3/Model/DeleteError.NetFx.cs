extern alias AWSSDK_NETFX;

using System;

namespace Amazon.S3.Model
{
	internal class DeleteErrorNetFx : DeleteError
	{
		#region Fields & Properties

		private readonly AWSSDK_NETFX::Amazon.S3.Model.DeleteError _error;

		public override string Key => _error.Key;

		public override string Code => _error.Code;

		public override string Message => _error.Message;

		#endregion

		#region .ctors

		public DeleteErrorNetFx(AWSSDK_NETFX::Amazon.S3.Model.DeleteError error)
		{
			_error = error.ThrowIfNull(nameof(error));
		}

		#endregion
	}
}
