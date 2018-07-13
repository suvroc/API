using System.Xml.Serialization;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [XmlInclude(typeof(CommandTrigger))]
    [XmlInclude(typeof(NotificationTrigger))]
    public abstract class Trigger : IRequest
    {
        [PropertyOrder(0)]
        public bool Enabled { get; set; } = true;
    }
}
