using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.API.Tests.HealthCheck
{
    [TestClass]
    public class HealthCheckTests
    {
        [TestMethod]
        public async Task API_HealthCheckTest()
        {
            var ping = new Ping();
            var healthChecker = new PingHealthChecker();
            var healthCheckRequest = new HealthCheckRequest<Ping>(ping);

            var response = await healthChecker.Handle(healthCheckRequest, CancellationToken.None);

            Assert.IsNotNull(response);
            Assert.AreEqual("OK", response.Message);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        class Ping : Widget, IHealthCheck
        {
        }

        class PingHealthChecker : IHealthChecker<Ping>
        {
            public Task<HealthCheckResponse> Handle(HealthCheckRequest<Ping> request, CancellationToken cancellationToken)
            {
                var response = new HealthCheckResponse
                {
                    Status = Status.Ok,
                    Message = "OK"
                };

                return Task.FromResult(response);
            }
        }
    }
}
