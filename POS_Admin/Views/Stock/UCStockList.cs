using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Supplier;
using Services.Category;
using Services.Product;
using Services.Stock;
using POS_Admin.Utilities;
using DAO.Common;
using Entities.Stock;
using Entities.Payment;
using Services.Payment;

namespace POS_Admin.Views.Stock
{
    public partial class UCStockList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the dtSupplier.
        /// </summary>
        private DataTable dtSupplier = new DataTable();

        /// <summary>
        /// Defines the supplierService.
        /// </summary>
        private SupplierService supplierService = new SupplierService();

        /// <summary>
        /// Defines the categoryService.
        /// </summary>
        private CategoryService categoryService = new CategoryService();

        /// <summary>
        /// Defines the dtSupplier.
        /// </summary>
        private DataTable dtProduct = new DataTable();

        /// <summary>
        /// Defines the dtCategory
        /// </summary>
        private DataTable dtCategory = new DataTable();

        /// <summary>
        /// Defines the dtSubCategory
        /// </summary>
        private DataTable dtSubCategory = new DataTable();

        /// <summary>
        /// Defines the productService.
        /// </summary>
        private ProductService productService = new ProductService();

        /// <summary>
        /// Defines the dtStock.
        /// </summary>
       // private DataTable dtStockList = new DataTable();

        /// <summary>
        /// Defines the dtPurchaseList
        /// </summary>
        private DataTable dtPurchaseList = new DataTable();

        /// <summary>
        /// Defines the dtPurchaseDetailList
        /// </summary>
        private DataTable dtPurchaseDetailList = new DataTable();

        /// <summary>
        /// dtPayment
        /// </summary>
        private DataTable dtPayment = new DataTable();

        /// <summary>
        /// Defines the st.
        /// </summary>
        //private StockService stockService = new StockService();


        /// <summary>
        /// Defines the stockService.
        /// </summary>
        private StockService stockService = new StockService();

        /// <summary>
        /// Defines the paymentService.
        /// </summary>
        private PaymentService paymentService = new PaymentService();

        /// <summary>
        /// Defines the stockEntity.
        /// </summary>
        private StockEntity stockEntity = new StockEntity();

        /// <summary>
        /// Defines the stockDetailEntity.
        /// </summary>
        private StockDetailEntity stockDetailEntity = new StockDetailEntity();

        /// <summary>
        /// Defines the paymentEntity.
        /// </summary>
        private PaymentEntity paymentEntity = new PaymentEntity();

        /// <summary>
        /// Gets or sets the startDate.
        /// </summary>
        private DateTime? startDate { get; set; }

        /// <summary>
        /// Gets or sets the endDate.
        /// </summary>
        private DateTime? endDate { get; set; }

        /// <summary>
        /// Gets or sets the dueDate.
        /// </summary>
        private DateTime? dueDate { get; set; }
        /// <summary>
        /// Defines the dtCategoryList, dtParentCategory, dtTemp.....
        /// </summary>
        private DataTable dtTemp = new DataTable(),
                          dtSearchResult = new DataTable();

        /// <summary>
        /// Defines the pageSize, currentPage, totalPageCount, count.....
        /// </summary>
        private int pageSize = 0,
                    currentPage = 1,
                    totalPageCount = 0,
                    count = 0,
                    changeFromDate = 0,
                    changeToDate = 0,
                    changeDueDate=0;

        /// <summary>
        /// Defines the getFilterList.
        /// </summary>
        internal List<object> getFilterList = new List<object>();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// detailIdList
        /// </summary>
        private List<string> lstDetailId = new List<string>();
        #endregion

        #region==========Bind Data==========
        /// <summary>
        /// The GetFilter.
        /// </summary>
        /// <returns>The <see cref="List{object}"/>.</returns>
        private List<object> GetFilter()
        {
            List<object> filterList = new List<object>();
            //index 0 for supplier
            if (cboSupplier.SelectedIndex == 0)
            {
                filterList.Add("");
            }
            else
            {
                filterList.Add(cboSupplier.Text);
            }

            //index 1 for due date
            if (dueDate != null)
            {
                filterList.Add(Convert.ToDateTime(dueDate).ToString(DAO.Common.Consts.DATEFORMAT));
            }
            else
            {
                filterList.Add("");
            }

            //index 2 for purchase from date
            if (startDate != null)
            {
                filterList.Add(Convert.ToDateTime(startDate).ToString(DAO.Common.Consts.DATEFORMAT));
            }
            else
            {
                filterList.Add("");
            }

            //index 3 for purchase to date
            if (endDate != null)
            {
                filterList.Add(Convert.ToDateTime(endDate).ToString(DAO.Common.Consts.DATEFORMAT));
            }
            else
            {
                filterList.Add("");
            }
            return filterList;
        }

        /// <summary>
        /// BindCboSupplier
        /// </summary>
        private void BindCboSupplier()
        {
            dtSupplier = supplierService.GetSupplierList();
            DataRow dr = dtSupplier.NewRow(); //Create New Row
            dr["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                dr["supplier_name"] = "Select Supplier Name";
            }
            else
            {
                dr["supplier_name"] = "ကုန်သွင်းသူအမည်ကို ရွေးပါ";
                cboSupplier.Font = new Font("Myanmar Text", 10);
            }
            dtSupplier.Rows.InsertAt(dr, 0);
            cboSupplier.DataSource = dtSupplier;
            cboSupplier.DisplayMember = "supplier_name";
            cboSupplier.ValueMember = "id";
            cboSupplier.SelectedIndex = 0;                   
        }

        /// <summary>
        /// BindDataGrid
        /// </summary>
        private void BindDataGrid()
        {          
            dtPurchaseList = stockService.GetStockList();
            dgvStock.DataSource = null;
            dgvStock.DataSource = dtPurchaseList;
            if (dtPurchaseList.Rows.Count > 0)
            {
                lblStockListText.Visible = false;
                cboShowItem.SelectedIndex = 0;
            }
            else
            {
                setBtnEnabled(false);
            }
      
        }

        /// <summary>
        /// ShowStockListForm
        /// </summary>
        public void ShowStockListForm()
        {
            this.Controls.Clear();
            UCStockList uc = new UCStockList();
            this.Controls.Add(uc);
        }

        /// <summary>
        /// DeleteStock
        /// </summary>
        /// <param name="id"></param>
        private void DeleteStock(int id)
        {
            stockService.DeleteStock(id);
            stockService.DeleteDetailsByStockId(id);
            paymentService.DeleteByStockId(id);
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                MessageBox.Show(POS_Admin.Properties.Messages.I0003, POS_Admin.Properties.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(POS_Admin.Properties.Messages.B0003, POS_Admin.Properties.Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateQty(int id)
        {
            DataTable dtDeleteQty = new DataTable();
            dtPurchaseDetailList = new DataTable();
            dtPurchaseDetailList = stockService.GetStockDetailListById(Convert.ToInt16(id));
            if (dtPurchaseDetailList.Rows.Count > 0)
            {
                for (int i = 0; i < dtPurchaseDetailList.Rows.Count; i++)
                {
                    string detailId = dtPurchaseDetailList.Rows[i]["id"].ToString();
                    lstDetailId.Add(detailId);
                }
            }
            dtDeleteQty = stockService.GetProductIdWithTotalQty(lstDetailId,id,0);
            if (dtDeleteQty.Rows.Count > 0)
            {
                for(int i = 0; i < dtDeleteQty.Rows.Count; i++)
                {
                    int productId = Convert.ToInt32(dtDeleteQty.Rows[i]["product_id"].ToString());
                    int totalQty = Convert.ToInt32(dtDeleteQty.Rows[i]["total"].ToString());
                    stockService.SubstractStockQty(productId, totalQty);
                }
            }
        }
        #endregion

        #region==========SetBtnEnable/Disable==========
        /// <summary>
        /// The HideDetail.
        /// </summary>
        private void setBtnEnabled(bool flag)
        {
            cboShowItem.Visible = flag;
            lblPage.Visible = flag;
            lblShowItemText.Visible = flag;
            btnFirst.Visible = flag;
            btnNext.Visible = flag;
            btnLast.Visible = flag;
            btnPrevious.Visible = flag;
            lblStockListText.Visible = !flag;
        }
        #endregion

        #region==========Pagination==========
        /// <summary>
        /// GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">.</param>
        private void GetCurrentPageRecords(int currentPage)
        {          
            dtPurchaseList = stockService.GetStockList();
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtPurchaseList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvStock.DataSource = dtResult;
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
            dgvStock.Columns["total_amount"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
            dgvStock.Columns["paid_amount"].DefaultCellStyle.Format = DAO.Common.Consts.ROUNDTO;
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            btnAdd.BackColor = Properties.Settings.Default.BackColor;
            dgvStock.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
            payment.LinkColor = Properties.Settings.Default.BackColor;
            payment.ActiveLinkColor = Properties.Settings.Default.BackColor;
            payment.VisitedLinkColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCStockList()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCStockList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCStockList_Load(object sender, EventArgs e)
        {
            UCStockList uCStockList = new UCStockList();
            this.BindCboSupplier();       
            this.BindDataGrid();
            dgvStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCStockList);
            localization.ChangeDatagridText(dgvStock);
        }

        /// <summary>
        /// btnAdd_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCStock ucStock = new UCStock();
            this.Controls.Clear();
            this.Controls.Add(ucStock);
            //ucStock.txtQuantity.Focus();
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
                startDate = dtpFromDate.Value;
            }
            if (changeToDate == 1)
            {
                endDate = dtpToDate.Value;
            }
            if (changeDueDate == 1)
            {
                dueDate = dtpPaymentDueDate.Value;
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
                    setBtnEnabled(false);
                    return;
                }
            }
            getFilterList = GetFilter();
            dtSearchResult = stockService.GetSearchStockList(getFilterList);
            dgvStock.DataSource = dtSearchResult;
            if (dtSearchResult.Rows.Count > 0)
            {
                lblStockListText.Visible = false;
                cboShowItem.SelectedIndex = 0;
                currentPage = 1;
                GetCurrentPageRecords(currentPage);
                setBtnEnabled(true);
            }
            else
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W0103, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0034, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                setBtnEnabled(false);
            }
        }

        /// <summary>
        /// dgvStock_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string MFdate = Convert.ToString(dgvStock.Rows[e.RowIndex].Cells["mfd_date"].Value);
            //string ExpiredDate = Convert.ToString(dgvStock.Rows[e.RowIndex].Cells["expired_date"].Value);
            if (e.RowIndex > -1)
            {
                int purchaseId = Convert.ToInt32(dgvStock.Rows[e.RowIndex].Cells["id"].Value);
                if (e.ColumnIndex == dgvStock.Columns["edit"].Index)
                {
                    UCStock ucStock = new UCStock();
                    this.Controls.Clear();
                    this.Controls.Add(ucStock);
                    if (Consts.LANGUAGEID == 1)
                    {
                        ucStock.lblFormTitle.Text = Messages.I0045;
                    }
                    else
                    {
                        ucStock.lblFormTitle.Text = Messages.M0008;
                        ucStock.lblFormTitle.Font = new Font("Myanmar Text", 10);
                    }
                    ucStock.dtpPurchaseDate.Value = Convert.ToDateTime(dgvStock.Rows[e.RowIndex].Cells["purchase_date"].Value.ToString());
                    ucStock.dtpPurchaseDate.CustomFormat = ucStock.dtpPurchaseDate.Value.ToString("yyyy-MM-dd");             
                    ucStock.stockId.Text = purchaseId.ToString();
                    ucStock.txtTotalAmount.Text = dgvStock.Rows[e.RowIndex].Cells["total_amount"].Value.ToString(); 
                    ucStock.txtOldTotalAmount.Text = dgvStock.Rows[e.RowIndex].Cells["total_amount"].Value.ToString();
                    //get payment info from m_payment by purchase_id
                    dtPayment = new DataTable();
                    dtPayment = paymentService.GetPaymentByStockId(Convert.ToInt32(purchaseId));
                    if (dtPayment != null)
                    {
                        if (dtPayment.Rows.Count > 0)
                        {
                            ucStock.txtPaymentId.Text = dtPayment.Rows[0]["id"].ToString();
                        
                        }
                    }

                    dtPurchaseDetailList = stockService.GetStockDetailListById(Convert.ToInt16(purchaseId));
                    if (dtPurchaseDetailList.Rows.Count > 0)
                    {
                        for(int i = 0; i < dtPurchaseDetailList.Rows.Count; i++)
                        {
                            string supplier = dtPurchaseDetailList.Rows[i]["supplier_name"].ToString();
                            string supplierId = dtPurchaseDetailList.Rows[i]["supplier_id"].ToString();
                            string product = dtPurchaseDetailList.Rows[i]["product_name"].ToString();
                            string productId = dtPurchaseDetailList.Rows[i]["product_id"].ToString();
                            string qty = dtPurchaseDetailList.Rows[i]["purchase_qty"].ToString();
                            string purchase_price = dtPurchaseDetailList.Rows[i]["purchase_price"].ToString();
                            string selling_price = dtPurchaseDetailList.Rows[i]["selling_price"].ToString();
                            string is_active = dtPurchaseDetailList.Rows[i]["is_active"].ToString();
                            string category = "";
                            string categoryId = dtPurchaseDetailList.Rows[i]["category_id"].ToString();
                            string subCategory = "";
                            string subCategoryId = dtPurchaseDetailList.Rows[i]["sub_category_id"].ToString();
                            string MFDate = dtPurchaseDetailList.Rows[i]["mfd_date"].ToString();
                            string expireDate = dtPurchaseDetailList.Rows[i]["expire_date"].ToString();
                            string remark = dtPurchaseDetailList.Rows[i]["remark"].ToString();
                            string detailId = dtPurchaseDetailList.Rows[i]["id"].ToString();
                            ucStock.lstOldDetailId.Add(detailId);
                            string[] row = { detailId, supplier, product, qty, qty, selling_price, purchase_price, remark, supplierId, productId, MFDate, expireDate, is_active, categoryId, category, subCategoryId, subCategory , remark };
                            ucStock.dgvStock.Rows.Add(row);                         

                        }                        
                    }
                 
                }
                if (e.ColumnIndex == dgvStock.Columns["delete"].Index)
                {
                    DialogResult res = DialogResult.None;
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        res = MessageBox.Show(POS_Admin.Properties.Messages.I0004, POS_Admin.Properties.Messages.T0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    else
                    {
                        res = MessageBox.Show(POS_Admin.Properties.Messages.B0004, POS_Admin.Properties.Messages.F0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    if (res == DialogResult.OK)
                    {
                       
                        this.UpdateQty(purchaseId);
                        this.DeleteStock(purchaseId);                       
                        //purchaseDetailService.UpdateSaleStockQuantity(purchaseDetailEntity); 
                        //dtProduct.Rows.RemoveAt(e.RowIndex);
                        ((DataTable)dgvStock.DataSource).AcceptChanges();
                        dgvStock.EndEdit(DataGridViewDataErrorContexts.Commit);
                        this.Validate();
                        dgvStock.Focus();
                        if (currentPage > 1)
                        {
                            currentPage = 1;
                        }
                        this.GetCurrentPageRecords(currentPage);
                    }
                }
                if (e.ColumnIndex == dgvStock.Columns["payment"].Index)
                {
                    string totalAmount = dgvStock.Rows[e.RowIndex].Cells["total_amount"].Value.ToString();
                    string paidAmount = dgvStock.Rows[e.RowIndex].Cells["paid_amount"].Value.ToString();

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
                        PaymentDetail paymentDetail = new PaymentDetail(purchaseId);
                        paymentDetail.txtTotalAmount.Text = dgvStock.Rows[e.RowIndex].Cells["total_amount"].Value.ToString();
                        paymentDetail.txtPaidAmount.Text = dgvStock.Rows[e.RowIndex].Cells["paid_amount"].Value.ToString();
                        paymentDetail.txtPurchaseId.Text = purchaseId.ToString();
                       // paymentDetail.txt.Text = dgvStock.Rows[e.RowIndex].Cells["idno"].Value.ToString();
                        var left = Convert.ToInt32(paymentDetail.txtTotalAmount.Text) - Convert.ToInt32(paymentDetail.txtPaidAmount.Text);
                        paymentDetail.txtLeftAmount.Text = left.ToString();
                        this.Controls.Add(paymentDetail);
                        paymentDetail.Show();
                    }
                }
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
        }

        /// <summary>
        /// dgvStock_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStock_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvStock.Columns[currentColumn].ReadOnly == true)
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
        /// btnSubmit_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// dgvStock_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStock.CurrentCell.Selected = false;
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
        /// btnLast_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPageCount;
            this.GetCurrentPageRecords(currentPage);
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
        /// dtpFromDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            changeFromDate = 1;
            this.dtpFromDate.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// dtpToDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            changeToDate = 1;
            this.dtpToDate.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// dtpPaymentDueDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpPaymentDueDate_ValueChanged(object sender, EventArgs e)
        {
            changeDueDate = 1;
            this.dtpPaymentDueDate.CustomFormat = Consts.DATEFORMAT;
        }
        /// <summary>
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            cboSupplier.SelectedIndex = 0;         
            changeFromDate = 0;
            changeToDate = 0;
            changeDueDate = 0;
            startDate = null;
            endDate = null;
            dueDate = null;
            dtpFromDate.CustomFormat = " ";
            dtpToDate.CustomFormat = " ";
            dtpPaymentDueDate.CustomFormat = " ";
            btnSearch_Click(null, null);
        }
        #endregion
    }
}
