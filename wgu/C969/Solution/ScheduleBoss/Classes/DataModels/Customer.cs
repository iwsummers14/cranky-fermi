using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBoss.Classes
{
    public class Customer
    {
        public int CustomerId { get; set; }
        
        public string CustomerName { get; set; }

        public int AddressId { get; set; }

        public int IsActive { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdateDate { get; set; }

        public string UpdatedBy { get; set; }

    }
}
