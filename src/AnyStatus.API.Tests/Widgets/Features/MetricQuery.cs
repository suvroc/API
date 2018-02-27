using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.API.Tests.Widgets.Features
{
    [TestClass]
    public class MetricQueryTests
    {
        [TestMethod]
        public async Task API_MetricQueryTest()
        {
            var widget = new TestWidget();
            var handler = new MetricQuery();
            var request = MetricQueryRequest.Create(widget);

            var response = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Value);
        }

        class MetricQuery : IMetricQuery<TestWidget>
        {
            public Task<MetricQueryResponse> Handle(MetricQueryRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                var response = new MetricQueryResponse
                {
                    Value = 1
                };

                return Task.FromResult(response);
            }
        }
    }
}
