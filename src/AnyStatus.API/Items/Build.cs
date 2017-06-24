namespace AnyStatus.API
{
    public abstract class Build : Plugin
    {
        public override Notification CreateNotification()
        {
            if (State == State.Ok)
                return new Notification($"Build {Name} completed", NotificationIcon.Info);

            if (State == State.PartiallySucceeded)
                return new Notification($"Build {Name} partially succeeded", NotificationIcon.Warning);

            if (State == State.Running)
                return new Notification($"Build {Name} started", NotificationIcon.Info);

            if (State == State.Queued)
                return new Notification($"Build {Name} is queued", NotificationIcon.Info);

            if (State == State.Canceled)
                return new Notification($"Build {Name} has been cancelled", NotificationIcon.Info);

            return base.CreateNotification();
        }
    }
}
