using System.ComponentModel;
using System.Xml.Serialization;

namespace AnyStatus.API.Demo
{
    public class WidgetDemo : Widget
    {
        [DisplayName("My Property")]
        [Category("My Category")]
        public string MyProperty { get; set; }

        [XmlIgnore] //ignore when saving.
        [Browsable(false)] //hide from user.
        public string MyHiddenProperty { get; set; }
    }
}