using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Brand;
using DAO.Common;
using Services.Brand;
using POS_Admin.Utilities;

namespace POS_Admin.Views.Brand
{
    public partial class UCBrandList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the brandEntity.
        /// </summary>
        private BrandEntity brandEntity = new BrandEntity();

        /// <summary>
        /// Defines the brandService.
        /// </summary>
        private BrandService brandService = new BrandService();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the dtBrandList, dtTemp.....
        /// </summary>
        private DataTable dtBrandList = new DataTable(),
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
            cboShowItem.Visible = false;
            lblPage.Visible = false;
            lblShowItemText.Visible = false;
            btnFirst.Visible = false;
            btnNext.Visible = false;
            btnLast.Visible = false;
            btnPrevious.Visible = false;
            lblNoBrandText.Visible = true;
        }

        /// <summary>
        /// ShowDetails.
        /// </summary>
        private void ShowDetails()
        {
            dgvBrand.Visible = true;
            cboShowItem.Visible = true;
            lblPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
            lblNoBrandText.Visible = false;
        }

        /// <summary>
        /// ShowBrandList
        /// </summary>
        private void ShowBrandList()
        {
            dtBrandList = brandService.GetBrandList();
            if (dtBrandList.Rows.Count < 1)
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
            ShowBrandList();
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtBrandList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dgvBrand.DataSource = dtResult;
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
        /// DeleteBrand
        /// </summary>
        /// <param name="id"></param>
        private void DeleteBrand(Int64 id)
        {
            brandEntity.id = id;
            if (brandService.DeleteBrand(id))
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
            dgvBrand.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }

        #endregion

        #region==========Initialization==========
        public UCBrandList()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCBrandList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCBrandList_Load(object sender, EventArgs e)
        {
            
            dgvBrand.AutoGenerateColumns = false;
            cboShowItem.SelectedIndex = 0;
            ShowBrandList();
            UCBrand uCBrand = new UCBrand();
            dgvBrand.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCBrand);
            localization.ChangeDatagridText(dgvBrand);
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
            dgvBrand.Focus();
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
            dgvBrand.Focus();
        }

        /// <summary>
        /// btnAdd_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCBrand ucBrand = new UCBrand();
            ucBrand.lblFormTitle.Text = Messages.I0044;
            ucBrand.lblFormTitle.Visible = true;
            this.Controls.Clear();
            this.Controls.Add(ucBrand);
        }

        /// <summary>
        /// dgvBrand_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dgvBrand.Columns["edit"].Index)
                {
                    this.Controls.Clear();
                    UCBrand ucBrand = new UCBrand();
                    this.Controls.Add(ucBrand);
                    if (Consts.LANGUAGEID == 1)
                    {
                        ucBrand.lblFormTitle.Text = Messages.I0039;
                    }
                    else
                    {
                        ucBrand.lblFormTitle.Text = Messages.M0006;
                        ucBrand.lblFormTitle.Font = new Font("Myanmar Text", 10);
                    }
                    ucBrand.lblFormTitle.Visible = true;
                    ucBrand.lblId.Text = dgvBrand.CurrentRow.Cells["id"].Value.ToString();
                    ucBrand.txtBrandName.Text = dgvBrand.CurrentRow.Cells["brand_name"].Value.ToString();
                    ucBrand.lblOldBrand.Text = dgvBrand.CurrentRow.Cells["brand_name"].Value.ToString();
                    ucBrand.txtBrandDescription.Text = dgvBrand.CurrentRow.Cells["brand_description"].Value.ToString();
                    //ucSupplier.txtSupplierName.Focus();
                    //ucSupplier.txtSupplierName.SelectAll();
                    ucBrand.btnClear.Visible = false;
                }
                if (e.ColumnIndex == dgvBrand.Columns["delete"].Index)
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
                        Int64 brandId = Convert.ToInt64(dgvBrand.Rows[e.RowIndex].Cells["id"].Value);
                        int count = brandService.GetBrandCountInProduct(brandId);
                        if (count <= 0)
                        {
                            this.DeleteBrand(brandId);
                            dgvBrand.Rows.RemoveAt(e.RowIndex);
                            ((DataTable)dgvBrand.DataSource).AcceptChanges();
                            dgvBrand.EndEdit(DataGridViewDataErrorContexts.Commit);
                            this.Validate();
                            dgvBrand.Focus();
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
                                MessageBox.Show(Messages.W0109, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0088, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string BrandName = String.Empty;
            dtSearchResult = brandService.GetSearchResult(txtBrandName.Text);
            dgvBrand.DataSource = null;
            if (dtSearchResult.Rows.Count > 0)
            {
                currentPage = 1;
                this.GetCurrentPageRecords(currentPage);
                this.ShowDetails();
            }
            else
            {
                dgvBrand.DataSource = dtSearchResult;
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W0110, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0089, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.HideDetails();
            }
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
            GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBrandName.Text = "";
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// dgvBrand_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBrand_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvBrand.Columns[currentColumn].ReadOnly == true)
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
        /// dgvBrand_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBrand_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvBrand.CurrentCell.Selected = false;
        }
        #endregion

    }
}
