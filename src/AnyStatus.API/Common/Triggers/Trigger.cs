using System.ComponentModel;
using System.Xml.Serialization;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [XmlInclude(typeof(CmdTrigger))]
    [XmlInclude(typeof(NotificationTrigger))]
    public abstract class Trigger
    {
        [PropertyOrder(1)]
        [Category("Trigger")]
        public string Name { get; set; }
    }
}
