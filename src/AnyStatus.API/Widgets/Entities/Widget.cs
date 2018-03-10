using PubSub;

namespace AnyStatus.API
{
    /// <summary>
    /// Base widget class.
    /// </summary>
    public abstract class Widget : Item
    {
        protected Widget() : base(aggregator: false)
        {
        }

        protected Widget(bool aggregate) : base(aggregate)
        {
        }

        public virtual Notification CreateNotification()
        {
            return NotificationFactory.Create(this);
        }

        public override void Add(Item item)
        {
            base.Add(item);

            this.Publish(new WidgetAdded((Widget)item));
        }

        public override void Remove(Item item)
        {
            base.Remove(item);

            this.Publish(new WidgetRemoved((Widget)item));
        }
    }
}