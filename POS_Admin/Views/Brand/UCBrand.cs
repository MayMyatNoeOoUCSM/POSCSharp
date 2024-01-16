using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Brand;
using DAO.Common;
using Services.Brand;
using POS_Admin.Utilities;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace POS_Admin.Views.Brand
{
    public partial class UCBrand : UserControl
    {
        #region==========Data Declaration==========
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
                if (txtBrandName.Text.ToString() == "" || txtBrandName.Text.ToString() == null)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0118, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0102, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtBrandName.Focus();
                    return false;
                }
                if ((txtBrandDescription.Text.Length > txtBrandDescription.MaxLength))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0068 + txtBrandDescription.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0012 + txtBrandDescription.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    txtBrandDescription.Focus();
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

        #region==========Data Clear==========
        /// <summary>
        /// Clear.
        /// </summary>
        private void Clear()
        {
            this.txtBrandName.Text = string.Empty;
            this.txtBrandDescription.Text = string.Empty;
            txtBrandName.Focus();
        }
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// SaveBrand.
        /// </summary>
        private void SaveBrand()
        {
            brandEntity.brand_name = txtBrandName.Text.ToString();
            brandEntity.brand_description = txtBrandDescription.Text.ToString();
            brandEntity.created_user_id = Convert.ToInt32(Consts.STAFFID);
            brandEntity.created_datetime = DateTime.Now;
            brandEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            brandEntity.updated_datetime = DateTime.Now;
            if (brandService.SaveBrand(brandEntity))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.I0001, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Messages.B0037, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Clear();
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
        /// UpdateBrand.
        /// </summary>
        private void UpdateBrand()
        {
            brandEntity.id = Convert.ToInt32(lblId.Text);
            brandEntity.brand_name = txtBrandName.Text.ToString();
            brandEntity.brand_description = txtBrandDescription.Text.ToString();
            brandEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            brandEntity.updated_datetime = DateTime.Now;
            if (brandService.UpdateBrand(brandEntity))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.I0002, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Messages.B0040, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ShowBrandListForm();
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
        /// ShowBrandListForm.
        /// </summary>
        private void ShowBrandListForm()
        {
            UCBrandList uc = new UCBrandList();
            this.Controls.Clear();
            this.Controls.Add(uc);
        }
        #endregion

        #region==========Customize Themes==========
        /// <summary>
        /// CustomizeThemes
        /// </summary>
        private void CustomizeThemes()
        {
            pnlHeader.BackColor = Properties.Settings.Default.BackColor;
            btnSubmit.BackColor = Properties.Settings.Default.BackColor;
            btnBack.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        public UCBrand()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCBrand_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCBrand_Load(object sender, EventArgs e)
        {
            UCBrand uCBrand = new UCBrand();
            txtBrandName.KeyPress += TextBox_KeyPress;
            txtBrandDescription.KeyPress += TextBox_KeyPress;
            //txtSupplierName.Focus();
            txtBrandName.KeyPress -= TextBox_KeyPress;
            txtBrandDescription.KeyPress -= TextBox_KeyPress;
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCBrand);
        }

        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string brandName = txtBrandName.Text.ToString();
            if (lblFormTitle.Text.Equals(Messages.I0044) || lblFormTitle.Text.Equals(Messages.I0038))
            {
                if (Validation())
                {
                    bool isExistBrandName = brandService.IsExistBrandName(brandName);
                    if (isExistBrandName)
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {
                            MessageBox.Show(Messages.W0032, Messages.I0044, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0017, Messages.F0007, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        this.txtBrandName.Text = string.Empty;
                        this.txtBrandName.Focus();
                    }
                    else
                    {
                        this.SaveBrand();
                    }
                }
            }
            else
            {
                if (Validation())
                {
                    string oldBrandName = lblOldBrand.Text.ToString();
                    if (brandName.Equals(oldBrandName))
                    {
                        this.UpdateBrand();
                    }
                    else
                    {
                        bool isExistBrandName = brandService.IsExistBrandName(brandName);
                        if (isExistBrandName)
                        {
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(Messages.W0032, Messages.I0039, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0017, Messages.F0008, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            this.txtBrandName.Text = string.Empty;
                        }
                        else
                        {
                            this.UpdateBrand();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// btnBack_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.ShowBrandListForm();
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
        /// TextBox_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && !string.Equals(txtbox.Name, txtBrandName.Name)
                && !string.Equals(txtbox.Name, txtBrandDescription.Name))
            {
                e.Handled = true;         //Just Digits
            }
            else if ((txtbox.Text.Length >= txtBrandName.MaxLength) && !string.Equals(txtbox.Name, txtBrandDescription.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtBrandName.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtBrandName.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
                e.Handled = false;   //Allow Backspace
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

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if ((txtbox.Text.Length > txtBrandDescription.MaxLength))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtBrandDescription.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtBrandDescription.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
        }
        #endregion


    }
}
