using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBoss.Classes
{
    public class Customer
    {
        public int customerId { get; set; }
        
        public string customerName { get; set; }

        public int addressId { get; set; }

        public bool active { get; set; }

        public DateTime createDate { get; set; }

        public string createdBy { get; set; }

        public DateTime lastUpdate { get; set; }

        public string lastUpdateBy { get; set; }

        public Customer()
        {

        }

        public Customer(DataRow row)
        {
            this.customerId = int.Parse(row["customerId"].ToString());
            this.customerName = row["customerName"].ToString();
            this.addressId = int.Parse(row["addressId"].ToString());
            this.active = bool.Parse(row["active"].ToString());
            this.createDate = DateTime.Parse(row["createDate"].ToString());
            this.createdBy = row["createdBy"].ToString();
            this.lastUpdate = DateTime.Parse(row["lastUpdate"].ToString());
            this.lastUpdateBy = row["lastUpdateBy"].ToString();
        }
    }
}
