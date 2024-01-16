using Entities.DamageLoss;
using POS_Admin.Utilities;
using Services.DamageLoss;
using Services.Product;
using Services.Supplier;
using System;
using POS_Admin.Properties;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO.Common;

namespace POS_Admin.Views.DamageLoss
{
    public partial class UCDamageLossList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the damageLossEntity.
        /// </summary>
        private DamageLossEntity damageLossEntity = new DamageLossEntity();

        /// <summary>
        /// Defines the damageLossService.
        /// </summary>
        private DamageLossService damageLossService = new DamageLossService();

        // <summary>
        /// Defines the SupplierService.
        /// </summary>
        private SupplierService supplierService = new SupplierService();

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

        // <summary>
        /// Defines the ProductService.
        /// </summary>
        private ProductService productService = new ProductService();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the mainForm.
        /// </summary>
        //private MainForm mainForm = null;

        /// <summary>
        /// Defines the dtCategoryList, dtParentCategory, dtTemp.....
        /// </summary>
        private DataTable dtDamageLossList = new DataTable(),
                          dtTemp = new DataTable(),
                          dtSearchResult = new DataTable(),
                          dtSupplierList = new DataTable(),
                          dtProductList = new DataTable();

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
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnReset.BackColor = Properties.Settings.Default.BackColor;
            btnAdd.BackColor = Properties.Settings.Default.BackColor;
            dgvDamageLoss.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        public UCDamageLossList()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design generated code==========
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
                    return;
                }
            }
            getFilterList = GetFilter();
            dtSearchResult = damageLossService.GetSearchResult(getFilterList);
            dgvDamageLoss.DataSource = dtSearchResult;
            if (dtSearchResult.Rows.Count > 0)
            {
                GetCurrentPageRecords(currentPage);
                ShowDetails();
            }
            else
            {
                dgvDamageLoss.DataSource = dtSearchResult;
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W0099, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0030, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            Int64 searchProductId = Convert.ToInt64(cboProductName.SelectedValue);
            Int64 searchSupplierId = Convert.ToInt64(cboSupplierName.SelectedValue);
            List<object> filterList = new List<object>();
            filterList.Add(searchProductId);
            filterList.Add(searchSupplierId);
            if (startDate != null)
                filterList.Add(Convert.ToDateTime(startDate).ToString(Consts.DATEFORMAT));
            else filterList.Add(startDate);
            if (endDate != null)
                filterList.Add(Convert.ToDateTime(endDate).ToString(Consts.DATEFORMAT));
            else filterList.Add(endDate);
            filterList.Add(changeFromDate);
            filterList.Add(changeToDate);
            return filterList;
        }

        /// <summary>
        /// btnFirstList_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstList_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// btnPreviousList_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousList_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                GetCurrentPageRecords(currentPage);
            }
        }

        /// <summary>
        /// btnNextList_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextList_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPageCount)
            {
                currentPage++;
                GetCurrentPageRecords(currentPage);
            }
            dgvDamageLoss.Focus();
        }

        /// <summary>
        /// btnLastList_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLastList_Click(object sender, EventArgs e)
        {
            currentPage = totalPageCount;
            GetCurrentPageRecords(currentPage);
            dgvDamageLoss.Focus();
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
        /// dgvDamageLoss_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDamageLoss_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Int64 Id = 0;
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dgvDamageLoss.Columns["delete"].Index)
                {
                    DialogResult res = DialogResult.None;
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        res = MessageBox.Show(DAO.Common.Messages.I0004, DAO.Common.Messages.T0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    else
                    {
                        res = MessageBox.Show(DAO.Common.Messages.B0042, DAO.Common.Messages.F0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    if (res == DialogResult.OK)
                    {
                        Id = Convert.ToInt64(dgvDamageLoss.Rows[e.RowIndex].Cells["idNo"].Value);
                        int productId = Convert.ToInt32(dgvDamageLoss.Rows[e.RowIndex].Cells["product_id"].Value);
                        int quantity = Convert.ToInt32(dgvDamageLoss.Rows[e.RowIndex].Cells["quantity"].Value);
                        int count = 0;
                        if (count <= 0)
                        {
                            DeleteDamageLossList(Id, productId, quantity);
                            damageLossService.ReduceStockQuantity(quantity, productId);
                            dtDamageLossList.Rows.RemoveAt(e.RowIndex);
                            ((DataTable)dgvDamageLoss.DataSource).AcceptChanges();
                            dgvDamageLoss.EndEdit(DataGridViewDataErrorContexts.Commit);
                            this.Validate();
                            dgvDamageLoss.Focus();
                            if (currentPage > 1)
                            {
                                currentPage = 1;
                            }
                            GetCurrentPageRecords(currentPage);
                        }
                        else
                        {
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(DAO.Common.Messages.W0086, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(DAO.Common.Messages.B0049, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                if (e.ColumnIndex == dgvDamageLoss.Columns["edit"].Index)
                {
                    Id = Convert.ToInt64(dgvDamageLoss.Rows[e.RowIndex].Cells["idNo"].Value.ToString());
                    this.Controls.Clear();
                    UCUpdateDamageLoss damageLossForm = new UCUpdateDamageLoss();
                    this.Controls.Add(damageLossForm);
                    damageLossForm.lblId.Text = dgvDamageLoss.CurrentRow.Cells["idNo"].Value.ToString();
                    damageLossForm.lblproductId.Text = dgvDamageLoss.CurrentRow.Cells["product_id"].Value.ToString();
                    damageLossForm.txtSupplierName.Text = dgvDamageLoss.CurrentRow.Cells["supplier_name"].Value.ToString();
                    damageLossForm.txtProductName.Text = dgvDamageLoss.CurrentRow.Cells["product_name"].Value.ToString();
                    damageLossForm.txtProductCode.Text = dgvDamageLoss.CurrentRow.Cells["product_code"].Value.ToString();
                    int product_status = Convert.ToInt32(dgvDamageLoss.CurrentRow.Cells["product_status"].Value.ToString());
                    if (product_status == 1)
                    {
                        dgvDamageLoss.CurrentRow.Cells["damage_loss"].Value = "Damage";
                    }
                    else
                    {
                        dgvDamageLoss.CurrentRow.Cells["damage_loss"].Value = "Loss";
                    }
                    damageLossForm.cboProductStatus.Text = dgvDamageLoss.CurrentRow.Cells["damage_loss"].Value.ToString();
                    damageLossForm.lbloldquantity.Text = dgvDamageLoss.CurrentRow.Cells["quantity"].Value.ToString();
                    damageLossForm.txtQuantity.Text = dgvDamageLoss.CurrentRow.Cells["quantity"].Value.ToString();
                    damageLossForm.txtPrice.Text = dgvDamageLoss.CurrentRow.Cells["price"].Value.ToString();
                    damageLossForm.dtpDamageLossDate.Text = dgvDamageLoss.CurrentRow.Cells["damageloss_date"].Value.ToString();
                    damageLossForm.txtRemark.Text = dgvDamageLoss.CurrentRow.Cells["remark"].Value == null ? "" : dgvDamageLoss.CurrentRow.Cells["remark"].Value.ToString();
                    damageLossForm.Show();
                    //damageLossForm.cboProductStatus.Focus();
                    //damageLossForm.cboProductStatus.SelectAll();
                }
            }
        }

        /// <summary>
        /// btnReset_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            cboSupplierName.SelectedIndex = 0;
            cboProductName.SelectedIndex = 0;
            dtpFromDate.CustomFormat = " ";
            dtpToDate.CustomFormat = " ";
            changeFromDate = 0;
            changeToDate = 0;
            startDate = null;
            endDate = null;
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// btnAdd_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCDamageLoss uc = new UCDamageLoss();
            this.Controls.Clear();
            this.Controls.Add(uc);
        }

        /// <summary>
        /// dgvDamageLoss_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDamageLoss_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvDamageLoss.Columns[currentColumn].ReadOnly == true)
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
        /// dgvDamageLoss_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDamageLoss_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvDamageLoss.CurrentCell.Selected = false;
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
        #endregion

        #region==========Filling Data==========
        /// <summary>
        /// UCDamageLossList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCDamageLossList_Load(object sender, EventArgs e)
        {
            UCDamageLossList uCDamageLossList = new UCDamageLossList();
            dgvDamageLoss.AutoGenerateColumns = false;
            dtDamageLossList = damageLossService.GetDamageLossList();
            if (dtDamageLossList.Rows.Count > 0)
            {
                //lblNoDamageLossListText.Visible = false;
                dgvDamageLoss.DataSource = dtDamageLossList;
                ShowDetails();
            }
            else
            {
                HideDetails();
            }
            GetSupplierSource();
            GetProductSource();
            dgvDamageLoss.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCDamageLossList);
            localization.ChangeDatagridText(dgvDamageLoss);
        }

        /// <summary>
        /// GetSupplierSource
        /// </summary>
        private void GetSupplierSource()
        {
            dtSupplierList = supplierService.GetSupplierList();
            DataRow dr = dtSupplierList.NewRow(); //Create New Row
            dr["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                dr["supplier_name"] = "Select Supplier Name";
            }
            else
            {
                dr["supplier_name"] = "ကုန်သွင်းသူအမည်ကို ရွေးပါ";
                cboSupplierName.Font = new Font("Myanmar Text", 10);
            }
            dtSupplierList.Rows.InsertAt(dr, 0);

            cboSupplierName.DataSource = dtSupplierList;
            cboSupplierName.DisplayMember = "supplier_name";
            cboSupplierName.ValueMember = "id";
            cboSupplierName.SelectedIndex = 0;
            cboShowItemList.SelectedIndex = 0;
        }

        /// <summary>
        /// GetProductSource
        /// </summary>
        private void GetProductSource()
        {
            dtProductList = productService.GetAllProduct();
            DataRow dr = dtProductList.NewRow(); //Create New Row
            dr["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                dr["product_name"] = "Select Product";
            }
            else
            {
                dr["product_name"] = "ကုန်ပစ္စည်းအမည်ကို ရွေးပါ";
                cboProductName.Font = new Font("Myanmar Text", 10);
            }
            dtProductList.Rows.InsertAt(dr, 0);
            cboProductName.DataSource = dtProductList;
            cboProductName.DisplayMember = "product_name";
            cboProductName.ValueMember = "id";
            cboProductName.SelectedIndex = 0;
            cboShowItemList.SelectedIndex = 0;
        }

        /// <summary>
        /// The HideDetail.
        /// </summary>
        private void HideDetails()
        {
            //dgvDamageLoss.Visible = false;
            cboShowItemList.Visible = false;
            lblListPage.Visible = false;
            lblShowItemText.Visible = false;
            btnFirstList.Visible = false;
            btnNextList.Visible = false;
            btnLastList.Visible = false;
            btnPreviousList.Visible = false;
            lblNoDamageLossListText.Visible = true;
        }

        /// <summary>
        /// The ShowDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvDamageLoss.Visible = true;
            cboShowItemList.Visible = true;
            lblListPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirstList.Visible = true;
            btnNextList.Visible = true;
            btnLastList.Visible = true;
            btnPreviousList.Visible = true;
            lblNoDamageLossListText.Visible = false;
        }

        /// <summary>
        /// GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">.</param>
        private void GetCurrentPageRecords(int currentPage)
        {
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtDamageLossList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
            {
                dgvDamageLoss.DataSource = dtResult;
                return;
            }
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblListPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvDamageLoss.DataSource = dtResult;
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                int product_status = Convert.ToInt32(dtResult.Rows[i]["product_status"]);
                if(product_status == 1)
                {
                    dgvDamageLoss.Rows[i].Cells["damage_loss"].Value = "Damage";
                }
                else
                {
                    dgvDamageLoss.Rows[i].Cells["damage_loss"].Value = "Loss";
                }
            }
            pagination.PaginationButtonAction(dtResult, btnFirstList, btnPreviousList, btnNextList, btnLastList, currentPage);
            pagination.PaginationButtonPaint(btnFirstList, btnPreviousList, btnNextList, btnLastList);
        }

        /// <summary>
        /// DeleteCategory.
        /// </summary>
        /// <param name="id">.</param>
        private void DeleteDamageLossList(Int64 id, int productId, int quantity)
        {
            damageLossEntity.id = id;
            damageLossService.DeleteDamageLossList(id, productId, quantity);
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                MessageBox.Show(DAO.Common.Messages.I0003, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(DAO.Common.Messages.B0041, DAO.Common.Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
