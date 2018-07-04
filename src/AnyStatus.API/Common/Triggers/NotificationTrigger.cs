using System.ComponentModel;

namespace AnyStatus.API.Triggers
{
    [DisplayName("Notification")]
    public class NotificationTrigger : StateTrigger, IRequest
    {
        [Category("Notification")]
        public string Message { get; set; }

        [Category("Notification")]
        public NotificationIcon Icon { get; set; }
    }
}
