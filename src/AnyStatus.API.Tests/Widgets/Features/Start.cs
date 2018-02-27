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

            var response = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotNull(response);
        }

        internal class Start : IStart<TestWidget>
        {
            public Task<StartResponse> Handle(StartRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new StartResponse());
            }
        }
    }
}
