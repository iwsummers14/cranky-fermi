using System.ComponentModel;

namespace TermTracker.Enum
{
    /// <summary>
    /// Enumeration of status values for Assessments. User-readable values are stored in the Description attribute.
    /// </summary>
    public enum AssessmentStatus
    {
        [Description("Not Attempted")]
        NotAttempted,
        
        [Description("In-Progress")]
        InProgress,

        [Description("Completed")]
        Completed,

        [Description("Failed")]
        Failed


    }
}
