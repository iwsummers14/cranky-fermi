using SQLite;
using System;

namespace TermTracker.Models
{
    /// <summary>
    /// Assessment model, maps to Assessments table in SQLite database.
    /// </summary>
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

        public int CourseId { get; set; }

    }

}
