
namespace POS_Admin.Views.DamageLoss
{
    partial class UCDamageLossList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblShowItemText = new System.Windows.Forms.Label();
            this.btnLastList = new System.Windows.Forms.Button();
            this.lblListPage = new System.Windows.Forms.Label();
            this.btnNextList = new System.Windows.Forms.Button();
            this.btnFirstList = new System.Windows.Forms.Button();
            this.btnPreviousList = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cboShowItemList = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.lblNoDamageLossListText = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvDamageLoss = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new POS_Admin.CustomControls.CustomImageDatePicker();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpFromDate = new POS_Admin.CustomControls.CustomImageDatePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboProductName = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboSupplierName = new POS_Admin.CustomControls.CustomNoBorderCombo();
            this.srno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damage_loss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damageloss_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageLoss)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "delete";
            this.dataGridViewImageColumn2.FillWeight = 59.70193F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::POS_Admin.Properties.Resources.icons8_delete_24;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 125;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "edit";
            this.dataGridViewImageColumn1.FillWeight = 61.86001F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::POS_Admin.Properties.Resources.icons8_edit_24;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 125;
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
            // btnLastList
            // 
            this.btnLastList.BackColor = System.Drawing.Color.Transparent;
            this.btnLastList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastList.Location = new System.Drawing.Point(491, 6);
            this.btnLastList.Margin = new System.Windows.Forms.Padding(2);
            this.btnLastList.Name = "btnLastList";
            this.btnLastList.Size = new System.Drawing.Size(38, 29);
            this.btnLastList.TabIndex = 115;
            this.btnLastList.Text = ">>";
            this.btnLastList.UseVisualStyleBackColor = false;
            this.btnLastList.Click += new System.EventHandler(this.btnLastList_Click);
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
            // btnNextList
            // 
            this.btnNextList.BackColor = System.Drawing.Color.Transparent;
            this.btnNextList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextList.Location = new System.Drawing.Point(449, 6);
            this.btnNextList.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextList.Name = "btnNextList";
            this.btnNextList.Size = new System.Drawing.Size(38, 29);
            this.btnNextList.TabIndex = 114;
            this.btnNextList.Text = ">";
            this.btnNextList.UseVisualStyleBackColor = false;
            this.btnNextList.Click += new System.EventHandler(this.btnNextList_Click);
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
            this.btnFirstList.TabIndex = 112;
            this.btnFirstList.Text = "<<";
            this.btnFirstList.UseVisualStyleBackColor = false;
            this.btnFirstList.Click += new System.EventHandler(this.btnFirstList_Click);
            // 
            // btnPreviousList
            // 
            this.btnPreviousList.BackColor = System.Drawing.Color.Transparent;
            this.btnPreviousList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousList.Location = new System.Drawing.Point(314, 6);
            this.btnPreviousList.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviousList.Name = "btnPreviousList";
            this.btnPreviousList.Size = new System.Drawing.Size(38, 29);
            this.btnPreviousList.TabIndex = 113;
            this.btnPreviousList.Text = "<";
            this.btnPreviousList.UseVisualStyleBackColor = false;
            this.btnPreviousList.Click += new System.EventHandler(this.btnPreviousList_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.lblShowItemText);
            this.panel6.Controls.Add(this.btnLastList);
            this.panel6.Controls.Add(this.lblListPage);
            this.panel6.Controls.Add(this.btnNextList);
            this.panel6.Controls.Add(this.cboShowItemList);
            this.panel6.Controls.Add(this.btnFirstList);
            this.panel6.Controls.Add(this.btnPreviousList);
            this.panel6.Location = new System.Drawing.Point(14, 552);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1055, 42);
            this.panel6.TabIndex = 124;
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
            this.cboShowItemList.Location = new System.Drawing.Point(196, 6);
            this.cboShowItemList.Margin = new System.Windows.Forms.Padding(0);
            this.cboShowItemList.Name = "cboShowItemList";
            this.cboShowItemList.Size = new System.Drawing.Size(48, 29);
            this.cboShowItemList.TabIndex = 117;
            this.cboShowItemList.TextAlign = System.Drawing.StringAlignment.Far;
            this.cboShowItemList.TextYOffset = 0;
            this.cboShowItemList.SelectedIndexChanged += new System.EventHandler(this.cboShowItemList_SelectedIndexChanged);
            // 
            // lblNoDamageLossListText
            // 
            this.lblNoDamageLossListText.AutoSize = true;
            this.lblNoDamageLossListText.BackColor = System.Drawing.Color.Transparent;
            this.lblNoDamageLossListText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDamageLossListText.Location = new System.Drawing.Point(437, 327);
            this.lblNoDamageLossListText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoDamageLossListText.Name = "lblNoDamageLossListText";
            this.lblNoDamageLossListText.Size = new System.Drawing.Size(242, 20);
            this.lblNoDamageLossListText.TabIndex = 134;
            this.lblNoDamageLossListText.Text = "There is no damage/loss records.";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.lblNoDamageLossListText);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.dgvDamageLoss);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.lblSupplierName);
            this.groupBox2.Controls.Add(this.lblToDate);
            this.groupBox2.Controls.Add(this.lblProductName);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.lblFromDate);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(29, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1082, 621);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(291, 145);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 42);
            this.btnReset.TabIndex = 654;
            this.btnReset.Text = "Clear";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnReset.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(398, 145);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(193, 42);
            this.btnAdd.TabIndex = 653;
            this.btnAdd.Text = "Add Damage/Loss";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnAdd.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // dgvDamageLoss
            // 
            this.dgvDamageLoss.AllowUserToAddRows = false;
            this.dgvDamageLoss.AllowUserToResizeColumns = false;
            this.dgvDamageLoss.AllowUserToResizeRows = false;
            this.dgvDamageLoss.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDamageLoss.BackgroundColor = System.Drawing.Color.White;
            this.dgvDamageLoss.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDamageLoss.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDamageLoss.ColumnHeadersHeight = 44;
            this.dgvDamageLoss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDamageLoss.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno,
            this.idNo,
            this.product_id,
            this.supplier_name,
            this.product_Name,
            this.product_code,
            this.quantity,
            this.price,
            this.damage_loss,
            this.product_status,
            this.damageloss_date,
            this.remark,
            this.edit,
            this.delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDamageLoss.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDamageLoss.EnableHeadersVisualStyles = false;
            this.dgvDamageLoss.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvDamageLoss.Location = new System.Drawing.Point(14, 207);
            this.dgvDamageLoss.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDamageLoss.Name = "dgvDamageLoss";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDamageLoss.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDamageLoss.RowHeadersVisible = false;
            this.dgvDamageLoss.RowHeadersWidth = 58;
            this.dgvDamageLoss.RowTemplate.Height = 35;
            this.dgvDamageLoss.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDamageLoss.Size = new System.Drawing.Size(1055, 320);
            this.dgvDamageLoss.TabIndex = 133;
            this.dgvDamageLoss.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDamageLoss_CellContentClick);
            this.dgvDamageLoss.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDamageLoss_CellFormatting);
            this.dgvDamageLoss.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDamageLoss_CellMouseMove);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(176)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(183, 145);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 42);
            this.btnSearch.TabIndex = 652;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnSearch.MouseHover += new System.EventHandler(this.btnSubmit_MouseHover);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.White;
            this.groupBox6.Controls.Add(this.dtpToDate);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.Location = new System.Drawing.Point(663, 78);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(255, 50);
            this.groupBox6.TabIndex = 634;
            this.groupBox6.TabStop = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = " ";
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(4, 20);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(246, 26);
            this.dtpToDate.TabIndex = 18;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.Location = new System.Drawing.Point(10, 34);
            this.lblSupplierName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(113, 20);
            this.lblSupplierName.TabIndex = 126;
            this.lblSupplierName.Text = "Supplier Name";
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
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(481, 34);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(110, 20);
            this.lblProductName.TabIndex = 129;
            this.lblProductName.Text = "Product Name";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.dtpFromDate);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Location = new System.Drawing.Point(183, 78);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 50);
            this.groupBox5.TabIndex = 633;
            this.groupBox5.TabStop = false;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = " ";
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(4, 20);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(246, 26);
            this.dtpFromDate.TabIndex = 18;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
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
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.cboProductName);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(663, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 50);
            this.groupBox4.TabIndex = 632;
            this.groupBox4.TabStop = false;
            // 
            // cboProductName
            // 
            this.cboProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProductName.BackColor = System.Drawing.SystemColors.Window;
            this.cboProductName.ButtonColor = System.Drawing.SystemColors.Control;
            this.cboProductName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboProductName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductName.FormattingEnabled = true;
            this.cboProductName.ItemHeight = 27;
            this.cboProductName.Location = new System.Drawing.Point(5, 11);
            this.cboProductName.Margin = new System.Windows.Forms.Padding(2);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(245, 33);
            this.cboProductName.TabIndex = 1;
            this.cboProductName.TextAlign = System.Drawing.StringAlignment.Center;
            this.cboProductName.TextYOffset = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.cboSupplierName);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(183, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 50);
            this.groupBox3.TabIndex = 631;
            this.groupBox3.TabStop = false;
            // 
            // cboSupplierName
            // 
            this.cboSupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSupplierName.BackColor = System.Drawing.SystemColors.Window;
            this.cboSupplierName.ButtonColor = System.Drawing.SystemColors.Control;
            this.cboSupplierName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboSupplierName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupplierName.FormattingEnabled = true;
            this.cboSupplierName.ItemHeight = 27;
            this.cboSupplierName.Location = new System.Drawing.Point(5, 11);
            this.cboSupplierName.Margin = new System.Windows.Forms.Padding(2);
            this.cboSupplierName.Name = "cboSupplierName";
            this.cboSupplierName.Size = new System.Drawing.Size(245, 33);
            this.cboSupplierName.TabIndex = 1;
            this.cboSupplierName.TextAlign = System.Drawing.StringAlignment.Center;
            this.cboSupplierName.TextYOffset = 0;
            // 
            // srno
            // 
            this.srno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.srno.DataPropertyName = "sr";
            this.srno.FillWeight = 58.78074F;
            this.srno.Frozen = true;
            this.srno.HeaderText = "Sr";
            this.srno.MinimumWidth = 6;
            this.srno.Name = "srno";
            this.srno.ReadOnly = true;
            this.srno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.srno.Width = 60;
            // 
            // idNo
            // 
            this.idNo.DataPropertyName = "id";
            this.idNo.FillWeight = 1F;
            this.idNo.HeaderText = "id";
            this.idNo.MinimumWidth = 6;
            this.idNo.Name = "idNo";
            this.idNo.ReadOnly = true;
            this.idNo.Visible = false;
            // 
            // product_id
            // 
            this.product_id.DataPropertyName = "product_id";
            this.product_id.FillWeight = 1F;
            this.product_id.HeaderText = "product_id";
            this.product_id.MinimumWidth = 6;
            this.product_id.Name = "product_id";
            this.product_id.Visible = false;
            // 
            // supplier_name
            // 
            this.supplier_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.supplier_name.DataPropertyName = "supplier_name";
            this.supplier_name.FillWeight = 153.809F;
            this.supplier_name.Frozen = true;
            this.supplier_name.HeaderText = "Supplier Name";
            this.supplier_name.MinimumWidth = 6;
            this.supplier_name.Name = "supplier_name";
            this.supplier_name.ReadOnly = true;
            this.supplier_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.supplier_name.Width = 140;
            // 
            // product_Name
            // 
            this.product_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.product_Name.DataPropertyName = "product_name";
            this.product_Name.FillWeight = 110F;
            this.product_Name.Frozen = true;
            this.product_Name.HeaderText = "Product Name";
            this.product_Name.MinimumWidth = 50;
            this.product_Name.Name = "product_Name";
            this.product_Name.ReadOnly = true;
            this.product_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.product_Name.Width = 150;
            // 
            // product_code
            // 
            this.product_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.product_code.DataPropertyName = "product_code";
            this.product_code.FillWeight = 110F;
            this.product_code.Frozen = true;
            this.product_code.HeaderText = "Product Code";
            this.product_code.MinimumWidth = 50;
            this.product_code.Name = "product_code";
            this.product_code.ReadOnly = true;
            this.product_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.product_code.Width = 140;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantity.FillWeight = 80F;
            this.quantity.HeaderText = "Qty";
            this.quantity.MinimumWidth = 26;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "Price";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price.Visible = false;
            // 
            // damage_loss
            // 
            this.damage_loss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.damage_loss.DataPropertyName = "damage_loss";
            this.damage_loss.FillWeight = 80.1391F;
            this.damage_loss.HeaderText = "Damage/Loss";
            this.damage_loss.MinimumWidth = 6;
            this.damage_loss.Name = "damage_loss";
            this.damage_loss.ReadOnly = true;
            this.damage_loss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.damage_loss.Width = 120;
            // 
            // product_status
            // 
            this.product_status.DataPropertyName = "product_status";
            this.product_status.FillWeight = 1F;
            this.product_status.HeaderText = "product_status";
            this.product_status.MinimumWidth = 6;
            this.product_status.Name = "product_status";
            this.product_status.ReadOnly = true;
            this.product_status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.product_status.Visible = false;
            // 
            // damageloss_date
            // 
            this.damageloss_date.DataPropertyName = "damageloss_date";
            this.damageloss_date.FillWeight = 160.1514F;
            this.damageloss_date.HeaderText = "Damage/Loss Date";
            this.damageloss_date.MinimumWidth = 6;
            this.damageloss_date.Name = "damageloss_date";
            this.damageloss_date.ReadOnly = true;
            this.damageloss_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.FillWeight = 1F;
            this.remark.HeaderText = "remark";
            this.remark.MinimumWidth = 6;
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Visible = false;
            // 
            // edit
            // 
            this.edit.DataPropertyName = "edit";
            this.edit.FillWeight = 61.86001F;
            this.edit.HeaderText = "";
            this.edit.Image = global::POS_Admin.Properties.Resources.icons8_edit_24__1_;
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            // 
            // delete
            // 
            this.delete.DataPropertyName = "delete";
            this.delete.FillWeight = 59.70193F;
            this.delete.HeaderText = "";
            this.delete.Image = global::POS_Admin.Properties.Resources.icons8_delete_48__6_;
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            // 
            // UCDamageLossList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCDamageLossList";
            this.Size = new System.Drawing.Size(1139, 669);
            this.Load += new System.EventHandler(this.UCDamageLossList_Load);
            this.panel6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageLoss)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label lblShowItemText;
        private System.Windows.Forms.Button btnLastList;
        private System.Windows.Forms.Label lblListPage;
        private System.Windows.Forms.Button btnNextList;
        private CustomControls.CustomNoBorderCombo cboShowItemList;
        private System.Windows.Forms.Button btnFirstList;
        private System.Windows.Forms.Button btnPreviousList;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblNoDamageLossListText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDamageLoss;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private CustomControls.CustomNoBorderCombo cboProductName;
        private System.Windows.Forms.GroupBox groupBox3;
        private CustomControls.CustomNoBorderCombo cboSupplierName;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private CustomControls.CustomImageDatePicker dtpFromDate;
        private CustomControls.CustomImageDatePicker dtpToDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn damage_loss;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn damageloss_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}
