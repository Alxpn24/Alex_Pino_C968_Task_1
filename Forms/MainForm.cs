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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Intializing of the DataGridViews is done here so the inventory lists will
            // load as soon as possible
            InitializeDataGrids();
        }




        private void InitializeDataGrids()
        {


            // PARTS GRID SETUP
            // Bind parts grid to the master list of parts
            // BindingList used here to updated grids accordingly when items are changed
            View_1.DataSource = Inventory.Allparts;
            View_1.MultiSelect = false;
            View_1.AllowUserToAddRows = false;
            View_1.AutoGenerateColumns = true;
            View_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            View_1.ReadOnly = true;



            // PARTS GRID SETUP
            // Same idea as parts grid
            View_2.DataSource = Inventory.Products;
            View_2.MultiSelect = false;
            View_2.AllowUserToAddRows = false;
            View_2.AutoGenerateColumns = true;
            View_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            View_2.ReadOnly = true;


        }
        // Open Add Part form
        private void add_part_Click(object sender, EventArgs e)
        {
            var addPartform = new AddPart();
            addPartform.ShowDialog(); // Used to pause main form until user finishes
         
        }
        // Deletes selected part after verifying its associations 
        private void Delete1_Click(object sender, EventArgs e)
        {
            Part selectedPart;

            // Verification user has actually selected a row
            var currentRow = View_1.CurrentRow;

            if (currentRow == null || currentRow.DataBoundItem == null)
            {
                MessageBox.Show("Please select part you wish to delete");
                return;
            }

            selectedPart = (Part)currentRow.DataBoundItem;
            
            // Verify if part is associated with any product before deleting
            bool partIsAssociated = false;


            foreach (Product product in Inventory.Products)
            {
                if (product.AssociatedParts != null)
                {
                    foreach (Part part in product.AssociatedParts)
                    {
                        if (part == selectedPart)
                        {
                            partIsAssociated = true;
                            break;
                        }
                    }
                }
                if (partIsAssociated)
                {
                    break;
                }
            }

            // If its associated deletion is blocked 
            if (partIsAssociated)
            {
                MessageBox.Show("Can't delete part becauese its associated with a product. Remove from product first");
                return;
            }
            // Confirm deletion
            var confirm = MessageBox.Show("Are you sure you'd like to delete this item?",
                "Confirm Y/N",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (confirm == DialogResult.Yes)
            {
                Part deletePart = (Part)currentRow.DataBoundItem;
                Inventory.deletePart(deletePart);
            }

            else
            {
                return;
            }


        }
        // Opens modify part form with the selected part
        private void Modify1_Click(object sender, EventArgs e)
        {
            if (View_1.CurrentRow == null || View_1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Please select the part you want to modify");
                return;
            }

            Part selectedPart = (Part)View_1.CurrentRow.DataBoundItem;

            // Pass selected part into the modify part form
            using (var modifyForm = new ModifyPart(selectedPart))
            {
                modifyForm.ShowDialog();
            }
            // Refresh grid so that changes show immediately
            View_1.Refresh();

        }
        // Open modify product form
        private void Modify2_Click(object sender, EventArgs e)
        {
            if (View_2.CurrentRow == null || View_2.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Must select product to modify");
                return;
            }

            Product selectedProduct = View_2.CurrentRow.DataBoundItem as Product;

            if (selectedProduct == null)
            {
                MessageBox.Show("Selected product unreadable");
                return;
            }

            using (var modifyProductForm = new ModifyProduct(selectedProduct))
            {
                modifyProductForm.ShowDialog();
            }

            View_2.Refresh();
        }
        // OPen add product form
        private void Add2_Click(object sender, EventArgs e)
        {
            using (var addProductForm = new AddProduct())
            {
                addProductForm.ShowDialog();
            }

            View_2.Refresh();
        }

        // Deletes product after verifying associated parts
        private void Delete2_Click(object sender, EventArgs e)
        {
            if (View_2.CurrentRow == null || View_2.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Please select product you want to delete");
                return;
            }

            Product selectedProduct = View_2.CurrentRow.DataBoundItem as Product;

            if (selectedProduct == null)
            {
                MessageBox.Show("Can't read the selected product");
                return;
            }
            // Cannot delete product if it still has associated parts
            if (selectedProduct.AssociatedParts != null && selectedProduct.AssociatedParts.Count > 0)
            {
                MessageBox.Show("Can't delete product that has associated parts. Must removed associated parts first");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Do you want to delete this product?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Inventory.Products.Remove(selectedProduct);
            }

            else
            {
                return;
            }
        }
        // Search by part ID or name
        private void SearchButton1_Click(object sender, EventArgs e)
        {
            string searchText = Search1.Text;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Enter a name or part ID to search");
                return;
            }


            searchText = searchText.Trim();
            bool foundMatch = false;

            // Id search first
            int searchId;
            bool isNumber = int.TryParse(searchText, out searchId);


            if (isNumber)
            {
                // Manually loop through rows so I can highlight a match (if any)
                for (int i = 0; i < View_1.Rows.Count; i++)
                {
                    Part rowPart = View_1.Rows[i].DataBoundItem as Part;


                    if (rowPart == null)
                    {
                        continue;
                    }

                    if (rowPart.PartID == searchId)
                    {
                        View_1.ClearSelection();
                        View_1.Rows[i].Selected = true;
                        View_1.CurrentCell = View_1.Rows[i].Cells[0];
                        View_1.FirstDisplayedScrollingRowIndex = i;
                        foundMatch = true;
                        break;


                    }

                }
            }
            // If no ID match found, continue to search by name
            if (!foundMatch)
            {
                string loweredSearch = searchText.ToLower();

                for (int i = 0; i < View_1.Rows.Count; i++)
                {
                    Part rowPart = View_1.Rows[i].DataBoundItem as Part;

                    if (rowPart == null)
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(rowPart.Name))
                    {
                        string loweredName = rowPart.Name.ToLower();

                        if (loweredName.Contains(loweredSearch))
                        {
                            View_1.ClearSelection();
                            View_1.Rows[i].Selected = true;
                            View_1.CurrentCell = View_1.Rows[i].Cells[0];
                            View_1.FirstDisplayedScrollingRowIndex = i;
                            foundMatch = true;
                            break;
                        }
                    }
                }
            }

            if (!foundMatch)
            {
                MessageBox.Show("No matching parts were found");
                View_1?.ClearSelection();
            }
        }





        // Search by ID or name for product
        private void SearchButton2_Click(object sender, EventArgs e)
        {
            string searchText = Search2.Text;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Enter name or product ID to search");
                return;
            }

            searchText = searchText.ToLower();
            bool foundMatch = false;

            int searchId;
            bool isNumber = int.TryParse(searchText, out searchId);

            // ID search first
            if (isNumber)

            {
                for (int i = 0; i < View_2.Rows.Count; i++)
                {
                    Product rowProduct = View_2.Rows[i].DataBoundItem as Product;


                    if (rowProduct == null)
                    {
                        continue;
                    }

                    if (rowProduct.ProductID == searchId)
                    {
                        View_2.ClearSelection();
                        View_2.Rows[i].Selected = true;
                        View_2.CurrentCell = View_2.Rows[i].Cells[0];
                        View_2.FirstDisplayedScrollingRowIndex = i;
                        foundMatch = true;
                        break;
                    }
                }
            }
            // Now search by name
            if (!foundMatch)
            {
                string loweredSearch = searchText;

                for (int i = 0; i < View_2.Rows.Count; i++)
                {
                    Product rowProduct = View_2.Rows[i].DataBoundItem as Product;

                    if (rowProduct == null)
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(rowProduct.Name))
                    {

                        string loweredName = rowProduct.Name.ToLower();

                        if (loweredName.Contains(loweredSearch))
                        {
                            View_2.ClearSelection();
                            View_2.Rows[i].Selected = true;
                            View_2.CurrentCell = View_2.Rows[i].Cells[0];
                            View_2.FirstDisplayedScrollingRowIndex = i;
                            foundMatch = true;
                            break;


                        }
                    }
                }

                if (!foundMatch)
                {
                    MessageBox.Show("No product found");
                    View_2.ClearSelection();
                }
            }



        }
        // Close application 
        private void Exit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
