using System;

namespace HelloSvc.SettingsProviders
{
	internal class ConfigGreetingFileNameProvider : IGreetingFileName
	{
		public String FileName
		{
			get;
			private set;
		}
		
		public ConfigGreetingFileNameProvider (Config.IConfigSettings settings)
		{
			FileName = settings.GreetingFileName;
		}
	}
}

