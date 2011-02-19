using System;
using System.Diagnostics;

namespace HelloSvc.Logging
{
	using SettingsProviders;
	
	public class EventLogFactory : IEventLogFactory
	{
		protected virtual String LogName
		{
			get;
			private set;
		}
		
		protected virtual String EventSource
		{
			get;
			private set;
		}
		
		public EventLogFactory(IEventLogConfigProvider eventLogConfig)
		{
			eventLogConfig.ThrowIfNull("eventLogConfig");
			
			LogName = eventLogConfig.LogName;
			EventSource = eventLogConfig.SourceName;
		}
	
		public EventLog Create()
		{
			return new EventLog(LogName, ".", EventSource);
		}
	}
}

