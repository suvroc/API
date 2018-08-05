using System;

namespace AnyStatus.API
{
    public interface INotificationService : IDisposable
    {
        void TrySend(Notification notification);
    }
}