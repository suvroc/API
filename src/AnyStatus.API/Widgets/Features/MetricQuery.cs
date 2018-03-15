namespace AnyStatus.API
{
    public interface IMetricQuery<T> : IRequestHandler<MetricQueryRequest<T>> where T : IMetricValue
    {
    }

    public class MetricQueryRequest<T> : Request<T> where T : IMetricValue
    {
        public MetricQueryRequest(T context) : base(context) { }
    }

    public class MetricQueryRequest
    {
        public static MetricQueryRequest<T> Create<T>(T context) where T : IMetricValue
        {
            return new MetricQueryRequest<T>(context);
        }
    }
}
