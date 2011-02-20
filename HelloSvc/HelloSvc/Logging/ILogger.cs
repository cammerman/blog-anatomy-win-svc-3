using System;

namespace HelloSvc.Logging
{
	internal interface ILogger
	{
		void Message(String message);
		void ExceptionWithMessage(Exception ex, String message);
		void ExceptionAlone(Exception ex);
	}
}

