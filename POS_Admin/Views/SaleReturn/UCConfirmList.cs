using DAO.Common;
using POS_Admin.Utilities;
using POS_Admin.Views.Auth;
using Services.Sale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Admin.Views.SaleReturn
{
    public partial class UCConfirmList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the saleService.
        /// </summary>
        private SaleService saleService = new SaleService();

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the mainForm.
        /// </summary>
        private MainForm mainForm = null;

        /// <summary>
        /// Defines the dtSearchResult, dtSaleList...............
        /// </summary>
        private DataTable dtSaleList = new DataTable(),
                            dtSearchResult = new DataTable();

        /// <summary>
        /// Defines the getFilterList.
        /// </summary>
        internal List<object> getFilterList = new List<object>();

        /// <summary>
        /// Defines the shopId, status, count, currentPage, totalPageCount...............
        /// </summary>
        private int count = 10, //show item count
                    currentPage = 1,
                    totalPageCount = 0,
                    startCount = 0,
                    changeDate = 0,
            changeFromDate = 0,
                    changeToDate = 0,
                    searchTotalCount = 0,
                    totalSaleCount = 0;// all search sale count

        /// <summary>
        /// Defines the startDate, endDate......
        /// </summary>
        private DateTime? startDate,
                         endDate;

        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// The HideDetails.
        /// </summary>
        private void HideDetails()
        {
            cboShowItem.Visible = false;
            lblPage.Visible = false;
            lblShowItemText.Visible = false;
            btnFirst.Visible = false;
            btnNext.Visible = false;
            btnLast.Visible = false;
            btnPrevious.Visible = false;
            lblPage.Visible = false;
            lblNoSaleText.Visible = true;
        }

        /// <summary>
        /// The ShowDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvSaleConfirm.Visible = true;
            cboShowItem.Visible = true;
            lblPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
            lblPage.Visible = true;
            lblNoSaleText.Visible = false;
        }

        /// <summary>
        /// The GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">The currentPage<see cref="int"/>.</param>
        private void GetCurrentPageRecords(int currentPage)
        {
            dtSaleList = saleService.GetSaleConfirmList(startCount,count);
            getFilterList = GetFilter();
            dtSaleList = saleService.GetSearchResult(getFilterList);
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtSaleList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvSaleConfirm.DataSource = dtResult;
            ConfigureGrid();
            pagination.PaginationButtonAction(dtSaleList, btnFirst, btnPrevious, btnNext, btnLast, currentPage);
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
            filterList.Add(2);
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
            dgvSaleConfirm.Columns["amount_tax"].DefaultCellStyle.Format = Consts.ROUNDTO;
            dgvSaleConfirm.Columns["amount"].DefaultCellStyle.Format = Consts.ROUNDTO;
            dgvSaleConfirm.Columns["total"].DefaultCellStyle.Format = Consts.ROUNDTO;
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            btnBack.BackColor = Properties.Settings.Default.BackColor;
            edit.LinkColor = Properties.Settings.Default.BackColor;
            edit.ActiveLinkColor = Properties.Settings.Default.BackColor;
            dgvSaleConfirm.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        public UCConfirmList(Form callingForm)
        {
            InitializeComponent();
            this.CustomizeThemes();
            mainForm = callingForm as MainForm;
        }

        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCConfirmList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCConfirmList_Load(object sender, EventArgs e)
        {
            UCConfirmList uCConfirmList = new UCConfirmList(mainForm);          
            totalSaleCount = saleService.GetSaleConfirmCount();
            if (totalSaleCount > 0)
            {
                dgvSaleConfirm.AutoGenerateColumns = false;
                lblNoSaleText.Visible = false;
                cboShowItem.SelectedIndex = 0;
            }
            else
            {
                HideDetails();
            }
            dgvSaleConfirm.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCConfirmList);
            localization.ChangeDatagridText(dgvSaleConfirm);
        }

        /// <summary>
        /// The dtpTo_ValueChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            changeToDate = 1;
            this.dtpDateFrom.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// btnBack_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UCSaleReturnList uCSaleReturnList = new UCSaleReturnList();
            this.Controls.Add(uCSaleReturnList);
            uCSaleReturnList.Show();
        }       

        /// <summary>
        /// btnReset_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpDateFrom.CustomFormat = " ";
            dtpDateTo.CustomFormat = " ";
            startDate = null;
            endDate = null;
            changeFromDate = 0;
            changeToDate = 0;
            txtInvoiceNumber.Text = "";
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// dgvSaleConfirm_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleConfirm_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvSaleConfirm.Columns[currentColumn].ReadOnly == true)
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
        /// dgvSaleConfirm_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleConfirm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvSaleConfirm.CurrentCell.Selected = false;
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
        /// The dtpFrom_ValueChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            changeFromDate = 1;
            this.dtpDateTo.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// The btnSearch_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpDateFrom.Text.ToString().Equals(" "))
                startDate = null;
            else startDate = Convert.ToDateTime(dtpDateFrom.Text);
            if (dtpDateTo.Text.ToString().Equals(" "))
                endDate = null;
            else endDate = Convert.ToDateTime(dtpDateTo.Text.ToString());

            if (changeFromDate == 1)
            {
                startDate = dtpDateFrom.Value;
            }
            if (changeToDate == 1)
            {
                endDate = dtpDateTo.Value;
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
            searchTotalCount = saleService.GetSearchConfirmCount(getFilterList);
            if (searchTotalCount > 0)
            {
                startCount = 0;
                currentPage = 1;
                GetCurrentPageRecords(currentPage);
                ShowDetails();
            }
            else
            {
                dgvSaleConfirm.DataSource = dtSearchResult;
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

        /// <summary>
        /// The cboShowItem_SelectedIndexChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void cboShowItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(cboShowItem.GetItemText(cboShowItem.SelectedItem));
            currentPage = 1;
            GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// The dgvSaleConfirm_CellContentClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/>.</param>
        private void dgvSaleConfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSaleConfirm.Columns["edit"].Index)
            {
                if (!dgvSaleConfirm.Rows[e.RowIndex].Cells["edit"].ReadOnly)
                {
                    Int64 saleId = Convert.ToInt64(dgvSaleConfirm.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    Consts.SALEID = saleId;
                    this.Controls.Clear();
                    UCSaleReturnEntryForm saleReturnEntryForm = new UCSaleReturnEntryForm(mainForm, Consts.SALEID);
                    this.Controls.Add(saleReturnEntryForm);
                    saleReturnEntryForm.Show();
                }
            }
        }

        /// <summary>
        /// The
        /// btnPrevious_Click.
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
        /// btnFirst_Click.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            startCount = 0;
            currentPage = 1;
            GetCurrentPageRecords(currentPage);
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
                dgvSaleConfirm.Focus();
            }
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
            dgvSaleConfirm.Focus();
        }

        #endregion
    }
}
