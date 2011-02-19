using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Diagnostics;

namespace HelloSvc.Services
{
	using SettingsProviders;

	internal class GreetServiceInstaller : ServiceInstaller
	{
		public GreetServiceInstaller(IServiceNameProvider serviceNameProvider, IEventLogConfigProvider eventLogConfig)
			: base()
		{
			serviceNameProvider.ThrowIfNull("serviceNameProvider");
			var serviceName =
				serviceNameProvider.ServiceName
					.ThrowIfNullOrEmpty("serviceNameProvider.ServiceName");

			ServiceName = serviceName;
			DisplayName = serviceName;
			Description = "Windows Services Hello World";
			StartType = ServiceStartMode.Automatic;
			
			var eventLogInstaller =
				Installers
					.OfType<EventLogInstaller>()
					.FirstOrDefault();
			                         
			if (eventLogInstaller == null)
			{
				eventLogInstaller = new EventLogInstaller();
				Installers.Add(eventLogInstaller);
			}
		
			eventLogInstaller.UninstallAction = UninstallAction.Remove;
			eventLogInstaller.Log = eventLogConfig.LogName;
			eventLogInstaller.Source = eventLogConfig.SourceName;
		}
	}
}
