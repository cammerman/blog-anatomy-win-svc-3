using System;

namespace HelloSvc.SettingsProviders
{
	public class ConstantEventLogProvider : IEventLogConfigProvider
	{
		public ConstantEventLogProvider ()
		{
		}
	
		public virtual String LogName
		{
			get { return "GreeterService"; }
		}

		public virtual String SourceName
		{
			get { return "GreeterService"; }
		}
		
	}
}

