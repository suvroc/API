using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void IsNotificationEmptyTest()
        {
            var notification = new Notification();

            Assert.IsFalse(notification.IsEmpty());

            notification = Notification.Empty;

            Assert.IsTrue(notification.IsEmpty());
        }
    }
}
