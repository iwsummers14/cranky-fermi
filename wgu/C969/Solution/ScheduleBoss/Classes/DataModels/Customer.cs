﻿using System;
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

        public bool IsActive { get; set; }



    }
}
