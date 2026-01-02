namespace InventorySystem_AlexPino
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Search1 = new TextBox();
            SearchButton1 = new Button();
            View_1 = new DataGridView();
            add_part = new Button();
            Modify1 = new Button();
            Delete1 = new Button();
            Exit1 = new Button();
            Delete2 = new Button();
            Modify2 = new Button();
            Add2 = new Button();
            View_2 = new DataGridView();
            SearchButton2 = new Button();
            Search2 = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)View_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)View_2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(259, 42);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 15);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(413, 40);
            label2.TabIndex = 1;
            label2.Text = "Inventroy Management System";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(40, 145);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 40);
            label3.TabIndex = 2;
            label3.Text = "Parts";
            // 
            // Search1
            // 
            Search1.Location = new Point(351, 153);
            Search1.Margin = new Padding(4, 5, 4, 5);
            Search1.Name = "Search1";
            Search1.Size = new Size(335, 31);
            Search1.TabIndex = 3;
            // 
            // SearchButton1
            // 
            SearchButton1.Location = new Point(239, 153);
            SearchButton1.Margin = new Padding(4, 5, 4, 5);
            SearchButton1.Name = "SearchButton1";
            SearchButton1.Size = new Size(83, 33);
            SearchButton1.TabIndex = 4;
            SearchButton1.Text = "Search";
            SearchButton1.UseVisualStyleBackColor = true;
            SearchButton1.Click += SearchButton1_Click;
            // 
            // View_1
            // 
            View_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            View_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            View_1.Location = new Point(40, 230);
            View_1.Margin = new Padding(4, 5, 4, 5);
            View_1.MultiSelect = false;
            View_1.Name = "View_1";
            View_1.ReadOnly = true;
            View_1.RowHeadersWidth = 62;
            View_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            View_1.Size = new Size(649, 320);
            View_1.TabIndex = 5;
            // 
            // add_part
            // 
            add_part.Location = new Point(353, 575);
            add_part.Margin = new Padding(4, 5, 4, 5);
            add_part.Name = "add_part";
            add_part.Size = new Size(77, 38);
            add_part.TabIndex = 6;
            add_part.Text = "Add";
            add_part.UseVisualStyleBackColor = true;
            add_part.Click += add_part_Click;
            // 
            // Modify1
            // 
            Modify1.Location = new Point(460, 575);
            Modify1.Margin = new Padding(4, 5, 4, 5);
            Modify1.Name = "Modify1";
            Modify1.Size = new Size(101, 38);
            Modify1.TabIndex = 7;
            Modify1.Text = "Modify";
            Modify1.UseVisualStyleBackColor = true;
            Modify1.Click += Modify1_Click;
            // 
            // Delete1
            // 
            Delete1.Location = new Point(591, 575);
            Delete1.Margin = new Padding(4, 5, 4, 5);
            Delete1.Name = "Delete1";
            Delete1.Size = new Size(97, 38);
            Delete1.TabIndex = 8;
            Delete1.Text = "Delete";
            Delete1.UseVisualStyleBackColor = true;
            Delete1.Click += Delete1_Click;
            // 
            // Exit1
            // 
            Exit1.Location = new Point(1296, 647);
            Exit1.Margin = new Padding(4, 5, 4, 5);
            Exit1.Name = "Exit1";
            Exit1.Size = new Size(97, 38);
            Exit1.TabIndex = 18;
            Exit1.Text = "Exit";
            Exit1.UseVisualStyleBackColor = true;
            Exit1.Click += Exit1_Click;
            // 
            // Delete2
            // 
            Delete2.Location = new Point(1296, 575);
            Delete2.Margin = new Padding(4, 5, 4, 5);
            Delete2.Name = "Delete2";
            Delete2.Size = new Size(97, 38);
            Delete2.TabIndex = 25;
            Delete2.Text = "Delete";
            Delete2.UseVisualStyleBackColor = true;
            Delete2.Click += Delete2_Click;
            // 
            // Modify2
            // 
            Modify2.Location = new Point(1164, 575);
            Modify2.Margin = new Padding(4, 5, 4, 5);
            Modify2.Name = "Modify2";
            Modify2.Size = new Size(101, 38);
            Modify2.TabIndex = 24;
            Modify2.Text = "Modify";
            Modify2.UseVisualStyleBackColor = true;
            Modify2.Click += Modify2_Click;
            // 
            // Add2
            // 
            Add2.Location = new Point(1057, 575);
            Add2.Margin = new Padding(4, 5, 4, 5);
            Add2.Name = "Add2";
            Add2.Size = new Size(77, 38);
            Add2.TabIndex = 23;
            Add2.Text = "Add";
            Add2.UseVisualStyleBackColor = true;
            Add2.Click += Add2_Click;
            // 
            // View_2
            // 
            View_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            View_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            View_2.Location = new Point(744, 230);
            View_2.Margin = new Padding(4, 5, 4, 5);
            View_2.MultiSelect = false;
            View_2.Name = "View_2";
            View_2.ReadOnly = true;
            View_2.RowHeadersWidth = 62;
            View_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            View_2.Size = new Size(649, 320);
            View_2.TabIndex = 22;
            // 
            // SearchButton2
            // 
            SearchButton2.Location = new Point(943, 153);
            SearchButton2.Margin = new Padding(4, 5, 4, 5);
            SearchButton2.Name = "SearchButton2";
            SearchButton2.Size = new Size(83, 33);
            SearchButton2.TabIndex = 21;
            SearchButton2.Text = "Search";
            SearchButton2.UseVisualStyleBackColor = true;
            SearchButton2.Click += SearchButton2_Click;
            // 
            // Search2
            // 
            Search2.Location = new Point(1056, 153);
            Search2.Margin = new Padding(4, 5, 4, 5);
            Search2.Name = "Search2";
            Search2.Size = new Size(335, 31);
            Search2.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(744, 145);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(137, 40);
            label4.TabIndex = 19;
            label4.Text = "Inventory";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1423, 752);
            Controls.Add(Delete2);
            Controls.Add(Modify2);
            Controls.Add(Add2);
            Controls.Add(View_2);
            Controls.Add(SearchButton2);
            Controls.Add(Search2);
            Controls.Add(label4);
            Controls.Add(Exit1);
            Controls.Add(Delete1);
            Controls.Add(Modify1);
            Controls.Add(add_part);
            Controls.Add(View_1);
            Controls.Add(SearchButton1);
            Controls.Add(Search1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)View_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)View_2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox Search1;
        private Button SearchButton1;
        private DataGridView View_1;
        private Button add_part;
        private Button Modify1;
        private Button Delete1;
        private Button Exit1;
        private Button Delete2;
        private Button Modify2;
        private Button Add2;
        private DataGridView View_2;
        private Button SearchButton2;
        private TextBox Search2;
        private Label label4;
    }
}