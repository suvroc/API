using System;

namespace AnyStatus.API
{
    [Obsolete("Use IBuildable instead.")]
    public interface ICanTriggerBuild : ITask
    {
        bool CanTriggerBuild();
    }
}