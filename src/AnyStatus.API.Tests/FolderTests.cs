using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class FolderTests
    {
        [TestMethod]
        public void Should_InvokeCollectionChangedEvent_When_AddingItems()
        {
            int counter = 0;

            var root = new Folder();

            root.CollectionChanged += (s, e) => counter++;

            var folder1 = new Folder();
            var folder2 = new Folder();
            var folder3 = new Folder();
            var item1 = new TestItem();
            var item2 = new TestItem();

            root.Add(folder1);

            Assert.AreEqual(1, counter);

            folder1.Add(folder2);

            Assert.AreEqual(2, counter);

            folder2.Add(item1);

            Assert.AreEqual(3, counter);

            folder2.Add(folder3);

            Assert.AreEqual(4, counter);

            folder3.Add(item2);

            Assert.AreEqual(5, counter);
        }

        [TestMethod]
        public void Should_InvokeCollectionChangedEvent_When_RemovingItems()
        {
            int counter = 0;

            var root = new Folder();

            root.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        counter++;
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        counter--;
                        break;
                    default:
                        break;
                }
            };

            var folder1 = new Folder();
            var folder2 = new Folder();
            var folder3 = new Folder();
            var item1 = new TestItem();
            var item2 = new TestItem();

            root.Add(folder1);
            folder1.Add(folder2);
            folder2.Add(item1);
            folder2.Add(folder3);
            folder3.Add(item2);

            Assert.AreEqual(5, counter);

            folder3.Remove(item2);

            Assert.AreEqual(4, counter);

            folder2.Remove(folder3);

            Assert.AreEqual(3, counter);
        }

        [TestMethod]
        public void Should_AggregateState_ByDefault()
        {
            var folder = new Folder();
            var subFolder = new Folder();
            var plugin = new TestItem();

            folder.Add(subFolder);
            subFolder.Add(plugin);

            plugin.State = State.Ok;

            Assert.AreEqual(State.Ok, plugin.State);
            Assert.AreEqual(State.Ok, subFolder.State);
            Assert.AreEqual(State.Ok, folder.State);
        }

        [TestMethod]
        public void Should_AggregateState_ByPriority()
        {
            var folder = new Folder();
            var subFolder = new Folder();
            var plugin1 = new TestItem();
            var plugin2 = new TestItem();

            folder.Add(subFolder);
            subFolder.Add(plugin1);
            subFolder.Add(plugin2);

            plugin1.State = State.Ok;
            plugin2.State = State.None;

            Assert.AreEqual(State.Ok, plugin1.State);
            Assert.AreEqual(State.None, plugin2.State);
            Assert.AreEqual(State.Ok, subFolder.State);
            Assert.AreEqual(State.Ok, folder.State);
            Assert.AreEqual(0, folder.Count);

            plugin2.State = State.Error;

            Assert.AreEqual(State.Ok, plugin1.State);
            Assert.AreEqual(State.Error, plugin2.State);
            Assert.AreEqual(State.Error, subFolder.State);
            Assert.AreEqual(State.Error, folder.State);
            Assert.AreEqual(1, folder.Count);

            plugin1.State = State.Error;

            Assert.AreEqual(2, folder.Count);

            plugin1.State = State.Ok;
            plugin2.State = State.None;

            Assert.AreEqual(State.Ok, plugin1.State);
            Assert.AreEqual(State.None, plugin2.State);
            Assert.AreEqual(State.Ok, subFolder.State);
            Assert.AreEqual(State.Ok, folder.State);
            Assert.AreEqual(0, folder.Count);
        }
    }
}
