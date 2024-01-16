using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using POS_Admin.Utilities;
using DAO.Common;
using Services.Stock;
using Services.Supplier;


namespace POS_Admin.Views.Report
{
    public partial class UCSupplierPaymentReport : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the stockService.
        /// </summary>
        private StockService stockService = new StockService();

        /// <summary>
        /// Defines the supplierService.
        /// </summary>
        private SupplierService supplierService = new SupplierService();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the dtStockList, dtParentCategory, dtTemp.....
        /// </summary>
        private DataTable dtSupplierList = new DataTable(),
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
                    changeDueDate = 0,
                    searchTotalCount = 0;// all search sale count

        /// <summary>
        /// Gets or sets the DueDate.
        /// </summary>
        private DateTime? dueDate { get; set; }

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

        /// <summary>
        /// Defines the dtSupplier.
        /// </summary>
        private DataTable dtSupplier = new DataTable();

        /// <summary>
        /// Defines the dtStock.
        /// </summary>
        //private DataTable dtStockList = new DataTable();
        #endregion

        #region==========Get Data==========
        /// <summary>
        /// GetSelectedReportData
        /// </summary>
        private void GetSelectedReportData()
        {
            Consts.REPORTNAME = "RptSupplierPaymentReport";
            dsReport = supplierService.GetSupplierPaymentReport();
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
            lblNoSupplierPaymentListText.Visible = true;
        }

        /// <summary>
        /// The ShowDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvSupplierPaymentReport.Visible = true;
            cboShowItem.Visible = true;
            lblListPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
            lblNoSupplierPaymentListText.Visible = false;
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

        #region==========Bind ComboData==========
        /// <summary>
        /// BindCboSupplier
        /// </summary>
        private void BindCboSupplier()
        {
            DataRow dr = dtSupplier.NewRow(); //Create New Row
            dr["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                dr["supplier_name"] = "Select Supplier Name";
            }
            else
            {
                dr["supplier_name"] = "ကုန်သွင်းသူအမည်ကိုရွေးပါ";
                cboSupplier.Font = new Font("Myanmar Text", 10);
            }
            dtSupplier.Rows.InsertAt(dr, 0);
            cboSupplier.DataSource = dtSupplier;
            cboSupplier.DisplayMember = "supplier_name";
            cboSupplier.ValueMember = "id";
            cboSupplier.SelectedIndex = 0;
        }
        #endregion

        #region==========Pagination==========
        /// <summary>
        /// GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">.</param>
        private void GetCurrentPageRecords(int currentPage)
        {
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtSupplierList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblListPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvSupplierPaymentReport.DataSource = dtResult;
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
            dgvSupplierPaymentReport.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        public UCSupplierPaymentReport()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region===========Filter Data==========
        /// <summary>
        /// GetFilter
        /// </summary>
        /// <returns> the <see cref="List{object}"/>.</returns>
        private List<object> GetFilter()
        {
            List<object> filterList = new List<object>();
            Int64 searchSupplierId = Convert.ToInt64(cboSupplier.SelectedValue);
            filterList.Add(searchSupplierId);
            if (startDate != null)
                filterList.Add(Convert.ToDateTime(startDate).ToString(Consts.DATEFORMAT));
            else filterList.Add(startDate);
            if (endDate != null)
                filterList.Add(Convert.ToDateTime(endDate).ToString(Consts.DATEFORMAT));
            else filterList.Add(endDate);
            if (dueDate != null)
                filterList.Add("'" + Convert.ToDateTime(dueDate).ToString(Consts.DATEFORMAT) + "'");
            else filterList.Add(0);
            filterList.Add(changeFromDate);
            filterList.Add(changeToDate);
            filterList.Add(changeDueDate);
            return filterList;
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCSupplierPaymentReport_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSupplierPaymentReport_Load(object sender, EventArgs e)
        {
            UCSupplierPaymentReport uCSupplierPaymentReport = new UCSupplierPaymentReport();
            lblNoSupplierPaymentListText.Visible = false;
            dtSupplierList = supplierService.GetSupplierPaymentList();
            if (dtSupplierList.Rows.Count > 0)
            {
                dgvSupplierPaymentReport.DataSource = dtSupplierList;
                ShowDetails();
            }
            else
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W0106, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0092, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                HideDetails();
            }
            cboShowItem.SelectedIndex = 0;
            dtSupplier = supplierService.GetSupplierList();
            this.BindCboSupplier();
            dgvSupplierPaymentReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCSupplierPaymentReport);
            localization.ChangeDatagridText(dgvSupplierPaymentReport);
        }

        /// <summary>
        /// cboSupplier_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
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
            if(changeFromDate == 1)
            {
                startDate = dtpFrom.Value;
            }
            if(changeToDate == 1)
            {
                endDate = dtpTo.Value;
            }
            if(changeDueDate == 1)
            {
                dueDate = dtpDue.Value;
            }
            if (!startDate.Equals(null) && !endDate.Equals(null))
            {
                if (startDate > endDate)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(DAO.Common.Messages.W0106, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(DAO.Common.Messages.B0092, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }
            }
            getFilterList = GetFilter();
            dtSearchResult = supplierService.GetSupplierPayment(getFilterList); // to change
            dgvSupplierPaymentReport.DataSource = dtSearchResult;
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
                    MessageBox.Show(DAO.Common.Messages.W0106, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0092, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                HideDetails();
            }
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

        private void dgvSupplierPaymentReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvSupplierPaymentReport.CurrentCell.Selected = false;
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
        /// dtpDue_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDue_ValueChanged(object sender, EventArgs e)
        {
            changeDueDate = 1;
            this.dtpDue.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// btnReset_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            cboSupplier.SelectedIndex = 0;
            changeFromDate = 0;
            changeToDate = 0;
            changeDueDate = 0;
            startDate = null;
            endDate = null;
            dueDate = null;
            dtpFrom.CustomFormat = " ";
            dtpTo.CustomFormat = " ";
            dtpDue.CustomFormat = " ";
            btnSearch_Click(null, null);
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
            Microsoft.Office.Interop.Excel.Worksheet objSheet = null;
            // collection of DataGrid Items
            var dtExcelDataTable = supplierService.GetSupplierPaymentXLSX(); // to change
            //var dtExcelDataTable = saleService.GetTopTenSaleProductXLSX(); // to change
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
            string fileName = "SupplierPaymentReport";
            int count = files.Count(file => { return file.Contains(fileName); });
            string newFileName = (count == 0) ? "SupplierPaymentReport.xlsx"
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
        /// btnFirst_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            this.GetCurrentPageRecords(currentPage);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                this.GetCurrentPageRecords(currentPage);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPageCount)
            {
                currentPage++;
                this.GetCurrentPageRecords(currentPage);
            }
            dgvSupplierPaymentReport.Focus();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPageCount;
            this.GetCurrentPageRecords(currentPage);
            dgvSupplierPaymentReport.Focus();
        }

        /// <summary>
        /// KnownFolder
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
