using SQLite;

namespace TermTracker.Interfaces
{
    /// <summary>
    /// Interface for data connections. Implemented by specific types on each platform, iOS and Android.
    /// </summary>
    public interface IDataConnection
    {
        IFileSystemHelper FileSystemHelper { get; }

        SQLiteAsyncConnection GetDataConnection();

        bool DatabaseExists();
    }

}
