using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBoss.Classes
{
    internal class LoginResponse
    {
        public int userId { get; set; }

        public int active { get; set; }

        public DateTime createDate { get; set; }

        public string createdBy { get; set; }

        public DateTime lastUpdate { get; set; }

        public string lastUpdateBy { get; set; }

    }
}
