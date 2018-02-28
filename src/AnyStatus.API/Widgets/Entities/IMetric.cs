namespace AnyStatus.API
{
    public interface IMetric : ISchedulable
    {
        object Value { get; set; }
    }
}
