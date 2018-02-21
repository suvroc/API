using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var notification = new Notification();

            Assert.IsFalse(notification.IsEmpty());

            notification = Notification.Empty;

            Assert.IsTrue(notification.IsEmpty());
        }
    }
}
