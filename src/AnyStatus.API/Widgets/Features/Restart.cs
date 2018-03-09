namespace AnyStatus.API
{
    public interface IRestartable : IContextAction
    {
    }

    public interface IRestart<T> : IRequestHandler<RestartRequest<T>> where T : IRestartable
    {
    }

    public class RestartRequest<T> : Request<T> where T : IRestartable
    {
        public RestartRequest(T context) : base(context) { }
    }

    public class RestartRequest
    {
        public static RestartRequest<T> Create<T>(T context) where T : IRestartable
        {
            return new RestartRequest<T>(context);
        }
    }
}
