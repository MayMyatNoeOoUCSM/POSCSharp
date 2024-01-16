using POS_Admin.Utilities;
using System;
using Entities.Sale;
using Services.Sale;
using Services.DamageLoss;
using Services.Product;
using Services.Supplier;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO.Common;
using POS_Admin.Properties;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace POS_Admin.Views.Sale
{
    public partial class UCSaleList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the damageLossEntity.
        /// </summary>
        private SaleEntity saleEntity = new SaleEntity();

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

        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// The GetHeaderSource.
        /// </summary>
        private void GetHeaderSource()
        {
            cboShowItemList.SelectedIndex = 0;
            Dictionary<int, string> staffStatus = new Dictionary<int, string>();         
            if (Consts.LANGUAGEID == 1)
            {
                staffStatus.Add(0, "Select Role");
            }
            else
            {
                staffStatus.Add(0, "အဆင့်ရွေးပါ");
                cboStatus.Font = new Font("Myanmar Text", 10);
            }
            staffStatus.Add(1, "Confirmed");
            staffStatus.Add(2, "Cancelled");
            cboStatus.DataSource = new BindingSource(staffStatus, null);
            cboStatus.DisplayMember = "Value";
            cboStatus.ValueMember = "Key";
            cboStatus.SelectedIndex = 0;
            cboShowItemList.SelectedIndex = 0;
        }

        /// <summary>
        /// WriteCSV.
        /// </summary>
        /// <param name="input">.</param>
        /// <returns>.</returns>
        public static string WriteCSV(string input)
        {
            try
            {
                if (input == null)
                    return string.Empty;
                bool containsQuote = false;
                bool containsComma = false;
                int len = input.Length;
                for (int i = 0; i < len && (containsComma == false || containsQuote == false); i++)
                {
                    char ch = input[i];
                    if (ch == '"')
                        containsQuote = true;
                    else if (ch == ',')
                        containsComma = true;
                }
                if (containsQuote && containsComma)
                    input = input.Replace("\"", "\"\"");
                if (containsComma)
                    return "\"" + input + "\"";
                else
                    return input;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">The currentPage<see cref="int"/>.</param>
        private void GetCurrentPageRecords(int currentPage)
        {
            dtSaleList = saleService.GetSaleList(startCount, count);
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtSaleList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblListPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvSale.DataSource = dtResult;
            ConfigureGrid();
            pagination.PaginationButtonAction(dtResult, btnFirst, btnPrevious, btnNext, btnLast, currentPage);
            pagination.PaginationButtonPaint(btnFirst, btnPrevious, btnNext, btnLast);
        }

        /// <summary>
        /// The GetFilter.
        /// </summary>
        /// <returns>The <see cref="List{object}"/>.</returns>
        private List<object> GetFilter()
        {
            List<object> filterList = new List<object>();
            filterList.Add(txtInvoiceNumber.Text);
            filterList.Add(status);
            if (startDate != null)
                filterList.Add(Convert.ToDateTime(startDate).ToString(Consts.DATEFORMAT));
            else filterList.Add(startDate);
            if (endDate != null)
                filterList.Add(Convert.ToDateTime(endDate).ToString(Consts.DATEFORMAT));
            else filterList.Add(endDate);
            filterList.Add(changeFromDate);
            filterList.Add(changeToDate);
            filterList.Add(startCount);
            filterList.Add(count);
            return filterList;
        }

        /// <summary>
        /// The ConfigureGrid.
        /// </summary>
        private void ConfigureGrid()
        {
            dgvSale.Columns["amount_tax"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvSale.Columns["amount"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvSale.Columns["total"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
        }

        /// <summary>
        /// The HideDetails.
        /// </summary>
        private void HideDetails()
        {
            cboShowItemList.Visible = false;
            lblListPage.Visible = false;
            lblShowItemText.Visible = false;
            btnFirst.Visible = false;
            btnNext.Visible = false;
            btnLast.Visible = false;
            btnPrevious.Visible = false;
            lblListPage.Visible = false;
            lblNoSaleListText.Visible = true;
        }
        
        /// <summary>
        /// The HideDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvSale.Visible = true;
            cboShowItemList.Visible = true;
            lblListPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
            lblListPage.Visible = true;
            lblNoSaleListText.Visible = false;
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

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            btnDownload.BackColor = Properties.Settings.Default.BackColor;        
            dgvSale.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
            edit.LinkColor = Properties.Settings.Default.BackColor;
            edit.ActiveLinkColor = Properties.Settings.Default.BackColor;
            edit.VisitedLinkColor = Properties.Settings.Default.BackColor;
            exceldetails.LinkColor = Properties.Settings.Default.BackColor;
            exceldetails.ActiveLinkColor = Properties.Settings.Default.BackColor;
            exceldetails.VisitedLinkColor = Properties.Settings.Default.BackColor;
            payment.LinkColor = Properties.Settings.Default.BackColor;
            payment.ActiveLinkColor = Properties.Settings.Default.BackColor;
            payment.VisitedLinkColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCSaleList()
        {
            InitializeComponent();
            this.CustomizeThemes();
            totalSaleCount = saleService.GetSaleCount();
            if (totalSaleCount > 0)
            {
                lblNoSaleListText.Visible = false;
                dgvSale.AutoGenerateColumns = false;
                GetHeaderSource();
                cboShowItemList.SelectedIndex = 0;
            }
            else
            {
                HideDetails();
            }
        }

        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCSaleList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSaleList_Load(object sender, EventArgs e)
        {
            UCSaleList uCSaleList = new UCSaleList();        
            totalSaleCount = saleService.GetSaleCount();
            if (totalSaleCount > 0)
            {
                ShowDetails();
                lblNoSaleListText.Visible = false;
                dgvSale.AutoGenerateColumns = false;
                cboShowItemList.SelectedIndex = 0;
            }
            else
            {
                HideDetails();
            }
            GetHeaderSource();
            dgvSale.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCSaleList);
            localization.ChangeDatagridText(dgvSale);
        }

        /// <summary>
        /// btnReset_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInvoiceNumber.Text = String.Empty;
            cboStatus.SelectedIndex = 0;
            dtpFrom.CustomFormat = " ";
            dtpTo.CustomFormat = " ";
            startDate = null;
            endDate = null;
            chkToday.Checked = false;
            chkWeekly.Checked = false;
            chkMonthly.Checked = false;
            chkYearly.Checked = false;
            changeFromDate = 0;
            changeToDate = 0;
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// btnDownload_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            dtResult = saleService.GetSaleListCSV();
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (DataColumn column in dtResult.Columns)
            {
                column.ColumnName = ti.ToTitleCase(column.ColumnName);
                column.ColumnName = column.ColumnName.Replace("_", " ");
            }
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= dtResult.Columns.Count - 1; i++)
            {
                // Append column name in quotes
                sb.Append("\"" + dtResult.Columns[i].ColumnName + "\"");
                // Add carriage return and linefeed if last column, else add comma
                sb.Append(i == dtResult.Columns.Count - 1 ? "\n" : ",");
            }
            foreach (DataRow row in dtResult.Rows)
            {
                for (int i = 0; i <= dtResult.Columns.Count - 1; i++)
                {
                    // Append value in quotes
                    //sb.Append("""" & row.Item(i) & """")
                    // OR only quote items that that are equivilant to strings
                    sb.Append(object.ReferenceEquals(dtResult.Columns[i].DataType, typeof(string)) || object.ReferenceEquals(dtResult.Columns[i].DataType, typeof(char)) ? "\"" + row[i] + "\"" : row[i]);

                    // Append CR+LF if last field, else add Comma
                    sb.Append(i == dtResult.Columns.Count - 1 ? "\n" : ",");
                }
            }
            string destFilePath = connection.GetIniString("SALE_FILE_PATH", "FILE_PATH_NAME", Consts.FILEPATH);
            string currDate = DateTime.Now.ToString();
            currDate = Regex.Replace(currDate, "[^0-9a-zA-Z]+", String.Empty);
            if (!Directory.Exists(destFilePath))
                Directory.CreateDirectory(destFilePath);
            File.WriteAllText(destFilePath + currDate + ".csv", sb.ToString());
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                MessageBox.Show(DAO.Common.Messages.I0036, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(DAO.Common.Messages.B0071, DAO.Common.Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// chkToday_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkToday_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_CheckedChanged(sender, e);
        }

        /// <summary>
        /// chkWeekly_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkWeekly_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_CheckedChanged(sender, e);
        }

        /// <summary>
        /// chkMonthly_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMonthly_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_CheckedChanged(sender, e);
        }

        /// <summary>
        /// chkYearly_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkYearly_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_CheckedChanged(sender, e);
        }

        /// <summary>
        /// The CheckBox_CheckedChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chkToday.Checked == true && chk.Text == chkToday.Text)
            {
                chkWeekly.Checked = false;
                chkMonthly.Checked = false;
                chkYearly.Checked = false;
                startDate = DateTime.Now.Date;
                endDate = DateTime.Now.Date;
                getFilterList = GetFilter();
                dtSearchResult = saleService.GetSearchResult(getFilterList);
                dgvSale.DataSource = dtSearchResult;
            }
            else if (chkWeekly.Checked == true && chk.Text == chkWeekly.Text)
            {
                chkToday.Checked = false;
                chkMonthly.Checked = false;
                chkYearly.Checked = false;
                startDate = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                if (!startDate.Equals(" "))
                {
                    endDate = startDate.Value.AddDays(6);
                }
                getFilterList = GetFilter();
                dtSearchResult = saleService.GetSearchResult(getFilterList);
                dgvSale.DataSource = dtSearchResult;
            }
            else if (chkMonthly.Checked == true && chk.Text == chkMonthly.Text)
            {
                chkToday.Checked = false;
                chkWeekly.Checked = false;
                chkYearly.Checked = false;
                DateTime now = DateTime.Now;
                startDate = new DateTime(now.Year, now.Month, 1);
                endDate = startDate.Value.AddMonths(1).AddDays(-1);
                getFilterList = GetFilter();
                dtSearchResult = saleService.GetSearchResult(getFilterList);
                dgvSale.DataSource = dtSearchResult;
            }
            else if (chkYearly.Checked == true && chk.Text == chkYearly.Text)
            {
                chkToday.Checked = false;
                chkWeekly.Checked = false;
                chkMonthly.Checked = false;
                int year = DateTime.Now.Year;
                startDate = new DateTime(year, 1, 1);
                endDate = startDate.Value.AddYears(1).AddTicks(-1);
                getFilterList = GetFilter();
                dtSearchResult = saleService.GetSearchResult(getFilterList);
                dgvSale.DataSource = dtSearchResult;
            }
            if (dtSearchResult.Rows.Count > 0)
            {
                currentPage = 1;
                searchTotalCount = saleService.GetSearchCount(getFilterList);
                GetCurrentPageRecords(currentPage);
                ShowDetails();
            }
            else
            {
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
        /// dgvSale_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSale_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvSale.CurrentCell.Selected = false;
            if (Convert.ToInt32(dgvSale.Rows[e.RowIndex].Cells["invoice_status"].Value) == 3)
            {
                DataGridViewRow row = dgvSale.Rows[e.RowIndex];// get you required index                        
                row.DefaultCellStyle.BackColor = Color.FromArgb(218, 218, 218);
                row.DefaultCellStyle.SelectionForeColor = Color.Black;
                if (dgvSale.Columns[e.ColumnIndex].Index == 9)
                {
                    //e.Value = Resources.already_cancel;
                    //edit.Text = "Already Cancel";
                    dgvSale.Columns["edit"].ReadOnly = true;
                }
                else dgvSale.Columns["edit"].ReadOnly = false;
            }
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
        /// cboShowItemList_SelectedIndexChanged_1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboShowItemList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            count = Convert.ToInt32(cboShowItemList.GetItemText(cboShowItemList.SelectedItem));
            currentPage = 1;
            GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// txtInvoiceNumber_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvoiceNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// dgvSale_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSale_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvSale.Columns[currentColumn].ReadOnly == true)
                {
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Hand;
                }
            }
        }

        /// <summary>
        /// cboStatus_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = cboStatus.SelectedIndex + 1;
        }

        /// <summary>
        /// cboShowItemList_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboShowItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(cboShowItemList.GetItemText(cboShowItemList.SelectedItem));
            currentPage = 1;
            GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// The btnLast_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            startCount = (totalPageCount - 1) * count;
            currentPage = totalPageCount;
            GetCurrentPageRecords(currentPage);
            dgvSale.Focus();
        }

        /// <summary>
        /// The btnNext_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPageCount)
            {
                currentPage++;
                startCount += count;
                GetCurrentPageRecords(currentPage);
            }
            dgvSale.Focus();
        }

        /// <summary>
        /// The btnPrevious_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                startCount = (currentPage - 1) * count;
                GetCurrentPageRecords(currentPage);
            }
        }

        /// <summary>
        /// The btnFirst_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            startCount = 0;
            currentPage = 1;
            GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// dgvSale_Scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSale_Scroll(object sender, ScrollEventArgs e)
        {
            this.Validate();
        }

        /// <summary>
        /// dgvSale_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Int64 saleId = Convert.ToInt64(dgvSale.Rows[e.RowIndex].Cells["idno"].Value.ToString());
            if (e.ColumnIndex == dgvSale.Columns["edit"].Index)
            {
                if (Convert.ToInt32(dgvSale.Rows[e.RowIndex].Cells["invoice_status"].Value) != 3)
                {
                    //if (!dgvSale.Rows[e.RowIndex].Cells["edit"].ReadOnly)
                    //{
                    DAO.Common.Consts.SALEID = saleId;
                    this.Controls.Clear();
                    UCSaleForm saleForm = new UCSaleForm(DAO.Common.Consts.SALEID);
                    this.Controls.Add(saleForm);
                    saleForm.Show();
                }
                else
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(DAO.Common.Messages.I0034, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(DAO.Common.Messages.M0012, DAO.Common.Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
            if (e.ColumnIndex == dgvSale.Columns["exceldetails"].Index)
            {
                string downloads;
                SHGetKnownFolderPath(KnownFolder.Downloads, 0, IntPtr.Zero, out downloads);
                if (!dgvSale.Rows[e.RowIndex].Cells["exceldetails"].ReadOnly)
                {
                    DAO.Common.Consts.SALEID = saleId;
                    dtResult = saleService.GetDetailCSV(DAO.Common.Consts.SALEID);
                    TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                    foreach (DataColumn column in dtResult.Columns)
                    {
                        column.ColumnName = ti.ToTitleCase(column.ColumnName);
                        column.ColumnName = column.ColumnName.Replace("_", " ");
                    }
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dtResult.Columns.Count - 7; i++)
                    {
                        sb.Append(dtResult.Columns[i]);
                        if (i < dtResult.Columns.Count - 8)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.AppendLine();
                    foreach (DataRow dr in dtResult.Rows)
                    {
                        for (int col = 0; col < dtResult.Columns.Count - 7; col++)
                        {
                            sb.Append(WriteCSV(dr[col].ToString()) + ",");
                        }
                        sb.Remove(sb.Length - 1, 1);
                        sb.AppendLine();
                        break;
                    }
                    sb.AppendLine();
                    for (int i = 6; i < dtResult.Columns.Count - 1; i++)
                    {
                        sb.Append(dtResult.Columns[i]);
                        if (i < dtResult.Columns.Count - 2)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.AppendLine();
                    int NoCol = 1;
                    foreach (DataRow dr in dtResult.Rows)
                    {
                        for (int col = 6; col < dtResult.Columns.Count - 1; col++)
                        {
                            //dr[6] = NoCol;
                            sb.Append(WriteCSV(dr[col].ToString()) + ",");
                        }
                        NoCol++;
                        sb.Remove(sb.Length - 1, 1);
                        sb.AppendLine();
                    }
                    string folderPath = downloads + "\\";
                    string[] files = Directory.GetFiles(folderPath);
                    string fileName = "saledetails";                  
                    int count = files.Count(file => { return file.Contains(fileName); });
                    string newFileName = (count == 0) ? "saledetails.csv"
                      : String.Format("{0} ({1}).csv", fileName, count);
                    
                    File.WriteAllText(folderPath + newFileName, sb.ToString());
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(DAO.Common.Messages.I0035, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(DAO.Common.Messages.B0070, DAO.Common.Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                  
                }
            }
            if (e.ColumnIndex == dgvSale.Columns["payment"].Index)
            {
                string totalAmount = dgvSale.Rows[e.RowIndex].Cells["amount"].Value.ToString();
                string paidAmount = dgvSale.Rows[e.RowIndex].Cells["paid_amount"].Value.ToString() == "" ? 
                    dgvSale.Rows[e.RowIndex].Cells["amount"].Value.ToString() : dgvSale.Rows[e.RowIndex].Cells["paid_amount"].Value.ToString();

                if (Convert.ToInt32(totalAmount) <= Convert.ToInt32(paidAmount))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(DAO.Common.Messages.I0037, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(DAO.Common.Messages.B0082, DAO.Common.Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    this.Controls.Clear();
                    PaymentDetail paymentDetail = new PaymentDetail(saleId);
                    paymentDetail.txtTotalAmount.Text = dgvSale.Rows[e.RowIndex].Cells["total"].Value.ToString();
                    paymentDetail.txtPaidAmount.Text = dgvSale.Rows[e.RowIndex].Cells["paid_amount"].Value.ToString();
                    paymentDetail.lblid.Text = dgvSale.Rows[e.RowIndex].Cells["idno"].Value.ToString();
                    var left = Convert.ToInt32(paymentDetail.txtTotalAmount.Text) - Convert.ToInt32(paymentDetail.txtPaidAmount.Text);
                    paymentDetail.txtLeftAmount.Text = left.ToString();
                    this.Controls.Add(paymentDetail);
                    paymentDetail.Show();
                }
            }
        }

        /// <summary>
        /// dgvSale_RowPostPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSale_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var g = (DataGridView)sender;
            //var r = new Rectangle(e.RowBounds.Left - 5, e.RowBounds.Top,
            //        g.RowHeadersWidth, e.RowBounds.Height);
            //TextRenderer.DrawText(e.Graphics, $"{e.RowIndex + 1 + ((currentPage - 1) * count) }",
            //         dgvSale.DefaultCellStyle.Font, r, g.RowHeadersDefaultCellStyle.ForeColor);
        }

        /// <summary>
        /// btnSearch_Click
        /// </summary>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var statusSelectedValue = Convert.ToInt32(cboStatus.SelectedValue);
            if (statusSelectedValue == 1)
            {
                status = 2;
            }
            else if (statusSelectedValue == 2)
            {
                status = 3;
            }
            else
            {
                status = 0;
            }
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
            searchTotalCount = saleService.GetSearchCount(getFilterList);
            dtSearchResult = saleService.GetSearchResult(getFilterList);
            dgvSale.DataSource = dtSearchResult;
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
                    MessageBox.Show(DAO.Common.Messages.W0097, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0028, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                HideDetails();
            }
        }
        #endregion
    }
}
