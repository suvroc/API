namespace AnyStatus.API
{
    public abstract class Build : Plugin
    {
        public override Notification CreateNotification()
        {
            if (State == State.Ok)
                return new Notification($"{Name} succeeded", NotificationIcon.Info);

            if (State == State.Running)
                return new Notification($"{Name} started", NotificationIcon.Info);

            return base.CreateNotification();
        }
    }
}
