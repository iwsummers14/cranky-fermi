using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TermTracker.Interfaces;

using Foundation;
using UIKit;

namespace TermTracker.iOS.Helpers
{
    public class FileSystemHelper : IFileSystemHelper
    {
        public string GetFilePathInPersonalFolder(string fileName)
        {
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");

            if (Directory.Exists(libraryFolder) == false)
            {
                Directory.CreateDirectory(libraryFolder);
            }

            return Path.Combine(libraryFolder, fileName);
        }
    }
}