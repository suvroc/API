namespace AnyStatus.API
{
    public class ItemAdded
    {
        public ItemAdded(Item item)
        {
            Item = item;
        }

        public Item Item { get; private set; }
    }
}