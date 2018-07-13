using AnyStatus.API.Triggers;
using AnyStatus.API.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API
{
    /// <summary>
    /// Widget base class.
    /// </summary>
    public abstract class Widget : Item
    {
        private const string StatePropertyName = nameof(State);

        protected Widget() : this(aggregate: false) { }

        protected Widget(bool aggregate) : base(aggregate)
        {
            PropertyChanged += OnPropertyChanged;
        }

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == StatePropertyName && State != PreviousState && Triggers?.Any() == true)
                this.Publish(new WidgetStateChanged(this, PreviousState, State));
        }

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