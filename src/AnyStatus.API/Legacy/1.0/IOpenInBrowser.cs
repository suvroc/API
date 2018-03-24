using System;

namespace AnyStatus.API
{
    [Obsolete("Use IOpenWebPage instead.")]
    public interface IOpenInBrowser<in T> : IHandler
    {
        void Handle(T item);
    }
}