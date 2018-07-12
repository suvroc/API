using System.ComponentModel;
using System.Xml.Serialization;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [XmlInclude(typeof(CmdTrigger))]
    [XmlInclude(typeof(NotificationTrigger))]
    public abstract class Trigger : IRequest<TriggerResult>
    {
        [PropertyOrder(0)]
        public string Name { get; set; }
    }
}
