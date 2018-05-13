using System;

namespace AnyStatus.API
{
    public interface ISchedulable
    {
        Guid Id { get; }

        string Name { get; }

        int Interval { get; }

        //IntervalUnit IntervalUnit { get; }
    }

    public enum IntervalUnit
    {
        None,
        Seconds,
        Minutes
    }
}
