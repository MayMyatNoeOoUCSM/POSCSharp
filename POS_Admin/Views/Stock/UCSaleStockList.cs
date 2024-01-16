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
using POS_Admin.Views.Stock;

namespace POS_Admin.Views.Stock
{
    public partial class UCSaleStockList : UserControl
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

        private CategoryService categoryService = new CategoryService();

        /// <summary>
        /// Defines the dtSupplier.
        /// </summary>
        private DataTable dtProduct = new DataTable();

        /// <summary>
        /// dtCategory
        /// </summary>
        private DataTable dtCategory = new DataTable();

        /// <summary>
        /// dtSubCategory
        /// </summary>
        private DataTable dtSubCategory = new DataTable();

        /// <summary>
        /// Defines the productService.
        /// </summary>
        private ProductService productService = new ProductService();

        /// <summary>
        /// Defines the dtStock.
        /// </summary>
        private DataTable dtSaleStockList = new DataTable();

        /// <summary>
        /// Defines the st.
        /// </summary>
        //private StockService stockService = new StockService();

        /// <summary>
        /// Defines the purchaseService.
        /// </summary>
        private StockService stockService = new StockService();


        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

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
                    changeToDate = 0;

        /// <summary>
        /// define active status
        /// </summary>
        private string active_status = "";

        /// <summary>
        /// Gets or sets the startDate.
        /// </summary>
        private DateTime? startDate { get; set; }

        /// <summary>
        /// Gets or sets the endDate.
        /// </summary>
        private DateTime? endDate { get; set; }

        /// <summary>
        /// Defines the getFilterList.
        /// </summary>
        internal List<object> getFilterList = new List<object>();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();
        #endregion

        #region==========Bind Data==========
        /// <summary>
        /// The GetFilter.
        /// </summary>
        /// <returns>The <see cref="List{object}"/>.</returns>
        private List<object> GetFilter()
        {
            List<object> filterList = new List<object>();
            if (cboProduct.SelectedIndex == 0)
            {
                cboProduct.Text = "";
            }
            if (cboSupplier.SelectedIndex == 0)
            {
                cboSupplier.Text = "";
            }
            filterList.Add(cboProduct.Text);
            filterList.Add(cboSupplier.Text);
            filterList.Add(active_status);
            if (startDate != null)
                filterList.Add(Convert.ToDateTime(startDate).ToString(DAO.Common.Consts.DATEFORMAT));
            else filterList.Add(startDate);
            if (endDate != null)
                filterList.Add(Convert.ToDateTime(endDate).ToString(DAO.Common.Consts.DATEFORMAT));
            else filterList.Add(endDate);
            filterList.Add(changeFromDate);
            filterList.Add(changeToDate);
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
        /// BindCboProduct
        /// </summary>
        private void BindCboProduct()
        {
            dtProduct = productService.GetAllProduct();
            DataRow dr = dtProduct.NewRow(); //Create New Row
            dr["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                dr["product_name"] = "Select Product Name";
            }
            else
            {
                dr["product_name"] = "ကုန်ပစ္စည်းအမည်ကို ရွေးပါ";
                cboProduct.Font = new Font("Myanmar Text", 10);
            }
            dtProduct.Rows.InsertAt(dr, 0);
            cboProduct.DataSource = dtProduct;
            cboProduct.DisplayMember = "product_name";
            cboProduct.ValueMember = "id";
            cboProduct.SelectedIndex = 0;
        }

        /// <summary>
        /// BindDataGrid
        /// </summary>
        private void BindDataGrid()
        {
            dtSaleStockList = stockService.GetSaleStockList();
            dgvSaleStock.DataSource = dtSaleStockList;
            if (dtSaleStockList.Rows.Count > 0)
            {
                lblSaleStockListText.Visible = false;
                cboShowItem.SelectedIndex = 0;
            }
            else
            {
                setBtnEnabled(false);
            }
        }
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// FillDataToUCStockDiscount
        /// </summary>
        private void FillDataToUCStockDiscount()
        {
            UCStockDiscount ucStockDiscount = new UCStockDiscount();
            this.Controls.Clear();
            this.Controls.Add(ucStockDiscount); 
            ucStockDiscount.txtSupplierName.Text = dgvSaleStock.CurrentRow.Cells["supplier_name"].Value.ToString();
            ucStockDiscount.lblProductID.Text = dgvSaleStock.CurrentRow.Cells["product_id"].Value.ToString();
            ucStockDiscount.txtProductName.Text = dgvSaleStock.CurrentRow.Cells["product_name"].Value.ToString();
            ucStockDiscount.txtProductCode.Text = dgvSaleStock.CurrentRow.Cells["product_code"].Value.ToString();
            ucStockDiscount.txtQty.Text = dgvSaleStock.CurrentRow.Cells["quantity"].Value.ToString();
            ucStockDiscount.txtSellingPrice.Text = dgvSaleStock.CurrentRow.Cells["selling_price"].Value.ToString();
            //ucStockDiscount.txtDiscountPercent.Focus();
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
            lblSaleStockListText.Visible = !flag ;
        }
        #endregion

        #region==========Pagination==========
        /// <summary>
        /// GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">.</param>
        private void GetCurrentPageRecords(int currentPage)
        {
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtSaleStockList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvSaleStock.DataSource = dtResult;
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
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            dgvSaleStock.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;          
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCSaleStockList()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }    
        #endregion

        #region==========Design Generated Code==========   
        /// <summary>
        /// UCSaleStockList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSaleStockList_Load(object sender, EventArgs e)
        {
            UCSaleStockList uCSaleStockList = new UCSaleStockList();
            this.BindCboSupplier();
            this.BindCboProduct();
            this.BindDataGrid();
            dgvSaleStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCSaleStockList);
            localization.ChangeDatagridText(dgvSaleStock);
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
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            cboProduct.SelectedIndex = 0;
            cboSupplier.SelectedIndex = 0;
            dtpToDate.CustomFormat = " ";
            dtpFromDate.CustomFormat = " ";
            changeFromDate = 0;
            changeToDate = 0;
            startDate = null;
            endDate = null;
            active_status = "";
            chkActive.Checked = false;
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// dtpToDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            changeToDate = 1;
            dtpToDate.CustomFormat = Consts.DATEFORMAT;
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
        /// dgvSaleStock_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleStock_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvSaleStock.Columns[currentColumn].ReadOnly == true)
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
        /// btnSubmit_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// dgvSaleStock_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvSaleStock.CurrentCell.Selected = false;
        }

        /// <summary>
        /// dtpFromDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            changeFromDate = 1;
            dtpFromDate.CustomFormat = Consts.DATEFORMAT;
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
            if(cboSupplier.SelectedIndex != 0 || cboProduct.SelectedIndex != 0 || changeFromDate != 0 || changeToDate != 0 || chkActive.Checked || chkActive.Checked == false)
            {
                dtSearchResult = stockService.GetSearchStockSaleList(getFilterList);
            }
            else
            {
                dtSearchResult = dtSaleStockList;
            }
            if (cboSupplier.SelectedIndex == 0)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    cboSupplier.Text = "Select Supplier Name";
                }
                else
                {
                    cboSupplier.Text = "ကုန်သွင်းသူအမည်ကို ရွေးပါ";
                }
            }
            if (cboProduct.SelectedIndex == 0)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    cboProduct.Text = "Select Product Name";
                }
                else
                {
                    cboProduct.Text = "ကုန်ပစ္စည်းအမည်ကို ရွေးပါ";
                }
            }
            dgvSaleStock.DataSource = dtSearchResult;
            if (dtSearchResult.Rows.Count > 0)
            {
                currentPage = 1;
                GetCurrentPageRecords(currentPage);
                setBtnEnabled(true);
            }
            else
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W0102, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0033, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                setBtnEnabled(false);
            }
        }

        /// <summary>
        /// chkActive_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkActive_Click(object sender, EventArgs e)
        {
            active_status = Convert.ToString(chkActive.Checked);
            if (active_status == "True")
            {
                active_status = "0";
            }
            if (active_status == "False")
            {
                active_status = "1";
            }
        }

        /// <summary>
        /// dgvSaleStock_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult res = DialogResult.None;
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                res = MessageBox.Show(Messages.W0088, Messages.T0001, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                res = MessageBox.Show(Messages.B0062, Messages.F0001, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (res == DialogResult.Yes)
            {
                this.FillDataToUCStockDiscount();
            }
        }

        /// <summary>
        /// dgvSaleStock_RowPostPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleStock_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var g = (DataGridView)sender;
            //var r = new Rectangle(e.RowBounds.Left + 10, e.RowBounds.Top,
            //        g.RowHeadersWidth, e.RowBounds.Height);
            //TextRenderer.DrawText(e.Graphics, $"{e.RowIndex + 1 + ((currentPage - 1) * count) }",
            //         dgvSaleStock.DefaultCellStyle.Font, r, g.RowHeadersDefaultCellStyle.ForeColor);
        }

        /// <summary>
        /// dgvSaleStock_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSaleStock.Columns["edit"].Index)
            {
                DialogResult res = DialogResult.None;
                if (dgvSaleStock.CurrentRow.Cells["Is_Active"].Value.ToString() == "Active")
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        res = MessageBox.Show(Messages.W0091, Messages.T0001, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else
                    {
                        res = MessageBox.Show(Messages.B0063, Messages.F0001, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    if (res == DialogResult.Yes)
                    {
                        stockService.UpdateSaleStockList(Convert.ToInt32(dgvSaleStock.CurrentRow.Cells["product_id"].Value.ToString()), dgvSaleStock.CurrentRow.Cells["Is_Active"].Value.ToString());
                        this.BindDataGrid();
                    }
                }
                else
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        res = MessageBox.Show(Messages.W0095, Messages.T0001, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else
                    {
                        res = MessageBox.Show(Messages.B0064, Messages.F0001, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    if (res == DialogResult.Yes)
                    {
                        stockService.UpdateSaleStockList(Convert.ToInt32(dgvSaleStock.CurrentRow.Cells["product_id"].Value.ToString()), dgvSaleStock.CurrentRow.Cells["Is_Active"].Value.ToString());
                        this.BindDataGrid();
                    }
                }
               
            }
        }
        #endregion      
    }
}
