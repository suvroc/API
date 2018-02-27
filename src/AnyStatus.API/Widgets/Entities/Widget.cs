namespace AnyStatus.API
{
    /// <summary>
    /// Base widget class.
    /// </summary>
    public abstract class Widget : Item
    {
        protected Widget() : base(aggregate: false)
        {
        }

        protected Widget(bool aggregate) : base(aggregate)
        {
        }

        public virtual Notification CreateNotification()
        {
            return NotificationFactory.Create(this);
        }
    }
}