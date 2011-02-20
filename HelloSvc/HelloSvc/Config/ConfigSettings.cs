using System;
using System.Xml.Serialization;

namespace HelloSvc.Config
{
	[XmlRoot("GreeterSettings")]
	public class ConfigSettings : IConfigSettings
	{
		public ConfigSettings ()
		{
		}
		
		[XmlAttribute]
		public String GreetingFileName
		{
			get;
			set;
		}
		
		[XmlAttribute]
		public Int32 WorkIntervalSeconds
		{
			get;
			set;
		}
	}
}

