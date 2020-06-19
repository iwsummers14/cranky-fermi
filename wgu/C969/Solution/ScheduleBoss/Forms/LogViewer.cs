using System;
using System.IO;
using System.Windows.Forms;

namespace ScheduleBoss.Forms
{
    /// <summary>
    /// Form that allows the user to view the activity log.
    /// </summary>
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
            // load the log data
            LoadLogData();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            // re-load the log data
            LoadLogData();
        }

        private void LoadLogData()
        {
            try
            {
                // clear any text in the viewerbox 
                tbox_LogData.Text = "";

                // make a copy of the log file
                File.Copy(this.LogFilePath, this.TmpLogPath);

                // read the entire file into the text box
                using (TextReader reader = new StreamReader(File.OpenRead(this.TmpLogPath)))
                {
                    tbox_LogData.Text = reader.ReadToEnd();
                    
                }

                File.Delete(this.TmpLogPath);
                tbox_LogData.ScrollToCaret();
            }
            catch (Exception ex)
            {
                // display error message to user and close the form
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


    }
}
