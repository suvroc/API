using System;

namespace AnyStatus.API
{
    public interface ILogger
    {
        bool IsEnabled { get; set; }

        void Info(string message);

        void Debug(string message);

        void Trace(string message);

        void Error(string message);

        void Error(Exception exception);

        void Error(Exception exception, string message);
    }
}