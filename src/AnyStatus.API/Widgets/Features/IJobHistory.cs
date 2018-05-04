using System.Collections.Generic;

namespace AnyStatus.API
{
    public interface IJobHistory
    {
        IEnumerable<IJobRun> JobHistory { get; set; }
    }
}
