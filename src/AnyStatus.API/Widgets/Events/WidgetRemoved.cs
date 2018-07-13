namespace AnyStatus.API
{
    public class WidgetRemoved
    {
        public WidgetRemoved(Widget widget)
        {
            Widget = widget;
        }

        public Widget Widget { get; }
    }
}