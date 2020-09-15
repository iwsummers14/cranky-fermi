using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TermTracker.Interfaces
{
    public interface IDataConnection
    {
        IFileSystemHelper FileSystemHelper { get; }

        SQLiteAsyncConnection GetDataConnection();

    }

}
