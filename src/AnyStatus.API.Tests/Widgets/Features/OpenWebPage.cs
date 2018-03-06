using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.API.Tests.Widgets.Features
{
    [TestClass]
    public class OpenWebPageTests
    {
        [TestMethod]
        public async Task API_OpenWebPageTest()
        {
            var widget = new TestWidget();
            var handler = new OpenWebPage();
            var request = OpenWebPageRequest.Create(widget);

            await handler.Handle(request, CancellationToken.None);
        }

        class OpenWebPage : IOpenWebPage<TestWidget>
        {
            public Task Handle(OpenWebPageRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
