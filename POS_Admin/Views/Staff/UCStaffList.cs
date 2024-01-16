using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DAO.Common;
using Services.Staff;
using POS_Admin.Utilities;
using POS_Admin.Views.Auth;
using System.IO;
using System.Text.RegularExpressions;

namespace POS_Admin.Views.Staff
{
    public partial class UCStaffList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the staffService.
        /// </summary>
        private StaffService staffService = new StaffService();

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the pagination.
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        ///  Defines the dtStaffList.
        /// </summary>
        private DataTable dtStaffList = new DataTable(),
                          dtSearchResult = new DataTable();

        /// <summary>
        /// Defines the pagecount.
        /// </summary>
        private int count = 0,
                    isDateChange = 0,
                    currentPage = 1,
                    totalPageCount = 0;

        private string active_status = "";

        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Define the staff
        /// </summary>
        private UCStaff ucStaff = new UCStaff();
        #endregion

        #region==========Bind ComboData==========
        /// <summary>
        /// The BindCboStaffRole.
        /// </summary>
        private void BindCboStaffRole()
        {
            Dictionary<int, string> staffRole = new Dictionary<int, string>();
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                staffRole.Add(0, "Select Role");
            }
            else
            {
                staffRole.Add(0, "အဆင့်ရွေးပါ");
                cboStaffRole.Font = new Font("Myanmar Text", 10);
            }
            staffRole.Add(1, "Admin");
            staffRole.Add(2, "Staff");
            cboStaffRole.DataSource = new BindingSource(staffRole, null);
            cboStaffRole.DisplayMember = "Value";
            cboStaffRole.ValueMember = "Key";
            cboStaffRole.SelectedIndex = 0;
            cboShowItem.SelectedIndex = 0;
        }       
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// GetCurrentPageRecords
        /// </summary>
        /// <param name="currentPage"></param>
        private void GetCurrentPageRecords(int currentPage)
        {
            dtStaffList = staffService.GetStaffList();
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtStaffList : dtSearchResult;
            if (dtResult.Rows.Count == 0)
                return;
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            lblPage.Text = currentPage + "/" + totalPageCount;
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            dtgStaff.DataSource = dtResult;
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                int roleId = Convert.ToInt32(dtResult.Rows[i]["role"]);
                if (roleId < 3)
                {
                    dtgStaff.Rows[i].Cells["role_name"].Value = cboStaffRole.GetItemText(cboStaffRole.Items[roleId]);
                }
                else
                {
                    dtgStaff.Rows[i].Cells["role_name"].Value = cboStaffRole.GetItemText(cboStaffRole.Items[1]);
                }
            }
            pagination.PaginationButtonAction(dtResult, btnFirst, btnPrevious, btnNext, btnLast, currentPage);
            pagination.PaginationButtonPaint(btnFirst, btnPrevious, btnNext, btnLast);
        }        

        /// <summary>
        /// The HideDetail.
        /// </summary>
        private void HideDetail()
        {
            cboShowItem.Visible = false;
            lblPage.Visible = false;
            lblShowItemText.Visible = false;
            btnFirst.Visible = false;
            btnNext.Visible = false;
            btnLast.Visible = false;
            btnPrevious.Visible = false;
            lblPage.Visible = false;
            lblNoStaffText.Visible = true;
        }

        /// <summary>
        /// The ShowDetail.
        /// </summary>
        private void ShowDetail()
        {
            dtgStaff.Visible = true;
            cboShowItem.Visible = true;
            lblPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
            lblPage.Visible = true;
            lblNoStaffText.Visible = false;
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            btnAdd.BackColor = Properties.Settings.Default.BackColor;
            dtgStaff.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCStaffList()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCStaffList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCStaffList_Load(object sender, EventArgs e)
        {
            dtgStaff.AutoGenerateColumns = false;
            dtgStaff.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            dtStaffList = staffService.GetStaffList();
            if (dtStaffList.Rows.Count > 0)
            {
                lblNoStaffText.Visible = false;
                this.BindCboStaffRole();
            }
            else
            {
                HideDetail();
            }
            localization.UCChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, ucStaff);
            localization.ChangeDatagridText(dtgStaff);
        }

        /// <summary>
        /// dtgStaff_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Int64 staffId = 0;
                if (e.ColumnIndex == dtgStaff.Columns["delete"].Index)
                {
                    staffId = Convert.ToInt64(dtgStaff.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    if (staffId == 1)
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {
                            MessageBox.Show(Messages.I0016, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0060, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        return;
                    }
                    else
                    {
                        if (staffId == Consts.STAFFID)
                        {
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(Messages.I0017, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0061, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            return;
                        }
                    }
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
                        staffService.DeleteStaff(staffId);
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {
                            MessageBox.Show(Messages.I0003, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0041, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        dtgStaff.Rows.RemoveAt(e.RowIndex);
                        ((DataTable)dtgStaff.DataSource).AcceptChanges();
                        dtgStaff.EndEdit(DataGridViewDataErrorContexts.Commit);
                        this.Validate();
                        dtgStaff.Focus();
                        if (currentPage > 1)
                        {
                            currentPage = 1;
                        }
                        GetCurrentPageRecords(currentPage);
                    }
                    else
                    {
                        return;
                    }
                }
                if (e.ColumnIndex == dtgStaff.Columns["edit"].Index)
                {
                    staffId = Convert.ToInt64(dtgStaff.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    this.Controls.Clear();
                    UCStaff ucStaff = new UCStaff(staffId);
                    if (Consts.LANGUAGEID == 1)
                    {
                        ucStaff.lblStaffTitle.Text = "Staff Edit";
                    }
                    else
                    {
                        ucStaff.lblStaffTitle.Text = Messages.M0005;
                        ucStaff.lblStaffTitle.Font = new Font("Myanmar Text", 10);
                    }
                    ucStaff.lblId.Text = staffId.ToString();
                    this.Controls.Add(ucStaff);
                }
            }
        }

        /// <summary>
        /// customNoBorderCombo_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customNoBorderCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(cboShowItem.GetItemText(cboShowItem.SelectedItem));
            currentPage = 1;
            this.GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// The btnAdd_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCStaff ucStaff = new UCStaff();       
            if (Consts.LANGUAGEID == 1)
            {
                ucStaff.lblStaffTitle.Text = "Staff Create";
            }
            else
            {
                ucStaff.lblStaffTitle.Text = Messages.M0004;
                ucStaff.lblStaffTitle.Font = new Font("Myanmar Text", 10);
            }
            this.Controls.Clear();
            this.Controls.Add(ucStaff);
        }

        /// <summary>
        /// The dtpJoinFrom_ValueChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void dtpJoinFrom_ValueChanged(object sender, EventArgs e)
        {
            isDateChange = 1;
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
            dtgStaff.Focus();
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
        /// btnLast_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPageCount;
            this.GetCurrentPageRecords(currentPage);
            dtgStaff.Focus();
        }

        /// <summary>
        /// btnSearch_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dRow = new DataTable();
            string staffNo = String.Empty;
            int role = 0, staffType = 0;
            role = Convert.ToInt16(cboStaffRole.SelectedValue);
            dtSearchResult = staffService.GetSearchResult(txtStaffName.Text, staffNo, role, staffType, active_status, isDateChange);
            dtgStaff.DataSource = null;
            if (dtSearchResult.Rows.Count > 0)
            {
                currentPage = 1;
                this.GetCurrentPageRecords(currentPage);
                this.ShowDetail();
            }
            else
            {
                dtgStaff.DataSource = dtSearchResult;
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W0101, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0032, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.HideDetail();
            }
        }

        /// <summary>
        /// chkActive1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkActive1_Click(object sender, EventArgs e)
        {
            active_status = Convert.ToString(chkActive.Checked);
            if (active_status == "True")
            {
                active_status = "1";
            }
            if (active_status == "False")
            {
                active_status = "2";
            }
        }

        /// <summary>
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStaffName.Text = "";
            cboStaffRole.SelectedIndex = 0;
            active_status = "";
            chkActive.Checked = false;
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// dtgStaff_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgStaff_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dtgStaff.Columns[currentColumn].ReadOnly == true)
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
        /// dtgStaff_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dtgStaff.CurrentCell.Selected = false;
        }

        /// <summary>
        /// btnAdd_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            //base.Label_MouseHover(sender, e);
            //base.ButtonColor_MouseHover(sender, e);
        }

        /// <summary>
        /// btnAdd_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            //base.Label_MouseLeave(sender, e);
            //base.ButtonColor_MouseLeave(sender, e);
        }

        /// <summary>
        /// btnDownload_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_MouseLeave(object sender, EventArgs e)
        {
            //base.Label_MouseLeave(sender, e);
            //base.ButtonColor_MouseLeave(sender, e);
        }

        /// <summary>
        /// noFlickerPanel1_Paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void noFlickerPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion
    }
}
