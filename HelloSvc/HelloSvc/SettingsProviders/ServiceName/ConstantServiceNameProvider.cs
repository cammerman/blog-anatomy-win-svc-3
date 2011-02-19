using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloSvc.SettingsProviders
{
	internal class ServiceNameProvider : IServiceNameProvider
	{
		public virtual String ServiceName
		{
			get { return "Greeter"; }
		}
	}
}
