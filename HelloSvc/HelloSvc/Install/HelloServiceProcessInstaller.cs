using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ServiceProcess;

namespace HelloSvc.Install
{
	using HelloSvc.SettingsProviders;
	
	internal class HelloServiceProcessInstaller : ServiceProcessInstaller
	{
		public HelloServiceProcessInstaller()
			: base()
		{
			Account = ServiceAccount.LocalService;
		}
	}
}
