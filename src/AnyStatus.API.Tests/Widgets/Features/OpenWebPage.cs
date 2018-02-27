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

            var response = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotNull(response);
        }

        class OpenWebPage : IOpenWebPage<TestWidget>
        {
            public Task<OpenWebPageResponse> Handle(OpenWebPageRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new OpenWebPageResponse());
            }
        }
    }
}
