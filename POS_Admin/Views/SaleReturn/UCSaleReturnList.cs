using Entities.SaleReturn;
using DAO.Common;
using POS_Admin.Utilities;
using POS_Admin.Views.Auth;
using Services.SaleReturn;
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
    public partial class UCSaleReturnList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the saleReturnEntity.
        /// </summary>
        private SaleReturnEntity saleReturnEntity = new SaleReturnEntity();

        /// <summary>
        /// Defines the saleReturnService.
        /// </summary>
        private SaleReturnService saleReturnService = new SaleReturnService();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the dtReturnResult, dtSearchResult.
        /// </summary>
        private DataTable dtReturnResult = new DataTable(),
                          dtSearchResult = new DataTable(),
                          dtSaleReturnList = new DataTable();

        /// <summary>
        /// Defines the mainForm.
        /// </summary>
        private MainForm mainForm = null;

        /// <summary>
        /// Defines the count, isDateChange, currentPage, totalPageCount.
        /// </summary>
        private int count = 0,
                    changeFromDate = 0,
                    changeToDate = 0,
                    currentPage = 1,
                    totalPageCount = 0;

        /// <summary>
        /// Gets or sets the startDate.
        /// </summary>
        private string startDate { get; set; }

        /// <summary>
        /// Gets or sets the endDate.
        /// </summary>
        private string endDate { get; set; }

        /// <summary>
        /// Defines the localization
        /// </summary>
        private Localization localization = new Localization();
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// The HideDetail.
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
            lblNoSaleReturnText.Visible = true;
        }

        /// <summary>
        /// The ShowDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvSaleReturn.Visible = true;
            cboShowItem.Visible = true;
            lblPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
            lblNoSaleReturnText.Visible = false;
        }

        /// <summary>
        /// The GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">The currentPage<see cref="int"/>.</param>
        private void GetCurrentPageRecords(int currentPage)
        {
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtReturnResult : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvSaleReturn.DataSource = dtResult;
            ConfigureGrid();
            pagination.PaginationButtonAction(dtResult, btnFirst, btnPrevious, btnNext, btnLast, currentPage);
            pagination.PaginationButtonPaint(btnFirst, btnPrevious, btnNext, btnLast);
        }

        /// <summary>
        /// The ConfigureGrid.
        /// </summary>
        private void ConfigureGrid()
        {
            if (dgvSaleReturn.Rows.Count > 5)
                dgvSaleReturn.Columns["return_invoice_number"].Width = 183;
            else
                dgvSaleReturn.Columns["return_invoice_number"].Width = 200;
        }

        /// <summary>
        /// DeleteCategory.
        /// </summary>
        /// <param name="id">.</param>
        private void DeleteDamageLossList(Int64 id, int productId, int quantity)
        {          
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                MessageBox.Show(Messages.I0003, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Messages.B0041, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            btnAdd.BackColor = Properties.Settings.Default.BackColor;
            edit.LinkColor = Properties.Settings.Default.BackColor;
            edit.ActiveLinkColor = Properties.Settings.Default.BackColor;
            dgvSaleReturn.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCSaleReturnList()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCDamageLossList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSaleReturnList_Load(object sender, EventArgs e)
        {
            UCSaleReturnList uCSaleReturnList = new UCSaleReturnList();
            dgvSaleReturn.AutoGenerateColumns = false;
            dtReturnResult = saleReturnService.GetSearchResult(txtInvoiceNumber.Text, null, null);
            dgvSaleReturn.DataSource = dtReturnResult;
            if (dtReturnResult.Rows.Count > 0)
            {
                //lblNoSaleReturnText.Visible = false;
                ShowDetails();
                cboShowItem.SelectedIndex = 0;
            }
            else
            {
                HideDetails();
            }
            dgvSaleReturn.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCSaleReturnList);
            localization.ChangeDatagridText(dgvSaleReturn);
        }

        /// <summary>
        /// The btnAdd_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCConfirmList ucConfirmList = new UCConfirmList(mainForm);
            this.Controls.Clear();
            this.Controls.Add(ucConfirmList);
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
        /// The dtpFrom_ValueChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void dtpReturnFrom_ValueChanged(object sender, EventArgs e)
        {
            changeFromDate = 1;
            this.dtpReturnFrom.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// The btnSearch_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (changeFromDate == 1)
            {
                startDate = dtpReturnFrom.Value.ToString(Consts.DATEFORMAT);
            }
            if (changeToDate == 1)
            {
                endDate = dtpReturnTo.Value.ToString(Consts.DATEFORMAT);
            }
            if (!String.IsNullOrEmpty(startDate) && !String.IsNullOrEmpty(endDate))
            {
                if (Convert.ToDateTime(startDate) > Convert.ToDateTime(endDate))
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
            dtSearchResult = saleReturnService.GetSearchResult(txtInvoiceNumber.Text, startDate, endDate);
            if (dtSearchResult.Rows.Count > 0)
            {
                currentPage = 1;
                GetCurrentPageRecords(currentPage);
                ShowDetails();
            }
            else
            {
                dgvSaleReturn.DataSource = dtSearchResult;
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
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInvoiceNumber.Text = String.Empty;
            dtpReturnFrom.Value = DateTime.Now;
            dtpReturnTo.Value = DateTime.Now;
            startDate = null;
            endDate = null;
            changeFromDate = 0;
            changeToDate = 0;
            dtpReturnTo.CustomFormat = " ";
            dtpReturnFrom.CustomFormat = " ";
            btnSearch_Click(null, null);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
        /// dgvSaleReturn_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleReturn_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvSaleReturn.Columns[currentColumn].ReadOnly == true)
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
        /// dgvSaleReturn_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleReturn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvSaleReturn.CurrentCell.Selected = false;
        }

        /// <summary>
        /// The dtpTo_ValueChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void dtpReturnTo_ValueChanged(object sender, EventArgs e)
        {
            changeToDate = 1;
            this.dtpReturnTo.CustomFormat = Consts.DATEFORMAT;
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
                GetCurrentPageRecords(currentPage);
            }
            dgvSaleReturn.Focus();
        }

        /// <summary>
        /// The btnLast_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPageCount;
            GetCurrentPageRecords(currentPage);
            dgvSaleReturn.Focus();
        }

        /// <summary>
        /// The dgvSaleReturn_CellContentClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/>.</param>
        private void dgvSaleReturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == dgvSaleReturn.Columns["edit"].Index)
            {
                this.Controls.Clear();
                UCSaleReturnDetailsList saleReturnDetailForm = new UCSaleReturnDetailsList();
                saleReturnDetailForm.lblReturnId.Text = dgvSaleReturn.Rows[e.RowIndex].Cells["id"].Value.ToString();
                this.Controls.Add(saleReturnDetailForm);
                saleReturnDetailForm.Show();
            }
        }
        #endregion
    }
}
