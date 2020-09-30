using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TermTracker.Enum
{
    public enum ViewType
    {
        [Description("AddOrEdit")]
        Entry,

        [Description("ViewDetail")]
        Detail
    }
}
