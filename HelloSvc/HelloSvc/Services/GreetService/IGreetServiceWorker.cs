using System;
namespace HelloSvc
{
	internal interface IGreetServiceWorker
	{
		Boolean Started { get; }
		Boolean Paused { get; }
		
		void Start();
		void Pause();
		void Continue();
		void Stop();
	}
}

