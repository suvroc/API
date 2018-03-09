namespace AnyStatus.API
{
    public interface IStoppable : IContextAction
    {
    }

    public interface IStop<T> : IRequestHandler<StopRequest<T>> where T : IStoppable
    {
    }

    public class StopRequest<T> : Request<T> where T : IStoppable
    {
        public StopRequest(T context) : base(context) { }
    }

    public class StopRequest
    {
        public static StopRequest<T> Create<T>(T context) where T : IStoppable
        {
            return new StopRequest<T>(context);
        }
    }
}
