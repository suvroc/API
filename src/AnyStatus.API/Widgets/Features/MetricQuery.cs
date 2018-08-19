namespace AnyStatus.API
{
    public interface IMetricQuery<T> : IRequestHandler<MetricQueryRequest<T>> 
        where T : IMetric
    {
    }

    public class MetricQueryRequest<T> : HealthCheckRequest<T> where T : IMetric
    {
        public MetricQueryRequest(T context) : base(context) { }
    }

    public static class MetricQueryRequest
    {
        public static MetricQueryRequest<T> Create<T>(T context) where T : IMetric
        {
            return new MetricQueryRequest<T>(context);
        }
    }
}
