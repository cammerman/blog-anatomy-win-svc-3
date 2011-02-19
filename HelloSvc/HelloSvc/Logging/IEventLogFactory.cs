using System;
using System.Diagnostics;

namespace HelloSvc.Logging
{
	public interface IEventLogFactory
	{
		EventLog Create();
	}
}

