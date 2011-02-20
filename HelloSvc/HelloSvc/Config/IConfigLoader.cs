using System;

namespace HelloSvc.Config
{
	internal interface IConfigLoader
	{
		IConfigSettings LoadConfig();
	}
}

