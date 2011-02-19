using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace HelloSvc.Services
{
	using SettingsProviders;

	internal class GreetService : ServiceBase
	{
		protected virtual IGreeter Greeter
		{
			get;
			private set;
		}
		
		public GreetService(IServiceNameProvider serviceNameProvider, IGreeter greeter)
		{
			serviceNameProvider.ThrowIfNull("serviceNameProvider");
			
			ServiceName =
				serviceNameProvider.ServiceName
					.ThrowIfNullOrEmpty("serviceNameProvider.ServiceName");
			
			Greeter = greeter.ThrowIfNull("greeter");
			
			CanStop = true;
			AutoLog = false;
		}

		protected override void OnStart(String[] args)
		{
			Greeter.SayHello();
		}

		protected override void OnStop()
		{
		}
	}
}
