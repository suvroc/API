using System;

namespace AnyStatus.API
{
    [Obsolete("Use IRequestHandler instead.")]
    public interface IHandler
    {
    }

    [Obsolete("Use IRequestHandler instead.")]
    public interface IHandler<in T> : IHandler
    {
        void Handle(T item);
    }
}