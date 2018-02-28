namespace AnyStatus.API
{

    public interface ICheckHealth<T> : IRequestHandler<HealthCheckRequest<T>, HealthCheckResponse> where T : IHealthCheck
    {
    }

    public class HealthCheckRequest
    {
        public static HealthCheckRequest<T> Create<T>(T context) where T : IHealthCheck
        {
            return new HealthCheckRequest<T>(context);
        }
    }

    public class HealthCheckRequest<T> : Request<T, HealthCheckResponse> where T : IHealthCheck
    {
        public HealthCheckRequest(T context) : base(context) { }
    }

    public class HealthCheckResponse
    {
        public State State { get; set; }

        public string Message { get; set; }
    }
}
