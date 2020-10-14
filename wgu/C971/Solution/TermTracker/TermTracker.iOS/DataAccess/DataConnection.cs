using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TermTracker.Interfaces;


using Foundation;
using UIKit;
using Xamarin.Essentials;
using Xamarin.Forms;
using TermTracker.iOS.Helpers;
using SQLite;

[assembly: Dependency(typeof(TermTracker.iOS.DataAccess.DataConnection))]
namespace TermTracker.iOS.DataAccess
{
    /// <summary>
    /// iOS specific implementation of the IDataConnection interface. Includes a file system helper and stores SQLite database in the user's data folder.
    /// </summary>
    public class DataConnection : IDataConnection
    {
        public IFileSystemHelper FileSystemHelper { get; private set; }

        private string dbPath;

        public DataConnection()
        {
            FileSystemHelper = new FileSystemHelper();
            GetDbFileLocation();
        }

        private void GetDbFileLocation()
        {
            dbPath = FileSystemHelper.GetFilePathInPersonalFolder("TermTracker.db3");
        }

        public SQLiteAsyncConnection GetDataConnection()
        {
            return new SQLiteAsyncConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
        }

        public bool DatabaseExists()
        {
            return FileSystemHelper.FileExists(dbPath);
        }

    }
}