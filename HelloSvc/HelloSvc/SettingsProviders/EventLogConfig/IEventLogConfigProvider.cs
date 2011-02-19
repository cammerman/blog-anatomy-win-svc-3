using System;
namespace HelloSvc
{
	public interface IEventLogConfigProvider
	{
		String LogName { get; }
		String SourceName { get; }
	}
}

