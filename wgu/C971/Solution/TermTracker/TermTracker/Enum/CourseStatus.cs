using System.ComponentModel;

namespace TermTracker.Enum
{
    /// <summary>
    /// Enumeration of status values for Courses. User-readable values are stored in the Description attribute.
    /// </summary>
    public enum CourseStatus
    {
        [Description("Not Started")]
        NotStarted,

        [Description("In-Progress")]
        InProgress,

        [Description("Completed")]
        Completed
    }
}
