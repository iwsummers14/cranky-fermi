using SQLite;
using System;

namespace TermTracker.Models
{
    /// <summary>
    /// Term model, maps to Terms table in SQLite database.
    /// </summary>
    [Table("Terms")]
    public class Term
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
