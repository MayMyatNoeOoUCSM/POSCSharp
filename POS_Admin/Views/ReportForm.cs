//<copyright file ="frmReport.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2020  All Rights Reserved
//</copyright>
//<author> EIEICHO-PC\Ei Ei Cho </author>
//<date>12/23/2020</date>

namespace POS_Admin.Views
{
    using Microsoft.Reporting.WinForms;
    using DAO.Common;
    using System;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="ReportForm" />.
    /// </summary>
    public partial class ReportForm : Form
    {
        /// <summary>
        /// Defines the dsReport.
        /// </summary>
        private DataSet dsReport = new DataSet();

        /// <summary>
        /// Defines the dsTransferReport.
        /// </summary>
        private DataSet[] dsTransferReport;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportForm"/> class.
        /// </summary>
        /// <param name="dsReportData">The dsReportData<see cref="DataSet"/>.</param>
        public ReportForm(DataSet dsReportData)
        {
            InitializeComponent();
            this.dsReport = dsReportData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportForm"/> class.
        /// </summary>
        /// <param name="dsTransferReport">The dsTransferReport<see cref="DataSet[]"/>.</param>
        public ReportForm(DataSet[] dsTransferReport)
        {
            InitializeComponent();
            this.dsTransferReport = dsTransferReport;
        }

        /// <summary>
        /// The frmReport_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void ReportFORM_Load(object sender, EventArgs e)
        {
            string exeFolder = Application.StartupPath;
            string startupPath = Path.Combine(exeFolder, @"RDLC\");
            rptViewer.LocalReport.ReportPath = startupPath + Consts.REPORTNAME + ".rdlc";

            //Add Parameters
            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("roundTo", Consts.ROUNDTO.Substring(1, 1));
            parameters[1] = new ReportParameter("printDate", DateTime.Now.Date.ToString());
            this.rptViewer.LocalReport.SetParameters(parameters);
            ReportDataSource rds = new ReportDataSource();

            rds = new ReportDataSource("DataSet1", dsReport.Tables[0]);
            this.rptViewer.LocalReport.DataSources.Clear();
            this.rptViewer.LocalReport.DataSources.Add(rds);

            this.rptViewer.SetDisplayMode(DisplayMode.PrintLayout); // Report PrintPreview            
            this.rptViewer.ZoomMode = ZoomMode.Percent;
            this.rptViewer.ZoomPercent = 100;

            this.rptViewer.RefreshReport();
        }
    }
}
