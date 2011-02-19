using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Diagnostics;

using Autofac;

namespace HelloSvc
{
    public static class Program
    {
		public static void Main(String[] args)
		{
			try
			{
				var iocBootstrap = new ServiceBootstrapper();
				var container = iocBootstrap.Build();
	
				var services = container.Resolve<IEnumerable<ServiceBase>>();
	
				ServiceBase.Run(
					services.ToArray());
			}
			catch (Exception ex)
			{
				var log = new EventLog("Application", ".", "Greeter");
				log.WriteEntry(ex.ToString());
			}
		}
    }
}
