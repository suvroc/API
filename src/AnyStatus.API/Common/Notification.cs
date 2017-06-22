namespace AnyStatus.API
{
    public enum NotificationIcon
    {
        None = 0,
        Info = 1,
        Warning = 2,
        Error = 3
    }

    public class Notification
    {
        public static Notification Empty = new Notification();

        public Notification()
        {
        }

        public Notification(string message, NotificationIcon icon)
        {
            Message = message;
            Icon = icon;
        }

        public string Message { get; set; }

        public NotificationIcon Icon { get; set; }

        public bool IsEmpty()
        {
            return this == Empty;
        }
    }
}
