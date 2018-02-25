namespace AnyStatus.API
{
    public interface IMetric : IHealthCheck
    {
        object Value { get; set; }
    }

    public interface IMetricQuery<TWidget> : IRequestHandler<MetricValueRequest<TWidget>, MetricValueResponse>
            where TWidget : IMetric
    {
    }

    public class MetricValueRequest<TContext> : HealthCheckRequest<TContext, MetricValueResponse>
        where TContext : IMetric
    {
        public MetricValueRequest(TContext context) : base(context) { }
    }

    public class MetricValueResponse : HealthCheckResponse
    {
        public object Value { get; set; }
    }
}
