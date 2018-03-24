using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.API.Tests.Widgets.Features
{
    [TestClass]
    public class InitializeTests
    {
        [TestMethod]
        public async Task API_InitializeTest()
        {
            var widget = new TestWidget();
            var handler = new Initializer();
            var request = InitializeRequest.Create(widget);

            await handler.Handle(request, CancellationToken.None);
        }

        class Initializer : IInitialize<TestWidget>
        {
            public Task Handle(InitializeRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
