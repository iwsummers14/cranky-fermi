using System;
using System.Configuration;
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

        public TimeZoneInfo UserTimeZone { get; private set; }

        public CultureInfo CurrentCulture { get; set; }

        public bool IsDaylightSavingsTime { get; private set; }

        public LoginResponse UserLoginInfo { get; set; }

        public TimeSpan WorkDayStart { get; private set; }

        public TimeSpan WorkDayEnd { get; private set; }

        public List<string> WorkDays { get; private set; }

        public List<string> WorkWeek { get; private set; }

        public UserSession()
        {

            var AppSettings = ConfigurationManager.AppSettings;

            // set the TimeZoneInfo property and determine if it the time zone supports daylight savings time.
            // if so, set this property based on the return, if it does not, then set the value to false
            this.UserTimeZone = TimeZoneInfo.Local;
            this.IsDaylightSavingsTime = UserTimeZone.SupportsDaylightSavingTime ? UserTimeZone.IsDaylightSavingTime(DateTime.Now) : false;

            // Parse the workdays string and convert to a list
            this.WorkDays = AppSettings["WorkDays"].Split(',').ToList<string>();

            // Parse the work week string and convert to a list
            this.WorkWeek = AppSettings["WorkWeek"].Split(',').ToList<string>();

            // read workday information in from app.config
            this.WorkDayStart = TimeSpan.Parse(AppSettings["WorkDayStart"]);
            this.WorkDayEnd = TimeSpan.Parse(AppSettings["WorkDayEnd"]);
                
        }
        
        public DateTime ConvertDateTimeFromUtc(DateTime time)
        {
            DateTime convertedTime = TimeZoneInfo.ConvertTimeFromUtc(time, this.UserTimeZone);
            return convertedTime;
        }

        public DateTime ConvertDateTimeToUtc(DateTime time)
        {
            DateTime convertedTime = TimeZoneInfo.ConvertTimeToUtc(time, this.UserTimeZone);
            return convertedTime;
        }

        public Dictionary<string, DateTime> GetThisWeek(DateTime now) 
        {
            var returnRange = new Dictionary<string, DateTime>();
            var weekIndex = this.WorkWeek.IndexOf(now.DayOfWeek.ToString());

            // special case for Saturday.. the work week is over, appointments on Saturday are not allowed,
            // so the range would then start on the next day, Sunday
            if (weekIndex == 6)
            {
                DateTime weekStart = now.AddDays(1);
                DateTime weekEnd = weekStart.AddDays(7);

                returnRange.Add("WeekStart", weekStart);
                returnRange.Add("WeekEnd", weekEnd);
            }

            else
            {
                DateTime weekStart = now.AddDays(-weekIndex);
                DateTime weekEnd = weekStart.AddDays(7);

                returnRange.Add("WeekStart", weekStart);
                returnRange.Add("WeekEnd", weekEnd);
            }
            

            return returnRange;
        }

        public Dictionary<string, DateTime> GetThisMonth(DateTime now)
        {
            var returnRange = new Dictionary<string, DateTime>();
            var monthIndex = (now.Day - 1);
            var daysThisMonth = this.CurrentCulture.Calendar.GetDaysInMonth(now.Year, now.Month);

            DateTime monthStart = now.AddDays(-monthIndex);
            DateTime monthEnd = monthStart.AddDays(daysThisMonth);

            returnRange.Add("MonthStart", monthStart);
            returnRange.Add("MonthEnd", monthEnd);

            return returnRange;
        }

    }

}
