using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RuleEngine.Tests
{
    [TestClass]
    public class StandAloneTests
    {
        [TestMethod]
        public void Unit_StandAlone_Minor()
        {
            var _ruleEngine = new Engine();
            var telemetry = new Telemetry { FridgeType = "StandAlone", value = 36 };

            var result = _ruleEngine.ProcessRules(telemetry);

            Assert.IsInstanceOfType(result, typeof(ContosoTask));
            Assert.AreEqual(Severity.Minor, result.SeverityLevel);
        }

        [TestMethod]
        public void Unit_StandAlone_Major()
        {
            var _ruleEngine = new Engine();
            var telemetry = new Telemetry { FridgeType = "StandAlone", value = 38 };

            var result = _ruleEngine.ProcessRules(telemetry);

            Assert.IsInstanceOfType(result, typeof(ContosoTask));
            Assert.AreEqual(Severity.Major, result.SeverityLevel);
        }

        [TestMethod]
        public void Unit_StandAlone_Critical()
        {
            var _ruleEngine = new Engine();
            var telemetry = new Telemetry { FridgeType = "StandAlone", value = 40 };

            var result = _ruleEngine.ProcessRules(telemetry);

            Assert.IsInstanceOfType(result, typeof(ContosoWorkorder));
            Assert.AreEqual(Severity.Critical, result.SeverityLevel);
        }

        [TestMethod]
        public void Unit_StandAlone_Terminal()
        {
            var _ruleEngine = new Engine();
            var telemetry = new Telemetry { FridgeType = "StandAlone", value = 42 };

            var result = _ruleEngine.ProcessRules(telemetry);

            Assert.IsInstanceOfType(result, typeof(ContosoWorkorder));
            Assert.AreEqual(Severity.Terminal, result.SeverityLevel);
        }

        [TestMethod]
        public void Unit_StandAlone_No_Event()
        {
            var _ruleEngine = new Engine();
            var telemetry = new Telemetry { FridgeType = "StandAlone", value = 30 };

            var result = _ruleEngine.ProcessRules(telemetry);

            Assert.IsNull(result);
        }
    }
}
