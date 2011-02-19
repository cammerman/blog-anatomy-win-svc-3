using System;

namespace HelloSvc.SettingsProviders
{
	public interface IEventLogConfigProvider
	{
		String LogName { get; }
		String SourceName { get; }
	}
}

