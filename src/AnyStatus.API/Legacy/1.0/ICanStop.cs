using System;

namespace AnyStatus.API
{
    [Obsolete("Use IStoppable instead.")]
    public interface ICanStop : ITask
    {
        bool CanStop();
    }
}