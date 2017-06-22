using System.Threading.Tasks;

namespace AnyStatus.API
{
    public interface IStartWindowsService<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}
