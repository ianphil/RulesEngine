using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine
{
    public interface IEvent
    {
        int Id { get; set; }
        string Name { get; set; }
        Severity? SeverityLevel { get; set; }
        Telemetry Telemetry { get; set; }
        DateTime Created { get; set; }
    }
}
