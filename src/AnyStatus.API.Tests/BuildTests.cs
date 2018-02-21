using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class BuildTests
    {
        [TestMethod]
        public void Should_CreateInfoNotification_When_StateChangeFromNoneToOk()
        {
            var build = new BuildTest
            {
                State = State.Ok
            };

            var notification = build.CreateNotification();

            AssertThatNotificationIsInfo(notification);
        }

        [TestMethod]
        public void Should_CreateInfoNotification_When_StateChangeFromQueuedToOk()
        {
            var build = new BuildTest
            {
                State = State.Queued
            };

            build.State = State.Ok;

            var notification = build.CreateNotification();

            Assert.IsNotNull(notification);
            Assert.AreEqual(NotificationIcon.Info, notification.Icon);
        }

        [TestMethod]
        public void Should_CreateInfoNotification_When_StateChangeFromRunningToOk()
        {
            var build = new BuildTest
            {
                State = State.Running
            };

            build.State = State.Ok;

            var notification = build.CreateNotification();

            AssertThatNotificationIsInfo(notification);
        }

        [TestMethod]
        public void Should_CreateInfoNotification_When_StateChangeFromQueuedToRunning()
        {
            var build = new BuildTest
            {
                State = State.Queued
            };

            build.State = State.Running;

            var notification = build.CreateNotification();

            AssertThatNotificationIsInfo(notification);
        }

        private static void AssertThatNotificationIsInfo(Notification notification)
        {
            Assert.IsNotNull(notification);
            Assert.AreEqual(NotificationIcon.Info, notification.Icon);
        }
    }

    internal class BuildTest : Build
    {
    }
}