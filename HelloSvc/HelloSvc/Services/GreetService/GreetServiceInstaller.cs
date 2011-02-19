using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ServiceProcess;

namespace HelloSvc.Services
{
	using SettingsProviders;

	internal class GreetServiceInstaller : ServiceInstaller
	{
		public GreetServiceInstaller(IServiceNameProvider serviceNameProvider)
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
		}
	}
}
