using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void Clone_Should_Create_A_New_Object()
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString()
            };

            var copy = (Item)item.Clone();

            Assert.AreNotSame(copy, item);

            Assert.AreEqual(item.Id, copy.Id);
            Assert.AreEqual(item.Name, copy.Name);

            Assert.IsNull(copy.Parent);
            Assert.IsNull(copy.Items);
        }
    }
}
