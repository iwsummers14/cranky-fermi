using System;

namespace ScheduleBoss.Classes
{
    /// <summary>
    /// DataModel class to hold login response (user) data from database
    /// </summary>
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
