using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    [DisplayName("Notification")]
    public class NotificationTrigger : StateTrigger, IRequest<TriggerResult>
    {
        [PropertyOrder(0)]
        [Category("Notification")]
        public string Message { get; set; }

        [PropertyOrder(1)]
        [Category("Notification")]
        public NotificationIcon Icon { get; set; }
    }
}
