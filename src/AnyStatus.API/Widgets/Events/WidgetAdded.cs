namespace AnyStatus.API
{
    public class WidgetAdded
    {
        public WidgetAdded(Item item)
        {
            Item = item;
        }

        public Item Item { get; private set; }
    }
}