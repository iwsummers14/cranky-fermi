using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TermTracker.Enum;

namespace TermTracker.Models
{
    [Table("Terms")]
    public class Term
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string Title { get; set; }

        public TermStatus Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
