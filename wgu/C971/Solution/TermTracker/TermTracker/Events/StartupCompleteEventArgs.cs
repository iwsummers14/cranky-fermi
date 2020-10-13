using System;

namespace TermTracker.Events
{
    /// <summary>
    /// Event arguments for the startup complete event.
    /// </summary>
    public class StartupCompleteEventArgs : EventArgs
    {
        public bool TablesHydrated { get; set; }
    }
}
