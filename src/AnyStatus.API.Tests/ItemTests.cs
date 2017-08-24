using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void IsEnabled_Should_ChangeState()
        {
            var item = new TestItem()
            {
                IsEnabled = true,
                State = State.Ok
            };

            item.IsEnabled = false;

            Assert.AreEqual(State.Disabled, item.State);
        }

        [TestMethod]
        public void Add_Should()
        {
            var folder = new Folder();
            var item = new TestItem();

            folder.Add(item);

            Assert.IsTrue(folder.Contains(item));
            Assert.AreSame(folder, item.Parent);
            Assert.AreNotEqual(Guid.Empty, item.Id);
        }

        [TestMethod]
        public void NotificationIsRequired_When_ShowNotifications_Is_True()
        {
            var item = new TestItem
            {
                ShowNotifications = false,
                State = State.Ok
            };

            item.State = State.Error;

            Assert.IsFalse(item.NotificationIsRequired);

            item.ShowNotifications = true;

            Assert.IsTrue(item.NotificationIsRequired);
        }

        [TestMethod]
        public void NotificationIsRequired_When_PreviousState_IsNotNullOrNone()
        {
            var item = new TestItem
            {
                ShowNotifications = true,
            };

            Assert.IsFalse(item.NotificationIsRequired);

            item.State = State.Ok;

            Assert.IsFalse(item.NotificationIsRequired);

            item.State = State.Error;

            Assert.IsTrue(item.NotificationIsRequired);
        }

        [TestMethod]
        public void NotificationIsRequired_When_PreviousState_Changed()
        {
            var item = new TestItem
            {
                ShowNotifications = true,
                State = State.Ok
            };

            item.State = item.State;

            Assert.IsFalse(item.NotificationIsRequired);

            item.State = State.Error;

            Assert.IsTrue(item.NotificationIsRequired);
        }

        [TestMethod]
        public void PreviousState()
        {
            var item = new TestItem
            {
                State = State.Ok
            };

            item.State = State.Error;

            Assert.AreEqual(State.Ok, item.PreviousState);

            item.State = State.Ok;

            Assert.AreEqual(State.Error, item.PreviousState);
        }

        [TestMethod]
        public void DefaultState_Is_None()
        {
            var folder = new Folder();
            var subFolder = new Folder();
            var plugin = new TestItem();

            folder.Add(subFolder);
            subFolder.Add(plugin);

            Assert.AreEqual(State.None, plugin.State);
            Assert.AreEqual(State.None, folder.State);
            Assert.AreEqual(State.None, subFolder.State);
        }

        [TestMethod]
        public void Should_CreateNewObjects_When_Cloning()
        {
            var item = new TestItem
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString()
            };

            var copy = (Item)item.Clone();

            Assert.AreNotSame(copy, item);
            Assert.AreNotSame(copy.Items, item.Items);

            Assert.AreEqual(item.Id, copy.Id);
            Assert.AreEqual(item.Name, copy.Name);

            Assert.IsNull(copy.Parent);
        }

        [TestMethod]
        public void Should_IncludeChildren_When_Cloning()
        {
            var item = new TestItem
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString()
            };

            item.Items.Add(new TestItem());

            var copy = (Item)item.Clone();

            Assert.IsNotNull(copy.Items);

            Assert.AreNotSame(copy.Items, item.Items);

            Assert.IsTrue(copy.Items.Count == 1);

            Assert.AreNotSame(copy.Items.First(), item.Items.First());
        }

        [TestMethod]
        public void CreateNotification_Should_ReturnNewNotification()
        {
            var item = new TestItem();

            var notification = item.CreateNotification();

            Assert.IsNotNull(notification);
        }
    }
}
