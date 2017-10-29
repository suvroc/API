namespace AnyStatus.API
{
    public interface ICanTriggerBuild : ITask
    {
        bool CanTriggerBuild();
    }
}
