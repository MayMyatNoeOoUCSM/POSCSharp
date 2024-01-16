using DAO.Common;
using POS_Admin.Utilities;
using POS_Admin.Views.Auth;
using Services.Sale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Admin.Views.Sale
{
    public partial class UCSaleForm : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the saleService.
        /// </summary>
        private SaleService saleService = new SaleService();

        /// <summary>
        /// Defines the pageSize, currentPage, totalPageCount, count.....
        /// </summary>
        private int pageSize = 0,
                    currentPage = 1,
                    totalPageCount = 0,
                    count = 0;

        private Int64 sid = 0;

        /// <summary>
        /// Defines the dtResult.
        /// </summary>
        private DataTable dtResult = new DataTable();
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// The GetSaleData.
        /// </summary>
        private void GetSaleData()
        {
            txtInvoiceNumber.Text = dtResult.Rows[0]["invoice_number"].ToString();
            txtStaffName.Text = dtResult.Rows[0]["staff_name"].ToString();
            txtAmount.Text = (Convert.ToDecimal(dtResult.Rows[0]["amount"]).ToString(Consts.ROUNDTO));
            txtSaleDate.Text = (Convert.ToDateTime(dtResult.Rows[0]["sale_date"]).ToString("yyy-MM-dd"));
            txtTotal.Text = (Convert.ToDecimal(dtResult.Rows[0]["total"])).ToString(Consts.ROUNDTO);
            dgvSale.DataSource = dtResult;
            ConfigureGrid();
            ReadOnly();
        }

        /// <summary>
        /// The ReadOnly.
        /// </summary>
        private void ReadOnly()
        {
            txtInvoiceNumber.ReadOnly = true;
            txtStaffName.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtSaleDate.ReadOnly = true;
            txtAmount.ReadOnly = true;
        }

        /// <summary>
        /// The ConfigureGrid.
        /// </summary>
        private void ConfigureGrid()
        {
            dgvSale.Columns["price"].DefaultCellStyle.Format = Consts.ROUNDTO;
            dgvSale.Columns["quantity"].DefaultCellStyle.Format = Consts.ROUNDTO;
            if (dgvSale.Rows.Count > 2)
            {
                dgvSale.Columns["remark"].Width = 200;
            }
            else
            {
                dgvSale.Columns["remark"].Width = 220;
            }
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            pnlHeader.BackColor = Properties.Settings.Default.BackColor;
            btnCancelInvoice.BackColor = Properties.Settings.Default.BackColor;
            btnBack.BackColor = Properties.Settings.Default.BackColor;         
            dgvSale.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCSaleForm(Int64 saleId)
        {
            sid = saleId;
            InitializeComponent();
            this.CustomizeThemes();
            dtResult = saleService.GetDetail(sid);
            dgvSale.DataSource = dtResult;
            GetSaleData();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCSaleForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSaleForm_Load(object sender, EventArgs e)
        {
            UCSaleForm uCSaleForm = new UCSaleForm(sid);
            txtReason.KeyPress += txtReason_KeyPress;
            txtReason.TextChanged += TxtBox_TextChanged;
            dgvSale.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCSaleForm);
            localization.ChangeDatagridText(dgvSale);
            //txtReason.Focus();
            txtReason.KeyPress -= txtReason_KeyPress;
            txtReason.TextChanged -= TxtBox_TextChanged;
        }

        /// <summary>
        /// btnCancelInvoice_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelInvoice_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtReason.Text))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0026, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0053, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
            saleService.UpdateStockCount(dgvSale.DataSource as DataTable);
            saleService.UpdatVoucher(Consts.SALEID, txtReason.Text);
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                MessageBox.Show(Messages.I0002, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Messages.B0040, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ShowSaleListForm();
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

        /// TxtBox_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if ((txtbox.Text.Length >= txtReason.MaxLength))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtReason.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtReason.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                return;
            }
        }

        /// <summary>
        /// txtReason_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtReason_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            if (txtBox.Text.Length >= txtReason.MaxLength)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtReason.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtReason.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
        }

        /// <summary>
        /// dgvSale_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSale_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvSale.CurrentCell.Selected = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ShowProductListForm
        /// </summary>
        private void ShowSaleListForm()
        {
            this.Controls.Clear();
            UCSaleList saleListForm = new UCSaleList();
            this.Controls.Add(saleListForm);
            saleListForm.Show();
        }

        /// <summary>
        /// btnBack_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            ShowSaleListForm();
        }

        /// <summary>
        /// dgvSale_RowPostPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSale_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var g = (DataGridView)sender;
            var r = new Rectangle(e.RowBounds.Left + 4, e.RowBounds.Top,
                    g.RowHeadersWidth, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, $"{e.RowIndex + 1 + ((currentPage - 1) * count) }",
                     dgvSale.DefaultCellStyle.Font, r, g.RowHeadersDefaultCellStyle.ForeColor);
        }
        #endregion
    }
}
