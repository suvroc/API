using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.API.Tests.Widgets.Features
{
    [TestClass]
    public class StopTests
    {
        [TestMethod]
        public async Task API_StopTest()
        {
            var widget = new TestWidget();
            var handler = new Stop();
            var request = StopRequest.Create(widget);

            var response = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotNull(response);
        }

        internal class Stop : IStop<TestWidget>
        {
            public Task<StopResponse> Handle(StopRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new StopResponse());
            }
        }
    }
}
