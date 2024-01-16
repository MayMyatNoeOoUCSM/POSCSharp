
namespace POS_Admin.Views.DamageLoss
{
    partial class UCDamageLoss
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpCategory = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvDamageLoss = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damageloss = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dl_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selling_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblSubCategoryName = new System.Windows.Forms.Label();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboProduct = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboSubCategory = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCategory = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboSupplier = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.gpCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageLoss)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpCategory
            // 
            this.gpCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpCategory.BackColor = System.Drawing.Color.White;
            this.gpCategory.Controls.Add(this.btnClear);
            this.gpCategory.Controls.Add(this.btnBack);
            this.gpCategory.Controls.Add(this.btnSubmit);
            this.gpCategory.Controls.Add(this.dgvDamageLoss);
            this.gpCategory.Controls.Add(this.btnAdd);
            this.gpCategory.Controls.Add(this.label3);
            this.gpCategory.Controls.Add(this.label1);
            this.gpCategory.Controls.Add(this.label24);
            this.gpCategory.Controls.Add(this.lblSubCategoryName);
            this.gpCategory.Controls.Add(this.lblCategoryName);
            this.gpCategory.Controls.Add(this.lblProduct);
            this.gpCategory.Controls.Add(this.lblSupplierName);
            this.gpCategory.Controls.Add(this.groupBox4);
            this.gpCategory.Controls.Add(this.groupBox3);
            this.gpCategory.Controls.Add(this.groupBox1);
            this.gpCategory.Controls.Add(this.groupBox2);
            this.gpCategory.Controls.Add(this.pnlHeader);
            this.gpCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gpCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpCategory.Location = new System.Drawing.Point(27, 14);
            this.gpCategory.Name = "gpCategory";
            this.gpCategory.Size = new System.Drawing.Size(1082, 616);
            this.gpCategory.TabIndex = 127;
            this.gpCategory.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(230, 533);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 42);
            this.btnClear.TabIndex = 658;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(122, 533);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(85, 42);
            this.btnBack.TabIndex = 657;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnBack.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnBack.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(14, 533);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(85, 42);
            this.btnSubmit.TabIndex = 656;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnSubmit.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnSubmit.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // dgvDamageLoss
            // 
            this.dgvDamageLoss.AllowUserToAddRows = false;
            this.dgvDamageLoss.AllowUserToResizeColumns = false;
            this.dgvDamageLoss.AllowUserToResizeRows = false;
            this.dgvDamageLoss.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDamageLoss.BackgroundColor = System.Drawing.Color.White;
            this.dgvDamageLoss.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDamageLoss.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDamageLoss.ColumnHeadersHeight = 42;
            this.dgvDamageLoss.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.product_name,
            this.damageloss,
            this.dl_qty,
            this.selling_price,
            this.remark,
            this.delete,
            this.qty});
            this.dgvDamageLoss.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDamageLoss.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDamageLoss.EnableHeadersVisualStyles = false;
            this.dgvDamageLoss.Location = new System.Drawing.Point(14, 295);
            this.dgvDamageLoss.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDamageLoss.Name = "dgvDamageLoss";
            this.dgvDamageLoss.RowHeadersVisible = false;
            this.dgvDamageLoss.RowHeadersWidth = 51;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvDamageLoss.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDamageLoss.RowTemplate.Height = 40;
            this.dgvDamageLoss.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDamageLoss.Size = new System.Drawing.Size(1053, 197);
            this.dgvDamageLoss.TabIndex = 655;
            this.dgvDamageLoss.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDamageLoss_CellContentClick);
            this.dgvDamageLoss.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDamageLoss_CellFormatting);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // product_name
            // 
            this.product_name.DataPropertyName = "product_name";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.product_name.DefaultCellStyle = dataGridViewCellStyle9;
            this.product_name.HeaderText = "Product Name";
            this.product_name.MinimumWidth = 6;
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            // 
            // damageloss
            // 
            this.damageloss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.damageloss.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.damageloss.DropDownWidth = 100;
            this.damageloss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.damageloss.HeaderText = "Choose Damage/Loss";
            this.damageloss.Items.AddRange(new object[] {
            "Damage",
            "Loss"});
            this.damageloss.MinimumWidth = 6;
            this.damageloss.Name = "damageloss";
            this.damageloss.Width = 200;
            // 
            // dl_qty
            // 
            this.dl_qty.DataPropertyName = "dl_qty";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dl_qty.DefaultCellStyle = dataGridViewCellStyle10;
            this.dl_qty.HeaderText = "Quantity";
            this.dl_qty.MinimumWidth = 6;
            this.dl_qty.Name = "dl_qty";
            // 
            // selling_price
            // 
            this.selling_price.DataPropertyName = "selling_price";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.selling_price.DefaultCellStyle = dataGridViewCellStyle11;
            this.selling_price.HeaderText = "Price";
            this.selling_price.MinimumWidth = 6;
            this.selling_price.Name = "selling_price";
            this.selling_price.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.remark.DefaultCellStyle = dataGridViewCellStyle12;
            this.remark.HeaderText = "Remark";
            this.remark.MinimumWidth = 6;
            this.remark.Name = "remark";
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.Image = global::POS_Admin.Properties.Resources.icons8_delete_24;
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "qty";
            this.qty.MinimumWidth = 6;
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(14, 217);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 42);
            this.btnAdd.TabIndex = 649;
            this.btnAdd.Text = "Add to List";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnAdd.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(952, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 648;
            this.label3.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(952, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 646;
            this.label1.Text = "*";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(450, 75);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 20);
            this.label24.TabIndex = 645;
            this.label24.Text = "*";
            // 
            // lblSubCategoryName
            // 
            this.lblSubCategoryName.AutoSize = true;
            this.lblSubCategoryName.BackColor = System.Drawing.Color.Transparent;
            this.lblSubCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoryName.Location = new System.Drawing.Point(10, 146);
            this.lblSubCategoryName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubCategoryName.Name = "lblSubCategoryName";
            this.lblSubCategoryName.Size = new System.Drawing.Size(152, 20);
            this.lblSubCategoryName.TabIndex = 644;
            this.lblSubCategoryName.Text = "Sub Category Name";
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.BackColor = System.Drawing.Color.Transparent;
            this.lblCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.Location = new System.Drawing.Point(529, 75);
            this.lblCategoryName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(119, 20);
            this.lblCategoryName.TabIndex = 643;
            this.lblCategoryName.Text = "Category Name";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.BackColor = System.Drawing.Color.Transparent;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(529, 146);
            this.lblProduct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(110, 20);
            this.lblProduct.TabIndex = 642;
            this.lblProduct.Text = "Product Name";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.Location = new System.Drawing.Point(10, 75);
            this.lblSupplierName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(113, 20);
            this.lblSupplierName.TabIndex = 635;
            this.lblSupplierName.Text = "Supplier Name";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.cboProduct);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(692, 131);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 50);
            this.groupBox4.TabIndex = 136;
            this.groupBox4.TabStop = false;
            // 
            // cboProduct
            // 
            this.cboProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduct.BackColor = System.Drawing.SystemColors.Window;
            this.cboProduct.ButtonColor = System.Drawing.SystemColors.Control;
            this.cboProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboProduct.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.ItemHeight = 27;
            this.cboProduct.Location = new System.Drawing.Point(5, 12);
            this.cboProduct.Margin = new System.Windows.Forms.Padding(2);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(245, 33);
            this.cboProduct.TabIndex = 1;
            this.cboProduct.TextAlign = System.Drawing.StringAlignment.Center;
            this.cboProduct.TextYOffset = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.cboSubCategory);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(190, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 50);
            this.groupBox3.TabIndex = 136;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // cboSubCategory
            // 
            this.cboSubCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSubCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSubCategory.BackColor = System.Drawing.SystemColors.Window;
            this.cboSubCategory.ButtonColor = System.Drawing.SystemColors.Control;
            this.cboSubCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboSubCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboSubCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSubCategory.FormattingEnabled = true;
            this.cboSubCategory.ItemHeight = 27;
            this.cboSubCategory.Location = new System.Drawing.Point(5, 12);
            this.cboSubCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cboSubCategory.Name = "cboSubCategory";
            this.cboSubCategory.Size = new System.Drawing.Size(245, 33);
            this.cboSubCategory.TabIndex = 1;
            this.cboSubCategory.TextAlign = System.Drawing.StringAlignment.Center;
            this.cboSubCategory.TextYOffset = 0;
            this.cboSubCategory.SelectedIndexChanged += new System.EventHandler(this.cboSubCategory_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(692, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 50);
            this.groupBox1.TabIndex = 136;
            this.groupBox1.TabStop = false;
            // 
            // cboCategory
            // 
            this.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCategory.BackColor = System.Drawing.SystemColors.Window;
            this.cboCategory.ButtonColor = System.Drawing.SystemColors.Control;
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.ItemHeight = 27;
            this.cboCategory.Location = new System.Drawing.Point(5, 12);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(245, 33);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.TextAlign = System.Drawing.StringAlignment.Center;
            this.cboCategory.TextYOffset = 0;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.cboSupplier);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(190, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 50);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            // 
            // cboSupplier
            // 
            this.cboSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSupplier.BackColor = System.Drawing.SystemColors.Window;
            this.cboSupplier.ButtonColor = System.Drawing.SystemColors.Control;
            this.cboSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.ItemHeight = 27;
            this.cboSupplier.Location = new System.Drawing.Point(5, 12);
            this.cboSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(245, 33);
            this.cboSupplier.TabIndex = 1;
            this.cboSupplier.TextAlign = System.Drawing.StringAlignment.Center;
            this.cboSupplier.TextYOffset = 0;
            this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.cboSupplier_SelectedIndexChanged);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Location = new System.Drawing.Point(0, 7);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1142, 42);
            this.pnlHeader.TabIndex = 127;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(7, 11);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(160, 20);
            this.lblFormTitle.TabIndex = 136;
            this.lblFormTitle.Text = "Damage/Loss Create";
            // 
            // UCDamageLoss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gpCategory);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCDamageLoss";
            this.Size = new System.Drawing.Size(1139, 669);
            this.Load += new System.EventHandler(this.UCDamageLoss_Load);
            this.gpCategory.ResumeLayout(false);
            this.gpCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageLoss)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpCategory;
        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.GroupBox groupBox4;
        private CustomControls.CustomNoBorderCombo cboProduct;
        private System.Windows.Forms.GroupBox groupBox3;
        private CustomControls.CustomNoBorderCombo cboSubCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomControls.CustomNoBorderCombo cboCategory;
        private System.Windows.Forms.GroupBox groupBox2;
        private CustomControls.CustomNoBorderCombo cboSupplier;
        private System.Windows.Forms.Label lblSubCategoryName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvDamageLoss;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn damageloss;
        private System.Windows.Forms.DataGridViewTextBoxColumn dl_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn selling_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
    }
}
