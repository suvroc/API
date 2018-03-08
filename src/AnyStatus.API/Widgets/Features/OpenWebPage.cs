using System;

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

    public class OpenWebPage<TWebPage> : RequestHandler<OpenWebPageRequest<TWebPage>>, IOpenWebPage<TWebPage> where TWebPage : IWebPage
    {
        private readonly IProcessStarter _ps;

        public OpenWebPage(IProcessStarter ps)
        {
            _ps = ps ?? throw new ArgumentNullException();
        }

        protected override void HandleCore(OpenWebPageRequest<TWebPage> request)
        {
            var uri = request.DataContext.URL;

            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                throw new UriFormatException(uri);
            }

            _ps.Start(uri);
        }
    }
}
