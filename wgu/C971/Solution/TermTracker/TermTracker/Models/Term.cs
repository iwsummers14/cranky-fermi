using System;
using System.Collections.Generic;
using System.Text;
using TermTracker.Enum;

namespace TermTracker.Models
{
    public class Term
    {
        public string Title { get; set; }

        public TermStatus Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
