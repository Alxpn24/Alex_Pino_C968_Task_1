using System;
using InventorySystem_AlexPino.Models;
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
    // Fields -- Holds list of the associated parts with the new product
    public partial class AddProduct : Form
    {
        private BindingList<Part> associatedParts = new BindingList<Part>();

        // Constructer -- Initializes form and preps both DataGridViews
        public AddProduct()
        {
            InitializeComponent();
            InitializeGrids();

        }
        // Grid Initialization -- Sets up the available parts grid and associated parts grid 
        private void InitializeGrids()
        {
            // All parts grid

            dataGridView1.DataSource = Inventory.Allparts;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoGenerateColumns = true;
            
            //Associated parts grid

            dataGridView2.DataSource = associatedParts;
            dataGridView2.MultiSelect = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AutoGenerateColumns = true;



        }

        // Add part to product -- Adds the selected part from the top grid to associated list
        private void Add3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Please select part to add to product");
                return;
            }

            Part selecedPart = dataGridView1.CurrentRow.DataBoundItem as Part;

            if (selecedPart == null)
            {
                MessageBox.Show("Unable to read selected part");
                return;
            }

            if (associatedParts.Contains(selecedPart))
            {
                MessageBox.Show("Part is associated with the product already");
                return;
            }

            associatedParts.Add(selecedPart);
        }
        // Remove part form prodcut -- Removes the associated part from the bottom gird
        private void Delete1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null || dataGridView2.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Must select part to remove from selected product");
                return;
            }

            Part selectedPart = dataGridView2.CurrentRow.DataBoundItem as Part;

            if (selectedPart == null)
            {
                MessageBox.Show("Unable to read selected associated part");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Do you want to remove this part from the product?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                associatedParts.Remove(selectedPart);
            }
        }
        // Save Product -- Builds new product, validates input, and adds to inventory
        private void Save1_Click(object sender, EventArgs e)
        {
            int id;
            int stock;
            double price;
            int min;
            int max;

            // ID Validation

            string idText = ID4.Text;
            if (string.IsNullOrWhiteSpace(idText))
            {
                MessageBox.Show("Must enter valid Product ID");
                return;

            }

            if (!int.TryParse(idText, out id))
            {
                MessageBox.Show("Product ID must be whole number");
                return;
            }
            // Name Validation

            string name = Name4.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Product name can't be empty");
                return;
            }
            // Inventory Validation

            string stockText = Stock4.Text;
            if (string.IsNullOrWhiteSpace(stockText))
            {
                MessageBox.Show("Inentory can't be empty");
                return;
            }

            if (!int.TryParse(stockText, out stock))
            {
                MessageBox.Show("Inventory must be whole number");
                return;
            }
            // Price Validation

            string priceText = Price4.Text;
            if (string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("Must enter price");
                return;

            }

            if (!double.TryParse(priceText, out price))
            {
                MessageBox.Show("Price must be valid number");
                return;
            }

            // Min Validation

            string minText = Min4.Text;
            if (!int.TryParse(minText, out min))
            {
                MessageBox.Show("Min must be whole number");
                return;
            }
            // Max Validation

            string maxText = Max4.Text;
            if (!int.TryParse(maxText, out max))
            {
                MessageBox.Show("Max must be whole number");
                return;
            }
            // Logical Validation

            if (min > max)
            {
                MessageBox.Show("Min must be less or equal to max");
                return;
                ;
            }

            if (stock < min || stock > max)
            {
                MessageBox.Show("Inventoruy must be between min and max");
                return;

            }

            if (associatedParts.Count == 0)
            {
                MessageBox.Show("Product must have atleast a signge associated part");
                return;

            }
            // Validate associated parts vs price

            double totalPrice = 0.0;
            foreach (Part part in associatedParts)
            {
                totalPrice = totalPrice + part.Price;
            }

            if (price < totalPrice)
            {
                MessageBox.Show("Product price can't be less than total price of the associated parts");
                return;
            }
            // Build new product

            Product newProduct = new Product
            {
                ProductID = id,
                Name = name,
                InStock = stock,
                Price = price,
                Min = min,
                Max = max,
                AssociatedParts = new BindingList<Part>()
            };

            foreach (Part part in associatedParts)
            {
                newProduct.AssociatedParts.Add(part);
            }
            // Add produt to the inventory

            Inventory.Products.Add(newProduct);

            this.Close();

        }

        private void Cancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Search -- Allows searching by name or ID
        private void Search2_Click(object sender, EventArgs e)
        {
            string searchText = SearchBox1.Text;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Enter a part ID or Name");
                return;
            }

            searchText = searchText.Trim();
            bool foundMatch = false;

            // ID search first

            int searchId;
            bool isNumber = int.TryParse(searchText, out searchId);

            if (isNumber)
            {
                for (int i = 0; i <dataGridView1.Rows.Count; i++)
                {
                    Part rowPart = dataGridView1.Rows[i].DataBoundItem as Part;

                    if (rowPart == null)
                    {
                        continue;
                    }

                    if (rowPart.PartID == searchId)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        foundMatch = true;
                        break;
                    }
                }
            }

            //Name search if no ID found

            if (!foundMatch)
            {
                string loweredSearch = searchText.ToLower();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Part rowPart = dataGridView1.Rows[i].DataBoundItem as Part;

                    if (rowPart == null)
                    {
                        continue;   
                    }

                    if (!string.IsNullOrEmpty(rowPart.Name))
                    {
                        string loweredName = rowPart.Name.ToLower();

                        if (loweredName.Contains(loweredSearch))
                        {
                            dataGridView1.ClearSelection();
                            dataGridView1.Rows[i].Selected = true;
                            dataGridView1.CurrentCell = dataGridView1.Rows[i ].Cells[0];
                            dataGridView1.FirstDisplayedScrollingRowIndex = i;
                            foundMatch = true; 
                            break;
                        }
                    }
                }
            }

            if (!foundMatch)
            {
                MessageBox.Show("No matching part was found");
                dataGridView1.ClearSelection();
            }

        }
    }
}
