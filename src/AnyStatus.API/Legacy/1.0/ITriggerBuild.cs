using System;
using System.Threading.Tasks;

namespace AnyStatus.API.Legacy
{
    [Obsolete("Deprecated.")]
    public interface ITriggerBuild<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}