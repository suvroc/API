namespace AnyStatus.API
{
    public class WidgetRemoved
    {
        public WidgetRemoved(Item item)
        {
            Item = item;
        }

        public Item Item { get; private set; }
    }
}