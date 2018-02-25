using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.API.Tests.Widgets.Features
{
    [TestClass]
    public class MetricValueTests
    {
        [TestMethod]
        public async Task API_MetricValueTest()
        {
            var context = new CPU();
            var handler = new CPUQuery();
            var request = new MetricValueRequest<CPU>(context);

            var response = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Value);
            Assert.AreEqual("OK", response.Message);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        class CPU : Metric
        {
        }

        class CPUQuery : IMetricQuery<CPU>
        {
            public Task<MetricValueResponse> Handle(MetricValueRequest<CPU> request, CancellationToken cancellationToken)
            {
                var response = new MetricValueResponse
                {
                    Status = Status.Ok,
                    Message = "OK",
                    Value = 1
                };

                return Task.FromResult(response);
            }
        }
    }
}
