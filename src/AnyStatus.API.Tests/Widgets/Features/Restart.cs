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

            var response = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotNull(response);
        }

        class Restart : IRestart<TestWidget>
        {
            public Task<RestartResponse> Handle(RestartRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new RestartResponse());
            }
        }
    }
}
