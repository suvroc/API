using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.API.Tests.Widgets.Features
{
    [TestClass]
    public class HealthCheckTests
    {
        [TestMethod]
        public async Task API_HealthCheckTest()
        {
            var widget = new TestWidget();
            var handler = new CheckHealth();
            var request = HealthCheckRequest.Create(widget);

            await handler.Handle(request, CancellationToken.None);
        }

        class CheckHealth : ICheckHealth<TestWidget>
        {
            public Task Handle(HealthCheckRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
