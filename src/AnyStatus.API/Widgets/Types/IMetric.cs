namespace AnyStatus.API
{
    public interface IMetric : IHealthCheck
    {
        object Value { get; set; }
    }
}
