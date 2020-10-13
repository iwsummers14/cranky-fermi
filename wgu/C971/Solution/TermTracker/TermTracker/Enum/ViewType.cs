using System.ComponentModel;

namespace TermTracker.Enum
{
    /// <summary>
    /// Enumeration of types for views. Description attribute is used to identify the view.
    /// </summary>
    public enum ViewType
    {
        [Description("AddOrEdit")]
        Entry,

        [Description("ViewDetail")]
        Detail
    }
}
