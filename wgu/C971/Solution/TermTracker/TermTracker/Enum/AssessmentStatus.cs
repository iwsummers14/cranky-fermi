using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TermTracker.Enum
{
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
