using System;
using System.Diagnostics;
using System.Text;

namespace HelloSvc.Logging
{
	public class EventLogLogger : ILogger
	{
		protected virtual EventLog Log
		{
			get;
			private set;
		}
		
		public EventLogLogger(EventLog log)
		{
			Log = log.ThrowIfNull("log");
		}
		
		public void Message(string message)
		{
			Log.WriteEntry(message);
		}

		public void ExceptionWithMessage(Exception ex, string message)
		{
			var formatter = new StringBuilder(message);
			formatter.AppendLine();
			formatter.AppendLine(ex.ToString());
			
			Log.WriteEntry(formatter.ToString());
		}

		public void ExceptionAlone(Exception ex)
		{
			Log.WriteEntry(ex.ToString());
		}
	}
}

