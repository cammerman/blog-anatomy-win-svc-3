using System;
namespace HelloSvc
{
	public interface IGreetServiceWorker
	{
		Boolean Started { get; }
		Boolean Paused { get; }
		
		void Start();
		void Pause();
		void Continue();
		void Stop();
	}
}

