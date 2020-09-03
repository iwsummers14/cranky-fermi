using System;
using System.Collections.Generic;
using System.Text;
using TermTracker.Enum;

namespace TermTracker.Models
{
    public abstract class Assessment
    {
        public string Title { get; set; }

        public AssessmentType AssessmentType { get; set; }

        public AssessmentStatus Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NotificationsEnabled { get; set; }

    }

}
