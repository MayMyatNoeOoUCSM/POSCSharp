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
    public partial class UCSaleReturnDetailsList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the saleReturnService.
        /// </summary>
        private SaleReturnService saleReturnService = new SaleReturnService();

        /// <summary>
        /// Defines the mainForm.
        /// </summary>
        private MainForm mainForm = null;

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the pageSize, totalPageCount, currentPage, count......
        /// </summary>
        private int pageSize = 0,
                    totalPageCount = 0,
                    currentPage = 1,
                    count = 0;

        /// <summary>
        /// Defines the dtSaleReturn, dtSaleReturnTemp...........
        /// </summary>
        private DataTable dtSaleReturn = new DataTable(),
                          dtSaleReturnTemp = new DataTable();

        /// <summary>
        /// Defines the localization
        /// </summary>
        private Localization localization = new Localization();
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">.</param>
        private void GetCurrentPageRecords(int currentPage)
        {
            ShowSaleReturnList();
            if (dtSaleReturn.Rows.Count < 1)
            {
                lblPage.Text = String.Empty;
            }
            else
            {
                pageSize = Convert.ToInt32(cboShowItem.SelectedItem.ToString());
                totalPageCount = pagination.CalculateTotalPages(dtSaleReturn, pageSize);
                lblPage.Text = currentPage + "/" + totalPageCount;
            }
            int previousPageOffSet = (currentPage - 1) * pageSize;

            if (dtSaleReturn.Rows.Count > 0)
            {
                dtSaleReturnTemp = dtSaleReturn.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            }
            else
            {
                dtSaleReturnTemp = dtSaleReturn;
            }
            dgvSaleReturnDetails.DataSource = dtSaleReturnTemp;
            pagination.PaginationButtonAction(
                dtSaleReturn,
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
        /// The ShowSaleReturnList.
        /// </summary>
        private void ShowSaleReturnList()
        {
            int returnId = Convert.ToInt32(lblReturnId.Text);
            dtSaleReturn = saleReturnService.GetSaleReturnDetail(returnId);
            dgvSaleReturnDetails.DataSource = dtSaleReturn;
            dgvSaleReturnDetails.Columns["price"].DefaultCellStyle.Format = Consts.ROUNDTO;
            txtInvoiceNumber.Text = dgvSaleReturnDetails.Rows[0].Cells["invoice_number"].Value.ToString();
            txtSaleDate.Text = dgvSaleReturnDetails.Rows[0].Cells["return_date"].Value.ToString();
            decimal totalprice =Convert.ToDecimal (dgvSaleReturnDetails.Rows[0].Cells["totalprice"].Value.ToString());
            lblTotalPrice.Text =string.Format ("{0:N0}", totalprice);
            lblTotalQty.Text = dgvSaleReturnDetails.Rows[0].Cells["totalqty"].Value.ToString();
        }

        /// <summary>
        /// The HideDetail.
        /// </summary>
        private void Hidedetails()
        {
            dgvSaleReturnDetails.Visible = false;
            cboShowItem.Visible = false;
            lblPage.Visible = false;
            lblShowItemText.Visible = false;
            btnFirst.Visible = false;
            btnNext.Visible = false;
            btnLast.Visible = false;
            btnPrevious.Visible = false;
        }

        /// <summary>
        /// btnBack_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {         
            UCSaleReturnList ucSaleReturnList = new UCSaleReturnList();
            this.Controls.Clear();
            this.Controls.Add(ucSaleReturnList);
        }

        /// <summary>
        /// The ShowDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvSaleReturnDetails.Visible = true;
            cboShowItem.Visible = true;
            lblPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnBack.BackColor = Properties.Settings.Default.BackColor;       
            dgvSaleReturnDetails.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }

        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initializes a new instance of the <see cref="UCSaleReturnDetailsList"/> class.
        /// </summary>
        /// <param name="callingForm">The callingForm<see cref="Form"/>.</param>
        public UCSaleReturnDetailsList()
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
        private void UCSaleReturnDetailsList_Load(object sender, EventArgs e)
        {
            UCSaleReturnDetailsList uCSaleReturnDetailsList = new UCSaleReturnDetailsList();
            dgvSaleReturnDetails.AutoGenerateColumns = false;
            dgvSaleReturnDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            cboShowItem.SelectedIndex = 0;
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCSaleReturnDetailsList);
            localization.ChangeDatagridText(dgvSaleReturnDetails);
        }

        /// <summary>
        /// The cboShowItems_SelectedIndexChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void cboShowItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(cboShowItem.GetItemText(cboShowItem.SelectedItem));
            if (currentPage > 1)
            {
                currentPage = 1;
            }
            GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// dgvSaleReturnDetails_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleReturnDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvSaleReturnDetails.CurrentCell.Selected = false;
        }
        #endregion
    }
}
