namespace AnyStatus.API
{
    public abstract class Build : Plugin
    {
        public override Notification CreateNotification()
        {
            if (State == State.Ok)
                return new Notification($"{Name} completed successfully", NotificationIcon.Info);

            if (State == State.PartiallySucceeded)
                return new Notification($"{Name} partially succeeded", NotificationIcon.Warning);

            if (State == State.Running)
                return new Notification($"{Name} started", NotificationIcon.Info);

            if (State == State.Queued)
                return new Notification($"{Name} has been queued", NotificationIcon.Info);

            if (State == State.Canceled)
                return new Notification($"{Name} has been cancelled", NotificationIcon.Info);

            return base.CreateNotification();
        }
    }
}
