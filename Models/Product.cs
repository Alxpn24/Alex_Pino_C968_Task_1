using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem_AlexPino.Models
{
    public class Product
    {
        // Parts list that are associated with this product
        // A BindingList was chosen so that the UI updates accordingly when items change
        public BindingList<Part> AssociatedParts { get; set; } = new BindingList<Part>();
        // Unique identifier for product
        public int ProductID { get; set; }
        // Price for the product
        public double Price { get; set; }
        // Name of product
        public string? Name { get; set; }
        // Currenty inventroy level
        public int InStock { get; set; }
        //Minimum allowed inventory
        public int Min { get; set; }
        // Maximum allowed inventory
        public int Max { get; set; }


    }
}
