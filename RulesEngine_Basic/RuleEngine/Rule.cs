using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine
{
    public class Rule : IRule
    {
        private readonly Func<Telemetry, Severity?, IEvent> _eventGenerator;

        public Rule(string name, int threshold, Severity severityLevel, Func<Telemetry, Severity?, IEvent> eventGenerator)
        {
            Name = name;
            Threshold = threshold;
            SeverityLevel = severityLevel;
            _eventGenerator = eventGenerator;
        }

        public int Id {get; set;}
        public string Name {get; set;}
        public int Threshold {get; set;}
        public int WindowOfTime {get; set;}
        public Severity? SeverityLevel {get; set;}

        public bool isMatch(Telemetry telemetry)
        {
            return (telemetry.FridgeType == Name && telemetry.value >= Threshold) ? true : false;
        }

        public IEvent CalculateEvent(Telemetry telemetry)
        {
            return _eventGenerator(telemetry, SeverityLevel);
        }
    }


}
