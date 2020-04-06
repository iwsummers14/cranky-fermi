using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterOfParts
{
    // child class for outsourced part, inherits abstract class Part
    public class Outsourced : Part
    {
        public string CompanyName { get; set; }

    }
}
