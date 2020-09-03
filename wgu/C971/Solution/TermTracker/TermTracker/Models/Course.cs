using System;
using System.Collections.Generic;
using System.Text;

namespace TermTracker.Models
{
    public class Course
    {
        public string CourseCode { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NotificationsEnabled { get; set; }

        public Instructor CourseInstructor { get; set; }

        public List<Assessment> Assessments { get; set; }

    }
}
