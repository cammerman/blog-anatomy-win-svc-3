using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

using Autofac;

namespace HelloSvc
{
	internal class ServiceBootstrapper
	{
		public IContainer Build()
		{
			var builder = new ContainerBuilder();

			builder
				.RegisterType<Services.GreetService>()
				.As<ServiceBase>()
				.InstancePerLifetimeScope();

			builder
				.RegisterType<Config.ServiceNameProvider>()
				.As<Config.IServiceNameProvider>()
				.InstancePerLifetimeScope();
			
			builder
				.RegisterType<Greeter>()
				.As<IGreeter>()
				.InstancePerLifetimeScope();

			return builder.Build();
		}
	}
}
