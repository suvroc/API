using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    public abstract class Item : NotifyPropertyChanged, IValidatable, ICloneable
    {
        #region Fields

        private string _name;
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

        public Item()
        {
            ShowNotifications = true;
            IsEnabled = true;
            IsExpanded = false;
            Interval = 5;
            State = State.None;
            Items = new ObservableCollection<Item>(); //todo: set only if is folder
        }

        #endregion

        #region Properties

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
                    State = State.Disabled; //todo: this is an issue since Item does not control its own state.
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
            if (State == State.Ok)
                return new Notification($"{Name} is OK", NotificationIcon.Info);

            if (State == State.Failed)
                return new Notification($"{Name} has failed", NotificationIcon.Error);

            if (State == State.Error)
                return new Notification($"{Name} has one or more errors", NotificationIcon.Error);

            if (State == State.PartiallySucceeded)
                return new Notification($"{Name} partially succeeded", NotificationIcon.Warning);

            if (State == State.Running)
                return new Notification($"{Name} is running", NotificationIcon.Info);

            if (State == State.Queued)
                return new Notification($"{Name} has been queued", NotificationIcon.Info);

            if (State == State.Canceled)
                return new Notification($"{Name} has been cancelled", NotificationIcon.Info);

            if (State == State.Unknown)
                return new Notification($"{Name} status is unknown", NotificationIcon.Warning);

            return Notification.Empty;
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

#warning Make sure Item.Id is not duplicated when cloning

        private static string[] CloneExcludes = new[] { /* nameof(Id), */ nameof(Parent), nameof(Items) };

        public virtual object Clone()
        {
            var type = GetType();

            var clone = (Item)Activator.CreateInstance(type);

            type.GetProperties()
                .Where(p => p.CanWrite && !CloneExcludes.Contains(p.Name))
                .ToList()
                .ForEach(p => p.SetValue(clone, p.GetValue(this, null), null));

            if (Items != null && Items.Any())
                foreach (var item in Items)
                    if (item != null)
                        clone.Add((Item)item.Clone());

            return clone;
        }

        #endregion
    }
}
