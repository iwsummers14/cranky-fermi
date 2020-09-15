using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TermTracker.Interfaces;


using Foundation;
using UIKit;
using Xamarin.Essentials;
using TermTracker.iOS.Helpers;
using SQLite;

namespace TermTracker.iOS.DataAccess
{
    public class DataConnection : IDataConnection
    {
        public IFileSystemHelper FileSystemHelper { get; private set; }

        public DataConnection()
        {
            FileSystemHelper = new FileSystemHelper();
        }

        public SQLiteAsyncConnection GetDataConnection()
        {
            var path = FileSystemHelper.GetDatabaseFilePath("TermTracker.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}