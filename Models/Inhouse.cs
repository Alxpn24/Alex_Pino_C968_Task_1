using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem_AlexPino.Models
{
    // Representation of a part that is internally manufactured
    // Inherits all shared fields from Part
    internal class InHouse : Part
    {
        // The machine ID is used to produce this part
        // This only will apply to InHouse parts
        public int MachineID { get; set; }

    }
}
