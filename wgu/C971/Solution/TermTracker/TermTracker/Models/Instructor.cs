using SQLite;

namespace TermTracker.Models
{
    /// <summary>
    /// Instructor model, maps to Instructors table in SQLite database.
    /// </summary>
    [Table("Instructors")]
    public class Instructor
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
