namespace AnyStatus.API
{
    public interface IHealthCheck
    {
    }

    public interface IHealthChecker<TWidget> : IRequestHandler<HealthCheckRequest<TWidget>, HealthCheckResponse>
            where TWidget : IHealthCheck
    {
    }

    public class HealthCheckRequest<TContext, TResponse> : Request<TContext, TResponse>
        where TContext : IHealthCheck
    {
        public HealthCheckRequest(TContext context) : base(context)
        {
        }
    }

    public class HealthCheckRequest<TContext> : HealthCheckRequest<TContext, HealthCheckResponse>
        where TContext : IHealthCheck
    {
        public HealthCheckRequest(TContext context) : base(context)
        {
        }
    }

    public class HealthCheckResponse
    {
        public Status Status { get; set; }

        public string Message { get; set; }
    }
}
