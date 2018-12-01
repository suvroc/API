using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [ExcludeFromCodeCoverage]
    [XmlInclude(typeof(CommandTrigger))]
    [XmlInclude(typeof(BatchScriptTrigger))]
    [XmlInclude(typeof(NotificationTrigger))]
    public abstract class Trigger : IRequest
    {
        [PropertyOrder(0)]
        public bool Enabled { get; set; } = true;
    }
}
