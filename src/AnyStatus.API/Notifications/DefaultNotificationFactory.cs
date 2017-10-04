using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    [ExcludeFromCodeCoverage]
    public static class NotificationFactory
    {
        public static Notification Create(Item item)
        {
            if (item.State == State.Ok)
                return new Notification($"{item.Name} is OK", NotificationIcon.Info);

            if (item.State == State.Failed)
                return new Notification($"{item.Name} has failed", NotificationIcon.Error);

            if (item.State == State.Error)
                return new Notification($"{item.Name} has one or more errors", NotificationIcon.Error);

            if (item.State == State.PartiallySucceeded)
                return new Notification($"{item.Name} partially succeeded", NotificationIcon.Warning);

            if (item.State == State.Running)
                return new Notification($"{item.Name} is running", NotificationIcon.Info);

            if (item.State == State.Queued)
                return new Notification($"{item.Name} has been queued", NotificationIcon.Info);

            if (item.State == State.Canceled)
                return new Notification($"{item.Name} has been cancelled", NotificationIcon.Info);

            if (item.State == State.Unknown)
                return new Notification($"{item.Name} status is unknown", NotificationIcon.Warning);

            return Notification.Empty;
        }
    }
}