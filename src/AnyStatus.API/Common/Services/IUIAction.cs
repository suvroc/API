using System;

namespace AnyStatus.API.Common.Services
{
    public interface IUiAction
    {
        /// <summary>
        /// Invoke an action on the UI thread.
        /// </summary>
        /// <param name="callback"></param>
        void Invoke(Action callback);
    }
}
