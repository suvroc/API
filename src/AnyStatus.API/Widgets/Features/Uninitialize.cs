namespace AnyStatus.API
{
    public interface IUninitializable
    {
    }

    public interface IUninitialize<T> : IRequestHandler<UninitializeRequest<T>> where T : IUninitializable
    {
    }

    public class UninitializeRequest<T> : Request<T> where T : IUninitializable
    {
        public UninitializeRequest(T context) : base(context) { }
    }

    public static class UninitializeRequest
    {
        public static UninitializeRequest<T> Create<T>(T context) where T : IUninitializable
        {
            return new UninitializeRequest<T>(context);
        }
    }
}
