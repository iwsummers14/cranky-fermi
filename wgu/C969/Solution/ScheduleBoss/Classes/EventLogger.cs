using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScheduleBoss.Classes
{
    public class EventLogger : IDisposable
    {
        
        public StreamWriter Writer;

        public FileStream LogFileStream;

        public string LogFilePath;

        EventLogger(string LogFilePath)
        {
            
            this.LogFilePath = LogFilePath;

            if (File.Exists(this.LogFilePath) == false)
            {
                File.Create(LogFilePath);
            }

            this.LogFileStream = File.OpenWrite(this.LogFilePath);
            this.Writer = new StreamWriter(LogFileStream);

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

        public void WriteLog(string message)
        {
            this.Writer.WriteLine(message);
        }

    }
}
