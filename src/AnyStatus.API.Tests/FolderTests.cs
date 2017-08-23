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
    }
}
