using System.Threading.Tasks;

namespace AnyStatus.API
{
    public interface IStop<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}