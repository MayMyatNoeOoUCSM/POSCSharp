using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Stock;
using DAO.Stock;
using DAO.Common;
using Services.Stock;
using System.Windows.Input;
using POS_Admin.Utilities;

namespace POS_Admin.Views.Stock
{
    public partial class UCStockDiscount : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the stockdiscountEntity.
        /// </summary>
        private StockDiscountEntity stockdiscountEntity = new StockDiscountEntity();

        /// <summary>
        /// Defines the stockService.
        /// </summary>
        private StockService stockService = new StockService();

        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        #endregion

        #region==========Data Validation==========
        /// <summary>
        /// Validation
        /// </summary>
        private Boolean Validation()
        {
            try
            {
                if (txtDiscountPercent.Text.ToString() == "" || txtDiscountPercent.Text.ToString() == null)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0089, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0024, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    txtDiscountPercent.Focus();
                    return false;
                }
                if (txtDiscountAmount.Text.ToString() == "" || txtDiscountAmount.Text.ToString() == null)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0090, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0025, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtSupplierName.Focus();
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

        #region==========Fill Data==========
        /// <summary>
        /// CalculateDiscoutAmount
        /// </summary>
        private void CalculateDiscoutAmount()
        {
            if (!String.IsNullOrWhiteSpace(txtDiscountPercent.Text))
            {
                if(Convert.ToInt32(txtDiscountPercent.Text) > 100)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.B0066, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0067, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //txtDiscountPercent.Focus();
                    return;
                }
                decimal sellingPrice = Convert.ToInt32(txtSellingPrice.Text);
                decimal discountPercent = Convert.ToInt32(txtDiscountPercent.Text);
                decimal amount = sellingPrice * (discountPercent / 100);
                int discountAmount = Convert.ToInt32(sellingPrice - amount);
                txtDiscountAmount.Text = Convert.ToString(discountAmount);
                txtDiscountAmount.ReadOnly = true;
            }
        }

        /// <summary>
        /// SaveData.
        /// </summary>
        private void SaveData()
        {
            stockdiscountEntity.product_id = Convert.ToInt32(lblProductID.Text.ToString());
            stockdiscountEntity.quantity = Convert.ToInt32(txtQty.Text.ToString());
            stockdiscountEntity.selling_price = Convert.ToInt32(txtSellingPrice.Text.ToString());
            stockdiscountEntity.discount_percent = Convert.ToInt32(txtDiscountPercent.Text.ToString());
            stockdiscountEntity.discount_amount = Convert.ToInt32(txtDiscountAmount.Text.ToString());
            stockdiscountEntity.created_user_id = Convert.ToInt32(Consts.STAFFID);
            stockdiscountEntity.created_datetime = DateTime.Now;
            stockdiscountEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            stockdiscountEntity.updated_datetime = DateTime.Now;
            stockdiscountEntity.is_active = 0;
            stockdiscountEntity.remark = txtReamark.Text.ToString();
            if (stockService.InsetStockDiscount(stockdiscountEntity))
            {
                stockService.UpdateStockDiscount(stockdiscountEntity);
                stockService.UpdateSaleStock(stockdiscountEntity);
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.I0001, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Messages.B0037, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Clear();
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
        /// ShowUCSaleStockList
        /// </summary>
        private void ShowUCSaleStockList()
        {
            UCSaleStockList ucSaleStockList = new UCSaleStockList();
            this.Controls.Clear();
            this.Controls.Add(ucSaleStockList);
        }
        #endregion

        #region==========Data Clear==========
        /// <summary>
        /// Clear.
        /// </summary>
        private void Clear()
        {
            this.txtDiscountAmount.ReadOnly = false;
            this.txtDiscountPercent.Text = string.Empty;
            this.txtDiscountAmount.Text = string.Empty;
            this.txtReamark.Text = string.Empty;
            txtDiscountPercent.Focus();
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            pnlHeader.BackColor = Properties.Settings.Default.BackColor;
            btnSubmit.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;   
            btnBack.BackColor = Properties.Settings.Default.BackColor;      
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCStockDiscount()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        private void UCStockDiscount_Load(object sender, EventArgs e)
        {
            UCStockDiscount uCStockDiscount = new UCStockDiscount();
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCStockDiscount);
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
                this.SaveData();
                this.ShowUCSaleStockList();
            }           
        }

        /// <summary>
        /// btnBack_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.ShowUCSaleStockList();
        }

        /// <summary>
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        /// <summary>
        /// txtDiscountPercent_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiscountPercent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateDiscoutAmount();
                txtDiscountPercent.Focus();
            }
        }

        /// <summary>
        /// txtDiscountPercent_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiscountPercent_Leave(object sender, EventArgs e)
        {
            CalculateDiscoutAmount();
        }

        /// <summary>
        /// txtDiscountPercent_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiscountPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && string.Equals(txtbox.Name, txtDiscountPercent.Name))
            {
                e.Handled = true;         //Just Digits
            }
            if (e.KeyChar == (char)8)
                e.Handled = false;
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
        #endregion       
    }
}
