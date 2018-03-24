using System.Diagnostics.CodeAnalysis;

namespace AnyStatus.API
{
    /// <summary>
    /// Default notification factory.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class NotificationFactory
    {
        public static Notification Create(Widget widget)
        {
            if (widget.State == State.Ok)
                return new Notification($"{widget.Name} is OK", NotificationIcon.Info);

            if (widget.State == State.Failed)
                return new Notification($"{widget.Name} failed", NotificationIcon.Error);

            if (widget.State == State.Error)
                return new Notification($"{widget.Name} has one or more errors", NotificationIcon.Error);

            if (widget.State == State.PartiallySucceeded)
                return new Notification($"{widget.Name} partially succeeded", NotificationIcon.Warning);

            if (widget.State == State.Running)
                return new Notification($"{widget.Name} is running", NotificationIcon.Info);

            if (widget.State == State.Queued)
                return new Notification($"{widget.Name} has been queued", NotificationIcon.Info);

            if (widget.State == State.Canceled)
                return new Notification($"{widget.Name} has been cancelled", NotificationIcon.Info);

            if (widget.State == State.Unknown)
                return new Notification($"{widget.Name} status is unknown", NotificationIcon.Warning);

            return Notification.Empty;
        }
    }
}