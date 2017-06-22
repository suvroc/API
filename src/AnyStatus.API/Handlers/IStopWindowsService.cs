using System.Threading.Tasks;

namespace AnyStatus.API
{
    public interface IStopWindowsService<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}
