using System.ComponentModel;

namespace AnyStatus.API
{
    public class Folder : Item
    {
        public Folder() : base(aggregateState: true) { }

        protected Folder(bool aggregateState) : base(aggregateState: true) { }

        [Browsable(false)]
        public new int Interval { get; set; }

        [Browsable(false)]
        public new bool ShowNotifications { get; set; }
    }
}
