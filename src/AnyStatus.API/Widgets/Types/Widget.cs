using AnyStatus.API.Triggers;
using AnyStatus.API.Utils;
using System;
using System.Collections.Generic;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API
{
    /// <summary>
    /// Base widget class.
    /// </summary>
    public abstract class Widget : Item
    {
        protected Widget() : this(false) { }

        protected Widget(bool aggregate) : base(aggregate) { }

        [NewItemTypes(typeof(CmdTrigger), typeof(NotificationTrigger))]
        public List<Trigger> Triggers { get; set; }

        [Obsolete("Replace with visitor.")]
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