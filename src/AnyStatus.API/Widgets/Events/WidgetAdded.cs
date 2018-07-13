namespace AnyStatus.API
{
    public class WidgetAdded
    {
        public WidgetAdded(Widget widget)
        {
            Widget = widget;
        }

        public Widget Widget { get; }
    }
}