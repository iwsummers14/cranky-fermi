using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TermTracker.Interfaces;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TermTracker.Droid.Helpers;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(TermTracker.Droid.DataAccess.DataConnection))]
namespace TermTracker.Droid.DataAccess
{
    /// <summary>
    /// Android specific implementation of the IDataConnection interface. 
    /// Includes the file system helper and puts the SQLite database in the user data folder.
    /// </summary>    
    public class DataConnection : IDataConnection
    {
        public IFileSystemHelper FileSystemHelper { get; private set; }

        public DataConnection()
        {
            FileSystemHelper = new FileSystemHelper();
        }

        public SQLiteAsyncConnection GetDataConnection()
        {
            var path = FileSystemHelper.GetFilePathInPersonalFolder("TermTracker.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}