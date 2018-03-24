using System;

namespace AnyStatus.API
{
    [Obsolete("Use IHealthChecker instead.")]
    public interface IMonitor<in T> : IHandler
    {
        void Handle(T item);
    }
}