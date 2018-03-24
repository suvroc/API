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

            await handler.Handle(request, CancellationToken.None);

            Assert.AreEqual(1, widget.Value);
        }

        class MetricQuery : IMetricQuery<TestWidget>
        {
            public Task Handle(MetricQueryRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                request.DataContext.Value = 1;

                return Task.CompletedTask;
            }
        }
    }
}
