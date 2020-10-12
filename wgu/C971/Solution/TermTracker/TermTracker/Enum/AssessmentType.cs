using System.ComponentModel;

namespace TermTracker.Enum
{
    /// <summary>
    /// Enumeration of type values for Assessments. User-readable values are stored in the Description attribute.
    /// </summary>
    public enum AssessmentType
    {

        [Description("Objective")]
        Objective,

        [Description("Performance")]
        Performance

    }
}
