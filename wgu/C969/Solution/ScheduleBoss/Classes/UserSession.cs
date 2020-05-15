using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security;

namespace ScheduleBoss.Classes
{
    internal class UserSession
    {
        public bool IsAuthenticated;

        public string SessionId;

        public TimeZone UserTimeZone = TimeZone.CurrentTimeZone;

        public LoginResponse AuthenticateUser(string Username, string Password, DatabaseConnection dbconn)
        {
            LoginResponse lResp = new LoginResponse();
            return lResp;
        }


        public void SetAuthentication(LoginResponse lResponse)
        {
            this.IsAuthenticated = true;
        }

        

    }

}
