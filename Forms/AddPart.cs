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
    public partial class AddPart : Form
    {
        public AddPart()
        {
            InitializeComponent();
            // Default the form to In-House
            InHouse1.Checked = true;

        }

        // If the user selects outsourced, clear the field and update the label
        private void Outsourced1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Outsourced1.Checked)
            {
                // "Company Name" replaces Machine ID for outsourced parts
                Machine1.Text = "Company Name";
                MachineId1.Text = "";
            }
        }
        
        // When In-house is selected, clear the field and update the label
        private void InHouse1_CheckedChanged(object sender, EventArgs e)
        {
            if (InHouse1.Checked)
            {
                // Machine ID is requirement for In-House parts

                Machine1.Text = "Machine ID";
                MachineId1.Text = "";
            }

        }


        // Validation handling and creation of a new part when user selects save
        private void SavePart_Click(object sender, EventArgs e)
        {
            int id;
            int stock;
            double price;
            int min;
            int max;

            // ID Validation

            string idText = ID.Text;
            if (string.IsNullOrWhiteSpace(idText))
            {
                MessageBox.Show("Please enter valid ID");
                return;
            }

            if (!int.TryParse(idText, out id))
            {
                MessageBox.Show("ID must be whole number");
                return;
            }
            // Name Validation

            string name = Name1.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name field must not be empty");
                return;
            }
            // Inventory Validation

            string inventoryText = Inventory1.Text;
            if (string.IsNullOrWhiteSpace(inventoryText))
            {
                MessageBox.Show("Inventory can't be empty");
                return;
            }

            if (!int.TryParse(inventoryText, out stock))
            {
                MessageBox.Show("Inventory must be whole number");
                return;
            }
            // Price Validation

            string priceText = Price1.Text;
            if (string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("Must enter price");
                return;
            }

            if (!double.TryParse(priceText, out price))
            {
                MessageBox.Show("Price must be a valid number");
                return;
            }
            // Min Validation

            string minText = Min1.Text;
            if (!int.TryParse(minText, out min))
            {
                MessageBox.Show("Min must be whole number");
                return;
            }
            // Max Validation

            string maxText = Max1.Text;
            if (!int.TryParse(maxText, out max))
            {
                MessageBox.Show("Max must be whole number");
                return;
            }
            // Inventory constraints

            if (min > max)
            {
                MessageBox.Show("Min must be less than max");
                return;
            }

            if (stock < min || stock > max)
            {
                MessageBox.Show("Inventory must be between min and max");
                return;
            }
            // Either outsourced object or In-House object is held here pending selection

            Part newPart;

            // Creation of In-House part

            if (InHouse1.Checked == true)
            {
                string machineIdText = MachineId1.Text;
                int machineId;

                if (string.IsNullOrWhiteSpace(machineIdText))
                {
                    MessageBox.Show("Machine ID is required for In-House");
                    return;
                }

                if (!int.TryParse(machineIdText, out machineId))
                {
                    MessageBox.Show("Machine ID must be whole number");
                    return;
                }

                // Build the In-House part using validated input
                newPart = new InHouse
                {
                    PartID = id,
                    Name = name,
                    InStock = stock,
                    Price = price,
                    Max = max,
                    Min = min,
                    MachineID = machineId
                };
            }
            // Outsourced part creation

            else if (Outsourced1.Checked == true)
            {
                string companyName = MachineId1.Text;

                if (string.IsNullOrWhiteSpace(companyName))
                {
                    MessageBox.Show("Company name required for outsourced");
                    return;
                }

                newPart = new Outsourced
                {
                    PartID = id,
                    Name = name,
                    InStock = stock,
                    Price = price,
                    Max = max,
                    Min = min,
                    CompanyName = companyName
                };
            }
            else
            {
                // Only occurs when either radio button isn't selected

                MessageBox.Show("Select in-house or outsourced");
                return;
            }

            // Part is added to inventory and form is closed

            Inventory.AddPart(newPart);


            this.Close();


        }
        // Closes form without saving anything
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
