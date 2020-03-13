using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterOfParts
{
    class Product
    {

        public BindingList<Part> AssociatedParts { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public static void addAssociatedPart(Part newPart)
        {

        }

        public static bool removeAssociatedPart(int partNum)
        {

            bool isRemoved = true;
            return isRemoved;
        }


        public static Part lookupAssociatedPart(int partNum)
        {

            Part retrievedPart = null;
            return retrievedPart;
        
        }
    
    }

}
