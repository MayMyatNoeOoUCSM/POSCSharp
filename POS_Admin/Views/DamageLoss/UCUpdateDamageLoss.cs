using DAO.Common;
using Entities.DamageLoss;
using POS_Admin.Utilities;
using Services.DamageLoss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Admin.Views.DamageLoss
{
    public partial class UCUpdateDamageLoss : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the damageLossEntity.
        /// </summary>
        private DamageLossEntity damageLossEntity = new DamageLossEntity();

        /// <summary>
        /// Defines the damageLossService.
        /// </summary>
        private DamageLossService damageLossService = new DamageLossService();
        #endregion

        #region==========Validation==========
        /// <summary>
        /// The Validation.
        /// </summary>
        /// <returns></returns>
        private Boolean Validation()
        {
            try
            {
                if (cboProductStatus.Text.ToString() == "" || cboProductStatus.Text.ToString() == null)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0047, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0026, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    return false;
                }
                if (txtQuantity.Text.ToString() == "" || txtQuantity.Text.ToString() == null)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0057, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0020, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    txtQuantity.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Messages.T0002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            pnlHeader.BackColor = Properties.Settings.Default.BackColor;          
            btnSubmit.BackColor = Properties.Settings.Default.BackColor;
            btnBack.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;         
        }
        #endregion

        #region==========Inialization==========
        /// <summary>
        /// UCUpdateDamageLoss
        /// </summary>
        public UCUpdateDamageLoss()
        {
            InitializeComponent();
            this.CustomizeThemes();
            BindCombo();
        }

        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// UCUpdateDamageLoss_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCUpdateDamageLoss_Load(object sender, EventArgs e)
        {
            UCUpdateDamageLoss uCUpdateDamageLoss = new UCUpdateDamageLoss();
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCUpdateDamageLoss);
        }

        /// <summary>
        /// The BindCombo.
        /// </summary>
        private void BindCombo()
        {
            Dictionary<int, string> productStatus = new Dictionary<int, string>();
            productStatus.Add(1, "Damage");
            productStatus.Add(2, "Loss");
            cboProductStatus.DataSource = new BindingSource(productStatus, null);
            cboProductStatus.DisplayMember = "Value";
            cboProductStatus.ValueMember = "Key";
        }

        /// <summary>
        /// ShowSupplierListForm.
        /// </summary>
        private void ShowDamageLostListForm()
        {
            UCDamageLossList uc = new UCDamageLossList();
            this.Controls.Clear();
            this.Controls.Add(uc);
        }

        /// <summary>
        /// UpdateSaleStockQuantity
        /// </summary>
        /// <param name="minus"></param>
        /// <param name="productId"></param>
        public void UpdateSaleStockQuantity(int minus, int productId)
        {
            damageLossService.ReduceStockQuantity(minus, productId);
        }

        /// <summary>
        /// UpdateDamageLossList.
        /// </summary>
        private void UpdateDamageLossList()
        {
            if (cboProductStatus.SelectedIndex == 0)
            {
                damageLossEntity.product_status = 1;
            }
            else if (cboProductStatus.SelectedIndex == 1)
            {
                damageLossEntity.product_status = 2;
            }
            damageLossEntity.id = Convert.ToInt32(lblId.Text);
            damageLossEntity.price = Convert.ToDecimal(txtPrice.Text);
            damageLossEntity.quantity = Convert.ToInt64(txtQuantity.Text);
            damageLossEntity.remark = txtRemark.Text.ToString();
            damageLossEntity.damageloss_date = Convert.ToDateTime(dtpDamageLossDate.Value);
            damageLossEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            damageLossEntity.updated_datetime = DateTime.Now;
            damageLossService.UpdateDamageLost(damageLossEntity);
            MessageBox.Show(Messages.I0002, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowDamageLostListForm();
        }

        /// <summary>
        /// setMultiline
        /// </summary>
        private void setMultiline()
        {
            txtQuantity.Multiline = false;
            txtPrice.Multiline = false;
        }
        #endregion

        #region==========Design generated code==========

        /// <summary>
        /// btnBack_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            ShowDamageLostListForm();
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
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            cboProductStatus.SelectedIndex = -1;
            txtQuantity.Text = "";
            txtPrice.Text = "";
            dtpDamageLossDate.CustomFormat = " ";
            txtRemark.Text = "";
        }

        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                int oldquantity = Convert.ToInt32(lbloldquantity.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);
                int productId = Convert.ToInt32(lblproductId.Text);
                if(quantity > oldquantity)
                {
                    bool isLargeQuantity = damageLossService.CheckSaleStockQuantity(quantity, productId);
                    if (isLargeQuantity)
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {
                            MessageBox.Show("Quantity " + Messages.W0082, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Quantity " + Messages.B0048, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        txtQuantity.Focus();
                    }                  
                }
                if (quantity != oldquantity)
                {
                    bool isLargeQuantity = damageLossService.CheckSaleStockQuantity(quantity, productId);
                    if (isLargeQuantity)
                    {                     
                        txtQuantity.Focus();
                    }
                    else
                    {
                        int minusquantity = oldquantity - quantity;
                        UpdateSaleStockQuantity(minusquantity, productId);
                        UpdateDamageLossList();
                    }
                }
                else
                {
                    UpdateDamageLossList();
                }

            }
        }

        /// <summary>
        /// The TextBox_KeyPress.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/>.</param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && !string.Equals(txtbox.Name, txtRemark.Name))
            {
                e.Handled = true;         //Just Digits
            }
            else if((txtbox.Text.Length >= txtQuantity.MaxLength) && !string.Equals(txtbox.Name, txtPrice.Name) && !string.Equals(txtbox.Name, txtRemark.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtQuantity.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtQuantity.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if((txtbox.Text.Length >= txtPrice.MaxLength) && !string.Equals(txtbox.Name, txtQuantity.Name) && !string.Equals(txtbox.Name, txtRemark.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtPrice.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtPrice.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if((txtbox.Text.Length >= txtRemark.MaxLength) && !string.Equals(txtbox.Name, txtQuantity.Name) && !string.Equals(txtbox.Name, txtPrice.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtRemark.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtRemark.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
                e.Handled = false;   //Allow Backspace
        }

        /// <summary>
        /// dtpDamageLossDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDamageLossDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpDamageLossDate.CustomFormat = Consts.DATEFORMAT;
        }

        private void gpCategory_Enter(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
