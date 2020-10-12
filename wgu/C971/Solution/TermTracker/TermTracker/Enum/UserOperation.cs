using System.ComponentModel;

namespace TermTracker.Enum
{
    /// <summary>
    /// Enumeration of user operations on entry views. User-readable values are stored in the Description attribute.
    /// </summary>
    public enum UserOperation
    {

        [Description("Add")]
        Add,

        [Description("Edit")]
        Edit,

        [Description("Delete")]
        Delete

    }
}
