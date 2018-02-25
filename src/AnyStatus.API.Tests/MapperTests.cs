using AnyStatus.API.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class MapperTests
    {
        [TestMethod]
        public void MapTo_Should_CopyObjectProperties()
        {
            var source = new Source
            {
                Prop1 = 1,
                Prop2 = 2,
                Prop3 = 3,
                Prop4 = string.Empty
            };

            var target = new Target
            {
                Prop1 = 0,
                Prop2 = 0,
                Prop3 = string.Empty,
                Prop4 = 4
            };

            source.MapTo(target);

            Assert.AreEqual(source.Prop1, target.Prop1);
            Assert.AreEqual(source.Prop2, target.Prop2);
            Assert.AreNotEqual(source.Prop3, target.Prop3);
            Assert.AreNotEqual(source.Prop4, target.Prop4);
        }

        private class Source
        {
            public int Prop1 { get; set; }
            public int Prop2 { get; set; }
            public int Prop3 { get; set; }
            public string Prop4 { get; set; }
        }

        private class Target
        {
            public int Prop1 { get; set; }
            public int Prop2 { get; set; }
            public string Prop3 { get; set; }
            public int Prop4 { get; set; }

        }
    }
}
