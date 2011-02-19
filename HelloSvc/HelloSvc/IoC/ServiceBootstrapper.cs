using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Reflection;

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
				.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.InNamespace("HelloSvc.SettingsProviders")
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			
			builder
				.RegisterType<Greeter>()
				.As<IGreeter>()
				.InstancePerLifetimeScope();

			return builder.Build();
		}
	}
}
