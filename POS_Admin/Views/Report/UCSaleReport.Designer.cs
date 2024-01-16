
namespace POS_Admin.Views.Report
{
    partial class UCSaleReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSaleReport));
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtpTo = new POS_Admin.CustomControls.CustomImageDatePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpFrom = new POS_Admin.CustomControls.CustomImageDatePicker();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNoSaleList = new System.Windows.Forms.Label();
            this.dgvSaleReport = new System.Windows.Forms.DataGridView();
            this.srno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale_Return_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale_Cancel_Process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent_category_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cboShowItem = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.lblShowItemText = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblListPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleReport)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(481, 34);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(66, 20);
            this.lblToDate.TabIndex = 637;
            this.lblToDate.Text = "To Date";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(10, 34);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(85, 20);
            this.lblFromDate.TabIndex = 636;
            this.lblFromDate.Text = "From Date";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.White;
            this.groupBox6.Controls.Add(this.dtpTo);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.Location = new System.Drawing.Point(633, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(255, 50);
            this.groupBox6.TabIndex = 635;
            this.groupBox6.TabStop = false;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = " ";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(4, 20);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(246, 26);
            this.dtpTo.TabIndex = 18;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.dtpFrom);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Location = new System.Drawing.Point(183, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 50);
            this.groupBox5.TabIndex = 634;
            this.groupBox5.TabStop = false;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = " ";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(6, 20);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(246, 26);
            this.dtpFrom.TabIndex = 18;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Location = new System.Drawing.Point(398, 85);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 42);
            this.btnPreview.TabIndex = 566;
            this.btnPreview.Text = "Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            this.btnPreview.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnPreview.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
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
            this.btnSearch.TabIndex = 154;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnSearch.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(291, 85);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 42);
            this.btnReset.TabIndex = 153;
            this.btnReset.Text = "Clear";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnReset.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(520, 85);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(136, 42);
            this.btnDownload.TabIndex = 152;
            this.btnDownload.Text = "Download";
            this.btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            this.btnDownload.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnDownload.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblNoSaleList);
            this.groupBox2.Controls.Add(this.lblToDate);
            this.groupBox2.Controls.Add(this.dgvSaleReport);
            this.groupBox2.Controls.Add(this.lblFromDate);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.btnDownload);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1082, 621);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // lblNoSaleList
            // 
            this.lblNoSaleList.AutoSize = true;
            this.lblNoSaleList.Location = new System.Drawing.Point(437, 327);
            this.lblNoSaleList.Name = "lblNoSaleList";
            this.lblNoSaleList.Size = new System.Drawing.Size(181, 20);
            this.lblNoSaleList.TabIndex = 638;
            this.lblNoSaleList.Text = "There is no sale records.";
            // 
            // dgvSaleReport
            // 
            this.dgvSaleReport.AllowUserToAddRows = false;
            this.dgvSaleReport.AllowUserToResizeColumns = false;
            this.dgvSaleReport.AllowUserToResizeRows = false;
            this.dgvSaleReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSaleReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaleReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvSaleReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSaleReport.ColumnHeadersHeight = 42;
            this.dgvSaleReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSaleReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno,
            this.Sale_Date,
            this.S_Name,
            this.Total_Amount,
            this.Sale_Quantity,
            this.Sale_Return_Quantity,
            this.Sale_Cancel_Process,
            this.id,
            this.parent_category_id,
            this.c_name,
            this.parent_category,
            this.description,
            this.edit,
            this.delete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSaleReport.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSaleReport.EnableHeadersVisualStyles = false;
            this.dgvSaleReport.Location = new System.Drawing.Point(14, 147);
            this.dgvSaleReport.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSaleReport.Name = "dgvSaleReport";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSaleReport.RowHeadersVisible = false;
            this.dgvSaleReport.RowHeadersWidth = 51;
            this.dgvSaleReport.RowTemplate.Height = 35;
            this.dgvSaleReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSaleReport.Size = new System.Drawing.Size(1055, 394);
            this.dgvSaleReport.TabIndex = 148;
            this.dgvSaleReport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSaleReport_CellFormatting);
            this.dgvSaleReport.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSaleReport_RowPostPaint);
            // 
            // srno
            // 
            this.srno.DataPropertyName = "sr";
            this.srno.FillWeight = 33.15669F;
            this.srno.HeaderText = "Sr";
            this.srno.MinimumWidth = 6;
            this.srno.Name = "srno";
            this.srno.ReadOnly = true;
            this.srno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sale_Date
            // 
            this.Sale_Date.DataPropertyName = "Sale_Date";
            this.Sale_Date.FillWeight = 100.5753F;
            this.Sale_Date.HeaderText = "Sale Date";
            this.Sale_Date.MinimumWidth = 6;
            this.Sale_Date.Name = "Sale_Date";
            this.Sale_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // S_Name
            // 
            this.S_Name.DataPropertyName = "Name";
            this.S_Name.FillWeight = 100.5753F;
            this.S_Name.HeaderText = "Staff Name";
            this.S_Name.MinimumWidth = 6;
            this.S_Name.Name = "S_Name";
            this.S_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Total_Amount
            // 
            this.Total_Amount.DataPropertyName = "Total_Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Total_Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Total_Amount.FillWeight = 100.5753F;
            this.Total_Amount.HeaderText = "Total Amount";
            this.Total_Amount.MinimumWidth = 6;
            this.Total_Amount.Name = "Total_Amount";
            this.Total_Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sale_Quantity
            // 
            this.Sale_Quantity.DataPropertyName = "Sale_Quantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Sale_Quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.Sale_Quantity.FillWeight = 100.5753F;
            this.Sale_Quantity.HeaderText = "Sale Quantity";
            this.Sale_Quantity.MinimumWidth = 6;
            this.Sale_Quantity.Name = "Sale_Quantity";
            this.Sale_Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sale_Return_Quantity
            // 
            this.Sale_Return_Quantity.DataPropertyName = "Sale_Return_Quantity";
            this.Sale_Return_Quantity.HeaderText = "Sale Return Quantity";
            this.Sale_Return_Quantity.MinimumWidth = 6;
            this.Sale_Return_Quantity.Name = "Sale_Return_Quantity";
            this.Sale_Return_Quantity.Visible = false;
            // 
            // Sale_Cancel_Process
            // 
            this.Sale_Cancel_Process.DataPropertyName = "Sale_Cancel_Process";
            this.Sale_Cancel_Process.HeaderText = "Sale Cancel Process";
            this.Sale_Cancel_Process.MinimumWidth = 6;
            this.Sale_Cancel_Process.Name = "Sale_Cancel_Process";
            this.Sale_Cancel_Process.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // parent_category_id
            // 
            this.parent_category_id.DataPropertyName = "parent_category_id";
            this.parent_category_id.HeaderText = "Parent Category Id";
            this.parent_category_id.MinimumWidth = 6;
            this.parent_category_id.Name = "parent_category_id";
            this.parent_category_id.Visible = false;
            // 
            // c_name
            // 
            this.c_name.DataPropertyName = "c_name";
            this.c_name.FillWeight = 112.2995F;
            this.c_name.HeaderText = "Category Name";
            this.c_name.MinimumWidth = 6;
            this.c_name.Name = "c_name";
            this.c_name.ReadOnly = true;
            this.c_name.Visible = false;
            // 
            // parent_category
            // 
            this.parent_category.DataPropertyName = "parent_category";
            this.parent_category.FillWeight = 114.0472F;
            this.parent_category.HeaderText = "Parent category";
            this.parent_category.MinimumWidth = 6;
            this.parent_category.Name = "parent_category";
            this.parent_category.ReadOnly = true;
            this.parent_category.Visible = false;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.FillWeight = 219.7651F;
            this.description.HeaderText = "Description";
            this.description.MinimumWidth = 6;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Visible = false;
            // 
            // edit
            // 
            this.edit.DataPropertyName = "edit";
            this.edit.FillWeight = 59.21504F;
            this.edit.HeaderText = "";
            this.edit.Image = global::POS_Admin.Properties.Resources.edit_icon;
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            this.edit.Visible = false;
            // 
            // delete
            // 
            this.delete.DataPropertyName = "delete";
            this.delete.FillWeight = 59.21504F;
            this.delete.HeaderText = "";
            this.delete.Image = ((System.Drawing.Image)(resources.GetObject("delete.Image")));
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.Visible = false;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.cboShowItem);
            this.panel6.Controls.Add(this.lblShowItemText);
            this.panel6.Controls.Add(this.btnLast);
            this.panel6.Controls.Add(this.lblListPage);
            this.panel6.Controls.Add(this.btnNext);
            this.panel6.Controls.Add(this.btnFirst);
            this.panel6.Controls.Add(this.btnPrevious);
            this.panel6.Location = new System.Drawing.Point(14, 559);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1055, 42);
            this.panel6.TabIndex = 145;
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
            this.cboShowItem.TabIndex = 120;
            this.cboShowItem.TextAlign = System.Drawing.StringAlignment.Far;
            this.cboShowItem.TextYOffset = 0;
            this.cboShowItem.SelectedIndexChanged += new System.EventHandler(this.cboShowItem_SelectedIndexChanged);
            // 
            // lblShowItemText
            // 
            this.lblShowItemText.BackColor = System.Drawing.Color.Transparent;
            this.lblShowItemText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowItemText.Location = new System.Drawing.Point(5, 9);
            this.lblShowItemText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowItemText.Name = "lblShowItemText";
            this.lblShowItemText.Size = new System.Drawing.Size(190, 23);
            this.lblShowItemText.TabIndex = 118;
            this.lblShowItemText.Text = "Show Items";
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Location = new System.Drawing.Point(491, 6);
            this.btnLast.Margin = new System.Windows.Forms.Padding(2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(38, 29);
            this.btnLast.TabIndex = 115;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
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
            this.lblListPage.TabIndex = 119;
            this.lblListPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(449, 6);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(38, 29);
            this.btnNext.TabIndex = 114;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.ForeColor = System.Drawing.Color.Black;
            this.btnFirst.Location = new System.Drawing.Point(272, 6);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(38, 29);
            this.btnFirst.TabIndex = 112;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Location = new System.Drawing.Point(314, 6);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(38, 29);
            this.btnPrevious.TabIndex = 113;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "edit";
            this.dataGridViewImageColumn1.FillWeight = 59.21504F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::POS_Admin.Properties.Resources.edit_icon;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Visible = false;
            this.dataGridViewImageColumn1.Width = 125;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "delete";
            this.dataGridViewImageColumn2.FillWeight = 59.21504F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Visible = false;
            this.dataGridViewImageColumn2.Width = 125;
            // 
            // UCSaleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Name = "UCSaleReport";
            this.Size = new System.Drawing.Size(1139, 669);
            this.Load += new System.EventHandler(this.UCSaleReport_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleReport)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSaleReport;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblShowItemText;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblListPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private CustomControls.CustomNoBorderCombo cboShowItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private CustomControls.CustomImageDatePicker dtpFrom;
        private System.Windows.Forms.GroupBox groupBox6;
        private CustomControls.CustomImageDatePicker dtpTo;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblNoSaleList;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale_Return_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale_Cancel_Process;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent_category_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}
