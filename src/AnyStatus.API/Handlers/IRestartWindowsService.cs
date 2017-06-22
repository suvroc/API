using System.Threading.Tasks;

namespace AnyStatus.API
{
    public interface IRestartWindowsService<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}
