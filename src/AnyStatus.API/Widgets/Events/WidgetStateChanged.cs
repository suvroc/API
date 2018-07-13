using System.ComponentModel.DataAnnotations;

namespace AnyStatus.API
{
    public class WidgetStateChanged : IRequest
    {
        public WidgetStateChanged(Widget widget, State oldState, State newState)
        {
            Widget = widget;
            OldState = oldState;
            NewState = newState;
        }

        [Required]
        public Widget Widget { get; }

        [Required]
        public State OldState { get; }

        [Required]
        public State NewState { get; }
    }
}