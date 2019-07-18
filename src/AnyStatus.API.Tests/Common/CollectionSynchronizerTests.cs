using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AnyStatus.API.Tests.Common
{
    [TestClass]
    public class CollectionSynchronizerTests
    {
        private class MyClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private readonly CollectionSynchronizer<MyClass, MyClass> _synchronizer;

        private readonly List<MyClass> _sourceList = new List<MyClass>
            {
                new MyClass { Id = 1, Name  = "Existing Item Name 2" },
                new MyClass { Id = 2, Name  = "New Item" },
            };

        private readonly List<MyClass> _destinationList = new List<MyClass>
            {
                new MyClass { Id = 0, Name = "Removed Item" },
                new MyClass { Id = 1, Name = "Existing Item Name 1" }
            };

        public CollectionSynchronizerTests()
        {
            _synchronizer = new CollectionSynchronizer<MyClass, MyClass>
            {
                Compare = (x, y) => x.Id == y.Id,
                Add = (x) => _destinationList.Add(x),
                Remove = (x) => _destinationList.Remove(x),
                Update = (x, y) => y.Name = x.Name,
            };
        }

        [TestMethod]
        public void CollectionSynchronizer_Should_UpdateExistingItems()
        {
            _synchronizer.Synchronize(_sourceList, _destinationList);

            Assert.AreEqual("Existing Item Name 2", _destinationList[0].Name);
        }

        [TestMethod]
        public void CollectionSynchronizer_Should_AddNewItems()
        {
            _synchronizer.Synchronize(_sourceList, _destinationList);

            Assert.AreEqual(2, _destinationList[1].Id);
        }

        [TestMethod]
        public void CollectionSynchronizer_Should_RemoveItems()
        {
            _synchronizer.Synchronize(_sourceList, _destinationList);

            Assert.IsNull(_destinationList.FirstOrDefault(k => k.Id == 0));
        }
    }
}
