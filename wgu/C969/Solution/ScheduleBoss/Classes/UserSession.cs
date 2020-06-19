using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace ScheduleBoss.Classes
{
    /// <summary>
    /// Class to hold user session data. This includes timezone information, work day start and end
    /// times, work days, and the order of work days in a work week. This class also holds methods to
    /// convert datetime information from the session time zone to UTC and from UTC to the session
    /// time zone. It also generates date ranges for 'this week' and 'this month' based on a date time.
    /// </summary>
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

        // constructor
        public UserSession()
        {
            // load the appsettings section of the app.config file
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
        
        // method to convert a time from UTC to the session time zone
        public DateTime ConvertDateTimeFromUtc(DateTime time)
        {
            DateTime convertedTime = TimeZoneInfo.ConvertTimeFromUtc(time, this.UserTimeZone);
            return convertedTime;
        }

        // method to convert a time from the session time zone to UTC
        public DateTime ConvertDateTimeToUtc(DateTime time)
        {
            DateTime convertedTime = TimeZoneInfo.ConvertTimeToUtc(time, this.UserTimeZone);
            return convertedTime;
        }

        // method to get 'this week' range from a given datetime
        public Dictionary<string, DateTime> GetThisWeek(DateTime now) 
        {
            // set up variables
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

            // processing for all other days
            else
            {
                DateTime weekStart = now.AddDays(-weekIndex);
                DateTime weekEnd = weekStart.AddDays(7);

                returnRange.Add("WeekStart", weekStart);
                returnRange.Add("WeekEnd", weekEnd);
            }
            
            // return the range of dates
            return returnRange;
        }

        // method to get 'this month' range from a given datetime
        public Dictionary<string, DateTime> GetThisMonth(DateTime now)
        {
            // set up variables
            var returnRange = new Dictionary<string, DateTime>();
            var monthIndex = (now.Day - 1);
            var daysThisMonth = this.CurrentCulture.Calendar.GetDaysInMonth(now.Year, now.Month);

            // set month start and end values
            DateTime monthStart = now.AddDays(-monthIndex);
            DateTime monthEnd = monthStart.AddDays(daysThisMonth);

            // add values to dictionary
            returnRange.Add("MonthStart", monthStart);
            returnRange.Add("MonthEnd", monthEnd);

            // return data
            return returnRange;
        }

    }

}
