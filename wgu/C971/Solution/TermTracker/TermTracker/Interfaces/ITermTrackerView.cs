using System;
using System.Collections.Generic;
using System.Text;

namespace TermTracker.Interfaces
{
    public interface ITermTrackerView
    {
        void Save();

        void Cancel();

        void Delete<T>();
    }
}
