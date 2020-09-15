using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TermTracker.Enum;

namespace TermTracker.Models
{
    [Table("Assessments")]
    public class Assessment
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string Title { get; set; }

        public string AssessmentType { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NotificationsEnabled { get; set; }

    }

}
