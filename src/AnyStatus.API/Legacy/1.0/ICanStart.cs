using System;

namespace AnyStatus.API
{
    [Obsolete("Use IStartable instead.")]
    public interface ICanStart : ITask
    {
        bool CanStart();
    }
}