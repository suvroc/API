using Microsoft.VisualStudio.TestTools.UnitTesting;
using PubSub;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class WidgetTests
    {
        [TestMethod]
        public void Assert_That_DefaultStateIsNone()
        {
            var widget = new WidgetMock();

            AssertStateIsNone(widget);
        }

        [TestMethod]
        public void Assert_That_State_Is_Disabled_When_Disabled()
        {
            var widget = new WidgetMock
            {
                IsEnabled = true,
                State = State.Ok
            };

            widget.IsEnabled = false;

            Assert.AreEqual(State.Disabled, widget.State);
        }

        [TestMethod]
        public void Assert_That_WidgetAddedEvent_Is_Fired_When_ChildAdded()
        {
            var eventFired = false;

            this.Subscribe<WidgetAdded>(e => { eventFired = true; });

            var parent = new WidgetMock();
            var child = new WidgetMock();

            parent.Add(child);

            Assert.IsTrue(eventFired);
        }

        [TestMethod]
        public void Assert_Parent_Child_Relationship_When_AddingNodes()
        {
            var parent = new WidgetMock();
            var child = new WidgetMock();

            parent.Add(child);

            Assert.IsTrue(parent.Contains(child));
            Assert.AreSame(parent, child.Parent);
            Assert.AreNotEqual(Guid.Empty, child.Id);
        }

        [TestMethod]
        public void Assert_That_Id_Is_Not_Empty_When_AddingNodes()
        {
            var parent = new WidgetMock();
            var child = new WidgetMock();

            parent.Add(child);

            Assert.AreNotEqual(Guid.Empty, child.Id);
        }

        [TestMethod]
        public void Assert_That_Nodes_Are_Cleared()
        {
            var parent = new WidgetMock();
            var child = new WidgetMock();

            parent.Add(child);

            Assert.IsTrue(parent.Items.Contains(child));

            parent.Clear();

            Assert.IsFalse(parent.Items.Any());
        }

        [TestMethod]
        public void Assert_That_State_Bubbles_Up()
        {
            var grandParent = new Folder();
            var parent = new Folder();
            var widget = new WidgetMock();

            grandParent.Add(parent);
            parent.Add(widget);

            widget.State = State.Ok;

            Assert.AreEqual(State.Ok, widget.State);
            Assert.AreEqual(State.Ok, parent.State);
            Assert.AreEqual(State.Ok, grandParent.State);
        }

        [TestMethod]
        public void Assert_That_State_Bubbles_Up_By_Priority()
        {
            var grandParent = new Folder();
            var parent = new Folder();
            var widget1 = new WidgetMock();
            var widget2 = new WidgetMock();

            grandParent.Add(parent);
            parent.Add(widget1);
            parent.Add(widget2);

            widget1.State = State.Ok;
            widget2.State = State.None;

            Assert.AreEqual(State.Ok, widget1.State);
            Assert.AreEqual(State.None, widget2.State);
            Assert.AreEqual(State.Ok, parent.State);
            Assert.AreEqual(State.Ok, grandParent.State);
            Assert.AreEqual(0, grandParent.Count);

            widget2.State = State.Error;

            Assert.AreEqual(State.Ok, widget1.State);
            Assert.AreEqual(State.Error, widget2.State);
            Assert.AreEqual(State.Error, parent.State);
            Assert.AreEqual(State.Error, grandParent.State);
            Assert.AreEqual(1, grandParent.Count);

            widget1.State = State.Error;

            Assert.AreEqual(2, grandParent.Count);

            widget1.State = State.Ok;
            widget2.State = State.None;

            Assert.AreEqual(State.Ok, widget1.State);
            Assert.AreEqual(State.None, widget2.State);
            Assert.AreEqual(State.Ok, parent.State);
            Assert.AreEqual(State.Ok, grandParent.State);
            Assert.AreEqual(0, grandParent.Count);
        }

        [TestMethod]
        public void Assert_That_Child_Is_Removed()
        {
            var parent = new WidgetMock();
            var child = new WidgetMock();

            parent.Add(child);

            Assert.IsTrue(parent.Contains(child));

            parent.Remove(child);

            Assert.IsFalse(parent.Contains(child));
        }

        [TestMethod]
        public void NotificationIsRequired_When_ShowNotifications_Is_True()
        {
            var item = new WidgetMock
            {
                ShowNotifications = false,
                State = State.Ok
            };

            item.State = State.Error;

            Assert.IsFalse(item.IsNotificationRequired());

            item.ShowNotifications = true;

            Assert.IsTrue(item.IsNotificationRequired());
        }

        [TestMethod]
        public void NotificationIsRequired_When_PreviousState_IsNotNullOrNone()
        {
            var item = new WidgetMock
            {
                ShowNotifications = true,
            };

            Assert.IsFalse(item.IsNotificationRequired());

            item.State = State.Ok;

            Assert.IsFalse(item.IsNotificationRequired());

            item.State = State.Error;

            Assert.IsTrue(item.IsNotificationRequired());
        }

        [TestMethod]
        public void NotificationIsRequired_When_PreviousState_Changed()
        {
            var item = new WidgetMock
            {
                ShowNotifications = true,
                State = State.Ok
            };

            item.State = item.State;

            Assert.IsFalse(item.IsNotificationRequired());

            item.State = State.Error;

            Assert.IsTrue(item.IsNotificationRequired());
        }

        [TestMethod]
        public void NotificationIsRequired_When_ShowErrorNotifications_And_State_Is_Error()
        {
            var widget = new WidgetMock
            {
                ShowNotifications = true,
                ShowErrorNotifications = true,
                State = State.Ok
            };

            widget.State = State.Error;

            Assert.IsTrue(widget.IsNotificationRequired());

            widget.State = State.Ok;

            Assert.IsTrue(widget.IsNotificationRequired());
        }

        [TestMethod]
        public void NotificationNotIsRequired_When_ShowErrorNotificationsFalse_And_State_Is_Error()
        {
            var widget = new WidgetMock
            {
                ShowNotifications = true,
                ShowErrorNotifications = false,
                State = State.Ok
            };

            widget.State = State.Error;

            Assert.IsFalse(widget.IsNotificationRequired());

            widget.State = State.Ok;

            Assert.IsFalse(widget.IsNotificationRequired());
        }

        [TestMethod]
        public void PreviousState()
        {
            var item = new WidgetMock
            {
                State = State.Ok
            };

            item.State = State.Error;

            Assert.AreEqual(State.Ok, item.PreviousState);

            item.State = State.Ok;

            Assert.AreEqual(State.Error, item.PreviousState);
        }

        [TestMethod]
        public void Default_State_Is_None_When_Adding()
        {
            var folder = new Folder();
            var subFolder = new Folder();
            var plugin = new WidgetMock();

            folder.Add(subFolder);
            subFolder.Add(plugin);

            Assert.AreEqual(State.None, plugin.State);
            Assert.AreEqual(State.None, folder.State);
            Assert.AreEqual(State.None, subFolder.State);
        }

        [TestMethod]
        public void Should_CreateNewObjects_When_Cloning()
        {
            var item = new WidgetMock
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Items = new ObservableCollection<Item>()
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
            var item = new WidgetMock
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Items = new ObservableCollection<Item>()
            };

            item.Items.Add(new WidgetMock());

            var copy = (Item)item.Clone();

            Assert.IsNotNull(copy.Items);

            Assert.AreNotSame(copy.Items, item.Items);

            Assert.IsTrue(copy.Items.Count == 1);

            Assert.AreNotSame(copy.Items.First(), item.Items.First());
        }

        [TestMethod]
        public void CreateNotification_Should_ReturnNewNotification()
        {
            var item = new WidgetMock
            {
                State = State.Ok
            };

            var notification = item.CreateNotification();

            Assert.IsNotNull(notification);
            Assert.AreNotEqual(Notification.Empty, notification);
        }

        #region Helpers

        public void AssertStateIsNone(Item item)
        {
            Assert.IsNotNull(item.State);

            Assert.AreEqual(State.None, item.State);
        }

        #endregion Helpers
    }
}