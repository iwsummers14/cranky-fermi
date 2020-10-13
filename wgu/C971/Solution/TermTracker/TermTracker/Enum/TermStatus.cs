using System.ComponentModel;

namespace TermTracker.Enum
{
    /// <summary>
    /// Enumeration of status values for Terms. User-readable values are stored in the Description attribute.
    /// </summary>
    public enum TermStatus
    {
        [Description("Not Started")]
        NotStarted,

        [Description("In-Progress")]
        InProgress,

        [Description("Completed")]
        Completed
    }
}
