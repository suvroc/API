using System.Threading.Tasks;

namespace AnyStatus.API
{
    public interface ITriggerBuild<in T> : IHandler
    {
        Task HandleAsync(T item);
    }
}
