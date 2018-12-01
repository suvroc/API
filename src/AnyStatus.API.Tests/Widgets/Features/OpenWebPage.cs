using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
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
            var processStarter = Substitute.For<IProcessStarter>();

            const string URL = "https://test-url.com";

            var widget = new TestWidget
            {
                URL = URL
            };

            var handler = new OpenWebPage<TestWidget>(processStarter);
            var request = OpenWebPageRequest.Create(widget);
            
            await handler.Handle(request, CancellationToken.None);

            processStarter.Received().Start(URL);
        }

        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public async Task API_OpenWebPageTest2()
        {
            var processStarter = Substitute.For<IProcessStarter>();

            const string url = "invalid-uri";

            var widget = new TestWidget
            {
                URL = url
            };

            var handler = new OpenWebPage<TestWidget>(processStarter);
            var request = OpenWebPageRequest.Create(widget);
            
            await handler.Handle(request, CancellationToken.None);
        }
    }
}
