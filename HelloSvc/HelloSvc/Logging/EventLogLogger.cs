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
			try
			{
				Log.WriteEntry(message);
			}
			catch
			{
				// Suppress. Nothing can be done except to not let logging crash the service.
			}
		}

		public void ExceptionWithMessage(Exception ex, string message)
		{
			try
			{
				var formatter = new StringBuilder(message);
				formatter.AppendLine();
				formatter.AppendLine(ex.ToString());
				
				Log.WriteEntry(formatter.ToString());
			}
			catch
			{
				// Suppress. Nothing can be done except to not let logging crash the service.
			}
		}

		public void ExceptionAlone(Exception ex)
		{
			try
			{
				Log.WriteEntry(ex.ToString());
			}
			catch
			{
				// Suppress. Nothing can be done except to not let logging crash the service.
			}
		}
	}
}

