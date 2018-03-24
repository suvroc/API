namespace AnyStatus.API
{
    public abstract class Request<TContext, TResponse> : IRequest<TResponse>
    {
        /// <summary>
        /// A general-purpose object for representing a request. 
        /// </summary>
        public Request() { }

        public Request(TContext context)
        {
            DataContext = context;
        }

        public TContext DataContext { get; protected set; }
    }

    public abstract class Request<TContext> : Request<TContext, Unit>, IRequest
    {
        /// <summary>
        /// A general-purpose object for representing a request. 
        /// </summary>
        public Request() : base() { }

        public Request(TContext context) : base(context) { }
    }
}
