using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.API.Tests.Widgets.Features
{
    [TestClass]
    public class UninitializeTests
    {
        [TestMethod]
        public async Task API_UninitializeTest()
        {
            var widget = new TestWidget();
            var handler = new Uninitializer();
            var request = UninitializeRequest.Create(widget);

            await handler.Handle(request, CancellationToken.None);
        }

        class Uninitializer : IUninitialize<TestWidget>
        {
            public Task Handle(UninitializeRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
