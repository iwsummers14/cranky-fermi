using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBoss.Classes
{
    public class LoginResponse
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdate { get; set; }

        public string LastUpdateBy { get; set; }

    }
}
