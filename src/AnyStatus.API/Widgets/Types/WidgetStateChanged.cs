namespace AnyStatus.API
{
    public class WidgetStateChanged
    {
        public WidgetStateChanged(Widget widget)
        {
            Widget = widget;
        }

        public Widget Widget { get; private set; }
    }
}