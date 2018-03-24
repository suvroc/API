namespace AnyStatus.API
{
    public interface IMetricValue : IHealthCheck
    {
        object Value { get; set; }
    }
}
