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
    /// <summary>
    /// Android specific implementaiton of the file system helper class. 
    /// </summary>
    public class FileSystemHelper : IFileSystemHelper
    {
        /// <summary>
        /// Returns a file path in the user's data folder with the given file name.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetFilePathInPersonalFolder(string fileName)
        {
            string fileSystemPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            return Path.Combine(fileSystemPath, fileName);
        }
    }
}