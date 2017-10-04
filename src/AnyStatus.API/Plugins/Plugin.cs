namespace AnyStatus.API
{
    /// <summary>
    /// Base plugin class.
    /// </summary>
    public abstract class Plugin : Item
    {
        public Plugin() : base(aggregate: false) { }

        protected Plugin(bool aggregate) : base(aggregate) { }
    }
}
