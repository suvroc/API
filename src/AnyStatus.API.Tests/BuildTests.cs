using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class BuildTests
    {
        [TestMethod]
        public void CreateNotificationForBuilds()
        {
            var build = new BuildTest();

            var notification = build.CreateNotification();

            Assert.IsNotNull(notification);
        }
    }

    class BuildTest : Build
    {
    }
}
