namespace AnyStatus.API
{
    public interface IWebPage
    {
        string URL { get; }
    }

    public interface IOpenWebPage<T> : IRequestHandler<OpenWebPageRequest<T>> where T : IWebPage
    {
    }

    public class OpenWebPageRequest<T> : Request<T> where T : IWebPage
    {
        public OpenWebPageRequest(T context) : base(context) { }
    }

    public class OpenWebPageRequest
    {
        public static OpenWebPageRequest<T> Create<T>(T context) where T : IWebPage
        {
            return new OpenWebPageRequest<T>(context);
        }
    }
}
