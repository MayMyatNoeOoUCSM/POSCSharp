
namespace POS_Admin.Views.Dashboard
{
    partial class UCDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlTotalSale = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalSale = new System.Windows.Forms.Label();
            this.pnlYearSale = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblYearSale = new System.Windows.Forms.Label();
            this.pnlMonthSale = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMonthSale = new System.Windows.Forms.Label();
            this.pnlTodaySale = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTodaySale = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chtMonthlyRpt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlRptMonthSale = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.lstTopTenView = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pnlRptTopTenSale = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlMinimunStock = new System.Windows.Forms.Panel();
            this.pnlExpire = new System.Windows.Forms.Panel();
            this.lblMinQty = new System.Windows.Forms.Label();
            this.lblExpire = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlTotalSale.SuspendLayout();
            this.pnlYearSale.SuspendLayout();
            this.pnlMonthSale.SuspendLayout();
            this.pnlTodaySale.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtMonthlyRpt)).BeginInit();
            this.pnlRptMonthSale.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.pnlRptTopTenSale.SuspendLayout();
            this.pnlMinimunStock.SuspendLayout();
            this.pnlExpire.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTotalSale
            // 
            this.pnlTotalSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTotalSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            this.pnlTotalSale.Controls.Add(this.label9);
            this.pnlTotalSale.Controls.Add(this.lblTotalSale);
            this.pnlTotalSale.Location = new System.Drawing.Point(590, 40);
            this.pnlTotalSale.Name = "pnlTotalSale";
            this.pnlTotalSale.Size = new System.Drawing.Size(150, 100);
            this.pnlTotalSale.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(17, 13);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.MinimumSize = new System.Drawing.Size(120, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 30);
            this.label9.TabIndex = 8;
            this.label9.Text = "Total\'s Sale";
            // 
            // lblTotalSale
            // 
            this.lblTotalSale.AutoSize = true;
            this.lblTotalSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTotalSale.ForeColor = System.Drawing.Color.White;
            this.lblTotalSale.Location = new System.Drawing.Point(18, 57);
            this.lblTotalSale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalSale.Name = "lblTotalSale";
            this.lblTotalSale.Size = new System.Drawing.Size(23, 25);
            this.lblTotalSale.TabIndex = 7;
            this.lblTotalSale.Text = "0";
            this.lblTotalSale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlYearSale
            // 
            this.pnlYearSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlYearSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            this.pnlYearSale.Controls.Add(this.label7);
            this.pnlYearSale.Controls.Add(this.lblYearSale);
            this.pnlYearSale.Location = new System.Drawing.Point(405, 40);
            this.pnlYearSale.Name = "pnlYearSale";
            this.pnlYearSale.Size = new System.Drawing.Size(150, 100);
            this.pnlYearSale.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(17, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.MinimumSize = new System.Drawing.Size(120, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 30);
            this.label7.TabIndex = 8;
            this.label7.Text = "Year\'s Sale";
            // 
            // lblYearSale
            // 
            this.lblYearSale.AutoSize = true;
            this.lblYearSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblYearSale.ForeColor = System.Drawing.Color.White;
            this.lblYearSale.Location = new System.Drawing.Point(18, 57);
            this.lblYearSale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYearSale.Name = "lblYearSale";
            this.lblYearSale.Size = new System.Drawing.Size(23, 25);
            this.lblYearSale.TabIndex = 7;
            this.lblYearSale.Text = "0";
            // 
            // pnlMonthSale
            // 
            this.pnlMonthSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMonthSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            this.pnlMonthSale.Controls.Add(this.label4);
            this.pnlMonthSale.Controls.Add(this.lblMonthSale);
            this.pnlMonthSale.Location = new System.Drawing.Point(215, 40);
            this.pnlMonthSale.Name = "pnlMonthSale";
            this.pnlMonthSale.Size = new System.Drawing.Size(150, 100);
            this.pnlMonthSale.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.MinimumSize = new System.Drawing.Size(120, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "Month\'s Sale";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblMonthSale
            // 
            this.lblMonthSale.AutoSize = true;
            this.lblMonthSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblMonthSale.ForeColor = System.Drawing.Color.White;
            this.lblMonthSale.Location = new System.Drawing.Point(18, 57);
            this.lblMonthSale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonthSale.Name = "lblMonthSale";
            this.lblMonthSale.Size = new System.Drawing.Size(23, 25);
            this.lblMonthSale.TabIndex = 7;
            this.lblMonthSale.Text = "0";
            // 
            // pnlTodaySale
            // 
            this.pnlTodaySale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTodaySale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            this.pnlTodaySale.Controls.Add(this.label1);
            this.pnlTodaySale.Controls.Add(this.lblTodaySale);
            this.pnlTodaySale.Location = new System.Drawing.Point(27, 40);
            this.pnlTodaySale.Name = "pnlTodaySale";
            this.pnlTodaySale.Size = new System.Drawing.Size(150, 100);
            this.pnlTodaySale.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.MinimumSize = new System.Drawing.Size(120, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Today\'s Sale";
            // 
            // lblTodaySale
            // 
            this.lblTodaySale.AutoSize = true;
            this.lblTodaySale.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTodaySale.ForeColor = System.Drawing.Color.White;
            this.lblTodaySale.Location = new System.Drawing.Point(18, 57);
            this.lblTodaySale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTodaySale.Name = "lblTodaySale";
            this.lblTodaySale.Size = new System.Drawing.Size(23, 25);
            this.lblTodaySale.TabIndex = 7;
            this.lblTodaySale.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chtMonthlyRpt);
            this.groupBox3.Controls.Add(this.pnlRptMonthSale);
            this.groupBox3.Location = new System.Drawing.Point(27, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(627, 471);
            this.groupBox3.TabIndex = 134;
            this.groupBox3.TabStop = false;
            // 
            // chtMonthlyRpt
            // 
            chartArea6.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.None;
            chartArea6.AxisX.Interval = 1D;
            chartArea6.Name = "ChartArea1";
            this.chtMonthlyRpt.ChartAreas.Add(chartArea6);
            legend6.Alignment = System.Drawing.StringAlignment.Far;
            legend6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            legend6.IsTextAutoFit = false;
            legend6.Name = "Legend1";
            this.chtMonthlyRpt.Legends.Add(legend6);
            this.chtMonthlyRpt.Location = new System.Drawing.Point(4, 56);
            this.chtMonthlyRpt.Name = "chtMonthlyRpt";
            series6.ChartArea = "ChartArea1";
            series6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series6.Legend = "Legend1";
            series6.Name = "Current";
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chtMonthlyRpt.Series.Add(series6);
            this.chtMonthlyRpt.Size = new System.Drawing.Size(617, 379);
            this.chtMonthlyRpt.TabIndex = 3;
            this.chtMonthlyRpt.Text = "chart3";
            // 
            // pnlRptMonthSale
            // 
            this.pnlRptMonthSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRptMonthSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            this.pnlRptMonthSale.Controls.Add(this.label2);
            this.pnlRptMonthSale.Location = new System.Drawing.Point(0, 0);
            this.pnlRptMonthSale.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRptMonthSale.Name = "pnlRptMonthSale";
            this.pnlRptMonthSale.Size = new System.Drawing.Size(627, 43);
            this.pnlRptMonthSale.TabIndex = 137;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Monthly Sale Report";
            // 
            // lstTopTenView
            // 
            this.lstTopTenView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTopTenView.HideSelection = false;
            this.lstTopTenView.Location = new System.Drawing.Point(5, 56);
            this.lstTopTenView.Name = "lstTopTenView";
            this.lstTopTenView.Size = new System.Drawing.Size(395, 398);
            this.lstTopTenView.TabIndex = 136;
            this.lstTopTenView.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pnlRptTopTenSale);
            this.groupBox5.Controls.Add(this.lstTopTenView);
            this.groupBox5.Location = new System.Drawing.Point(684, 165);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(424, 470);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // pnlRptTopTenSale
            // 
            this.pnlRptTopTenSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRptTopTenSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            this.pnlRptTopTenSale.Controls.Add(this.label5);
            this.pnlRptTopTenSale.Location = new System.Drawing.Point(0, 0);
            this.pnlRptTopTenSale.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRptTopTenSale.Name = "pnlRptTopTenSale";
            this.pnlRptTopTenSale.Size = new System.Drawing.Size(425, 42);
            this.pnlRptTopTenSale.TabIndex = 139;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(24, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.MinimumSize = new System.Drawing.Size(175, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Top Ten Sale Products";
            // 
            // pnlMinimunStock
            // 
            this.pnlMinimunStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMinimunStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            this.pnlMinimunStock.Controls.Add(this.lblMinQty);
            this.pnlMinimunStock.Controls.Add(this.label6);
            this.pnlMinimunStock.Location = new System.Drawing.Point(775, 40);
            this.pnlMinimunStock.Name = "pnlMinimunStock";
            this.pnlMinimunStock.Size = new System.Drawing.Size(150, 100);
            this.pnlMinimunStock.TabIndex = 135;
            // 
            // lblMinQty
            // 
            this.lblMinQty.AutoSize = true;
            this.lblMinQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinQty.ForeColor = System.Drawing.Color.White;
            this.lblMinQty.Location = new System.Drawing.Point(17, 13);
            this.lblMinQty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinQty.MinimumSize = new System.Drawing.Size(120, 30);
            this.lblMinQty.Name = "lblMinQty";
            this.lblMinQty.Size = new System.Drawing.Size(125, 30);
            this.lblMinQty.TabIndex = 12;
            this.lblMinQty.Text = "Minimum Stocks";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(18, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "0";
            // 
            // pnlExpire
            // 
            this.pnlExpire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExpire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(99)))), ((int)(((byte)(174)))));
            this.pnlExpire.Controls.Add(this.lblExpire);
            this.pnlExpire.Controls.Add(this.label8);
            this.pnlExpire.Location = new System.Drawing.Point(959, 40);
            this.pnlExpire.Name = "pnlExpire";
            this.pnlExpire.Size = new System.Drawing.Size(150, 100);
            this.pnlExpire.TabIndex = 135;
            this.pnlExpire.Click += new System.EventHandler(this.pnlExpire_Click);
            // 
            // lblExpire
            // 
            this.lblExpire.AutoSize = true;
            this.lblExpire.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpire.ForeColor = System.Drawing.Color.White;
            this.lblExpire.Location = new System.Drawing.Point(17, 13);
            this.lblExpire.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExpire.MinimumSize = new System.Drawing.Size(120, 30);
            this.lblExpire.Name = "lblExpire";
            this.lblExpire.Size = new System.Drawing.Size(125, 30);
            this.lblExpire.TabIndex = 12;
            this.lblExpire.Text = "Expire";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(18, 57);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "0";
            // 
            // UCDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlTodaySale);
            this.Controls.Add(this.pnlMonthSale);
            this.Controls.Add(this.pnlYearSale);
            this.Controls.Add(this.pnlTotalSale);
            this.Controls.Add(this.pnlMinimunStock);
            this.Controls.Add(this.pnlExpire);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Name = "UCDashboard";
            this.Size = new System.Drawing.Size(1139, 669);
            this.Load += new System.EventHandler(this.UCDashboard_Load);
            this.pnlTotalSale.ResumeLayout(false);
            this.pnlTotalSale.PerformLayout();
            this.pnlYearSale.ResumeLayout(false);
            this.pnlYearSale.PerformLayout();
            this.pnlMonthSale.ResumeLayout(false);
            this.pnlMonthSale.PerformLayout();
            this.pnlTodaySale.ResumeLayout(false);
            this.pnlTodaySale.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtMonthlyRpt)).EndInit();
            this.pnlRptMonthSale.ResumeLayout(false);
            this.pnlRptMonthSale.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.pnlRptTopTenSale.ResumeLayout(false);
            this.pnlRptTopTenSale.PerformLayout();
            this.pnlMinimunStock.ResumeLayout(false);
            this.pnlMinimunStock.PerformLayout();
            this.pnlExpire.ResumeLayout(false);
            this.pnlExpire.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pnlTotalSale;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalSale;
        private System.Windows.Forms.Panel pnlYearSale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblYearSale;
        private System.Windows.Forms.Panel pnlMonthSale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMonthSale;
        private System.Windows.Forms.Panel pnlTodaySale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTodaySale;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.ListView lstTopTenView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtMonthlyRpt;
        private System.Windows.Forms.Panel pnlRptMonthSale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel pnlRptTopTenSale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlMinimunStock;
        private System.Windows.Forms.Panel pnlExpire;
        private System.Windows.Forms.Label lblMinQty;
        private System.Windows.Forms.Label lblExpire;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}
