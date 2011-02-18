using System;
using System.IO;

namespace HelloSvc
{
	public class Greeter : IGreeter
	{
		public Greeter ()
		{
		}
	
		public void SayHello()
		{
			using (var helloStream = new FileStream(@"C:\Hello\World.txt", FileMode.Create, FileAccess.Write, FileShare.Read));
		}
	}
}

