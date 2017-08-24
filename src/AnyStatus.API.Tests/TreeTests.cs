using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AnyStatus.API.Tests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void SerializeDeserializeTreeObject()
        {
            RootItem.ExtraTypes = new[] { typeof(Folder), typeof(TestItem) };

            var tree = new RootItem();
            var folder = new Folder();
            var item = new TestItem();

            tree.Add(folder);
            folder.Add(item);

            var sb = new StringBuilder();
            var serializer = new XmlSerializer(tree.GetType());

            using (var writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, tree);
            }

            var xml = sb.ToString();

            Assert.IsFalse(string.IsNullOrEmpty(xml), "Xml is null or empty after serializing tree object.");

            object obj;

            using (TextReader reader = new StringReader(xml))
            {
                obj = serializer.Deserialize(reader);
            }

            Assert.IsNotNull(obj);
        }
    }
}
