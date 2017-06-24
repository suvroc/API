using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API
{
    [Serializable]
    [CategoryOrder("General", 1)]
    [XmlInclude(typeof(Folder))]
    [XmlInclude(typeof(RootItem))]
    public class Plugin : Item
    {
        private Plugin _parent;
        private ObservableCollection<Plugin> _items;

        public Plugin() : base()
        {
            //todo: set only if is folder
            Items = new ObservableCollection<Plugin>();
        }

        #region Properties

        [Browsable(false)]
        public ObservableCollection<Plugin> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }

        [XmlIgnore]
        [Browsable(false)]
        public Plugin Parent
        {
            get { return _parent; }
            set { _parent = value; OnPropertyChanged(); }
        }

        #endregion

        #region Methods

        public virtual void Add(Plugin item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (Items == null)
                Items = new ObservableCollection<Plugin>();

            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();

            item.Parent = this;

            Items.Add(item);

            IsExpanded = true;
        }


        public static bool IsNullOrError(object obj)
        {
            return obj == null || !(obj is Plugin item) || item.State == State.Error;
        }


        public override object Clone()
        {
            var clone = base.Clone();

            if (clone is Plugin && Items == null || !Items.Any())
                return clone;

            foreach (var child in Items.Where(item => item != null))
                ((Plugin)clone).Add((Plugin)child.Clone());

            return clone;
        }

        #endregion
    }
}
