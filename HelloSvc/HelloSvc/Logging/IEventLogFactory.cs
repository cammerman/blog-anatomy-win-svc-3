using System;
using System.Diagnostics;

namespace HelloSvc.Logging
{
	internal interface IEventLogFactory
	{
		EventLog Create();
	}
}

