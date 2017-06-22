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
    public class Item : ItemBase
    {
        private Item _parent;
        private ObservableCollection<Item> _items;

        public Item() : base()
        {
            Items = new ObservableCollection<Item>(); //todo: set for root and folder items only.
        }

        #region Properties

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

        #endregion

        #region Methods

        public virtual void Add(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (Items == null)
                Items = new ObservableCollection<Item>();

            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();

            item.Parent = this;

            Items.Add(item);

            IsExpanded = true;
        }


        public static bool IsNullOrError(object obj)
        {
            return obj == null || !(obj is Item item) || item.State == State.Error;
        }


        public override object Clone()
        {
            var clone = base.Clone();

            if (clone is Item && Items == null || !Items.Any())
                return clone;

            foreach (var child in Items.Where(item => item != null))
                ((Item)clone).Add((Item)child.Clone());

            return clone;
        }

        #endregion
    }
}
