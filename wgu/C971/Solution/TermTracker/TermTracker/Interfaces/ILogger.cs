using System;
using System.Collections.Generic;
using System.Text;

namespace TermTracker.Interfaces
{
    public interface ILogger
    {
        IFileSystemHelper FileSystemHelper { get; }

        void WriteLogEntry(string entry);

    }
}
