using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem_AlexPino.Models
{
   
    // The base class for all of the parts in the inventory.
    // Both InHouse and Outsourced inherit from this.
    public class Part
    {
        // Unique ID for the part
        public int PartID { get; set; }

        // Display the name of the part
        public string? Name { get; set; }

        // Cost or the price of a single unit
        public double Price { get; set; }

        // Current available quantity
        public int InStock { get; set; }

        // Minimum inventory level allowed
        public int Min {  get; set; }

        // Maximum invetory level allowed
        public int Max { get; set; }


    }
}
