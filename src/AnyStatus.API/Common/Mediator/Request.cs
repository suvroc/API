using System.ComponentModel.DataAnnotations;

namespace AnyStatus.API
{
    public abstract class Request<TContext, TResponse> : IRequest<TResponse>
    {
        /// <summary>
        /// A general-purpose object for representing a request. 
        /// </summary>
        public Request()
        {
        }

        public Request(TContext context)
        {
            DataContext = context;
        }

        public TContext DataContext { get; protected set; }
    }

    public abstract class Request<TContext> : Request<TContext, Unit>
    {
        /// <summary>
        /// A general-purpose object for representing a request. 
        /// </summary>
        public Request()
        {
        }

        public Request(TContext context)
        {
            DataContext = context;
        }

        [Required]
        public TContext DataContext { get; protected set; }
    }
}
