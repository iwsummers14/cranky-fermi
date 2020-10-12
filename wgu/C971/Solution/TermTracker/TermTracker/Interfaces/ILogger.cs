using System;
using System.Collections.Generic;
using System.Text;

namespace TermTracker.Interfaces
{
    /// <summary>
    /// Interface for logging to file. Implemented by specific types on each platform, iOS and Android.
    /// </summary>
    public interface ILogger
    {
        IFileSystemHelper FileSystemHelper { get; }

        void WriteLogEntry(string entry);

    }
}
