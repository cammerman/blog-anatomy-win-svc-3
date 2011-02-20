using System;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;

namespace HelloSvc.Config
{
	internal class ConfigLoader : IConfigLoader
	{
		public ConfigLoader()
		{
		}
		
		protected String ConfigFilePath()
		{
			return
				Path.Combine(
					Path.GetDirectoryName(
						Assembly.GetExecutingAssembly().Location),
					"settings.xml");
		}
		
		protected FileStream OpenConfigFile()
		{
			return
				new FileStream(
					ConfigFilePath(),
					FileMode.Open,
					FileAccess.Read,
					FileShare.Read);
		}
		
		public IConfigSettings LoadConfig ()
		{
			var settings = null as IConfigSettings;
			
			using (var fs = OpenConfigFile())
			{
				var xml = new XmlSerializer(typeof(ConfigSettings));
				settings = xml.Deserialize(fs) as ConfigSettings;
			}
			
			return settings;
		}
	}
}

