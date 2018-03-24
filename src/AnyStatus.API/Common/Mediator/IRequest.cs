namespace AnyStatus.API
{
    public interface IBaseRequest { }
    public interface IRequest : IRequest<Unit> { }
    public interface IRequest<out TResponse> : IBaseRequest { }
}