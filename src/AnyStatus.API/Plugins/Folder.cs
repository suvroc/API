using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly bool _aggregateState;

        public Folder() : this(aggregateState: true)
        {
        }

        public Folder(bool aggregateState)
        {
            _aggregateState = aggregateState;

            Items = new ObservableCollection<Item>();

            Items.CollectionChanged += OnCollectionChanged;
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

        public void Clear()
        {
            Items?.Clear();
        }

        public bool Contains(Item item)
        {
            return Items != null && Items.Contains(item);
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (!_aggregateState) return;

            Unsubscribe(args.OldItems);

            Subscribe(args.NewItems);

            AggregateState();
        }

        private void Subscribe(IList items)
        {
            if (items == null) return;

            foreach (Item item in items)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Unsubscribe(IList items)
        {
            if (items == null) return;

            foreach (Item item in items)
            {
                item.PropertyChanged -= Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_aggregateState && e.PropertyName.Equals(nameof(State)))
                AggregateState();
        }

        private void AggregateState()
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
