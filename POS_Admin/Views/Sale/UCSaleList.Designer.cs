
namespace POS_Admin.Views.Sale
{
    partial class UCSaleList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lblNoSaleListText = new System.Windows.Forms.Label();
            this.chkYearly = new System.Windows.Forms.CheckBox();
            this.dgvSale = new System.Windows.Forms.DataGridView();
            this.sr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sale_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.invoice_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exceldetails = new System.Windows.Forms.DataGridViewLinkColumn();
            this.payment = new System.Windows.Forms.DataGridViewLinkColumn();
            this.chkMonthly = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cboShowItemList = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.lblShowItemText = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblListPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.chkWeekly = new System.Windows.Forms.CheckBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.chkToday = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtInvoiceNumber = new POS_Admin.CustomControls.CustomPaddingTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboStatus = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpFrom = new POS_Admin.CustomControls.CustomImageDatePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtpTo = new POS_Admin.CustomControls.CustomImageDatePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblToDate = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).BeginInit();
            this.panel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDownload);
            this.groupBox2.Controls.Add(this.lblNoSaleListText);
            this.groupBox2.Controls.Add(this.chkYearly);
            this.groupBox2.Controls.Add(this.dgvSale);
            this.groupBox2.Controls.Add(this.chkMonthly);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.chkWeekly);
            this.groupBox2.Controls.Add(this.lblFromDate);
            this.groupBox2.Controls.Add(this.chkToday);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.lblToDate);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1082, 621);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(878, 145);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(136, 42);
            this.btnDownload.TabIndex = 642;
            this.btnDownload.Text = "Download";
            this.btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            this.btnDownload.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnDownload.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // lblNoSaleListText
            // 
            this.lblNoSaleListText.AutoSize = true;
            this.lblNoSaleListText.BackColor = System.Drawing.Color.Transparent;
            this.lblNoSaleListText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNoSaleListText.Location = new System.Drawing.Point(437, 327);
            this.lblNoSaleListText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoSaleListText.Name = "lblNoSaleListText";
            this.lblNoSaleListText.Size = new System.Drawing.Size(181, 20);
            this.lblNoSaleListText.TabIndex = 147;
            this.lblNoSaleListText.Text = "There is no sale records.";
            // 
            // chkYearly
            // 
            this.chkYearly.AutoSize = true;
            this.chkYearly.BackColor = System.Drawing.Color.Transparent;
            this.chkYearly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkYearly.Location = new System.Drawing.Point(447, 155);
            this.chkYearly.Margin = new System.Windows.Forms.Padding(2);
            this.chkYearly.Name = "chkYearly";
            this.chkYearly.Size = new System.Drawing.Size(72, 24);
            this.chkYearly.TabIndex = 641;
            this.chkYearly.Text = "Yearly";
            this.chkYearly.UseVisualStyleBackColor = false;
            this.chkYearly.CheckedChanged += new System.EventHandler(this.chkYearly_CheckedChanged);
            // 
            // dgvSale
            // 
            this.dgvSale.AllowUserToAddRows = false;
            this.dgvSale.AllowUserToResizeColumns = false;
            this.dgvSale.AllowUserToResizeRows = false;
            this.dgvSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSale.BackgroundColor = System.Drawing.Color.White;
            this.dgvSale.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSale.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSale.ColumnHeadersHeight = 42;
            this.dgvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sr,
            this.sale_date,
            this.invoice_number,
            this.staff_name,
            this.amount_tax,
            this.amount,
            this.total,
            this.paid_amount,
            this.remark,
            this.idno,
            this.edit,
            this.invoice_status,
            this.exceldetails,
            this.payment});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.NullValue = null;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSale.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSale.EnableHeadersVisualStyles = false;
            this.dgvSale.Location = new System.Drawing.Point(14, 207);
            this.dgvSale.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSale.MultiSelect = false;
            this.dgvSale.Name = "dgvSale";
            this.dgvSale.RowHeadersVisible = false;
            this.dgvSale.RowHeadersWidth = 51;
            this.dgvSale.RowTemplate.Height = 35;
            this.dgvSale.Size = new System.Drawing.Size(1055, 325);
            this.dgvSale.TabIndex = 146;
            this.dgvSale.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSale_CellContentClick);
            this.dgvSale.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSale_CellFormatting);
            this.dgvSale.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSale_CellMouseMove);
            this.dgvSale.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSale_RowPostPaint);
            this.dgvSale.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvSale_Scroll);
            // 
            // sr
            // 
            this.sr.DataPropertyName = "sr";
            this.sr.FillWeight = 79.01739F;
            this.sr.HeaderText = "Sr";
            this.sr.MinimumWidth = 6;
            this.sr.Name = "sr";
            this.sr.ReadOnly = true;
            this.sr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sale_date
            // 
            this.sale_date.DataPropertyName = "sale_date";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sale_date.DefaultCellStyle = dataGridViewCellStyle2;
            this.sale_date.FillWeight = 100.3921F;
            this.sale_date.HeaderText = "Date";
            this.sale_date.MinimumWidth = 6;
            this.sale_date.Name = "sale_date";
            this.sale_date.ReadOnly = true;
            this.sale_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // invoice_number
            // 
            this.invoice_number.DataPropertyName = "invoice_number";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.invoice_number.DefaultCellStyle = dataGridViewCellStyle3;
            this.invoice_number.FillWeight = 145.5686F;
            this.invoice_number.HeaderText = "Invoice Number";
            this.invoice_number.MinimumWidth = 6;
            this.invoice_number.Name = "invoice_number";
            this.invoice_number.ReadOnly = true;
            this.invoice_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // staff_name
            // 
            this.staff_name.DataPropertyName = "staff_name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.staff_name.DefaultCellStyle = dataGridViewCellStyle4;
            this.staff_name.FillWeight = 123.5489F;
            this.staff_name.HeaderText = "Staff Name";
            this.staff_name.MinimumWidth = 6;
            this.staff_name.Name = "staff_name";
            this.staff_name.ReadOnly = true;
            this.staff_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // amount_tax
            // 
            this.amount_tax.DataPropertyName = "amount_tax";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amount_tax.DefaultCellStyle = dataGridViewCellStyle5;
            this.amount_tax.FillWeight = 105.5144F;
            this.amount_tax.HeaderText = "Amount Tax";
            this.amount_tax.MinimumWidth = 6;
            this.amount_tax.Name = "amount_tax";
            this.amount_tax.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amount.DefaultCellStyle = dataGridViewCellStyle6;
            this.amount.FillWeight = 95.4854F;
            this.amount.HeaderText = "Amount";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.total.DefaultCellStyle = dataGridViewCellStyle7;
            this.total.FillWeight = 98.2272F;
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // paid_amount
            // 
            this.paid_amount.DataPropertyName = "paid_amount";
            this.paid_amount.DefaultCellStyle = dataGridViewCellStyle7;
            this.paid_amount.FillWeight = 98.2272F;
            this.paid_amount.HeaderText = "Paid Amount";
            this.paid_amount.MinimumWidth = 6;
            this.paid_amount.Name = "paid_amount";
            this.paid_amount.ReadOnly = true;
            this.paid_amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.remark.DefaultCellStyle = dataGridViewCellStyle8;
            this.remark.FillWeight = 120F;
            this.remark.HeaderText = "Remark";
            this.remark.MinimumWidth = 6;
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Visible = false;
            // 
            // idno
            // 
            this.idno.DataPropertyName = "id";
            this.idno.HeaderText = "id";
            this.idno.MinimumWidth = 6;
            this.idno.Name = "idno";
            this.idno.ReadOnly = true;
            this.idno.Visible = false;
            // 
            // edit
            // 
            this.edit.ActiveLinkColor = System.Drawing.Color.Empty;
            this.edit.DataPropertyName = "edit";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5);
            this.edit.DefaultCellStyle = dataGridViewCellStyle9;
            this.edit.FillWeight = 144.5939F;
            this.edit.HeaderText = "";
            this.edit.LinkColor = System.Drawing.Color.Empty;
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            this.edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.edit.Text = "Cancel Invoice";
            this.edit.UseColumnTextForLinkValue = true;
            // 
            // invoice_status
            // 
            this.invoice_status.DataPropertyName = "invoice_status";
            this.invoice_status.HeaderText = "invoice_status";
            this.invoice_status.MinimumWidth = 6;
            this.invoice_status.Name = "invoice_status";
            this.invoice_status.ReadOnly = true;
            this.invoice_status.Visible = false;
            // 
            // exceldetails
            // 
            this.exceldetails.ActiveLinkColor = System.Drawing.Color.Empty;
            this.exceldetails.DataPropertyName = "exceldetails";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5);
            this.exceldetails.DefaultCellStyle = dataGridViewCellStyle10;
            this.exceldetails.FillWeight = 132.6522F;
            this.exceldetails.HeaderText = "";
            this.exceldetails.LinkColor = System.Drawing.Color.Empty;
            this.exceldetails.MinimumWidth = 6;
            this.exceldetails.Name = "exceldetails";
            this.exceldetails.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.exceldetails.Text = "Export Excel";
            this.exceldetails.UseColumnTextForLinkValue = true;
            // 
            // payment
            // 
            this.payment.ActiveLinkColor = System.Drawing.Color.Empty;
            this.payment.DataPropertyName = "payment";
            this.payment.DefaultCellStyle = dataGridViewCellStyle10;
            this.payment.FillWeight = 110.6522F;
            this.payment.HeaderText = "";
            this.payment.LinkColor = System.Drawing.Color.Empty;
            this.payment.MinimumWidth = 6;
            this.payment.Name = "payment";
            this.payment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.payment.Text = "Payment";
            this.payment.UseColumnTextForLinkValue = true;
            // 
            // chkMonthly
            // 
            this.chkMonthly.AutoSize = true;
            this.chkMonthly.BackColor = System.Drawing.Color.Transparent;
            this.chkMonthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMonthly.Location = new System.Drawing.Point(358, 155);
            this.chkMonthly.Margin = new System.Windows.Forms.Padding(2);
            this.chkMonthly.Name = "chkMonthly";
            this.chkMonthly.Size = new System.Drawing.Size(83, 24);
            this.chkMonthly.TabIndex = 640;
            this.chkMonthly.Text = "Monthly";
            this.chkMonthly.UseVisualStyleBackColor = false;
            this.chkMonthly.CheckedChanged += new System.EventHandler(this.chkMonthly_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.cboShowItemList);
            this.panel6.Controls.Add(this.lblShowItemText);
            this.panel6.Controls.Add(this.btnLast);
            this.panel6.Controls.Add(this.lblListPage);
            this.panel6.Controls.Add(this.btnNext);
            this.panel6.Controls.Add(this.btnFirst);
            this.panel6.Controls.Add(this.btnPrevious);
            this.panel6.Location = new System.Drawing.Point(14, 556);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1055, 42);
            this.panel6.TabIndex = 145;
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
            this.cboShowItemList.SelectedIndexChanged += new System.EventHandler(this.cboShowItemList_SelectedIndexChanged_1);
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
            // chkWeekly
            // 
            this.chkWeekly.AutoSize = true;
            this.chkWeekly.BackColor = System.Drawing.Color.Transparent;
            this.chkWeekly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWeekly.Location = new System.Drawing.Point(259, 155);
            this.chkWeekly.Margin = new System.Windows.Forms.Padding(2);
            this.chkWeekly.Name = "chkWeekly";
            this.chkWeekly.Size = new System.Drawing.Size(79, 24);
            this.chkWeekly.TabIndex = 639;
            this.chkWeekly.Text = "Weekly";
            this.chkWeekly.UseVisualStyleBackColor = false;
            this.chkWeekly.CheckedChanged += new System.EventHandler(this.chkWeekly_CheckedChanged);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(10, 94);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(85, 20);
            this.lblFromDate.TabIndex = 621;
            this.lblFromDate.Text = "From Date";
            // 
            // chkToday
            // 
            this.chkToday.AutoSize = true;
            this.chkToday.BackColor = System.Drawing.Color.Transparent;
            this.chkToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkToday.Location = new System.Drawing.Point(183, 155);
            this.chkToday.Margin = new System.Windows.Forms.Padding(2);
            this.chkToday.Name = "chkToday";
            this.chkToday.Size = new System.Drawing.Size(71, 24);
            this.chkToday.TabIndex = 638;
            this.chkToday.Text = "Today";
            this.chkToday.UseVisualStyleBackColor = false;
            this.chkToday.CheckedChanged += new System.EventHandler(this.chkToday_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txtInvoiceNumber);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(183, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 50);
            this.groupBox3.TabIndex = 631;
            this.groupBox3.TabStop = false;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtInvoiceNumber.Location = new System.Drawing.Point(2, 18);
            this.txtInvoiceNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceNumber.MaxLength = 100;
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(250, 27);
            this.txtInvoiceNumber.TabIndex = 2;
            this.txtInvoiceNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvoiceNumber_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 156);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 637;
            this.label6.Text = "Search By";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.cboStatus);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(663, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 50);
            this.groupBox4.TabIndex = 632;
            this.groupBox4.TabStop = false;
            // 
            // cboStatus
            // 
            this.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStatus.BackColor = System.Drawing.SystemColors.Window;
            this.cboStatus.ButtonColor = System.Drawing.SystemColors.Control;
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.ItemHeight = 27;
            this.cboStatus.Location = new System.Drawing.Point(5, 13);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(245, 33);
            this.cboStatus.TabIndex = 1;
            this.cboStatus.TextAlign = System.Drawing.StringAlignment.Center;
            this.cboStatus.TextYOffset = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(481, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 636;
            this.label4.Text = "Status";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(663, 145);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 42);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnSearch.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 635;
            this.label1.Text = "Invoice";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.dtpFrom);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Location = new System.Drawing.Point(183, 78);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 50);
            this.groupBox5.TabIndex = 633;
            this.groupBox5.TabStop = false;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = " ";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(4, 20);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(246, 26);
            this.dtpFrom.TabIndex = 18;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.White;
            this.groupBox6.Controls.Add(this.dtpTo);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.Location = new System.Drawing.Point(663, 78);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(255, 50);
            this.groupBox6.TabIndex = 634;
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
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(769, 145);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 42);
            this.btnClear.TabIndex = 628;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnClear.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(481, 94);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(66, 20);
            this.lblToDate.TabIndex = 620;
            this.lblToDate.Text = "To Date";
            // 
            // UCSaleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Name = "UCSaleList";
            this.Size = new System.Drawing.Size(1139, 669);
            this.Load += new System.EventHandler(this.UCSaleList_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).EndInit();
            this.panel6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSale;
        private System.Windows.Forms.Panel panel6;
        private CustomControls.CustomNoBorderCombo cboShowItemList;
        private System.Windows.Forms.Label lblShowItemText;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblListPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblNoSaleListText;
        private System.Windows.Forms.GroupBox groupBox6;
        private CustomControls.CustomImageDatePicker dtpTo;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox5;
        private CustomControls.CustomImageDatePicker dtpFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox4;
        private CustomControls.CustomNoBorderCombo cboStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkYearly;
        private System.Windows.Forms.CheckBox chkMonthly;
        private System.Windows.Forms.CheckBox chkWeekly;
        private System.Windows.Forms.CheckBox chkToday;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDownload;
        public CustomControls.CustomPaddingTextBox txtInvoiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn sr;
        private System.Windows.Forms.DataGridViewTextBoxColumn sale_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn idno;
        private System.Windows.Forms.DataGridViewLinkColumn edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_status;
        private System.Windows.Forms.DataGridViewLinkColumn exceldetails;
        private System.Windows.Forms.DataGridViewLinkColumn payment;
    }
}
