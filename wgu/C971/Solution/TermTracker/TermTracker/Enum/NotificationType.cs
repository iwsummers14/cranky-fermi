using System.ComponentModel;

namespace TermTracker.Enum
{
    /// <summary>
    /// Enumeration of type values for Notifications. User-readable values are stored in the Description attribute.
    /// </summary>
    public enum NotificationType
    {
        [Description("Starts")]
        Starts,

        [Description("Is Due")]
        IsDue
    }
}
