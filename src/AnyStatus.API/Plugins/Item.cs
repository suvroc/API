using PubSub;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API
{
    /// <summary>
    /// Base tree-view node object.
    /// Plugins should not directly inherit this class.
    /// Please use the "Plugin" class instead.
    /// </summary>
    [Serializable]
    [CategoryOrder("General", 1)]
    public abstract class Item : NotifyPropertyChanged, IValidatable, ICloneable, IDisposable
    {
        #region Fields

        private readonly bool _aggregate;

        private bool _disposed = false;

        private string _name;
        private int _count;
        private int _interval;
        private bool _isExpanded;
        private bool _isEnabled;
        private bool _isEditing;
        private bool _isSelected;
        private bool _showNotifications;
        private Item _parent;
        private ObservableCollection<Item> _items;

        [NonSerialized]
        private State _state;

        [NonSerialized]
        private State _previousState;

        #endregion

        #region Ctor

        protected Item(bool aggregate) : this()
        {
            _aggregate = aggregate;

            Items = new ObservableCollection<Item>();

            if (_aggregate) Items.CollectionChanged += OnCollectionChanged;
        }

        public Item()
        {
            Interval = 5;
            IsEnabled = true;
            IsExpanded = false;
            State = State.None;
            ShowNotifications = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The number of child nodes with the same state
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public int Count
        {
            get { return _count; }
            private set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        [Browsable(false)]
        public Guid Id { get; set; }

        [Browsable(false)]
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }

        [XmlIgnore]
        [Browsable(false)]
        public Item Parent
        {
            get { return _parent; }
            set { _parent = value; OnPropertyChanged(); }
        }

        [Required]
        [Category("General")]
        [PropertyOrder(0)]
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        [Required]
        [PropertyOrder(1)]
        [Category("General")]
        [Range(0, ushort.MaxValue, ErrorMessage = "Interval must be between 0 and 65535")]
        [Description("The monitor interval in minutes. Use 0 to bypass.")]
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; OnPropertyChanged(); }
        }

        [PropertyOrder(2)]
        [Category("General")]
        [DisplayName("Show Notifications")]
        [Description("Check to show notifications when the status change.")]
        public bool ShowNotifications
        {
            get { return _showNotifications; }
            set { _showNotifications = value; OnPropertyChanged(); }
        }

        [XmlIgnore]
        [Browsable(false)]
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { _isExpanded = value; OnPropertyChanged(); }
        }

        [XmlIgnore]
        [Browsable(false)]
        public State State
        {
            get { return _state; }
            set
            {
                _previousState = _state;
                _state = value;
                OnPropertyChanged();
            }
        }

        [XmlIgnore]
        [Browsable(false)]
        public State PreviousState
        {
            get { return _previousState; }
        }

        [Browsable(false)]
        [DisplayName("Enabled")]
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;

                OnPropertyChanged();

                if (_isEnabled == false)
                    State = State.Disabled;
            }
        }

        [Browsable(false)]
        [ExcludeFromCodeCoverage]
        public bool IsDisabled
        {
            get { return !_isEnabled; }
        }

        [XmlIgnore]
        [Browsable(false)]
        public bool IsEditing
        {
            get { return _isEditing; }
            set { _isEditing = value; OnPropertyChanged(); }
        }

        [XmlIgnore]
        [Browsable(false)]
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; OnPropertyChanged(); }
        }

        [XmlIgnore]
        [Browsable(false)]
        public bool NotificationIsRequired
        {
            get
            {
                return ShowNotifications &&
                       PreviousState != null &&
                       PreviousState != State &&
                       PreviousState != State.None;
            }
        }

        #endregion

        #region Helpers

        public virtual Notification CreateNotification()
        {
            return NotificationFactory.Create(this);
        }

        public static bool IsNullOrError(object obj)
        {
            return obj == null || !(obj is Item item) || item.State == State.Error;
        }

        public virtual void Add(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (Items == null)
                Items = new ObservableCollection<Item>();

            Items.Add(item);

            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            item.Parent = this;

            IsExpanded = true;

            this.Publish(new ItemAdded(item));
        }

        public virtual void Remove(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (Items == null) return;

            Items.Remove(item);

            this.Publish(new ItemRemoved(item));
        }

        public void Clear()
        {
            Items?.Clear();
        }

        public bool Contains(Item item)
        {
            return Items != null && Items.Contains(item);
        }

        #endregion

        #region IValidatable

        public bool IsValid()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);

            return Validator.TryValidateObject(this, context, null/*, true*/);
        }

        #endregion

        #region ICloneable

        public virtual object Clone()
        {
            var type = GetType();

            var clone = (Item)Activator.CreateInstance(type);

            type.GetProperties()
                .Where(p => p.CanWrite && p.Name != nameof(Parent) && p.Name != nameof(Items))
                .ToList()
                .ForEach(p => p.SetValue(clone, p.GetValue(this, null), null));

            if (Items != null && Items.Any())
                foreach (var childNode in Items.Where(i => i != null))
                    clone.Add(childNode.Clone() as Item);

            return clone;
        }

        #endregion

        #region Aggregate

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            try
            {
                Unsubscribe(args.OldItems);

                Subscribe(args.NewItems);

                Aggregate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Subscribe(IList childNodes)
        {
            if (childNodes == null) return;

            foreach (Item childNode in childNodes)
            {
                childNode.PropertyChanged += OnChildPropertyChanged;
            }
        }

        private void Unsubscribe(IList childNodes)
        {
            if (childNodes == null) return;

            foreach (Item childNode in childNodes)
            {
                childNode.PropertyChanged -= OnChildPropertyChanged;
            }
        }

        private void OnChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e != null && e.PropertyName == nameof(State)) Aggregate();
        }

        private void Aggregate()
        {
            State = Items != null && Items.Any() ?
                    Items.Aggregate(ByPriority).State :
                    State.None;

            Count = State == State.None || State == State.Disabled || State == State.Ok ?
                    0 :
                    CountChildrenByState(Items, State);

            Item ByPriority(Item a, Item b)
            {
                return a.State.Metadata.Priority > b.State.Metadata.Priority ? a : b;
            }

            int CountChildrenByState(IEnumerable<Item> items, State state)
            {
                int count = 0;

                foreach (var item in items)
                {
                    if (item.Items != null && item.Items.Any())
                    {
                        count += CountChildrenByState(item.Items, state);
                    }
                    else if (item.State == state)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (_aggregate) Items.CollectionChanged -= OnCollectionChanged;

            _disposed = true;
        }

        #endregion
    }
}
