using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Supplier;
using DAO.Common;
using Services.Supplier;
using POS_Admin.Utilities;

namespace POS_Admin.Views.Supplier
{
    public partial class UCSupplierList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the supplierEntity.
        /// </summary>
        private SupplierEntity supplierEntity = new SupplierEntity();

        /// <summary>
        /// Defines the supplierService.
        /// </summary>
        private SupplierService supplierService = new SupplierService();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the dtCategoryList, dtParentCategory, dtTemp.....
        /// </summary>
        private DataTable dtSupplierList = new DataTable(),
                          dtTemp = new DataTable(),
                          dtSearchResult = new DataTable();

        /// <summary>
        /// Defines the pageSize, currentPage, totalPageCount, count.....
        /// </summary>
        private int pageSize = 0,
                    currentPage = 1,
                    totalPageCount = 0,
                    count = 0;
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            btnAdd.BackColor = Properties.Settings.Default.BackColor;
            dgvSupplier.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCSupplierList()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCSupplierList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSupplierList_Load(object sender, EventArgs e)
        {
            UCSupplierList uCSupplierList = new UCSupplierList();
            dgvSupplier.AutoGenerateColumns = false;
            cboShowItemList.SelectedIndex = 0;
            ShowSupplierList();
            dgvSupplier.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCSupplierList);
            localization.ChangeDatagridText(dgvSupplier);
        }      

        /// <summary>
        /// btnFirstList_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstList_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            this.GetCurrentPageRecords(currentPage);
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
                this.GetCurrentPageRecords(currentPage);
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
                this.GetCurrentPageRecords(currentPage);
            }
            dgvSupplier.Focus();
        }

        /// <summary>
        /// btnLastList_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLastList_Click(object sender, EventArgs e)
        {
            currentPage = totalPageCount;
            this.GetCurrentPageRecords(currentPage);
            dgvSupplier.Focus();
        }

        /// <summary>
        /// btnAdd_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCSupplier ucSupplier = new UCSupplier();
            ucSupplier.lblFormTitle.Text = Messages.I0029;
            ucSupplier.lblFormTitle.Visible = true;
            this.Controls.Clear();
            this.Controls.Add(ucSupplier);
        }

        /// <summary>
        /// dgvSupplier_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dgvSupplier.Columns["edit"].Index)
                {
                    this.Controls.Clear();
                    UCSupplier ucSupplier = new UCSupplier();
                    this.Controls.Add(ucSupplier);
                    if (Consts.LANGUAGEID == 1)
                    {
                        ucSupplier.lblFormTitle.Text = Messages.I0031;
                    }
                    else
                    {
                        ucSupplier.lblFormTitle.Text = Messages.M0003;
                        ucSupplier.lblFormTitle.Font = new Font("Myanmar Text", 10);
                    }
                    ucSupplier.lblFormTitle.Visible = true;
                    ucSupplier.lblId.Text = dgvSupplier.CurrentRow.Cells["idNo"].Value.ToString();
                    ucSupplier.txtSupplierName.Text = dgvSupplier.CurrentRow.Cells["name"].Value.ToString();
                    ucSupplier.lblOldSupplier.Text = dgvSupplier.CurrentRow.Cells["name"].Value.ToString();
                    ucSupplier.txtDescription.Text = dgvSupplier.CurrentRow.Cells["description"].Value.ToString();
                    ucSupplier.txtPhoneNo.Text = dgvSupplier.CurrentRow.Cells["phoneno"].Value.ToString();
                    ucSupplier.txtEmail.Text = dgvSupplier.CurrentRow.Cells["email"].Value.ToString();
                    ucSupplier.txtAddress.Text = dgvSupplier.CurrentRow.Cells["add"].Value.ToString();
                    //ucSupplier.txtSupplierName.Focus();
                    //ucSupplier.txtSupplierName.SelectAll();
                    ucSupplier.btnClear.Visible = false;
                }
                if (e.ColumnIndex == dgvSupplier.Columns["delete"].Index)
                {
                    DialogResult res = DialogResult.None;
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        res = MessageBox.Show(Messages.I0004, Messages.T0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    else
                    {
                        res = MessageBox.Show(Messages.B0042, Messages.F0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    if (res == DialogResult.OK)
                    {
                        Int64 supplierId = Convert.ToInt64(dgvSupplier.Rows[e.RowIndex].Cells["idNo"].Value);
                        int count = supplierService.GetSupplierCountInProduct(supplierId);
                        if (count <= 0)
                        {
                            this.DeleteSupplier(supplierId);
                            dgvSupplier.Rows.RemoveAt(e.RowIndex);
                            ((DataTable)dgvSupplier.DataSource).AcceptChanges();
                            dgvSupplier.EndEdit(DataGridViewDataErrorContexts.Commit);
                            this.Validate();
                            dgvSupplier.Focus();
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
                                MessageBox.Show(Messages.W0086, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0049, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// btnSearch_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        { 
            string supplierName = String.Empty;
            dtSearchResult = supplierService.GetSearchResult(txtSearchBox.Text);
            dgvSupplier.DataSource = null;
            if (dtSearchResult.Rows.Count > 0)
            {
                currentPage = 1;
                this.GetCurrentPageRecords(currentPage);
                this.ShowDetails();
            }
            else
            {
                dgvSupplier.DataSource = dtSearchResult;
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W0104, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0036, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.HideDetails();
            }         
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
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchBox.Text = "";
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// dgvSupplier_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSupplier_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvSupplier.Columns[currentColumn].ReadOnly == true)
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
        /// dgvSupplier_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSupplier_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvSupplier.CurrentCell.Selected = false;
        }

        /// <summary>
        /// The HideDetail.
        /// </summary>
        private void HideDetails()
        {
            cboShowItemList.Visible = false;
            lblListPage.Visible = false;
            lblShowItemText.Visible = false;
            btnFirstList.Visible = false;
            btnNextList.Visible = false;
            btnLastList.Visible = false;
            btnPreviousList.Visible = false;
            lblNoSupplierListText.Visible = true;
        }

        /// <summary>
        /// The HideDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvSupplier.Visible = true;
            cboShowItemList.Visible = true;
            lblListPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirstList.Visible = true;
            btnNextList.Visible = true;
            btnLastList.Visible = true;
            btnPreviousList.Visible = true;
            lblNoSupplierListText.Visible = false;
        }

        /// <summary>
        /// GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">.</param>
        private void GetCurrentPageRecords(int currentPage)
        {
            ShowSupplierList();
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtSupplierList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblListPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvSupplier.DataSource = dtResult;           
            pagination.PaginationButtonAction(
                dtResult,
                btnFirstList,
                btnPreviousList,
                btnNextList,
                btnLastList,
                currentPage);
            pagination.PaginationButtonPaint(
                btnFirstList,
                btnPreviousList,
                btnNextList,
                btnLastList);
        }

        /// <summary>
        /// ShowSupplierListdataTable.
        /// </summary>
        private void ShowSupplierList()
        {
            dtSupplierList = supplierService.GetSupplierList();
            if (dtSupplierList.Rows.Count < 1)
            {
                HideDetails();
            }
            else
            {          
                ShowDetails();
            }
        }

        /// <summary>
        /// DeleteCategory.
        /// </summary>
        /// <param name="id">.</param>
        private void DeleteSupplier(Int64 id)
        {
            supplierEntity.id = id;
            if(supplierService.DeleteSupplier(id))
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
            else
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.I0030, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Messages.B0038, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
    }
}
