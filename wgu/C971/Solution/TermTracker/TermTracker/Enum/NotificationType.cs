using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TermTracker.Enum
{
    public enum NotificationType
    {
        [Description("Starts")]
        Starts,

        [Description("Is Due")]
        IsDue
    }
}
