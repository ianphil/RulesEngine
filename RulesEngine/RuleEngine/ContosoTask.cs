using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine
{
    public class ContosoTask : IEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Severity? SeverityLevel { get; set; }
        public Telemetry Telemetry { get; set; }
        public DateTime Created { get; set; }

        public static IEvent GenerateTask(Telemetry telemetry, Severity? severity)
        {
            return new ContosoTask { Name = "CokeFridgeTask", SeverityLevel = severity, Telemetry = telemetry, Created = DateTime.UtcNow };
        }
    }
}
