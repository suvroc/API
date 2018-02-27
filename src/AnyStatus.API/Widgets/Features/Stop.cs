namespace AnyStatus.API
{
    public interface IStoppable
    {
    }

    public interface IStop<T> : IRequestHandler<StopRequest<T>, StopResponse> where T : IStoppable
    {
    }

    public class StopRequest
    {
        public static StopRequest<T> Create<T>(T context) where T : IStoppable
        {
            return new StopRequest<T>(context);
        }
    }

    public class StopRequest<T> : Request<T, StopResponse> where T : IStoppable
    {
        public StopRequest(T context) : base(context) { }
    }

    public class StopResponse
    {
    }
}
