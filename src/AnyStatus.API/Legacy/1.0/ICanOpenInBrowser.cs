using System;

namespace AnyStatus.API
{
    [Obsolete("Use IWebPage instead.")]
    public interface ICanOpenInBrowser : ITask
    {
        bool CanOpenInBrowser();
    }
}