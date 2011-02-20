using System;
using System.IO;

namespace HelloSvc
{
	using Logging;
	
	internal class Greeter : IGreeter
	{
		protected virtual String FileName
		{
			get;
			private set;
		}
		
		protected virtual ILogger Logger
		{
			get;
			private set;
		}
		
		public Greeter(SettingsProviders.IGreetingFileName fileNameProvider, ILogger logger)
		{
			FileName = fileNameProvider.FileName;
			Logger = logger.ThrowIfNull("logger");
		}
		
		protected virtual String FilePath()
		{
			return
				Path.Combine(
					@"C:\Hello",
					FileName);
		}
		
		protected virtual FileStream CreateFile()
		{
			return
				new FileStream(
					FilePath(),
					FileMode.Create,
					FileAccess.Write,
					FileShare.Read);
		}
	
		public void SayHello()
		{
			Logger.Message("Greeting the world.");
			
			try
			{
				using (var helloStream = CreateFile());
			}
			catch (Exception ex)
			{
				Logger.ExceptionAlone(ex);
			}
		}
	}
}

