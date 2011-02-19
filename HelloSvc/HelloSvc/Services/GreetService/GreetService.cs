using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace HelloSvc.Services
{
	using SettingsProviders;
	using Logging;

	internal class GreetService : ServiceBase
	{
		protected virtual IGreeter Greeter
		{
			get;
			private set;
		}
		
		protected virtual ILogger Logger
		{
			get;
			private set;
		}
		
		public GreetService(IServiceNameProvider serviceNameProvider, ILogger logger, IGreeter greeter)
		{
			serviceNameProvider.ThrowIfNull("serviceNameProvider");
			
			ServiceName =
				serviceNameProvider.ServiceName
					.ThrowIfNullOrEmpty("serviceNameProvider.ServiceName");
			
			Greeter = greeter.ThrowIfNull("greeter");
			Logger = logger.ThrowIfNull("logger");
			
			CanStop = true;
			AutoLog = true;
		}

		protected override void OnStart(String[] args)
		{
			Logger.Message("Starting service.");
			
			try
			{
				Greeter.SayHello();
			}
			catch (Exception ex)
			{
				Logger.ExceptionAlone(ex);
			}
		}

		protected override void OnStop()
		{
			Logger.Message("Stopping service.");
		}
	}
}
