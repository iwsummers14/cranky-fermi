using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterOfParts
{
    // static class Inventory
    public static class Inventory
    {

        // BindingList for Products using type Product
        public static BindingList<Product> Products = new BindingList<Product>();

        // Bindinglist for Parts using type Part
        public static BindingList<Part> AllParts = new BindingList<Part>();

        // method to add a Product to Products BindingList
        public static void addProduct(Product productToAdd)
        {

            Products.Add(productToAdd);

        }

        // method to remove a Product from the Products BindingList
        public static bool removeProduct(int productId)
        {
            // lookup the product by ID
            Product productToRemove = lookupProduct(productId);

            // remove the product object and return the result
            bool result = Products.Remove(productToRemove);
            return result;
        }

        // method to lookup a Product from the Products bindingList
        public static Product lookupProduct(int lookupProductId)
        {
            // search Products list for the matching Product ID
            var foundProducts = from Product in Products
                                let productId = Product.ProductID
                                where productId.Equals(lookupProductId)
                                select Product as Product;

            // throw error if multiple results are returned
            if (foundProducts.Count() > 1)
            {
                throw new Exception("Error: Multiple products returned with same Product ID.");
            }

            // otherwise, return the data
            else
            {
                Product foundProduct = foundProducts.First();
                return foundProduct;
            }
        }
    
        // method to update a Product in the Products BindingList
        public static void updateProduct (int lookupProductId, Product updatedProduct)
        {
            // lookup the product by ID
            Product productToUpdate = lookupProduct(lookupProductId);

            // update the product
            productToUpdate.Name = updatedProduct.Name;
            productToUpdate.Price = updatedProduct.Price;
            productToUpdate.Max = updatedProduct.Max;
            productToUpdate.Min = updatedProduct.Min;
            productToUpdate.InStock = updatedProduct.InStock;
            productToUpdate.AssociatedParts.Clear();

            foreach (Part AssociatedPart in updatedProduct.AssociatedParts)
            {
                productToUpdate.AssociatedParts.Add(AssociatedPart);
            }
            
        }
    
        // method to add a Part to the AllParts bindingList
        public static void addPart(Part partToAdd)
        {
            
            AllParts.Add(partToAdd);
        }

        // method to remove a Part to the AllParts bindingList
        public static bool deletePart(Part partToDelete)
        {
            bool result = AllParts.Remove(partToDelete);
            return result;
        }

        // method to lookup a Part from the AllParts bindingList
        public static Part lookupPart(int lookupPartId)
        {
            
            var foundParts = from Part in AllParts
                             let partId = Part.PartID
                             where partId.Equals(lookupPartId)
                             select Part;

            if (foundParts.Count() > 1)
            {
                throw new Exception("Error: Multiple parts returned with same Part ID.");
            }
            else
            {
                Part foundPart = foundParts.First();
                return foundPart;
            }
                           
        }

        // overload updatePart method for Inhouse part (derived class from abstract class Part)
        public static void updatePart(int lookupPartId, Inhouse updatedPart)
        {
            // search Inhouse parts for the partId
            var foundInhouse = from Part in AllParts.OfType<Inhouse>()
                               let partId = Part.PartID
                               where partId.Equals(lookupPartId)
                               select Part as Inhouse;

            // throw an exception if multiple parts were returned
            if (foundInhouse.Count() > 1)
            {
                
                throw new Exception("Error: Multiple parts returned with same Part ID.");
            
            }
            else if (foundInhouse.Count() == 0)
            {

                // search parts of both types
                var foundParts = from Part in AllParts
                                 let partId = Part.PartID
                                 where partId.Equals(lookupPartId)
                                 select Part as Part;

                Part foundPart = foundParts.First();

                deletePart(foundPart);
                addPart(updatedPart);

            }
            else
            {
                Inhouse foundPart = foundInhouse.First();

                foundPart.Name = updatedPart.Name;
                foundPart.InStock = updatedPart.InStock;
                foundPart.Price = updatedPart.Price;
                foundPart.Max = updatedPart.Max;
                foundPart.Min = updatedPart.Min;
                foundPart.MachineId = updatedPart.MachineId;

            }

        }

        // overload updatePart method for Outsourced part (derived class from abstract class Part)
        public static void updatePart(int lookupPartId, Outsourced updatedPart)
        {
            // search Outsourced parts for the partId
            var foundOutsourced = from Part in AllParts.OfType<Outsourced>()
                             let partId = Part.PartID
                             where partId.Equals(lookupPartId)
                             select Part as Outsourced;

            // throw an error if more than one part was found
            if (foundOutsourced.Count() > 1)
            {

                throw new Exception("Error: Multiple parts returned with same Part ID.");
            
            }

            // if no parts were found, widen the search, because the type has changed
            else if (foundOutsourced.Count() == 0)
            {

                // search parts of both types
                var foundParts = from Part in AllParts
                                 let partId = Part.PartID
                                 where partId.Equals(lookupPartId)
                                 select Part as Part;

                Part foundPart = foundParts.First();

                // delete the part and add a new one of the changed type
                deletePart(foundPart);
                addPart(updatedPart);
                
            }

            // update the existing part if no other conditions were met
            else
            {

                Outsourced foundPart = foundOutsourced.First();
                                
                foundPart.Name = updatedPart.Name;
                foundPart.InStock = updatedPart.InStock;
                foundPart.Price = updatedPart.Price;
                foundPart.Max = updatedPart.Max;
                foundPart.Min = updatedPart.Min;
                foundPart.CompanyName = updatedPart.CompanyName;
                
            }

        }

    }

}
