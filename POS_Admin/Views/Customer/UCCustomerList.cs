using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Customer;
using DAO.Common;
using Services.Customer;
using POS_Admin.Utilities;

namespace POS_Admin.Views.Customer
{
    public partial class UCCustomerList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the customerEntity.
        /// </summary>
        private CustomerEntity customerEntity = new CustomerEntity();

        /// <summary>
        /// Defines the customerService.
        /// </summary>
        private CustomerService customerService = new CustomerService();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the dtCustomerList, dtTemp.....
        /// </summary>
        private DataTable dtCustomerList = new DataTable(),
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

        #region==========Fill Data========
        /// <summary>
        /// HideDetails
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
            lblNoCustomerListText.Visible = true;
        }

        /// <summary>
        /// ShowDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvCustomer.Visible = true;
            cboShowItemList.Visible = true;
            lblListPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirstList.Visible = true;
            btnNextList.Visible = true;
            btnLastList.Visible = true;
            btnPreviousList.Visible = true;
            lblNoCustomerListText.Visible = false;
        }

        /// <summary>
        /// ShowCustomerList
        /// </summary>
        private void ShowCustomerList()
        {
            dtCustomerList = customerService.GetCustomerList();
            if (dtCustomerList.Rows.Count < 1)
            {
                HideDetails();
            }
            else
            {
                ShowDetails();
            }
        }

        /// <summary>
        /// GetCurrentPageRecords
        /// </summary>
        /// <param name="currentPage"></param>
        private void GetCurrentPageRecords(int currentPage)
        {
            ShowCustomerList();
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtCustomerList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblListPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvCustomer.DataSource = dtResult;
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
        /// DeleteCustomer
        /// </summary>
        /// <param name="id"></param>
        private void DeleteCustomer(Int64 id)
        {
            customerEntity.id = id;
            if (customerService.DeleteCustomer(id))
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

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            btnAdd.BackColor = Properties.Settings.Default.BackColor;
            dgvCustomer.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        public UCCustomerList()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCCustomerList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCustomerList_Load(object sender, EventArgs e)
        {
            UCCustomerList uCCustomerList = new UCCustomerList();
            dgvCustomer.AutoGenerateColumns = false;
            cboShowItemList.SelectedIndex = 0;
            ShowCustomerList();
            dgvCustomer.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCCustomerList);
            localization.ChangeDatagridText(dgvCustomer);
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
            dgvCustomer.Focus();
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
            dgvCustomer.Focus();
        }

        /// <summary>
        /// btnAdd_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCCustomer ucCustomer = new UCCustomer();
            ucCustomer.lblFormTitle.Text = Messages.I0041;
            ucCustomer.lblFormTitle.Visible = true;
            this.Controls.Clear();
            this.Controls.Add(ucCustomer);
        }

        /// <summary>
        /// dgvCustomer_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dgvCustomer.Columns["edit"].Index)
                {
                    this.Controls.Clear();
                    UCCustomer ucCustomer = new UCCustomer();
                    this.Controls.Add(ucCustomer);
                    if (Consts.LANGUAGEID == 1)
                    {
                        ucCustomer.lblFormTitle.Text = Messages.I0040;
                    }
                    else
                    {
                        ucCustomer.lblFormTitle.Text = Messages.M0007;
                        ucCustomer.lblFormTitle.Font = new Font("Myanmar Text", 10);
                    }
                    ucCustomer.lblFormTitle.Visible = true;
                    ucCustomer.lblId.Text = dgvCustomer.CurrentRow.Cells["idNo"].Value.ToString();
                    ucCustomer.txtCustomerName.Text = dgvCustomer.CurrentRow.Cells["name"].Value.ToString();
                    ucCustomer.lblOldCustomer.Text = dgvCustomer.CurrentRow.Cells["name"].Value.ToString();
                    ucCustomer.txtCustomerDescription.Text = dgvCustomer.CurrentRow.Cells["description"].Value.ToString();
                    ucCustomer.txtCustomerPhoneNo.Text = dgvCustomer.CurrentRow.Cells["phoneno"].Value.ToString();
                    ucCustomer.txtCustomerEmail.Text = dgvCustomer.CurrentRow.Cells["email"].Value.ToString();
                    ucCustomer.txtCustomerAddress.Text = dgvCustomer.CurrentRow.Cells["add"].Value.ToString();
                    //ucSupplier.txtSupplierName.Focus();
                    //ucSupplier.txtSupplierName.SelectAll();
                    ucCustomer.btnClear.Visible = false;
                }
                if (e.ColumnIndex == dgvCustomer.Columns["delete"].Index)
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
                        Int64 customerId = Convert.ToInt64(dgvCustomer.Rows[e.RowIndex].Cells["idNo"].Value);
                        int count = customerService.GetCustomerCountInSale(customerId);
                        if (count <= 0)
                        {
                            this.DeleteCustomer(customerId);
                            dgvCustomer.Rows.RemoveAt(e.RowIndex);
                            ((DataTable)dgvCustomer.DataSource).AcceptChanges();
                            dgvCustomer.EndEdit(DataGridViewDataErrorContexts.Commit);
                            this.Validate();
                            dgvCustomer.Focus();
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
                                MessageBox.Show(Messages.W0111, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0091, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string CustomerName = String.Empty;
            dtSearchResult = customerService.GetSearchResult(txtCustomerName.Text);
            dgvCustomer.DataSource = null;
            if (dtSearchResult.Rows.Count > 0)
            {
                currentPage = 1;
                this.GetCurrentPageRecords(currentPage);
                this.ShowDetails();
            }
            else
            {
                dgvCustomer.DataSource = dtSearchResult;
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W0107, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0081, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtCustomerName.Text = "";
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// dgvCustomer_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCustomer_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvCustomer.Columns[currentColumn].ReadOnly == true)
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
        /// dgvCustomer_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvCustomer.CurrentCell.Selected = false;
        }
        #endregion


    }
}
