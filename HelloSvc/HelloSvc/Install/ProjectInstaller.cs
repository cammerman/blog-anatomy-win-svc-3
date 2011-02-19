using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess;

using Autofac;

namespace HelloSvc.Install
{
	[RunInstaller(true)]
	public class ProjectInstaller : Installer
	{
		public ProjectInstaller()
		{
			var bootstrapper = new InstallBootstrapper();
			var container = bootstrapper.Build();

			var installers = container.Resolve<IEnumerable<Installer>>();
			
			Installers.AddRange(
				installers.ToArray());
		}
	}
}