using System;

namespace TermTracker.Interfaces
{
    /// <summary>
    /// Interface for managing local user notifications. Implemented by specific types on each platform, iOS and Android.
    /// </summary>
    public interface INotificationManager
    {
        event EventHandler NotificationReceived;

        void Initialize();

        int ScheduleNotification(string title, string message);

        void ReceiveNotification(string title, string message);
    }
}
