namespace AnyStatus.API
{
    public interface IMetricQuery<T> : IRequestHandler<MetricQueryRequest<T>, MetricQueryResponse> where T : IMetric
    {
    }

    public class MetricQueryRequest
    {
        public static MetricQueryRequest<T> Create<T>(T context) where T : IMetric
        {
            return new MetricQueryRequest<T>(context);
        }
    }

    public class MetricQueryRequest<T> : Request<T, MetricQueryResponse> where T : IMetric
    {
        public MetricQueryRequest(T context) : base(context) { }
    }

    public class MetricQueryResponse
    {
        public object Value { get; set; }
    }
}
