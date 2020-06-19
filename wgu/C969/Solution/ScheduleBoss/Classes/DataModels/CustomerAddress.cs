using System;
using System.Data;

namespace ScheduleBoss.Classes
{
    /// <summary>
    /// DataModel class to hold Address data. Mirrors the columns in the Address table.
    /// </summary>
    public class CustomerAddress
    {
        
        public int addressId { get; set; }

        public string address { get; set; }

        public string address2 { get; set; }

        public int cityId { get; set; }

        public string postalCode { get; set; }

        public string phone { get; set; }

        public DateTime createDate { get; set; }

        public string createdBy { get; set; }

        public DateTime lastUpdate { get; set; }

        public string lastUpdateBy { get; set; }

        // default constructor
        public CustomerAddress(){}

        // constructor taking a data row to set property values
        public CustomerAddress(DataRow row)
        {
            this.addressId = int.Parse(row["addressId"].ToString());
            this.address = row["address"].ToString();
            this.address2 = row["address2"].ToString();
            this.cityId = int.Parse(row["cityId"].ToString());
            this.postalCode = row["postalCode"].ToString();
            this.phone = row["phone"].ToString();
            this.createDate = DateTime.Parse(row["createDate"].ToString());
            this.createdBy = row["createdBy"].ToString();
            this.lastUpdate = DateTime.Parse(row["lastUpdate"].ToString());
            this.lastUpdateBy = row["lastUpdateBy"].ToString();
        }
    }
}
