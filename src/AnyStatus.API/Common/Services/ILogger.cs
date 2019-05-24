using System;

namespace AnyStatus.API
{
    public interface ILogger
    {
        void Info(string message);

        void Debug(string message);

        void Trace(string message);

        void Error(string message);

        void Error(Exception exception);

        void Error(Exception exception, string message);
    }
}