namespace AnyStatus.API
{
    public interface IWebPage
    {
        string URL { get; set; }
    }

    public interface IOpenWebPage<T> : IRequestHandler<OpenWebPageRequest<T>, OpenWebPageResponse> where T : IWebPage
    {
    }

    public class OpenWebPageRequest
    {
        public static OpenWebPageRequest<T> Create<T>(T context) where T : IWebPage
        {
            return new OpenWebPageRequest<T>(context);
        }
    }

    public class OpenWebPageRequest<T> : Request<T, OpenWebPageResponse> where T : IWebPage
    {
        public OpenWebPageRequest(T context) : base(context) { }
    }

    public class OpenWebPageResponse
    {
    }
}
