using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Reflection;
using System.Diagnostics;

using Autofac;

namespace HelloSvc
{
	using Logging;
	
	internal class ServiceBootstrapper
	{
		protected virtual EventLog ResolveEventLog(IComponentContext context)
		{
			return
				context.Resolve<IEventLogFactory>()
					.Create();
		}
		
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
			
			builder
				.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.InNamespace("HelloSvc.Logging")
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			
			builder
				.Register(ResolveEventLog)
				.AsSelf()
				.InstancePerLifetimeScope();

			return builder.Build();
		}
	}
}
