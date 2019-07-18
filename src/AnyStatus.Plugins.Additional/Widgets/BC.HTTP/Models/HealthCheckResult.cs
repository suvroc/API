using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyStatus.Plugins.Additional.Widgets.BC.HTTP.Models
{
    public class HealthCheckResult
    {
        public bool allChecksPassed { get; set; }
        public string version { get; set; }
        public CheckDetail[] checksDetails { get; set; }
    }

    public class CheckDetail
    {
        public bool testPassed { get; set; }
        public string checkType { get; set; }
        public string name { get; set; }
        public string errorMessage { get; set; }
    }
}
