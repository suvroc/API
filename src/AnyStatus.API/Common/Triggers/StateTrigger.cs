using System.ComponentModel;
using System.Xml.Serialization;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.API.Triggers
{
    public abstract class StateTrigger : Trigger
    {
        [PropertyOrder(0)]
        [DisplayName("Transition From")]
        [Editor(typeof(StateEditor), typeof(StateEditor))]
        public int TransitionFromState { get; set; }

        [PropertyOrder(1)]
        [DisplayName("Transition To")]
        [Editor(typeof(StateEditor), typeof(StateEditor))]
        public int TransitionToState { get; set; }

        /// <summary>
        /// Holds the actual new state.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public State NewState { get; set; }

        /// <summary>
        /// Holds the actual old state.
        /// </summary>
        [XmlIgnore]
        [Browsable(false)]
        public State OldState { get; set; }
    }
}
