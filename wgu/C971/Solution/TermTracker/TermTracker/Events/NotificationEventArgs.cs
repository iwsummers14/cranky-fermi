using System;

namespace TermTracker.Events
{
    /// <summary>
    /// Event arguments for user notification implementation.
    /// </summary>

    public class NotificationEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
