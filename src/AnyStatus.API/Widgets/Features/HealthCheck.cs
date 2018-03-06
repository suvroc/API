namespace AnyStatus.API
{
    public interface ICheckHealth<T> : IRequestHandler<HealthCheckRequest<T>> where T : IHealthCheck
    {
    }

    public class HealthCheckRequest
    {
        public static HealthCheckRequest<T> Create<T>(T context) where T : IHealthCheck
        {
            return new HealthCheckRequest<T>(context);
        }
    }

    public class HealthCheckRequest<T> : Request<T> where T : IHealthCheck
    {
        public HealthCheckRequest(T context) : base(context) { }
    }
}
