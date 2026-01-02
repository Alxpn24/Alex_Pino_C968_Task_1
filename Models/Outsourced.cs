using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem_AlexPino.Models
{
    // Representation of parts that are purchased externaly from another company
    internal class Outsourced : Part
    {
        // Company name that supplies the part
        public string? CompanyName { get; set; }
    }
}
