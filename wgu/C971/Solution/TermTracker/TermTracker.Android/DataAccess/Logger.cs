using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TermTracker.Interfaces;
using TermTracker.Droid.Helpers;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(TermTracker.Droid.DataAccess.Logger))]
namespace TermTracker.Droid.DataAccess
{
    public class Logger : ILogger
    {
        public IFileSystemHelper FileSystemHelper { get; private set; }

        public Logger()
        {
            FileSystemHelper = new FileSystemHelper();
        }

        public void WriteLogEntry(string entry)
        {
            var log = File.Open(Path.Combine(FileSystemHelper.GetFilePathInPersonalFolder("TermTracker.log")), FileMode.OpenOrCreate);
            var sw = new StreamWriter(log);

            sw.WriteLine(entry);
            
            sw.Flush();
            sw.Dispose();

            log.Close();

        }
    }
}