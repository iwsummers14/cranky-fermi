﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TermTracker.Interfaces
{
    public interface IFileSystemHelper
    {
        string GetFilePathInPersonalFolder(string fileName);

    }
}