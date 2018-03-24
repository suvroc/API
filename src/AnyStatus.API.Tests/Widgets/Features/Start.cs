using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.API.Tests.Widgets.Features
{
    [TestClass]
    public class StartTests
    {
        [TestMethod]
        public async Task API_StartTest()
        {
            var widget = new TestWidget();
            var handler = new Start();
            var request = StartRequest.Create(widget);

            await handler.Handle(request, CancellationToken.None);
        }

        class Start : IStart<TestWidget>
        {
            public Task Handle(StartRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
