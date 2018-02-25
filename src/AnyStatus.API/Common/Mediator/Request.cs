namespace AnyStatus.API
{
    public abstract class Request<TContext, TResponse> : IRequest<TResponse>
    {
        public Request()
        {
        }

        public Request(TContext context)
        {
            DataContext = context;
        }

        public TContext DataContext { get; protected set; }
    }
}
