using System;
using System.Collections.Generic;

namespace AnyStatus.API
{
    public interface IJobHistory
    {
        IEnumerable<JobRun> JobHistory { get; set; }
    }

    public class JobRun
    {
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public State State { get; set; }
        public double Percentage { get; set; }
        public string URL { get; set; }
    }
}
