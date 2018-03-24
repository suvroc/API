using System;
using System.Threading.Tasks;

namespace AnyStatus.API.Legacy
{
    [Obsolete("Use IRestart instead.")]
    public interface IRestart<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}