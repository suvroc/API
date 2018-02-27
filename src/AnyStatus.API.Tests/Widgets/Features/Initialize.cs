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

            var response = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotNull(response);
        }

        class Initializer : IInitialize<TestWidget>
        {
            public Task<InitializeResponse> Handle(InitializeRequest<TestWidget> request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new InitializeResponse());
            }
        }
    }
}
