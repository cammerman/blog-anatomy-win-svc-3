using System;

namespace HelloSvc.SettingsProviders
{
	internal interface IEventLogConfigProvider
	{
		String LogName { get; }
		String SourceName { get; }
	}
}

