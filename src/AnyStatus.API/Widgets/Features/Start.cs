namespace AnyStatus.API
{
    public interface IStartable : IContextAction
    {
    }

    public interface IStart<T> : IRequestHandler<StartRequest<T>> where T : IStartable
    {
    }

    public class StartRequest<T> : Request<T> where T : IStartable
    {
        public StartRequest(T context) : base(context) { }
    }

    public static class StartRequest
    {
        public static StartRequest<T> Create<T>(T context) where T : IStartable
        {
            return new StartRequest<T>(context);
        }
    }
}
