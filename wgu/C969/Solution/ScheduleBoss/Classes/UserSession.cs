using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security;

namespace ScheduleBoss.Classes
{
    public class UserSession
    {
        public bool IsAuthenticated { get; set; }
        
        public DateTime UserLoginTime { get; set; }

        public TimeZone UserTimeZone { get; }  = TimeZone.CurrentTimeZone;

        public LoginResponse UserLoginInfo { get; set; }

    }

}
