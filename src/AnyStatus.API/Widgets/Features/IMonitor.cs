namespace AnyStatus.API
{
    public interface IMonitor<in T> : IHandler
    {
        void Handle(T item);
    }
}
