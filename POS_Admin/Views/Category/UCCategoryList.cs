using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Category;
using DAO.Common;
using Services.Category;
using Services.Product;
using POS_Admin.Utilities;
using POS_Admin.Views.Auth;

namespace POS_Admin.Views.Category
{
    public partial class UCCategoryList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the categoryEntity.
        /// </summary>
        private CategoryEntity categoryEntity = new CategoryEntity();

        /// <summary>
        /// Defines the categoryService.
        /// </summary>
        private CategoryService categoryService = new CategoryService();

        /// <summary>
        /// Defines the productService.
        /// </summary>
        private ProductService productService = new ProductService();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        /// Defines the DataTable.
        /// </summary>
        private DataTable dtCategoryList = new DataTable(),
                          dtParentCategory = new DataTable(),
                          dtTemp = new DataTable();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private int pageSize = 0,
                    currentPage = 1,
                    totalPageCount = 0,
                    count = 0;
        #endregion

        #region==========Bind ComboData==========
        /// <summary>
        /// BindcboParentCategory
        /// </summary>
        private void BindcboParentCategory()
        {
            dtParentCategory = categoryService.GetParentCategoryList();
            DataRow dr = dtParentCategory.NewRow(); //Create New Row
            dr["id"] = "0";
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                dr["name"] = "Select Parent Category";
            }
            else
            {
                dr["name"] = "ပထမအမျိုးအစား";
                cboParentCategory.Font = new Font("Myanmar Text", 10);
            }
            dtParentCategory.Rows.InsertAt(dr, 0);
            cboParentCategory.DataSource = dtParentCategory;
            cboParentCategory.DisplayMember = "name";
            cboParentCategory.ValueMember = "id";
            cboParentCategory.SelectedIndex = 0;
            cboShowItem.SelectedIndex = 0;
        }
        #endregion

        #region==========Fill Data==========       
        /// <summary>
        /// GetCurrentPageRecords.
        /// </summary>
        /// <param name="currentPage">.</param>
        private void GetCurrentPageRecords(int currentPage)
        {
            ShowCategoryList();
            if (dtCategoryList.Rows.Count < 1)
            {
                lblPage.Text = String.Empty;
            }
            else
            {
                pageSize = Convert.ToInt32(cboShowItem.SelectedItem.ToString());
                totalPageCount = pagination.CalculateTotalPages(dtCategoryList, pageSize);
                lblPage.Text = currentPage + "/" + totalPageCount;
            }
            int previousPageOffSet = (currentPage - 1) * pageSize;
            if (dtCategoryList.Rows.Count > 0)
            {
                dtTemp = dtCategoryList.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            }
            else
            {
                dtTemp = dtCategoryList;
            }
            dgvCategory.DataSource = dtTemp;
            //ConfigureGrid();
            pagination.PaginationButtonAction(
                dtCategoryList,
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
        /// styleDataGridV
        /// </summary>
        private void styleDataGridV()
        {
            dgvCategory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            dgvCategory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCategory.RowHeadersVisible = false;
            dgvCategory.EnableHeadersVisualStyles = false;

            dgvCategory.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCategory.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCategory.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCategory.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvCategory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCategory.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCategory.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCategory.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        /// <summary>
        /// removeBorder
        /// </summary>
        private void removeBorder()
        {
            btnFirst.TabStop = false;
            btnFirst.FlatStyle = FlatStyle.Flat;
            btnFirst.FlatAppearance.BorderSize = 0;

            btnPrevious.TabStop = false;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.FlatAppearance.BorderSize = 0;

            btnLast.TabStop = false;
            btnLast.FlatStyle = FlatStyle.Flat;
            btnLast.FlatAppearance.BorderSize = 0;

            btnNext.TabStop = false;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.FlatAppearance.BorderSize = 0;

            btnFirst.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnPrevious.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnLast.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btnNext.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

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
            lblPage.Visible = false;
            lblNoCategoryText.Visible = true;
        }

        /// <summary>
        /// ShowDetails
        /// </summary>
        private void ShowDetails()
        {
            dgvCategory.Visible = true;
            cboShowItem.Visible = true;
            lblPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
            lblPage.Visible = true;
            lblNoCategoryText.Visible = false;
        }

        /// <summary>
        /// DeleteCategory
        /// </summary>
        /// <param name="id"></param>
        private void DeleteCategory(Int64 id)
        {
            categoryEntity.id = id;
            if(categoryService.DeleteCategory(id))
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

        /// <summary>
        /// ShowCategoryList
        /// </summary>
        private void ShowCategoryList()
        {
            Int64 searchParentCategoryId = Convert.ToInt64(cboParentCategory.SelectedValue);
            if (searchParentCategoryId == 0)
            {
                dtCategoryList = categoryService.GetCategoryList();
            }
            else
            {
                dtCategoryList = categoryService.GetSearchParentCategoryList(searchParentCategoryId);
            }
            if (dtCategoryList.Rows.Count < 1)
            {
                HideDetails();
            }
            else
            {
                dgvCategory.DataSource = dtCategoryList;
                ShowDetails();
            }
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {     
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            btnAdd.BackColor = Properties.Settings.Default.BackColor;
            dgvCategory.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCCategoryList()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCCategoryList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCategoryList_Load(object sender, EventArgs e)
        {
            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            BindcboParentCategory();
            MainForm frm = new MainForm();
            frm.lblCommonHeader.Text = Messages.I0007;
            UCCategory ucCategory = new UCCategory();
            Localization localization = new Localization();
            localization.UCChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, ucCategory);
            localization.ChangeDatagridText(dgvCategory);            
        }

        /// <summary>
        /// btnSearch_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
            }
            GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// btnAdd_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {         
            this.Controls.Clear();
            UCCategory ucCategory = new UCCategory();
            this.Controls.Add(ucCategory);
            if (Consts.LANGUAGEID == 1)
            {
                ucCategory.lblFormTitle.Text = Messages.I0007;
            }
            else
            {
                ucCategory.lblFormTitle.Text = Messages.M0001;
                ucCategory.lblFormTitle.Font = new Font("Myanmar Text", 10);
            }          
            ucCategory.lblFormTitle.Visible = true;
        }    

        private void showItemPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// dgvCategory_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dgvCategory.Columns["edit"].Index)
                {
                    this.Controls.Clear();
                    UCCategory ucCategory = new UCCategory();
                    if (Consts.LANGUAGEID == 1)
                    {
                        ucCategory.lblFormTitle.Text = Messages.I0008;
                    }
                    else 
                    {
                        ucCategory.lblFormTitle.Text = Messages.M0002;
                        ucCategory.lblFormTitle.Font = new Font("Myanmar Text", 10);
                    }
                    ucCategory.btnClear.Visible = false;
                    ucCategory.lblFormTitle.Visible = true;
                    ucCategory.lblId.Text = dgvCategory.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    ucCategory.lblParentId.Text = dgvCategory.Rows[e.RowIndex].Cells["parent_category_id"].Value.ToString();
                    ucCategory.cboParentCategory.SelectedValue = dgvCategory.Rows[e.RowIndex].Cells["parent_category_id"].Value.ToString();
                    ucCategory.txtCategoryName.Text = dgvCategory.Rows[e.RowIndex].Cells["name"].Value.ToString();
                    ucCategory.lblOldCategory.Text = dgvCategory.Rows[e.RowIndex].Cells["name"].Value.ToString();
                    ucCategory.txtDescription.Text = dgvCategory.Rows[e.RowIndex].Cells["description"].Value.ToString();
                    this.Controls.Add(ucCategory);
                }
                if (e.ColumnIndex == dgvCategory.Columns["delete"].Index)
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
                        Int64 categoryId = Convert.ToInt64(dgvCategory.Rows[e.RowIndex].Cells["id"].Value);
                        var tempId = dgvCategory.Rows[e.RowIndex].Cells["parent_category_id"].Value;
                        Int64 parentCategoryId = tempId == DBNull.Value ? 0 : Convert.ToInt64(tempId);
                        int count = 0;
                        if (parentCategoryId == 0)
                        {
                            count = categoryService.GetChildCountByCategoryId(categoryId);
                            if (count == 0)
                            {
                                count = productService.GetProductCountByCategoryId(categoryId);

                                if (count > 0)
                                {
                                    if (DAO.Common.Consts.LANGUAGEID == 1)
                                    {
                                        MessageBox.Show(Messages.W0069, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        MessageBox.Show(Messages.B0043, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }                                    
                                    return;
                                }
                            }
                        }
                        else
                        {
                            count = productService.GetProductCountByCategoryId(categoryId);
                        }
                        if (count <= 0)
                        {
                            DeleteCategory(categoryId);
                            if (currentPage > 1)
                            {
                                currentPage = 1;
                            }
                            this.GetCurrentPageRecords(currentPage);
                            this.BindcboParentCategory();
                        }
                        else
                        {
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(Messages.W0069, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0043, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            cboParentCategory.SelectedIndex = 0;
            btnSearch_Click(null, null);
            if (dtCategoryList.Rows.Count <= 0)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.B0072, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0073, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// dgvCategory_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCategory_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvCategory.Columns[currentColumn].ReadOnly == true)
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
        /// btnSearch_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnSearch_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnClear_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnClear_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnAdd_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnAdd_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// dgvCategory_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCategory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvCategory.CurrentCell.Selected = false;
        }

        /// <summary>
        /// cboShowItem_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboShowItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(cboShowItem.GetItemText(cboShowItem.SelectedItem));
            if (currentPage > 1)
            {
                currentPage = 1;
            }
            this.GetCurrentPageRecords(currentPage);
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
        /// btnPrevious_Click.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                GetCurrentPageRecords(currentPage);
            }
        }

        /// <summary>
        /// btnNext_Click.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPageCount)
            {
                currentPage++;
                GetCurrentPageRecords(currentPage);
            }
        }
        #endregion           
    }
}
