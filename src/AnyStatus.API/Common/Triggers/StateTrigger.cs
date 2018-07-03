using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    public abstract class StateTrigger
    {
        [PropertyOrder(2)]
        [Category("Trigger")]
        [DisplayName("Transition From")]
        [Editor(typeof(StateEditor), typeof(StateEditor))]
        public int TransitionFromState { get; set; }

        [PropertyOrder(3)]
        [Category("Trigger")]
        [DisplayName("Transition To")]
        [Editor(typeof(StateEditor), typeof(StateEditor))]
        public int TransitionToState { get; set; }
    }
}
