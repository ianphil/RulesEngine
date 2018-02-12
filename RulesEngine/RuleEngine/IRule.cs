using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine
{
    public interface IRule
    {
        int Id { get; set; }
        string Name { get; set; }
        int Threshold { get; set; }
        int WindowOfTime { get; set; }
        Severity? SeverityLevel { get; set; }
        bool isMatch(Telemetry telemetry);
        IEvent CalculateEvent(Telemetry telemetry);
    }

    public enum Severity
    {
        Minor,
        Major,
        Critical,
        Terminal
    }
}
