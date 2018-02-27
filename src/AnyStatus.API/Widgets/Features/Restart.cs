namespace AnyStatus.API
{
    public interface IRestartable
    {
    }

    public interface IRestart<T> : IRequestHandler<RestartRequest<T>, RestartResponse> where T : IRestartable
    {
    }

    public class RestartRequest
    {
        public static RestartRequest<T> Create<T>(T context) where T : IRestartable
        {
            return new RestartRequest<T>(context);
        }
    }

    public class RestartRequest<T> : Request<T, RestartResponse> where T : IRestartable
    {
        public RestartRequest(T context) : base(context) { }
    }

    public class RestartResponse
    {
    }
}
