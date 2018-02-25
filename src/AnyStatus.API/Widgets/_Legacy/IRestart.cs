using System.Threading.Tasks;

namespace AnyStatus.API
{
    public interface IRestart<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}