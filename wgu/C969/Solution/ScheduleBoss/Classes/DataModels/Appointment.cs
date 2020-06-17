using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBoss.Classes
{
    /// <summary>
    /// DataModel class to hold Appointment data. Mirrors the columns in the Appointment table.
    /// </summary>
    public class Appointment
    {
        
        public int appointmentId { get; set; }

        public int customerId { get; set; }

        public int userId { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string location { get; set; }

        public string contact { get; set; }

        public string type { get; set; }

        public string url { get; set; }

        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public DateTime createDate { get; set; }

        public string createdBy { get; set; }

        public DateTime lastUpdate { get; set; }

        public string lastUpdateBy { get; set; }

        // default constructor 
        public Appointment() { }

        // constructor taking a datarow to set property values
        public Appointment(DataRow row)
        {
            this.appointmentId = int.Parse(row["appointmentId"].ToString());
            this.customerId = int.Parse(row["customerId"].ToString());
            this.userId = int.Parse(row["userId"].ToString());
            this.title = row["title"].ToString();
            this.description = row["description"].ToString();
            this.location = row["location"].ToString();
            this.contact = row["contact"].ToString();
            this.type = row["type"].ToString();
            this.url = row["url"].ToString();
            this.start = DateTime.Parse(row["start"].ToString());
            this.end = DateTime.Parse(row["end"].ToString());
            this.createDate = DateTime.Parse(row["createDate"].ToString());
            this.createdBy = row["createdBy"].ToString();
            this.lastUpdate = DateTime.Parse(row["lastUpdate"].ToString());
            this.lastUpdateBy = row["lastUpdateBy"].ToString();

        }
    }
}
