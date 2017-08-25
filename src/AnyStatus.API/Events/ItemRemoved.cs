namespace AnyStatus.API
{
    public class ItemRemoved
    {
        public ItemRemoved(Item item)
        {
            Item = item;
        }

        public Item Item { get; private set; }
    }
}