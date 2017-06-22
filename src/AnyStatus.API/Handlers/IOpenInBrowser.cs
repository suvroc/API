namespace AnyStatus.API
{
    public interface IOpenInBrowser<in T> : IHandler
    {
        void Handle(T item);
    }
}