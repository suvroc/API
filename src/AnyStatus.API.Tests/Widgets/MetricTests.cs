using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.API.Tests.Widgets
{
    [TestClass]
    public class MetricTests
    {
        [TestMethod]
        public void SimpleMetricTest()
        {
            var metric = new MetricTest
            {
                Value = 1,
                Symbol = "$"
            };

            Assert.AreEqual(1, metric.Value);
            Assert.AreEqual("$", metric.Symbol);
        }

        private class MetricTest : Metric
        {

        }
    }
}
