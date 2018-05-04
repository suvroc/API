using System;

namespace AnyStatus.API
{
    public interface IJobRun
    {
        string Description { get; set; }
        TimeSpan Duration { get; set; }
        State State { get; set; }
        double Percentage { get; set; }
        string URL { get; set; }
    }
}