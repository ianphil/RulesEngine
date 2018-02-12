using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RuleEngine.Tests
{
    [TestClass]
    public class CokeFridgeTests
    {
        [TestMethod]
        public void Unit_CokeFridge_Minor()
        {
            var _ruleEngine = new Engine();
            var telemetry = new Telemetry { FridgeType = "CokeFridge", value = 36 };

            var result = _ruleEngine.ProcessRules(telemetry);

            Assert.IsInstanceOfType(result, typeof(ContosoTask));
            Assert.AreEqual(Severity.Minor, result.SeverityLevel);
        }

        [TestMethod]
        public void Unit_CokeFridge_Major()
        {
            var _ruleEngine = new Engine();
            var telemetry = new Telemetry { FridgeType = "CokeFridge", value = 38 };

            var result = _ruleEngine.ProcessRules(telemetry);

            Assert.IsInstanceOfType(result, typeof(ContosoTask));
            Assert.AreEqual(Severity.Major, result.SeverityLevel);
        }

        [TestMethod]
        public void Unit_CokeFridge_Critical()
        {
            var _ruleEngine = new Engine();
            var telemetry = new Telemetry { FridgeType = "CokeFridge", value = 40 };

            var result = _ruleEngine.ProcessRules(telemetry);

            Assert.IsInstanceOfType(result, typeof(ContosoWorkorder));
            Assert.AreEqual(Severity.Critical, result.SeverityLevel);
        }

        [TestMethod]
        public void Unit_CokeFridge_Terminal()
        {
            var _ruleEngine = new Engine();
            var telemetry = new Telemetry { FridgeType = "CokeFridge", value = 42 };

            var result = _ruleEngine.ProcessRules(telemetry);

            Assert.IsInstanceOfType(result, typeof(ContosoWorkorder));
            Assert.AreEqual(Severity.Terminal, result.SeverityLevel);
        }

        [TestMethod]
        public void Unit_CokeFridge_No_Event()
        {
            var _ruleEngine = new Engine();
            var telemetry = new Telemetry { FridgeType = "CokeFridge", value = 30 };

            var result = _ruleEngine.ProcessRules(telemetry);

            Assert.IsNull(result);
        }
    }
}
