using System;
using System.Diagnostics;

namespace AnyStatus.API
{
    public interface IProcessStarter
    {
        /// <summary>
        /// Start a new process.
        /// </summary>
        /// <param name="fileName">The file path or URL address to open browser.</param>
        void Start(string fileName);

        /// <summary>
        /// Start a new process.
        /// </summary>
        /// <param name="info">The process start info.</param>
        void Start(ProcessStartInfo info);


        int Start(ProcessStartInfo info, TimeSpan timeout);
    }
}