
namespace POS_Admin.Views.Customer
{
    partial class UCCustomerList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLastList = new System.Windows.Forms.Button();
            this.btnNextList = new System.Windows.Forms.Button();
            this.lblListPage = new System.Windows.Forms.Label();
            this.btnPreviousList = new System.Windows.Forms.Button();
            this.btnFirstList = new System.Windows.Forms.Button();
            this.cboShowItemList = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.lblShowItemText = new System.Windows.Forms.Label();
            this.lblNoCustomerListText = new System.Windows.Forms.Label();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.srno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ViewDetails = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCustomerName = new POS_Admin.CustomControls.CustomPaddingTextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.lblNoCustomerListText);
            this.groupBox1.Controls.Add(this.dgvCustomer);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Location = new System.Drawing.Point(27, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1082, 621);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnLastList);
            this.panel1.Controls.Add(this.btnNextList);
            this.panel1.Controls.Add(this.lblListPage);
            this.panel1.Controls.Add(this.btnPreviousList);
            this.panel1.Controls.Add(this.btnFirstList);
            this.panel1.Controls.Add(this.cboShowItemList);
            this.panel1.Controls.Add(this.lblShowItemText);
            this.panel1.Location = new System.Drawing.Point(14, 559);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 42);
            this.panel1.TabIndex = 124;
            // 
            // btnLastList
            // 
            this.btnLastList.BackColor = System.Drawing.Color.Transparent;
            this.btnLastList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastList.Location = new System.Drawing.Point(491, 6);
            this.btnLastList.Margin = new System.Windows.Forms.Padding(2);
            this.btnLastList.Name = "btnLastList";
            this.btnLastList.Size = new System.Drawing.Size(38, 29);
            this.btnLastList.TabIndex = 125;
            this.btnLastList.Text = ">>";
            this.btnLastList.UseVisualStyleBackColor = false;
            this.btnLastList.Click += new System.EventHandler(this.btnLastList_Click);
            // 
            // btnNextList
            // 
            this.btnNextList.BackColor = System.Drawing.Color.Transparent;
            this.btnNextList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextList.Location = new System.Drawing.Point(449, 6);
            this.btnNextList.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextList.Name = "btnNextList";
            this.btnNextList.Size = new System.Drawing.Size(38, 29);
            this.btnNextList.TabIndex = 124;
            this.btnNextList.Text = ">";
            this.btnNextList.UseVisualStyleBackColor = false;
            this.btnNextList.Click += new System.EventHandler(this.btnNextList_Click);
            // 
            // lblListPage
            // 
            this.lblListPage.BackColor = System.Drawing.Color.Transparent;
            this.lblListPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblListPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListPage.Location = new System.Drawing.Point(356, 6);
            this.lblListPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblListPage.Name = "lblListPage";
            this.lblListPage.Size = new System.Drawing.Size(89, 29);
            this.lblListPage.TabIndex = 123;
            this.lblListPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPreviousList
            // 
            this.btnPreviousList.BackColor = System.Drawing.Color.Transparent;
            this.btnPreviousList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousList.Location = new System.Drawing.Point(314, 6);
            this.btnPreviousList.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviousList.Name = "btnPreviousList";
            this.btnPreviousList.Size = new System.Drawing.Size(38, 29);
            this.btnPreviousList.TabIndex = 122;
            this.btnPreviousList.Text = "<";
            this.btnPreviousList.UseVisualStyleBackColor = false;
            this.btnPreviousList.Click += new System.EventHandler(this.btnPreviousList_Click);
            // 
            // btnFirstList
            // 
            this.btnFirstList.BackColor = System.Drawing.Color.Transparent;
            this.btnFirstList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstList.ForeColor = System.Drawing.Color.Black;
            this.btnFirstList.Location = new System.Drawing.Point(272, 6);
            this.btnFirstList.Margin = new System.Windows.Forms.Padding(2);
            this.btnFirstList.Name = "btnFirstList";
            this.btnFirstList.Size = new System.Drawing.Size(38, 29);
            this.btnFirstList.TabIndex = 121;
            this.btnFirstList.Text = "<<";
            this.btnFirstList.UseVisualStyleBackColor = false;
            this.btnFirstList.Click += new System.EventHandler(this.btnFirstList_Click);
            // 
            // cboShowItemList
            // 
            this.cboShowItemList.BorderColor = System.Drawing.Color.DimGray;
            this.cboShowItemList.ButtonColor = System.Drawing.SystemColors.Control;
            this.cboShowItemList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboShowItemList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShowItemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboShowItemList.FormattingEnabled = true;
            this.cboShowItemList.ItemHeight = 23;
            this.cboShowItemList.Items.AddRange(new object[] {
            "10",
            "20",
            "30"});
            this.cboShowItemList.Location = new System.Drawing.Point(197, 6);
            this.cboShowItemList.Margin = new System.Windows.Forms.Padding(0);
            this.cboShowItemList.Name = "cboShowItemList";
            this.cboShowItemList.Size = new System.Drawing.Size(48, 29);
            this.cboShowItemList.TabIndex = 120;
            this.cboShowItemList.TextAlign = System.Drawing.StringAlignment.Far;
            this.cboShowItemList.TextYOffset = 0;
            this.cboShowItemList.SelectedIndexChanged += new System.EventHandler(this.cboShowItemList_SelectedIndexChanged);
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
            // lblNoCustomerListText
            // 
            this.lblNoCustomerListText.AutoSize = true;
            this.lblNoCustomerListText.BackColor = System.Drawing.Color.Transparent;
            this.lblNoCustomerListText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNoCustomerListText.Location = new System.Drawing.Point(437, 327);
            this.lblNoCustomerListText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoCustomerListText.Name = "lblNoCustomerListText";
            this.lblNoCustomerListText.Size = new System.Drawing.Size(218, 20);
            this.lblNoCustomerListText.TabIndex = 135;
            this.lblNoCustomerListText.Text = "There is no customer records.";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToResizeColumns = false;
            this.dgvCustomer.AllowUserToResizeRows = false;
            this.dgvCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomer.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomer.ColumnHeadersHeight = 42;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno,
            this.idNo,
            this.name,
            this.phoneno,
            this.email,
            this.add,
            this.description,
            this.edit,
            this.delete,
            this.ViewDetails});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomer.EnableHeadersVisualStyles = false;
            this.dgvCustomer.Location = new System.Drawing.Point(14, 143);
            this.dgvCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCustomer.Name = "dgvCustomer";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCustomer.RowHeadersVisible = false;
            this.dgvCustomer.RowHeadersWidth = 51;
            this.dgvCustomer.RowTemplate.Height = 35;
            this.dgvCustomer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCustomer.Size = new System.Drawing.Size(1055, 394);
            this.dgvCustomer.TabIndex = 134;
            this.dgvCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellContentClick);
            this.dgvCustomer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCustomer_CellFormatting);
            this.dgvCustomer.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCustomer_CellMouseMove);
            // 
            // srno
            // 
            this.srno.DataPropertyName = "sr";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.srno.DefaultCellStyle = dataGridViewCellStyle2;
            this.srno.FillWeight = 60.91369F;
            this.srno.HeaderText = "Sr";
            this.srno.MinimumWidth = 6;
            this.srno.Name = "srno";
            this.srno.ReadOnly = true;
            this.srno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // idNo
            // 
            this.idNo.DataPropertyName = "id";
            this.idNo.HeaderText = "id";
            this.idNo.MinimumWidth = 6;
            this.idNo.Name = "idNo";
            this.idNo.ReadOnly = true;
            this.idNo.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "customer_name";
            this.name.FillWeight = 163.2639F;
            this.name.HeaderText = "Customer Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // phoneno
            // 
            this.phoneno.DataPropertyName = "phone_no";
            this.phoneno.FillWeight = 115.5584F;
            this.phoneno.HeaderText = "Phone Number";
            this.phoneno.MinimumWidth = 6;
            this.phoneno.Name = "phoneno";
            this.phoneno.ReadOnly = true;
            this.phoneno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.FillWeight = 141.9935F;
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // add
            // 
            this.add.DataPropertyName = "address";
            this.add.FillWeight = 88.68687F;
            this.add.HeaderText = "Address";
            this.add.MinimumWidth = 6;
            this.add.Name = "add";
            this.add.ReadOnly = true;
            this.add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // description
            // 
            this.description.DataPropertyName = "customer_description";
            this.description.FillWeight = 107.4833F;
            this.description.HeaderText = "Description";
            this.description.MinimumWidth = 6;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // edit
            // 
            this.edit.DataPropertyName = "edit";
            this.edit.FillWeight = 60.81721F;
            this.edit.HeaderText = "";
            this.edit.Image = global::POS_Admin.Properties.Resources.icons8_edit_24__1_;
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            // 
            // delete
            // 
            this.delete.DataPropertyName = "delete";
            this.delete.FillWeight = 61.28304F;
            this.delete.HeaderText = "";
            this.delete.Image = global::POS_Admin.Properties.Resources.icons8_delete_48__6_;
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            // 
            // ViewDetails
            // 
            this.ViewDetails.HeaderText = "";
            this.ViewDetails.MinimumWidth = 6;
            this.ViewDetails.Name = "ViewDetails";
            this.ViewDetails.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ViewDetails.Text = "ViewDetails";
            this.ViewDetails.UseColumnTextForLinkValue = true;
            this.ViewDetails.Visible = false;
            this.ViewDetails.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(398, 85);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(136, 42);
            this.btnAdd.TabIndex = 133;
            this.btnAdd.Text = "Add Customer";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(291, 85);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 42);
            this.btnClear.TabIndex = 132;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(183, 85);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 42);
            this.btnSearch.TabIndex = 131;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(183, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 50);
            this.groupBox2.TabIndex = 129;
            this.groupBox2.TabStop = false;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(2, 18);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 27);
            this.txtCustomerName.TabIndex = 7;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(10, 34);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(124, 20);
            this.lblCustomerName.TabIndex = 7;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // UCCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCCustomerList";
            this.Size = new System.Drawing.Size(1139, 669);
            this.Load += new System.EventHandler(this.UCCustomerList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneno;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn add;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewLinkColumn ViewDetails;
        private System.Windows.Forms.Label lblNoCustomerListText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblShowItemText;
        private CustomControls.CustomNoBorderCombo cboShowItemList;
        private System.Windows.Forms.Button btnFirstList;
        private System.Windows.Forms.Button btnPreviousList;
        private System.Windows.Forms.Label lblListPage;
        private System.Windows.Forms.Button btnNextList;
        private System.Windows.Forms.Button btnLastList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public CustomControls.CustomPaddingTextBox txtCustomerName;
    }
}
