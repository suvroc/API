using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public sealed class Folder : Widget
    {
        public Folder(bool aggregate = true) : base(aggregate) { }

        [XmlIgnore]
        [Browsable(false)]
        public new int Interval { get; set; } = 0;

        [XmlIgnore]
        [Browsable(false)]
        public new bool ShowNotifications { get; set; } = false;
    }
}