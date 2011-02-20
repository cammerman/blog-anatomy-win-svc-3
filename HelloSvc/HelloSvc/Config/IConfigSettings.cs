using System;

namespace HelloSvc.Config
{
	internal interface IConfigSettings
	{
		String GreetingFileName { get; }
		Int32 WorkIntervalSeconds { get; }
	}
}

