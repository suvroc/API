using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AnyStatus.API
{
    public class RootItem : Folder, IXmlSerializable
    {
        public RootItem() : base(aggregateState: false) { }

        public static Type[] ExtraTypes { get; set; }

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.Name != nameof(RootItem))
                return;

            try
            {
                var serializer = new XmlSerializer(typeof(SerializationHelper), ExtraTypes);

                var helper = (SerializationHelper)serializer.Deserialize(reader);

                Items = helper.Items;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while loading items. See inner exception.", ex);
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Item>), new XmlAttributeOverrides(), ExtraTypes, new XmlRootAttribute("Items"), null);

                serializer.Serialize(writer, Items);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while saving items. See inner exception.", ex);
            }
        }

        #endregion
    }

    [Browsable(false)]
    [XmlType(TypeName = "RootItem")]
    [XmlRoot(ElementName = "RootItem")]
    public class SerializationHelper : Item
    {
    }
}
