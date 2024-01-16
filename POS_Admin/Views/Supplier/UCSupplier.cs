using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Supplier;
using DAO.Common;
using Services.Supplier;
using POS_Admin.Utilities;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace POS_Admin.Views.Supplier
{
    public partial class UCSupplier : UserControl
    {
        #region==========Data Declaration==========
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
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// patternEmail
        /// </summary>
        //private string patternEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private string patternEmail = @"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";

        #endregion

        #region==========Data Validation==========
        /// <summary>
        /// Validation
        /// </summary>
        private Boolean Validation()
        {
            try
            {
                if (txtSupplierName.Text.ToString() == "" || txtSupplierName.Text.ToString() == null)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0085, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0012, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtSupplierName.Focus();
                    return false;
                }
                if ((txtAddress.Text.Length > txtAddress.MaxLength))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0068 + txtAddress.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0012 + txtAddress.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                    }                    
                    txtAddress.Focus();
                    return false;
                }
                if ((txtDescription.Text.Length > txtDescription.MaxLength))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0068 + txtAddress.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0012 + txtAddress.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    txtDescription.Focus();
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
            this.txtSupplierName.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtPhoneNo.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            txtSupplierName.Focus();
        }
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// SaveCategory.
        /// </summary>
        private void SaveSupplier()
        {
            supplierEntity.supplier_name = txtSupplierName.Text.ToString();
            supplierEntity.supplier_description = txtDescription.Text.ToString();
            supplierEntity.phone_no = txtPhoneNo.Text.ToString();
            supplierEntity.email = txtEmail.Text.ToString();
            supplierEntity.address = txtAddress.Text.ToString();
            supplierEntity.created_user_id = Convert.ToInt32(Consts.STAFFID);
            supplierEntity.created_datetime = DateTime.Now;
            supplierEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            supplierEntity.updated_datetime = DateTime.Now;
            if (supplierService.SaveSupplier(supplierEntity))
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
        /// UpdateCategory.
        /// </summary>
        private void UpdateSupplier()
        {
            supplierEntity.id = Convert.ToInt32(lblId.Text);
            supplierEntity.supplier_name = txtSupplierName.Text.ToString();
            supplierEntity.supplier_description = txtDescription.Text.ToString();
            supplierEntity.phone_no = txtPhoneNo.Text.ToString();
            supplierEntity.email = txtEmail.Text.ToString();
            supplierEntity.address = txtAddress.Text.ToString();
            supplierEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            supplierEntity.updated_datetime = DateTime.Now;
            if(supplierService.UpdateSupplier(supplierEntity))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.I0002, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Messages.B0040, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ShowSupplierListForm();
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
        /// ShowSupplierListForm.
        /// </summary>
        private void ShowSupplierListForm()
        {
            UCSupplierList uc = new UCSupplierList();
            this.Controls.Clear();
            this.Controls.Add(uc);
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

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCSupplier()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCSupplier_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSupplier_Load(object sender, EventArgs e)
        {
            UCSupplier uCSupplier = new UCSupplier();
            txtSupplierName.KeyPress += TextBox_KeyPress;
            txtAddress.KeyPress += TextBox_KeyPress;
            txtDescription.KeyPress += TextBox_KeyPress;
            txtPhoneNo.KeyPress += TextBox_KeyPress;
            //txtSupplierName.Focus();
            txtSupplierName.KeyPress -= TextBox_KeyPress;
            txtAddress.KeyPress -= TextBox_KeyPress;
            txtDescription.KeyPress -= TextBox_KeyPress;
            txtPhoneNo.KeyPress -= TextBox_KeyPress;
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCSupplier);
        }

        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string supplierName = txtSupplierName.Text.ToString();
            if (lblFormTitle.Text.Equals(Messages.I0029) || lblFormTitle.Text.Equals(Messages.I0032))
            {
               if(Validation())
                {
                    bool isExistSupplierName = supplierService.IsExistSupplierName(supplierName);
                    if (isExistSupplierName)
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {
                            MessageBox.Show(Messages.W0032, Messages.I0029, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0017, Messages.F0005, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        this.txtSupplierName.Text = string.Empty;
                        this.txtSupplierName.Focus();
                    }
                    else
                    {
                        this.SaveSupplier();
                    }
                }
            }
            else
            {
                if (Validation())
                {
                    string oldSupplierName = lblOldSupplier.Text.ToString();
                    if (supplierName.Equals(oldSupplierName))
                    {
                        this.UpdateSupplier();
                    }
                    else
                    {
                        bool isExistSupplierName = supplierService.IsExistSupplierName(supplierName);
                        if (isExistSupplierName)
                        {
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(Messages.W0032, Messages.I0031, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0017, Messages.F0006, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            this.txtSupplierName.Text = string.Empty;
                        }
                        else
                        {
                            this.UpdateSupplier();
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
            this.ShowSupplierListForm();
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
        /// The TextBox_KeyPress.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/>.</param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && !string.Equals(txtbox.Name, txtSupplierName.Name) 
                && !string.Equals(txtbox.Name, txtAddress.Name) && !string.Equals(txtbox.Name, txtDescription.Name) 
                && !string.Equals(txtbox.Name, txtEmail.Name))
            {
                e.Handled = true;         //Just Digits
            }
            else if ((txtbox.Text.Length >= txtPhoneNo.MaxLength) && !string.Equals(txtbox.Name, txtAddress.Name) 
                && !string.Equals(txtbox.Name, txtSupplierName.Name) && !string.Equals(txtbox.Name, txtDescription.Name) 
                && !string.Equals(txtbox.Name, txtEmail.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtPhoneNo.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtPhoneNo.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtSupplierName.MaxLength) && !string.Equals(txtbox.Name, txtAddress.Name) && !string.Equals(txtbox.Name, txtDescription.Name) && !string.Equals(txtbox.Name, txtEmail.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtSupplierName.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtSupplierName.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtAddress.MaxLength) && !string.Equals(txtbox.Name, txtDescription.Name) && !string.Equals(txtbox.Name, txtEmail.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtAddress.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtAddress.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtDescription.MaxLength) && !string.Equals(txtbox.Name, txtEmail.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtDescription.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtDescription.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }          
            if (e.KeyChar == (char)8)
                e.Handled = false;   //Allow Backspace
        }

        /// <summary>
        /// txtEmail_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (Regex.IsMatch(this.txtEmail.Text, patternEmail))
                {
                    return;
                }
                else
                {                 
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0092, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0065, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtEmail.Focus();
                    return;
                }
            }
            return;
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
            if ((txtbox.Text.Length > txtAddress.MaxLength))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtAddress.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtAddress.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
            if ((txtbox.Text.Length > txtDescription.MaxLength))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtDescription.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtDescription.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
        }
        #endregion       
    }
}
