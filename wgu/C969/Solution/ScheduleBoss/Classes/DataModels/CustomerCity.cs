using System;
using System.Data;

namespace ScheduleBoss.Classes
{
    /// <summary>
    /// DataModel class to hold City data. Mirrors the columns in the City table.
    /// </summary>
    public class CustomerCity
    {
        public int cityId { get; set; }

        public string city { get; set; }

        public int countryId { get; set; }
        
        public DateTime createDate { get; set; }

        public string createdBy { get; set; }

        public DateTime lastUpdate { get; set; }

        public string lastUpdateBy { get; set; }

        // default constructor
        public CustomerCity() { }
        
        // constructor taking a datarow as input to set property values
        public CustomerCity(DataRow row)
        {
            this.cityId = int.Parse(row["cityId"].ToString());
            this.city = row["city"].ToString();
            this.countryId = int.Parse(row["countryId"].ToString());
            this.createDate = DateTime.Parse(row["createDate"].ToString());
            this.createdBy = row["createdBy"].ToString();
            this.lastUpdate = DateTime.Parse(row["lastUpdate"].ToString());
            this.lastUpdateBy = row["lastUpdateBy"].ToString();
        }

    }

}
