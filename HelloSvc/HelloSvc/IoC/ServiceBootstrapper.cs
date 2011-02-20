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
		protected virtual void RegisterService(ContainerBuilder builder)
		{
			builder
				.RegisterType<Services.GreetService>()
				.As<ServiceBase>()
				.InstancePerLifetimeScope();
			
			builder
				.RegisterType<GreetServiceWorker>()
				.As<IGreetServiceWorker>()
				.InstancePerLifetimeScope();
		}
		
		protected virtual EventLog ResolveEventLog(IComponentContext context)
		{
			return
				context.Resolve<IEventLogFactory>()
					.Create();
		}
		
		protected virtual void RegisterLogging(ContainerBuilder builder)
		{
			builder
				.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.InNamespace("HelloSvc.Logging")
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			
			builder
				.Register(ResolveEventLog)
				.AsSelf()
				.InstancePerLifetimeScope();
		}
		
		protected virtual Config.IConfigSettings ResolveConfigSettings(IComponentContext context)
		{
			return
				context.Resolve<Config.IConfigLoader>()
					.LoadConfig();
		}
		
		protected virtual void RegisterConfig(ContainerBuilder builder)
		{
			builder
				.RegisterType<Config.ConfigLoader>()
				.As<Config.IConfigLoader>()
				.InstancePerLifetimeScope();
			
			builder
				.Register(ResolveConfigSettings)
				.As<Config.IConfigSettings>()
				.InstancePerLifetimeScope();
		}
		
		public IContainer Build()
		{
			var builder = new ContainerBuilder();

			RegisterService(builder);
			
			builder
				.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.InNamespace("HelloSvc.SettingsProviders")
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			
			builder
				.RegisterType<Greeter>()
				.As<IGreeter>()
				.InstancePerLifetimeScope();
			
			RegisterLogging(builder);
			RegisterConfig(builder);

			return builder.Build();
		}
	}
}
