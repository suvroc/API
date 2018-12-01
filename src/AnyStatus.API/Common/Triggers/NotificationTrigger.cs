using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [ExcludeFromCodeCoverage]
    [DisplayName("Notification")]
    public class NotificationTrigger : StateTrigger
    {
        [PropertyOrder(10)]
        [DisplayName("Notification Message")]
        public string Message { get; set; }

        [PropertyOrder(11)]
        [DisplayName("Notification Icon")]
        public NotificationIcon Icon { get; set; }
    }
}
