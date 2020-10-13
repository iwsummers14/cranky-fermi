namespace TermTracker.Interfaces
{
    /// <summary>
    /// Interface for file system operations. Implemented by specific types on each platform, iOS and Android.
    /// </summary>
    public interface IFileSystemHelper
    {
        string GetFilePathInPersonalFolder(string fileName);

    }
}
