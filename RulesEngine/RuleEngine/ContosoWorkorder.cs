using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine
{
    public class ContosoWorkorder : IEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Severity? SeverityLevel { get; set; }
        public Telemetry Telemetry { get; set; }
        public DateTime Created { get; set; }
        public static IEvent GenerateWorkorder(Telemetry telemetry, Severity? severity)
        {
            return new ContosoWorkorder { Name = "RuleWorkorder", SeverityLevel = severity, Telemetry = telemetry, Created = DateTime.UtcNow };
        }
    }
}
