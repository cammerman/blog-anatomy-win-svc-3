using System;

namespace HelloSvc.SettingsProviders
{
	internal class ConfigWorkIntervalProvider
	{
		public Int32 IntervalSeconds
		{
			get;
			private set;
		}
		
		public ConfigWorkIntervalProvider(Config.IConfigSettings settings)
		{
			IntervalSeconds = settings.WorkIntervalSeconds;
		}
	}
}

