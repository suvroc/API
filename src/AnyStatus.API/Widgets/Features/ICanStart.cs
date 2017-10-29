namespace AnyStatus.API
{
    public interface ICanStart : ITask
    {
        bool CanStart();
    }
}
