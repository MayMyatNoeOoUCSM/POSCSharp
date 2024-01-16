using DAO.Common;
using POS_Admin.Utilities;
using Services.Sale;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace POS_Admin.Views.Report
{
    public partial class UCYearlyReport : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the damageLossService.
        /// </summary>
        private SaleService saleService = new SaleService();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the dtCategoryList, dtParentCategory, dtTemp.....
        /// </summary>
        private DataTable dtYearlySaleList = new DataTable(),
                          dtTemp = new DataTable(),
                          dtSearchResult = new DataTable();

        /// <summary>
        /// Defines the getFilterList.
        /// </summary>
        internal List<object> getFilterList = new List<object>();

        /// <summary>
        /// Defines the dsReport.
        /// </summary>
        private DataSet dsReport = new DataSet();

        /// <summary>
        /// Defines the status, count, currentPage, totalPageCount...
        /// </summary>
        private int count = 0, //show item count
                    currentPage = 1,
                    totalPageCount = 0;// all search sale count

        /// <summary>
        /// Defines the dtResult.
        /// </summary>
        private DataTable dtResult = new DataTable();

        #endregion

        #region==========Initialization==========
        public UCYearlyReport()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Get Data==========
        /// <summary>
        /// GetSelectedReportData
        /// </summary>
        private void GetSelectedReportData()
        {
            Consts.REPORTNAME = "RptYearlySale";
            dsReport = saleService.GetYearlySale();
        }

        /// <summary>
        /// The HideDetail.
        /// </summary>
        private void HideDetails()
        {
            cboShowItem.Visible = false;
            lblListPage.Visible = false;
            lblShowItemText.Visible = false;
            btnFirst.Visible = false;
            btnNext.Visible = false;
            btnLast.Visible = false;
            btnPrevious.Visible = false;
            lblNoYearlySaleList.Visible = true;
        }

        /// <summary>
        /// The ShowDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvYearlySaleReport.Visible = true;
            cboShowItem.Visible = true;
            lblListPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
            lblNoYearlySaleList.Visible = false;
        }

        /// <summary>
        /// The ShowReportForm.
        /// </summary>
        private void ShowReportForm()
        {
            if (dsReport != null)
            {
                if (dsReport.Tables[0].Rows.Count > 0)
                {
                    ReportForm reportForm = new ReportForm(dsReport);
                    reportForm.Show();
                }
                else
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0060, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0052, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0060, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Messages.B0052, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region==========Pagination==========
        /// <summary>
        /// GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">.</param>
        private void GetCurrentPageRecords(int currentPage)
        {
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtYearlySaleList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblListPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvYearlySaleReport.DataSource = dtResult;
            ConfigureGrid();
            pagination.PaginationButtonAction(
                dtResult,
                btnFirst,
                btnPrevious,
                btnNext,
                btnLast,
                currentPage);
            pagination.PaginationButtonPaint(
                btnFirst,
                btnPrevious,
                btnNext,
                btnLast);
        }

        /// <summary>
        /// The ConfigureGrid.
        /// </summary>
        private void ConfigureGrid()
        {
            dgvYearlySaleReport.Columns["jan"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["feb"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["mar"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["apr"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["may"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["jun"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["jul"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["aug"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["sep"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["oct"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["Nov"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["Dece"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvYearlySaleReport.Columns["total"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnReset.BackColor = Properties.Settings.Default.BackColor;
            btnPreview.BackColor = Properties.Settings.Default.BackColor;
            btnDownload.BackColor = Properties.Settings.Default.BackColor;
            dgvYearlySaleReport.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Design generated code==========
        /// <summary>
        /// UCSaleReport_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCYearlyReport_Load(object sender, EventArgs e)
        {
            UCYearlyReport uCYearlyReport = new UCYearlyReport();
            dtYearlySaleList = saleService.GetYearlySaleTotal();
            lblTotalPrice.Text = Convert.ToString(saleService.GetTotalYearlyAmount());
            if (dtYearlySaleList.Rows.Count > 0)
            {
                lblNoYearlySaleList.Visible = false;
                dgvYearlySaleReport.DataSource = dtYearlySaleList;
                ShowDetails();
            }
            else
            {
                HideDetails();
            }
            cboShowItem.SelectedIndex = 0;
            dgvYearlySaleReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCYearlyReport);
            localization.ChangeDatagridText(dgvYearlySaleReport);
        }

        /// <summary>
        /// cboShowItem_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboShowItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(cboShowItem.GetItemText(cboShowItem.SelectedItem));
            currentPage = 1;
            this.GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// btnFirst_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            this.GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// btnPrevious_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                this.GetCurrentPageRecords(currentPage);
            }
        }

        /// <summary>
        /// btnNext_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPageCount)
            {
                currentPage++;
                this.GetCurrentPageRecords(currentPage);
            }
            dgvYearlySaleReport.Focus();
        }

        /// <summary>
        /// btnLast_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPageCount;
            this.GetCurrentPageRecords(currentPage);
            dgvYearlySaleReport.Focus();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// btnPreview_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.GetSelectedReportData();
            this.ShowReportForm();
        }

        /// <summary>
        /// btnDownload_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            string downloads;
            SHGetKnownFolderPath(KnownFolder.Downloads, 0, IntPtr.Zero, out downloads);

            Microsoft.Office.Interop.Excel.Workbook objBook = null;
            Microsoft.Office.Interop.Excel.Application objExcel = new Microsoft.Office.Interop.Excel.Application();
            object missing = Type.Missing;
            Microsoft.Office.Interop.Excel.Worksheet objSheet = null;
            // collection of DataGrid Items
            var dtExcelDataTable = saleService.GetYearlyXLSXData();
            object misValue = System.Reflection.Missing.Value;
            objBook = objExcel.Workbooks.Add(misValue);
            objSheet = (Microsoft.Office.Interop.Excel.Worksheet)objBook.ActiveSheet;
            objSheet.Columns.AutoFit();
            objSheet.Columns.EntireColumn.ColumnWidth = 15;
            // Header row
            for (int Idx = 0; Idx < dtExcelDataTable.Columns.Count; Idx++)
            {
                objSheet.Range["A1"].Offset[0, Idx].Value = dtExcelDataTable.Columns[Idx].ColumnName;
            }
            // Data Rows
            for (int Idx = 0; Idx < dtExcelDataTable.Rows.Count; Idx++)
            {
                objSheet.Range["A2"].Offset[Idx].Resize[1, dtExcelDataTable.Columns.Count].Value = dtExcelDataTable.Rows[Idx].ItemArray;
            }
            string folderPath = downloads + "\\";
            string[] files = Directory.GetFiles(folderPath);
            string fileName = "YearlySaleReport";
            int count = files.Count(file => { return file.Contains(fileName); });
            string newFileName = (count == 0) ? "YearlySaleReport.xlsx"
                : String.Format("{0} ({1}).xlsx", fileName, count + 1);
            folderPath = folderPath + newFileName;

            objBook.SaveAs(folderPath);
            objBook.Close(true, misValue, misValue);
            objExcel.Quit();
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                MessageBox.Show(DAO.Common.Messages.I0035, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(DAO.Common.Messages.B0070, DAO.Common.Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// KnownFolder.
        /// </summary>
        public static class KnownFolder
        {
            /// <summary>
            /// Defines the Downloads.
            /// </summary>
            public static readonly Guid Downloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        }

        /// <summary>
        /// SHGetKnownFolderPath.
        /// </summary>
        /// <param name="rfid">.</param>
        /// <param name="dwFlags">.</param>
        /// <param name="hToken">.</param>
        /// <param name="pszPath">.</param>
        /// <returns>.</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        internal static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);
        #endregion
    }
}
