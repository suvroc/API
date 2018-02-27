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

            var response = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotNull(response);
            Assert.AreEqual("OK", response.Message);
            Assert.AreEqual(State.Ok, response.State);
        }

        class CheckHealth : ICheckHealth<TestWidget>
        {
            public Task<HealthCheckResponse> Handle(HealthCheckRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                var response = new HealthCheckResponse
                {
                    State = State.Ok,
                    Message = "OK"
                };

                return Task.FromResult(response);
            }
        }
    }
}
