using System;
using System.Threading;

namespace HelloSvc
{
	public class GreetServiceWorker : IGreetServiceWorker
	{
		protected virtual IGreeter Greeter
		{
			get;
			private set;
		}
		
		public GreetServiceWorker(IGreeter greeter)
		{
			Greeter = greeter.ThrowIfNull("greeter");
		}
		
		protected virtual Boolean Running
		{
			get;
			set;
		}
		
		public virtual Boolean Paused
		{
			get;
			protected set;
		}
		
		protected virtual Timer GreeterTimer
		{
			get;
			private set;
		}
		
		protected virtual void TimerPulse(Object state)
		{
			if (!Paused && !Running)
			{
				Running = true;
				
				try
				{
					Greeter.SayHello();
				}
				finally
				{
					Running = false;
				}
			}
		}
		
		protected virtual Int32 IntervalMilliseconds
		{
			get { return 5000; }
		}
		
		public virtual Boolean Started
		{
			get { return GreeterTimer != null; }
		}
		
		public virtual void Start()
		{
			if (GreeterTimer == null)
			{
				GreeterTimer =
					new Timer(
						TimerPulse,
						null,
						IntervalMilliseconds,
						IntervalMilliseconds);
			}
		}
		
		public virtual void Pause()	
		{
			Paused = true;
			GreeterTimer.Change(Timeout.Infinite, Timeout.Infinite);
		}
		
		public virtual void Continue()	
		{
			Paused = false;
			GreeterTimer.Change(IntervalMilliseconds, IntervalMilliseconds);
		}
		
		public virtual void Stop()	
		{
			GreeterTimer.Change(Timeout.Infinite, Timeout.Infinite);
			
			var waitHandle = new AutoResetEvent(false);
			
			GreeterTimer.Dispose(waitHandle);
			
			waitHandle.WaitOne();
			
			GreeterTimer = null;
		}
	}
}

