using System;
using System.Threading.Tasks;

namespace AnyStatus.API.Legacy
{
    [Obsolete("Use IStart instead.")]
    public interface IStart<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}