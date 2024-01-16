using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO.Common;
using Services.Sale;
using POS_Admin.Utilities;
using System.Runtime.InteropServices;
using System.IO;

namespace POS_Admin.Views.Report
{
    public partial class UCTopTenSaleReport : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the damageLossService.
        /// </summary>
        private SaleService saleService = new SaleService();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the dtCategoryList, dtParentCategory, dtTemp.....
        /// </summary>
        private DataTable dtSaleList = new DataTable(),
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
        private int status = 0,
                    count = 0, //show item count
                    currentPage = 1,
                    totalPageCount = 0,
                    totalSaleCount = 0, //all sale count
                    startCount = 0,
                    changeFromDate = 0,
                    changeToDate = 0,
                    pageCount = 0,
                    searchTotalCount = 0;// all search sale count

        
        /// <summary>
        /// Gets or sets the startDate.
        /// </summary>
        private DateTime? startDate { get; set; }

        /// <summary>
        /// Gets or sets the endDate.
        /// </summary>
        private DateTime? endDate { get; set; }

        /// <summary>
        /// Defines the dtResult.
        /// </summary>
        private DataTable dtResult = new DataTable();

        #endregion

        #region==========Get Data==========
        /// <summary>
        /// GetSelectedReportData
        /// </summary>
        private void GetSelectedReportData()
        {
            Consts.REPORTNAME = "RptTopTenSaleProductList";
            dsReport = saleService.GetRptTopTenSaleProductList(pageCount);
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
            lblNoSaleListText.Visible = true;
        }

        /// <summary>
        /// The ShowDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvTopTenSaleReport.Visible = true;
            cboShowItem.Visible = true;
            lblListPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
            lblNoSaleListText.Visible = false;
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
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtSaleList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblListPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvTopTenSaleReport.DataSource = dtResult;
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
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnReset.BackColor = Properties.Settings.Default.BackColor;
            btnPreview.BackColor = Properties.Settings.Default.BackColor;
            btnDownload.BackColor = Properties.Settings.Default.BackColor;
            dgvTopTenSaleReport.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCTopTenSaleReport()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCTopTenSaleReport_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCTopTenSaleReport_Load(object sender, EventArgs e)
        {
            UCTopTenSaleReport uCTopTenSaleReport = new UCTopTenSaleReport();
            dtSaleList = saleService.GetTopTenSaleProductLists();
            if (dtSaleList.Rows.Count > 0)
            {
                dgvTopTenSaleReport.DataSource = dtSearchResult;
                ShowDetails();
            }
            else
            {
                HideDetails();
            }
            cboShowItem.SelectedIndex = 0;
            cboSelectItem.SelectedIndex = 0;
            dgvTopTenSaleReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCTopTenSaleReport);
            localization.ChangeDatagridText(dgvTopTenSaleReport);
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
        /// btnSearch_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (changeFromDate == 1)
            {
                startDate = dtpFrom.Value;
            }
            if (changeToDate == 1)
            {
                endDate = dtpTo.Value;
            }
            if (!startDate.Equals(null) && !endDate.Equals(null))
            {
                if (startDate > endDate)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(DAO.Common.Messages.W0016, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(DAO.Common.Messages.B0009, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }
            }
            getFilterList = GetFilter();
            dtSearchResult = saleService.GetSearchResultForTopTenSaleProductList(getFilterList);
            dgvTopTenSaleReport.DataSource = dtSearchResult;
            if (dtSearchResult.Rows.Count > 0)
            {
                startCount = 0;
                currentPage = 1;
                GetCurrentPageRecords(currentPage);
                ShowDetails();
            }
            else
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W00105, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0068, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                HideDetails();
            }
        }

        /// <summary>
        /// The GetFilter.
        /// </summary>
        /// <returns>The <see cref="List{object}"/>.</returns>
        private List<object> GetFilter()
        {
            List<object> filterList = new List<object>();
            if (startDate != null)
                filterList.Add(Convert.ToDateTime(startDate).ToString(Consts.DATEFORMAT));
            else filterList.Add(startDate);
            if (endDate != null)
                filterList.Add(Convert.ToDateTime(endDate).ToString(Consts.DATEFORMAT));
            else filterList.Add(endDate);
            filterList.Add(changeFromDate);
            filterList.Add(changeToDate);
            filterList.Add(pageCount);
            return filterList;
        }

        /// <summary>
        /// dtpFrom_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            changeFromDate = 1;
            this.dtpFrom.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// dtpTo_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            changeToDate = 1;
            this.dtpTo.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// btnReset_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            changeFromDate = 0;
            changeToDate = 0;
            dtpFrom.CustomFormat = " ";
            dtpTo.CustomFormat = " ";
            startDate = null;
            endDate = null;
            cboSelectItem.SelectedIndex = 0;
            cboShowItem.SelectedIndex = 0;
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// btnSubmit_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnSubmit_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// dgvTopTenSaleReport_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTopTenSaleReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvTopTenSaleReport.CurrentCell.Selected = false;
        }

        /// <summary>
        /// cboSelectItem_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSelectItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageCount = Convert.ToInt32(cboShowItem.GetItemText(cboSelectItem.SelectedItem));
        }

        private void dgvTopTenSaleReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            Microsoft.Office.Interop.Excel.Worksheet objSheet = null;
            // collection of DataGrid Items
            var dtExcelDataTable = saleService.GetTopTenSaleProductXLSX(pageCount);
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
            string fileName = "TopTenSaleReport";
            int count = files.Count(file => { return file.Contains(fileName); });
            string newFileName = (count == 0) ? "TopTenSaleReport.xlsx"
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
        /// dgvTopTenSaleReport_RowPostPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTopTenSaleReport_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {         
            //var g = (DataGridView)sender;
            //var r = new Rectangle(e.RowBounds.Left - 20, e.RowBounds.Top,
            //        g.RowHeadersWidth, e.RowBounds.Height);
            //TextRenderer.DrawText(e.Graphics, $"{e.RowIndex + 1 + ((currentPage - 1) * count) }",
            //         dgvTopTenSaleReport.DefaultCellStyle.Font, r, g.RowHeadersDefaultCellStyle.ForeColor);
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
            dgvTopTenSaleReport.Focus();
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
            dgvTopTenSaleReport.Focus();
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
        #endregion     
    }
}
