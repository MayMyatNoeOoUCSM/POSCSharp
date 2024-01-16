namespace POS_Admin.Views.Product
{
    partial class UCProductList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboProduct = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboCategory = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboSupplier = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNoProductText = new System.Windows.Forms.Label();
            this.dtgProduct = new System.Windows.Forms.DataGridView();
            this.sr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image = new System.Windows.Forms.DataGridViewImageColumn();
            this.supplier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.product_image_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_deleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub_category_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showItemPanel = new POS_Admin.CustomControls.NoFlickerPanel();
            this.lblShowItemText = new System.Windows.Forms.Label();
            this.cboShowItem = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtProductName = new POS_Admin.CustomControls.CustomPaddingTextBox();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProduct)).BeginInit();
            this.showItemPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(702, 88);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(136, 42);
            this.btnAdd.TabIndex = 128;
            this.btnAdd.Text = "Add Product";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnAdd.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(485, 88);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 42);
            this.btnSearch.TabIndex = 127;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnSearch.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 23);
            this.label2.TabIndex = 122;
            this.label2.Text = "Supplier Name";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(481, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 23);
            this.label1.TabIndex = 121;
            this.label1.Text = "Category Name";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(10, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 23);
            this.label8.TabIndex = 120;
            this.label8.Text = "Product Name";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.cboProduct);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Location = new System.Drawing.Point(183, 80);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 50);
            this.groupBox5.TabIndex = 133;
            this.groupBox5.TabStop = false;
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
            this.cboProduct.Location = new System.Drawing.Point(5, 11);
            this.cboProduct.Margin = new System.Windows.Forms.Padding(2);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(245, 33);
            this.cboProduct.TabIndex = 1;
            this.cboProduct.TextAlign = System.Drawing.StringAlignment.Center;
            this.cboProduct.TextYOffset = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.cboCategory);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(663, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 50);
            this.groupBox4.TabIndex = 132;
            this.groupBox4.TabStop = false;
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
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.cboSupplier);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(183, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 50);
            this.groupBox3.TabIndex = 131;
            this.groupBox3.TabStop = false;
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
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(593, 88);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 42);
            this.btnClear.TabIndex = 130;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnClear.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.lblNoProductText);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.dtgProduct);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.showItemPanel);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1082, 621);
            this.groupBox2.TabIndex = 132;
            this.groupBox2.TabStop = false;
            // 
            // lblNoProductText
            // 
            this.lblNoProductText.AutoSize = true;
            this.lblNoProductText.BackColor = System.Drawing.Color.Transparent;
            this.lblNoProductText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNoProductText.Location = new System.Drawing.Point(437, 327);
            this.lblNoProductText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoProductText.Name = "lblNoProductText";
            this.lblNoProductText.Size = new System.Drawing.Size(206, 20);
            this.lblNoProductText.TabIndex = 132;
            this.lblNoProductText.Text = "There is no product records.";
            // 
            // dtgProduct
            // 
            this.dtgProduct.AllowUserToAddRows = false;
            this.dtgProduct.AllowUserToResizeColumns = false;
            this.dtgProduct.AllowUserToResizeRows = false;
            this.dtgProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProduct.BackgroundColor = System.Drawing.Color.White;
            this.dtgProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgProduct.ColumnHeadersHeight = 42;
            this.dtgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sr,
            this.image,
            this.supplier_name,
            this.product_name,
            this.product_code,
            this.product_description,
            this.edit,
            this.delete,
            this.product_image_path,
            this.barcode,
            this.is_deleted,
            this.category_id,
            this.supplier_id,
            this.id,
            this.sub_category_id,
            this.stock_level,
            this.brand_id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgProduct.EnableHeadersVisualStyles = false;
            this.dtgProduct.Location = new System.Drawing.Point(14, 153);
            this.dtgProduct.Margin = new System.Windows.Forms.Padding(2);
            this.dtgProduct.Name = "dtgProduct";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgProduct.RowHeadersVisible = false;
            this.dtgProduct.RowHeadersWidth = 51;
            this.dtgProduct.RowTemplate.Height = 35;
            this.dtgProduct.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgProduct.Size = new System.Drawing.Size(1055, 394);
            this.dtgProduct.TabIndex = 131;
            this.dtgProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProduct_CellContentClick);
            this.dtgProduct.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgProduct_CellFormatting);
            this.dtgProduct.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgProduct_CellMouseMove);
            // 
            // sr
            // 
            this.sr.DataPropertyName = "sr";
            this.sr.FillWeight = 56.6626F;
            this.sr.HeaderText = "Sr";
            this.sr.MinimumWidth = 6;
            this.sr.Name = "sr";
            this.sr.ReadOnly = true;
            this.sr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // image
            // 
            this.image.DataPropertyName = "image";
            this.image.FillWeight = 59.16245F;
            this.image.HeaderText = "";
            this.image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.image.MinimumWidth = 6;
            this.image.Name = "image";
            this.image.Visible = false;
            // 
            // supplier_name
            // 
            this.supplier_name.DataPropertyName = "supplier_name";
            this.supplier_name.FillWeight = 129.6357F;
            this.supplier_name.HeaderText = "Supplier Name";
            this.supplier_name.MinimumWidth = 6;
            this.supplier_name.Name = "supplier_name";
            this.supplier_name.ReadOnly = true;
            // 
            // product_name
            // 
            this.product_name.DataPropertyName = "product_name";
            this.product_name.FillWeight = 134.7354F;
            this.product_name.HeaderText = "Product Name";
            this.product_name.MinimumWidth = 6;
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            // 
            // product_code
            // 
            this.product_code.DataPropertyName = "product_code";
            this.product_code.FillWeight = 140.8876F;
            this.product_code.HeaderText = "Product Code";
            this.product_code.MinimumWidth = 6;
            this.product_code.Name = "product_code";
            this.product_code.ReadOnly = true;
            // 
            // product_description
            // 
            this.product_description.DataPropertyName = "product_description";
            this.product_description.FillWeight = 165.4158F;
            this.product_description.HeaderText = "Description";
            this.product_description.MinimumWidth = 6;
            this.product_description.Name = "product_description";
            this.product_description.ReadOnly = true;
            // 
            // edit
            // 
            this.edit.DataPropertyName = "edit";
            this.edit.FillWeight = 56.40895F;
            this.edit.HeaderText = "";
            this.edit.Image = global::POS_Admin.Properties.Resources.icons8_edit_24__1_;
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            // 
            // delete
            // 
            this.delete.DataPropertyName = "delete";
            this.delete.FillWeight = 57.09136F;
            this.delete.HeaderText = "";
            this.delete.Image = global::POS_Admin.Properties.Resources.icons8_delete_48__6_;
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            // 
            // product_image_path
            // 
            this.product_image_path.DataPropertyName = "product_image_path";
            this.product_image_path.HeaderText = "product_image_path";
            this.product_image_path.MinimumWidth = 6;
            this.product_image_path.Name = "product_image_path";
            this.product_image_path.Visible = false;
            // 
            // barcode
            // 
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "BarCode";
            this.barcode.MinimumWidth = 6;
            this.barcode.Name = "barcode";
            this.barcode.Visible = false;
            // 
            // is_deleted
            // 
            this.is_deleted.DataPropertyName = "is_deleted";
            this.is_deleted.HeaderText = "is_deleted";
            this.is_deleted.MinimumWidth = 6;
            this.is_deleted.Name = "is_deleted";
            this.is_deleted.Visible = false;
            // 
            // category_id
            // 
            this.category_id.DataPropertyName = "category_id";
            this.category_id.HeaderText = "category_id";
            this.category_id.MinimumWidth = 6;
            this.category_id.Name = "category_id";
            this.category_id.Visible = false;
            // 
            // supplier_id
            // 
            this.supplier_id.DataPropertyName = "supplier_id";
            this.supplier_id.HeaderText = "supplier_id";
            this.supplier_id.MinimumWidth = 6;
            this.supplier_id.Name = "supplier_id";
            this.supplier_id.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // sub_category_id
            // 
            this.sub_category_id.DataPropertyName = "sub_category_id";
            this.sub_category_id.HeaderText = "sub_category_id";
            this.sub_category_id.MinimumWidth = 6;
            this.sub_category_id.Name = "sub_category_id";
            this.sub_category_id.Visible = false;
            // 
            // stock_level
            // 
            this.stock_level.DataPropertyName = "stock_level";
            this.stock_level.HeaderText = "Product_Level";
            this.stock_level.MinimumWidth = 6;
            this.stock_level.Name = "stock_level";
            this.stock_level.Visible = false;
            // 
            // brand_id
            // 
            this.brand_id.DataPropertyName = "brand_id";
            this.brand_id.HeaderText = "brand_id";
            this.brand_id.Name = "brand_id";
            this.brand_id.ReadOnly = true;
            this.brand_id.Visible = false;
            // 
            // showItemPanel
            // 
            this.showItemPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showItemPanel.BackColor = System.Drawing.SystemColors.Control;
            this.showItemPanel.Controls.Add(this.lblShowItemText);
            this.showItemPanel.Controls.Add(this.cboShowItem);
            this.showItemPanel.Controls.Add(this.btnFirst);
            this.showItemPanel.Controls.Add(this.lblPage);
            this.showItemPanel.Controls.Add(this.btnPrevious);
            this.showItemPanel.Controls.Add(this.btnLast);
            this.showItemPanel.Controls.Add(this.btnNext);
            this.showItemPanel.Location = new System.Drawing.Point(14, 561);
            this.showItemPanel.Margin = new System.Windows.Forms.Padding(2);
            this.showItemPanel.Name = "showItemPanel";
            this.showItemPanel.Size = new System.Drawing.Size(1055, 42);
            this.showItemPanel.TabIndex = 123;
            // 
            // lblShowItemText
            // 
            this.lblShowItemText.BackColor = System.Drawing.Color.Transparent;
            this.lblShowItemText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowItemText.Location = new System.Drawing.Point(5, 9);
            this.lblShowItemText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowItemText.Name = "lblShowItemText";
            this.lblShowItemText.Size = new System.Drawing.Size(190, 23);
            this.lblShowItemText.TabIndex = 119;
            this.lblShowItemText.Text = "Show Items";
            // 
            // cboShowItem
            // 
            this.cboShowItem.BorderColor = System.Drawing.Color.DimGray;
            this.cboShowItem.ButtonColor = System.Drawing.SystemColors.Control;
            this.cboShowItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboShowItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShowItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboShowItem.FormattingEnabled = true;
            this.cboShowItem.ItemHeight = 23;
            this.cboShowItem.Items.AddRange(new object[] {
            "10",
            "20",
            "30"});
            this.cboShowItem.Location = new System.Drawing.Point(197, 6);
            this.cboShowItem.Margin = new System.Windows.Forms.Padding(0);
            this.cboShowItem.Name = "cboShowItem";
            this.cboShowItem.Size = new System.Drawing.Size(48, 29);
            this.cboShowItem.TabIndex = 118;
            this.cboShowItem.TextAlign = System.Drawing.StringAlignment.Far;
            this.cboShowItem.TextYOffset = 0;
            this.cboShowItem.SelectedIndexChanged += new System.EventHandler(this.cboShowItem_SelectedIndexChanged);
            // 
            // btnFirst
            // 
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Location = new System.Drawing.Point(272, 6);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(38, 29);
            this.btnFirst.TabIndex = 20;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click_1);
            // 
            // lblPage
            // 
            this.lblPage.BackColor = System.Drawing.Color.Transparent;
            this.lblPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(356, 6);
            this.lblPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(89, 29);
            this.lblPage.TabIndex = 24;
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Location = new System.Drawing.Point(314, 6);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(38, 29);
            this.btnPrevious.TabIndex = 22;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click_1);
            // 
            // btnLast
            // 
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Location = new System.Drawing.Point(491, 6);
            this.btnLast.Margin = new System.Windows.Forms.Padding(2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(38, 29);
            this.btnLast.TabIndex = 21;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(449, 6);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(38, 29);
            this.btnNext.TabIndex = 23;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.White;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(172, 152);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(186, 24);
            this.txtProductName.TabIndex = 125;
            // 
            // UCProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtProductName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCProductList";
            this.Size = new System.Drawing.Size(1139, 669);
            this.Load += new System.EventHandler(this.UCProductList_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProduct)).EndInit();
            this.showItemPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private CustomControls.CustomPaddingTextBox txtProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private CustomControls.NoFlickerPanel showItemPanel;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgProduct;
        private System.Windows.Forms.Label lblNoProductText;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox3;
        private CustomControls.CustomNoBorderCombo cboSupplier;
        private System.Windows.Forms.GroupBox groupBox4;
        private CustomControls.CustomNoBorderCombo cboCategory;
        private System.Windows.Forms.GroupBox groupBox5;
        private CustomControls.CustomNoBorderCombo cboProduct;
        private CustomControls.CustomNoBorderCombo cboShowItem;
        private System.Windows.Forms.Label lblShowItemText;
        private System.Windows.Forms.DataGridViewTextBoxColumn sr;
        private System.Windows.Forms.DataGridViewImageColumn image;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_description;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_image_path;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_deleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub_category_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand_id;
    }
}
