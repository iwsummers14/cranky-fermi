using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBoss.Classes
{
    public class CustomerAddress
    {
        public int AddressId { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public int CityId { get; set; }

        public string PostalCode { get; set; }

        public DateTime CreateTime { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdatedBy { get; set; }

    }
}
