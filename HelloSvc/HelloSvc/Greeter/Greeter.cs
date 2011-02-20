using System;
using System.IO;

namespace HelloSvc
{
	using Logging;
	
	internal class Greeter : IGreeter
	{
		protected virtual ILogger Logger
		{
			get;
			private set;
		}
		
		public Greeter(ILogger logger)
		{
			Logger = logger.ThrowIfNull("logger");
		}
	
		public void SayHello()
		{
			Logger.Message("Greeting the world.");
			
			try
			{
				using (var helloStream = new FileStream(@"C:\Hello\World.txt", FileMode.Create, FileAccess.Write, FileShare.Read));
			}
			catch (Exception ex)
			{
				Logger.ExceptionAlone(ex);
			}
		}
	}
}

