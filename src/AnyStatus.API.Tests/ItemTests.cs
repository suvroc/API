using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AnyStatus.API.Tests
{
    class TestItem : Item
    {

    }

    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void Clone_Should_CreateNewObject()
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
        public void Clone_Should_CloneChildItems()
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
    }
}
