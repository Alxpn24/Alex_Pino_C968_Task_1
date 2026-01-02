using InventorySystem_AlexPino.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem_AlexPino
{
    public partial class ModifyPart : Form
    {
        // Fields - Stores original part being edited

        private Part originalPart;

        // Constructer -- Selected part is loaded into form for editing
        public ModifyPart(Part partToEdit)
        {
            InitializeComponent();

            originalPart = partToEdit;

            // Exsisting part data populates the form fields

            ID2.Text = originalPart.PartID.ToString();
            Name2.Text = originalPart.Name;
            Stock2.Text = originalPart.InStock.ToString();
            Cost2.Text = originalPart.Price.ToString();
            Max2.Text = originalPart.Max.ToString();
            Min2.Text = originalPart.Min.ToString();

            // Determine the part type and update the UI accordingly

            if (originalPart is InHouse inHousePart)
            {
                InHouse2.Checked = true;
                MachineId3.Text = "Machine ID";
                MachineId3Text.Text = inHousePart.MachineID.ToString();

            }

            else if (originalPart is Outsourced outsourcedPart)
            {

                Outsourced2.Checked = true;
                MachineId3.Text = "Company Name";
                MachineId3Text.Text = outsourcedPart.CompanyName;

            }



        }
        // Radio button event handlers -- Switch label depending on part type selection
        private void Outsourced2_CheckedChanged(object sender, EventArgs e)
        {
            if (Outsourced2.Checked)
            {
                MachineId3.Text = "Company Name";
            }
        }

        private void InHouse2_CheckedChanged(object sender, EventArgs e)
        {
            if (InHouse2.Checked)
            {
                MachineId3.Text = "Machine ID";
            }
        }

        // Save button logic -- Updates the part in inventory and validates input
        private void Save2_Click(object sender, EventArgs e)
        {
            int id;
            int stock;
            double price;
            int min;
            int max;

            // ID Validation

            string idText = ID2.Text;
            if (string.IsNullOrWhiteSpace(idText))
            {
                MessageBox.Show("Please enter a valid ID");
                return;
            }

            if (!int.TryParse(idText, out id))
            {
                MessageBox.Show("ID must be whole number. No decimals");
                return;
            }
            // Name Validation

            string name = Name2.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Must enter name. Cannot be blank");
                return;
            }
            // Inventory Validation

            string stockText = Stock2.Text;
            if (string.IsNullOrEmpty(stockText))
            {
                MessageBox.Show("Inventory cannot be empty");
                return;
            }

            if (!int.TryParse(stockText, out stock))
            {
                MessageBox.Show("Inventory must be whole number");
                return;
            }
            // Price Validation

            string priceText = Cost2.Text;
            if (string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("Must enter a price");
                return;
            }

            if (!double.TryParse(priceText, out price))
            {
                MessageBox.Show("Price must be a valid number");
                return;
            }

            // Min/Max Validation

            if (!int.TryParse(Min2.Text, out min) ||
                !int.TryParse(Max2.Text, out max))
            {
                MessageBox.Show("Min and max must be whole numbers");
                return;

            }

            if (min > max)
            {
                MessageBox.Show("Min must be less than or equal to max");
                return;
            }

            if (stock < min || stock > max)
            {
                MessageBox.Show("Inventory must be between the min and max");
                return;
            }

            // Build updated part -- Either create In-house, or Outsourced based on the selection

            Part updatedPart;

            if (InHouse2.Checked)
            {
                if (!int.TryParse(MachineId3Text.Text, out int machineId))
                {
                    MessageBox.Show("Machine ID must be a valid number");
                    return;
                }

                updatedPart = new InHouse
                {
                    PartID = id,
                    Name = name,
                    InStock = stock,
                    Price = price,
                    Min = min,
                    Max = max,
                    MachineID = machineId
                };
            }

            else if (Outsourced2.Checked == true)
            {
                string companyName = MachineId3Text.Text;

                if (string.IsNullOrEmpty(companyName))
                {
                    MessageBox.Show("Must enter company name for outsourced");
                    return;
                }

                updatedPart = new Outsourced
                {
                    PartID = id,
                    Name = name,
                    InStock = stock,
                    Price = price,
                    Min = min,
                    Max = max,
                    CompanyName = companyName
                };
            }

            else
            {
                MessageBox.Show("Must have outsoured or in-house selected");
                return;
            }

            // Update Inventory -- Replace the original part with the updated version

            int index = Inventory.Allparts.IndexOf(originalPart);
            if (index == -1)
            {
                MessageBox.Show("Couldn't find orginal part in inventory");
                return;
            }


            Inventory.Allparts[index] = updatedPart;

            this.Close();

                
            
        }
    }
}
