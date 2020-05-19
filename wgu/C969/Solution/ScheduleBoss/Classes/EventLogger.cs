using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScheduleBoss.Classes
{
    public class EventLogger
    {
        
        public StreamWriter Writer { get; set; }

        public FileStream LogFileStream { get; set; }

        public string LogFilePath { get; set; }

        public EventLogger(string FilePath)
        {
            // set the logfilepath property
            this.LogFilePath = FilePath;

            // open the log file in append mode and set the LogFileStream property to this filestream
            this.LogFileStream = File.Open(this.LogFilePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            
            // establish a stream writer to the log file and set it to auto-flush the buffer
            this.Writer = new StreamWriter(LogFileStream, Encoding.UTF8, 4096);
            this.Writer.AutoFlush = true;

        }
        public void WriteLog(FormattableString message)
        {
            this.Writer.WriteLine(message);
        }

        public void Dispose()
        {

            try
            {
                
                this.Writer.Dispose();
                this.LogFileStream.Close();
            }

            catch
            {
                
            }

        }

        

    }
}
