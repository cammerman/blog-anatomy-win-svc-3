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
		
		protected virtual Func<IGreetServiceWorker> WorkerFactory
		{
			get;
			private set;
		}
		
		public GreetService(IServiceNameProvider serviceNameProvider, ILogger logger, Func<IGreetServiceWorker> workerFactory)
		{
			serviceNameProvider.ThrowIfNull("serviceNameProvider");
			
			ServiceName =
				serviceNameProvider.ServiceName
					.ThrowIfNullOrEmpty("serviceNameProvider.ServiceName");
			
			Logger = logger.ThrowIfNull("logger");
			WorkerFactory = workerFactory.ThrowIfNull("workerFactory");
			
			CanStop = true;
			AutoLog = true;
		}
		
		protected IGreetServiceWorker CurrentWorker
		{
			get;
			set;
		}

		protected override void OnStart(String[] args)
		{
			Logger.Message("Starting service.");
			
			if (CurrentWorker == null)
			{	
				try
				{
					CurrentWorker = WorkerFactory();
					CurrentWorker.Start();
					
					Logger.Message("Service started.");
				}
				catch (Exception ex)
				{
					Logger.ExceptionAlone(ex);
				}
			}
			else
			{
				Logger.Message("Cannot start service. Service is already running.");
			}
		}

		protected override void OnStop()
		{
			Logger.Message("Stopping service.");
			CurrentWorker.Stop();
			CurrentWorker = null;
			Logger.Message("Service stopped.");
		}
	}
}
