namespace AnyStatus.API
{
    public interface ICanStop : ITask
    {
        bool CanStop();
    }
}
