using System;

namespace HelloSvc.SettingsProviders
{
	internal class ConstantEventLogProvider : IEventLogConfigProvider
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
			get { return "Greeter"; }
		}
		
	}
}

