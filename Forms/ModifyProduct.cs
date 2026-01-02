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
    public partial class ModifyProduct : Form
    {

        // Stores original product as well as a working list of the assoiated parts
        private Product originalProduct;
        private BindingList<Part> associatedParts = new BindingList<Part>();

        // Default constructer -- Only used when the form is opened without a product
        public ModifyProduct()
        {
            InitializeComponent();

        }
        // Overloaded constructer -- The selected product is loaded into form for editing
        public ModifyProduct(Product productToEdit)
        {
            InitializeComponent();

            originalProduct = productToEdit;

            InitializeGrids();
            // Populate the form fields with exisitng product data

            ID3.Text = originalProduct.ProductID.ToString();
            Name3.Text = originalProduct.Name;
            Stock3.Text = originalProduct.InStock.ToString();
            Price3.Text = originalProduct.Price.ToString();
            Min3.Text = originalProduct.Min.ToString();
            Max3.Text = originalProduct.Max.ToString();


            // Copy the exisiting associated parts into a working list

            if (originalProduct.AssociatedParts != null)
            {
                foreach (Part p in originalProduct.AssociatedParts)
                {
                    associatedParts.Add(p);
                }
            }

            dataGridView2.DataSource = associatedParts;


        }
        // Initialize Grids -- Both DataGridViews are set up for associated and available parts
        private void InitializeGrids()
        {
            // Parts grid

            dataGridView1.DataSource = Inventory.Allparts;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoGenerateColumns = true;

            // Associated parts grid

            dataGridView2.DataSource = associatedParts;
            dataGridView2.MultiSelect = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AutoGenerateColumns = true;




        }
        // Selected part is added from the top grid to the associated list
        private void Add3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Must select part to add to current product");
                return;
            }

            Part selectedPart = dataGridView1.CurrentRow.DataBoundItem as Part;

            if (selectedPart == null)
            {
                MessageBox.Show("Selected part unreadable");
                return;

            }

            if (associatedParts.Contains(selectedPart))
            {
                MessageBox.Show("Part is already associated with product");
                return;
            }

            associatedParts.Add(selectedPart);
        }

        // Selected associated part is removed from bottom grid
        private void Delete3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null || dataGridView2.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Select part to remove from this product");
                return;
            }

            Part selectedPart = dataGridView2.CurrentRow.DataBoundItem as Part;

            if (selectedPart == null)
            {
                MessageBox.Show("Unable to read the selected part");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to remove part from this product?",
                "Confirm removal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                associatedParts.Remove(selectedPart);
            }


        }
        // Input validation, updates inventory, rebuilds product
        private void Save3_Click(object sender, EventArgs e)
        {
            int id;
            int stock;
            double price;
            int min;
            int max;

            // ID Validation

            string idText = ID3.Text;
            if (string.IsNullOrWhiteSpace(idText))
            {
                MessageBox.Show("Please enter a valid ID for product");
                return;
            }

            if (!int.TryParse(idText, out id))
            {
                MessageBox.Show("Produt ID must be whole number");
                return;
            }
            // Name Validation

            string name = Name3.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Product name can't be empty");
                return;
            }
            // Inventory Validation

            string stockText = Stock3.Text;
            if (string.IsNullOrWhiteSpace(stockText))
            {
                MessageBox.Show("Invetory can't be empty");
                return;
            }

            if (!int.TryParse(stockText, out stock))
            {
                MessageBox.Show("Inventory must be whole number");
                return;
            }
            // Price Validation

            string priceText = Price3.Text;
            if (string.IsNullOrWhiteSpace(priceText))
            {
                MessageBox.Show("Price required");
                return;
            }

            if (!double.TryParse(priceText, out price))
            {
                MessageBox.Show("Price must be valid number");
                return;
            }
            // Min Validation 

            string minText = Min3.Text;
            if (!int.TryParse(minText, out min))
            {
                MessageBox.Show("Min must be whole number");
                return;

            }
            // Max Validation

            string maxText = Max3.Text;
            if (!int.TryParse(maxText, out max))
            {
                MessageBox.Show("Max must be whole number");
                return;
            }
            // Logic Validation

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
            // Validate associated parts vs price

            double totalPrice = 0.0;
            foreach (Part part in associatedParts)
            {
                totalPrice = totalPrice + part.Price;
            }

            if (price < totalPrice)
            {
                MessageBox.Show("Product price can't be less than totall price of associated parts");
                return;
            }
            // Build updated product

            Product updatedProduct = new Product
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
                updatedProduct.AssociatedParts.Add(part);
            }
            // Replace the original product in inventory

            int index = Inventory.Products.IndexOf(originalProduct);
            if (index == -1)
            {
                MessageBox.Show("Can't locate original product in inventory");
                return;
            }

            Inventory.Products[index] = updatedProduct;

            this.Close();

        }
        // Search for parts by ID or name
        private void Search3_Click(object sender, EventArgs e)
        {
            string searchText = SearchBox3.Text;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Enter Part ID or Name");
                return;
            }

            searchText = searchText.Trim();
            bool foundMatch = false;
            // ID search first

            int searchId;
            bool isNumber = int.TryParse(searchText, out searchId);

            if (isNumber)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
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
            // Name search if not found

            if (!foundMatch)
            {
                string loweredSearch = searchText.ToLower();

                for (int i = 0; i < dataGridView1.Rows.Count;i++)
                {
                    Part rowPart = dataGridView1.Rows [i].DataBoundItem as Part;

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
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells [0];
                            foundMatch = true;
                            break;
                        }
                    }
                }
            }
            if (!foundMatch)
            {
                MessageBox.Show("No matching part was found");
                dataGridView1.ClearSelection ();
            }
        }
    }
}
