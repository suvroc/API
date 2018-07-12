namespace AnyStatus.API
{
    public class WidgetStateChanged
    {
        public WidgetStateChanged(Widget widget, State oldState, State newState)
        {
            Widget = widget;
            OldState = oldState;
            NewState = newState;
        }

        public Widget Widget { get; }

        public State OldState { get; }

        public State NewState { get; }
    }
}