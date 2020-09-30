using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TermTracker.Interfaces;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TermTracker.Droid.Helpers
{
    public class FileSystemHelper : IFileSystemHelper
    {
        
        public string GetFilePathInPersonalFolder(string fileName)
        {
            string fileSystemPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            return Path.Combine(fileSystemPath, fileName);
        }
    }
}