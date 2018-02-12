using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine
{
    public class Engine
    {
        List<IRule> _rulesList = new List<IRule>();

        public Engine()
        {
            _rulesList.Add(new CokeFridge(36, Severity.Minor, ContosoTask.GenerateTask));
            _rulesList.Add(new CokeFridge(38, Severity.Major, ContosoTask.GenerateTask));
            _rulesList.Add(new CokeFridge(40, Severity.Critical, ContosoWorkorder.GenerateWorkorder));
            _rulesList.Add(new CokeFridge(42, Severity.Terminal, ContosoWorkorder.GenerateWorkorder));
        }

        public IEvent ProcessRules(Telemetry telemetry)
        {
            List<IEvent> eventsList = new List<IEvent>();

            foreach( var rule in _rulesList)
            {
                if (rule.isMatch(telemetry))
                {
                    var result = rule.CalculateEvent(telemetry);

                    if (result != null)
                        eventsList.Add(result);
                }
            }

            if (eventsList.Count > 0)
                return eventsList.Aggregate((i1, i2) => i1.SeverityLevel > i2.SeverityLevel ? i1 : i2);
            else
                return null;
        }
    }
}
