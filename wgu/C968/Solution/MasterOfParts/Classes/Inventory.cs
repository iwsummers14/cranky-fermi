using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterOfParts
{
    class Inventory
    {
        public BindingList<Product> Products { get; set; }

        public BindingList<Part> AllParts { get; set; }

        public static void addProduct(Product productToAdd)
        {

        }

        public static bool removeProduct(int productId)
        {
            return true;
        }

        public static Product lookupProduct(int productId)
        {
            Product foundProduct = new Product();
            return foundProduct;
        }
    
        public static void updateProduct (int newVal, Product targetProduct)
        {

        }
    
        public static void addPart(Part partToAdd)
        {

        }

        public static bool deletePart(Part partToDelete)
        {

            return true;
        }

        public static Part lookupPart(int partId)
        {
            var foundPart = new Outsourced();
            return foundPart;
        }

        public static void updatePart(int newValue, Part targetPart)
        {

        }
    
    }
}
