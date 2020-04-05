using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterOfParts
{
    public class Product
    {

        public BindingList<Part> AssociatedParts = new BindingList<Part>();

        public int ProductID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public void addAssociatedPart(Inhouse newPart)
        {
            AssociatedParts.Add(newPart);
        }
        
        public void addAssociatedPart(Outsourced newPart)
        {
            AssociatedParts.Add(newPart);
        }

        public bool removeAssociatedPart(int lookupPartId)
        {
            try {

                // lookup the part based on the supplied partId value
                Part foundPart = lookupAssociatedPart(lookupPartId);
                
                bool result = AssociatedParts.Remove(foundPart);
                return result;
                
            }
            catch (Exception)
            {
                // return false value if the exception was thrown, indicating that the part was not removed
                return false;
            }
            
        }


        public Part lookupAssociatedPart(int lookupPartId)
        {

            // lookup the part based on the supplied partId value
            var foundParts = from Part in Inventory.AllParts
                             let partId = Part.PartID
                             where partId.Equals(lookupPartId)
                             select Part as Part;

            // throw an error if more than one part was identified
            if (foundParts.Count() > 1)
            {
                throw new Exception("Error: Multiple parts returned with same Part ID.");

            }

            // remove the part from the list of associated parts
            else
            {
                Part foundPart = foundParts.First();
                return foundPart;

            }

        }
    
    }

}
