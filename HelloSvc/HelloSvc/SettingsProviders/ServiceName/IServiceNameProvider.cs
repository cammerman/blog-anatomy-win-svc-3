using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloSvc.Config
{
	internal interface IServiceNameProvider
	{
		String ServiceName { get; }
	}
}
