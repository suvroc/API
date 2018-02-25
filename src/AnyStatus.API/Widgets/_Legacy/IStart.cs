using System.Threading.Tasks;

namespace AnyStatus.API
{
    public interface IStart<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}