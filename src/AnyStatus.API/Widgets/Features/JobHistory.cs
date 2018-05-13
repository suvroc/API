using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AnyStatus.API
{
    public interface IJobHistory
    {
        [XmlIgnore]
        IEnumerable<IJobRun> JobHistory { get; set; }
    }

    public interface IJobRun
    {
        string Description { get; set; }
        TimeSpan Duration { get; set; }
        State State { get; set; }
        double Percentage { get; set; }
        string URL { get; set; }
    }
}
