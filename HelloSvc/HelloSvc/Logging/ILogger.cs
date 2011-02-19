using System;

namespace HelloSvc.Logging
{
	public interface ILogger
	{
		void Message(String message);
		void ExceptionWithMessage(Exception ex, String message);
		void ExceptionAlone(Exception ex);
	}
}

