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
using System.Runtime.CompilerServices;
using TermTracker.Droid.Helpers;

namespace TermTracker.Droid.DataAccess
{
    public class DataConnection : IDataConnection
    {
        public IFileSystemHelper FileSystemHelper { get; private set; }

        public DataConnection()
        {
            FileSystemHelper = new FileSystemHelper();
        }
    }
}