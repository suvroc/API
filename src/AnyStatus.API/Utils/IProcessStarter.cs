using System;
using System.Diagnostics;

namespace AnyStatus.API
{
    public interface IProcessStarter
    {
        void Start(string fileName);

        int Start(ProcessStartInfo info, TimeSpan timeout);
    }
}
