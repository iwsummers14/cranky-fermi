using System;
using System.Data;

namespace ScheduleBoss.Classes
{
    /// <summary>
    /// DataModel class to hold Country data. Mirrors the columns in the Country table.
    /// </summary>
    public class CustomerCountry
    {
        public int countryId { get; set; }

        public string country { get; set; }

        public DateTime createDate { get; set; }

        public string createdBy { get; set; }

        public DateTime lastUpdate { get; set; }

        public string lastUpdateBy { get; set; }

        // default constructor
        public CustomerCountry() { }

        // constructor taking datarow as input to set property values
        public CustomerCountry(DataRow row)
        {
            this.countryId = int.Parse(row["countryId"].ToString());
            this.country = row["country"].ToString();
            this.createDate = DateTime.Parse(row["createDate"].ToString());
            this.createdBy = row["createdBy"].ToString();
            this.lastUpdate = DateTime.Parse(row["lastUpdate"].ToString());
            this.lastUpdateBy = row["lastUpdateBy"].ToString();
        }
    }

}
