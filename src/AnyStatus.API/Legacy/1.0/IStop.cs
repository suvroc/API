using System;
using System.Threading.Tasks;

namespace AnyStatus.API.Legacy
{
    [Obsolete("Use IStop instead.")]
    public interface IStop<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}