using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleBoss.Classes;
using ScheduleBoss.Enums;

namespace ScheduleBoss.Forms
{
    public partial class LogViewer : Form
    {

        public string LogFilePath { get; set; }

        public string TmpLogPath { get; set; }

        public LogViewer(string path)
        {
            InitializeComponent();

            // set the log file path property
            this.LogFilePath = path;
            this.TmpLogPath = Path.Combine(Environment.CurrentDirectory, "tmp.log");
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                // make a copy of the log file
                File.Copy(this.LogFilePath, this.TmpLogPath);

                // read the entire file into the text box
                using (TextReader reader = new StreamReader(File.OpenRead(this.TmpLogPath)))
                {
                    tbox_LogData.Text = reader.ReadToEnd();
                }

                File.Delete(this.TmpLogPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error reading log file {this.LogFilePath}.\n\nMessage: {ex.Message}.\n\nThe log viewer will now close.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                if (File.Exists(this.TmpLogPath)) { File.Delete(this.TmpLogPath); }
                this.Close();
            }
            
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
