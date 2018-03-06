using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.API.Tests.Widgets.Features
{
    [TestClass]
    public class RestartTests
    {
        [TestMethod]
        public async Task API_RestartTest()
        {
            var widget = new TestWidget();
            var handler = new Restart();
            var request = RestartRequest.Create(widget);

            await handler.Handle(request, CancellationToken.None);
        }

        class Restart : IRestart<TestWidget>
        {
            public Task Handle(RestartRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
