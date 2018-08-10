using System;
using System.Diagnostics;

namespace AnyStatus.API
{
    public interface IProcessStarter
    {
        void Start(string fileName);

        void Start(ProcessStartInfo info);

        int Start(ProcessStartInfo info, TimeSpan timeout);
    }
}