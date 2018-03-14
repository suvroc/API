using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public class Folder : Widget
    {
        public Folder() : base(aggregate: true) { }

        public Folder(bool aggregate) : base(aggregate) { }

        [XmlIgnore]
        [Browsable(false)]
        public new int Interval { get; set; } = 0;

        [XmlIgnore]
        [Browsable(false)]
        public new bool ShowNotifications { get; set; } = false;
    }
}