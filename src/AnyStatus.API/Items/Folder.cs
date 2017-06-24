using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace AnyStatus.API
{
    [Browsable(false)]
    public class Folder : Item
    {
        private int _count;

        public Folder() : this(aggregateState: true) { }

        public Folder(bool aggregateState)
        {
            if (aggregateState)
                Items.CollectionChanged += Items_CollectionChanged;
        }

        /// <summary>
        /// The number of child items with same state
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        [Browsable(false)]
        public new int Interval { get; set; }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Unsubscribe(e.OldItems);

            Subscribe(e.NewItems);

            AggregateState();
        }

        private void Subscribe(IList items)
        {
            if (items == null)
                return;

            foreach (INotifyPropertyChanged item in items)
                item.PropertyChanged += Item_PropertyChanged;
        }

        private void Unsubscribe(IList items)
        {
            if (items == null)
                return;

            foreach (INotifyPropertyChanged item in items)
                item.PropertyChanged -= Item_PropertyChanged;
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(State)))
                AggregateState();
        }

        public void AggregateState()
        {
            State = Items != null && Items.Any() ?
                        Items.Aggregate(ByPriority).State :
                            State.None;

            Count = (State == State.None || State == State.Disabled || State == State.Ok) ? 0 : CountItems(Items, State);
        }

        private static int CountItems(IEnumerable<Item> items, State state)
        {
            int count = 0;

            foreach (var item in items)
            {
                if (item.Items != null && item.Items.Any())
                {
                    count += CountItems(item.Items, state);
                }
                else if (item.State == state)
                {
                    count++;
                }
            }

            return count;
        }

        private static Item ByPriority(Item a, Item b)
        {
            return a.State.Metadata.Priority > b.State.Metadata.Priority ? a : b;
        }
    }
}
