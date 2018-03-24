using System;

namespace AnyStatus.API
{
    [Obsolete("Use IRestartable instead.")]
    public interface ICanRestart : ITask
    {
        bool CanRestart();
    }
}