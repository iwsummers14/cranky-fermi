using System;
using System.IO;
using System.Text;

namespace ScheduleBoss.Classes
{
    /// <summary>
    /// Class to handle event logging, to a plaintext log file.
    /// </summary>
    public class EventLogger : IDisposable
    {
        
        public StreamWriter Writer { get; set; }

        public FileStream LogFileStream { get; set; }

        public string LogFilePath { get; set; }

        // constructor - requires a log file path to be passed in
        public EventLogger(string FilePath)
        {
            // set the logfilepath property
            this.LogFilePath = FilePath;

            // open the log file in append mode and set the LogFileStream property to this filestream
            this.LogFileStream = File.Open(this.LogFilePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            
            // establish a stream writer to the log file and set it to auto-flush the buffer
            this.Writer = new StreamWriter(LogFileStream, Encoding.UTF8, 4096, false);
            
        }

        // method to write an entry to the log 
        public void WriteLog(FormattableString message)
        {
            // write line to buffer and flush buffer to file
            this.Writer.WriteLine(message);
            this.Writer.Flush();
        }

        // dispose method for implementing the IDisposable interface
        public void Dispose()
        {
            // dispose of the streamWriter and close the file stream
            this.Writer.Dispose();
            this.LogFileStream.Close();
            
        }
        
    }

}
