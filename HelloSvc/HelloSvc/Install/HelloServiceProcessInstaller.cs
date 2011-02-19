using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Diagnostics;

namespace HelloSvc.Install
{
	using HelloSvc.SettingsProviders;
	
	internal class HelloServiceProcessInstaller : ServiceProcessInstaller
	{
		public HelloServiceProcessInstaller(IEventLogConfigProvider eventLogConfig)
			: base()
		{
			Account = ServiceAccount.LocalService;
			
			var eventLogInstaller =
				Installers
					.OfType<EventLogInstaller>()
					.FirstOrDefault();
			
			eventLogInstaller.Log = eventLogConfig.LogName;
			eventLogInstaller.Source = eventLogConfig.SourceName;
		}
	}
}
