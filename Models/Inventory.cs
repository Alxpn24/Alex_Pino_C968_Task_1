using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem_AlexPino.Models;

// Static class sotring all products and parts
// Again, I chose binding list so the DataGridViews update accordingly
internal static class Inventory
{
    // The mastre list of all the parts in the system
    public static BindingList<Part> Allparts = new BindingList<Part>();
    // The master list of all the products
    public static BindingList<Product> Products = new BindingList<Product>();


    // Adds a new part to inventory
    public static void AddPart(Part part)
    {
        Allparts.Add(part);
    }
    // Adds new product to the inventory
    public static void AddProduct(Product product)
    {
        Products.Add(product);

    }

    // Removes part from inventory
    // I am calling this only after its confirmed that the part is not associated with the product
   public static void deletePart(Part part)
    {
        Allparts.Remove(part);
    }
    

}



