using Entities.DamageLoss;
using Entities.SaleReturn;
using DAO.Common;
using POS_Admin.Utilities;
using POS_Admin.Views.Auth;
using Services.DamageLoss;
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
using static Entities.SaleReturn.SaleReturnEntity;

namespace POS_Admin.Views.SaleReturn
{
    public partial class UCSaleReturnEntryForm : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the saleReturnService.
        /// </summary>
        private SaleReturnService saleReturnService = new SaleReturnService();

        /// <summary>
        /// Defines the damageLossService.
        /// </summary>
        private DamageLossService damageLossService = new DamageLossService();

        /// <summary>
        /// Defines the mainForm.
        /// </summary>
        private MainForm mainForm = null;

        /// <summary>
        /// Defines the dtResult.
        /// </summary>
        private DataTable dtResult = new DataTable();

        /// <summary>
        /// Defines the saleReturnEntity.
        /// </summary>
        private SaleReturnEntity saleReturnEntity = new SaleReturnEntity();

        /// <summary>
        /// Defines the infoDetails.
        /// </summary>
        private SaleReturnEntityDetails infoDetails = new SaleReturnEntityDetails();

        /// <summary>
        /// Defines the damageLossEntity.
        /// </summary>
        private DamageLossEntity damageLossEntity = new DamageLossEntity();

        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        private Int64 sid = 0;

        #endregion

        #region==========Data Validation==========
        /// <summary>
        /// The CheckValidaition.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool CheckValidation()
        {
            bool isValid = true;           
            if (dgvSaleReturnEntry.Rows.Count == 0)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0033, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0045, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                return false;
            }
            for (int i = 0; i < dgvSaleReturnEntry.Rows.Count; i++)
            {
                if (String.IsNullOrEmpty(dgvSaleReturnEntry.Rows[i].Cells["damage_quantity"].Value.ToString()))
                {
                    dgvSaleReturnEntry.Rows[i].Cells["damage_quantity"].Value = 0;
                }
                if (dgvSaleReturnEntry.Rows[i].Cells["return_quantity"].Value == null)
                {
                    dgvSaleReturnEntry.Rows[i].Cells["return_quantity"].Value = 0;
                }
                if (String.IsNullOrEmpty(dgvSaleReturnEntry.Rows[i].Cells["total_return_quantity"].Value.ToString()))
                {
                    dgvSaleReturnEntry.Rows[i].Cells["total_return_quantity"].Value = 0;
                }
                int totalQty = Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["total_return_quantity"].Value) + Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["return_quantity"].Value);
                if (Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["return_quantity"].Value) < Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["damage_quantity"].Value))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0052, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0054, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                    isValid = false;
                }
                else if (Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["return_quantity"].Value) > Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["qty"].Value))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0053, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0055, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    isValid = false;
                    break;
                }
                else if (totalQty > Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["qty"].Value))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0054, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0056, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    isValid = false;
                    break;
                }
                else if (Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["return_quantity"].Value) == 0 || dgvSaleReturnEntry.Rows[i].Cells["return_quantity"].Value == DBNull.Value)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0055, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0057, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    isValid = false;
                    break;
                }
                else if (dgvSaleReturnEntry.Rows[i].Cells["remark"].Value == null || dgvSaleReturnEntry.Rows[i].Cells["remark"].Value == DBNull.Value ||  String.IsNullOrEmpty(dgvSaleReturnEntry.Rows[i].Cells["remark"].Value.ToString()))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0026, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0053, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    isValid = false;
                    break;
                }
                else if (Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["qty"].Value) < Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["return_quantity"].Value))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0056, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0058, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// The SaveProductReturnInfo.
        /// </summary>
        private void SaveProductReturnInfo()
        {
            this.Validate();
            int dlqty = 0;          
            saleReturnEntity.return_invoice_number = txtInvoiceNumber.Text;
            saleReturnEntity.sale_id = Convert.ToInt64(dgvSaleReturnEntry.Rows[0].Cells["id"].Value);
            saleReturnEntity.return_date = dtpReturn.Value;
            saleReturnEntity.is_deleted = 0;              
            saleReturnEntity.remark = dgvSaleReturnEntry.Rows[0].Cells["remark"].Value.ToString();
            saleReturnEntity.created_user_id = Convert.ToInt32(Consts.STAFFID);
            saleReturnEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            saleReturnEntity.created_datetime = DateTime.Now;
            saleReturnEntity.updated_datetime = DateTime.Now;           
            saleReturnEntity.SaleReturnDetails = new List<SaleReturnEntityDetails>();
            for (int i = 0; i< (dgvSaleReturnEntry.DataSource as DataTable).Rows.Count; i++)
            {
                infoDetails = new SaleReturnEntityDetails();
                infoDetails.return_id = 0;
                infoDetails.product_id = Convert.ToInt64(dgvSaleReturnEntry.Rows[i].Cells["product_id"].Value);
                infoDetails.sale_id = Convert.ToInt64(dgvSaleReturnEntry.Rows[i].Cells["sale_id"].Value);
                infoDetails.price = Convert.ToDecimal(dgvSaleReturnEntry.Rows[i].Cells["price"].Value);
                infoDetails.quantity = Convert.ToInt32(dgvSaleReturnEntry.Rows[i].Cells["return_quantity"].Value);
                infoDetails.remark = dgvSaleReturnEntry.Rows[i].Cells["remark"].Value.ToString();
                saleReturnEntity.SaleReturnDetails.Add(infoDetails);
            }
            saleReturnService.Confirm(saleReturnEntity);           
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                MessageBox.Show(Messages.I0001, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Messages.B0037, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSubmit.BackColor = Properties.Settings.Default.BackColor;
            btnBack.BackColor = Properties.Settings.Default.BackColor;
            dgvSaleReturnEntry.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        /// <param name="callingForm"></param>
        /// <param name="saleId"></param>
        public UCSaleReturnEntryForm(Form callingForm, Int64 saleId)
        {
            sid = saleId;
            InitializeComponent();
            this.CustomizeThemes();
            mainForm = callingForm as MainForm;
            dtResult = saleReturnService.GetSaleDetail(saleId);
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCSaleReturnEntryForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSaleReturnEntryForm_Load(object sender, EventArgs e)
        {
            UCSaleReturnEntryForm uCSaleReturnEntryForm = new UCSaleReturnEntryForm(mainForm, sid);
            dgvSaleReturnEntry.AutoGenerateColumns = false;
            txtInvoiceNumber.Text = dtResult.Rows[0]["invoice_number"].ToString();
            txtSaleDate.Text = dtResult.Rows[0]["sale_date"].ToString();
            txtStaffName.Text = dtResult.Rows[0]["staffname"].ToString();
            txtAmount.Text = Convert.ToDecimal(dtResult.Rows[0]["amount"]).ToString(Consts.ROUNDTO);
            txtTotal.Text = Convert.ToDecimal(dtResult.Rows[0]["total"]).ToString(Consts.ROUNDTO);
            dgvSaleReturnEntry.DataSource = dtResult;
            dgvSaleReturnEntry.Columns["price"].DefaultCellStyle.Format = Consts.ROUNDTO;
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCSaleReturnEntryForm);
            localization.ChangeDatagridText(dgvSaleReturnEntry);
        }

        /// <summary>
        /// The btnSubmit_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                SaveProductReturnInfo();
                btnBack_Click(sender, e);
            }
        }

        /// <summary>
        /// The btnBack_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UCConfirmList ucConfirmListForm = new UCConfirmList(mainForm);
            this.Controls.Add(ucConfirmListForm);
            ucConfirmListForm.Show();
        }

        /// <summary>
        /// The dtgSaleReturn_CellContentClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/>.</param>
        private void dgvSaleReturnEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSaleReturnEntry.Columns["delete"].Index)
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
                    dgvSaleReturnEntry.Rows.RemoveAt(e.RowIndex);
                    ((DataTable)dgvSaleReturnEntry.DataSource).AcceptChanges();
                    dgvSaleReturnEntry.EndEdit(DataGridViewDataErrorContexts.Commit);
                    this.Validate();
                    dgvSaleReturnEntry.Focus();
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// dtpReturn_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpReturn_ValueChanged(object sender, EventArgs e)
        {
            this.dtpReturn.CustomFormat = Consts.DATEFORMAT;
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
        /// dgvSaleReturnEntry_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleReturnEntry_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvSaleReturnEntry.Columns[currentColumn].ReadOnly == true)
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
        /// dgvSaleReturnEntry_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSaleReturnEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvSaleReturnEntry.CurrentCell.Selected = false;
        }
        #endregion
    }
}
