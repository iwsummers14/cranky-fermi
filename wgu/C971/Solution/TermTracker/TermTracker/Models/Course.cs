﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TermTracker.Models
{
    /// <summary>
    /// Course model, maps to Courses table in SQLite database.
    /// </summary>
    [Table("Courses")]
    public class Course
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string CourseCode { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NotificationsEnabled { get; set; }

        public string Notes { get; set; }        
        
        public int InstructorId { get; set; }

        public int TermId { get; set; }

        

    }
}
