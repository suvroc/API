namespace AnyStatus.API
{
    public interface IHandler
    {
    }

    public interface IHandler<in T> : IHandler
    {
        void Handle(T item);
    }
}