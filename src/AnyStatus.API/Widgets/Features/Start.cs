namespace AnyStatus.API
{
    public interface IStartable
    {
    }

    public interface IStart<T> : IRequestHandler<StartRequest<T>, StartResponse> where T : IStartable
    {
    }

    public class StartRequest
    {
        public static StartRequest<T> Create<T>(T context) where T : IStartable
        {
            return new StartRequest<T>(context);
        }
    }

    public class StartRequest<T> : Request<T, StartResponse> where T : IStartable
    {
        public StartRequest(T context) : base(context) { }
    }

    public class StartResponse
    {
    }
}
