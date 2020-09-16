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