using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TermTracker.Enum
{
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
