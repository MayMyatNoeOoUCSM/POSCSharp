using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Customer;
using DAO.Common;
using Services.Customer;
using POS_Admin.Utilities;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace POS_Admin.Views.Customer
{
    public partial class UCCustomer : UserControl
    {
        #region==========Data Declaration==========
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
                if (txtCustomerName.Text.ToString() == "" || txtCustomerName.Text.ToString() == null)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0108, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0080, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtCustomerName.Focus();
                    return false;
                }
                if ((txtCustomerAddress.Text.Length > txtCustomerAddress.MaxLength))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0068 + txtCustomerAddress.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0012 + txtCustomerAddress.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtCustomerAddress.Focus();
                    return false;
                }
                if ((txtCustomerDescription.Text.Length > txtCustomerDescription.MaxLength))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0068 + txtCustomerAddress.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0012 + txtCustomerAddress.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    txtCustomerDescription.Focus();
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
            this.txtCustomerName.Text = string.Empty;
            this.txtCustomerDescription.Text = string.Empty;
            this.txtCustomerPhoneNo.Text = string.Empty;
            this.txtCustomerEmail.Text = string.Empty;
            this.txtCustomerAddress.Text = string.Empty;
            txtCustomerName.Focus();
        }
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// SaveCustomer.
        /// </summary>
        private void SaveCustomer()
        {
            customerEntity.customer_name = txtCustomerName.Text.ToString();
            customerEntity.customer_description = txtCustomerDescription.Text.ToString();
            customerEntity.phone_no = txtCustomerPhoneNo.Text.ToString();
            customerEntity.email = txtCustomerEmail.Text.ToString();
            customerEntity.address = txtCustomerAddress.Text.ToString();
            customerEntity.created_user_id = Convert.ToInt32(Consts.STAFFID);
            customerEntity.created_datetime = DateTime.Now;
            customerEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            customerEntity.updated_datetime = DateTime.Now;
            if (customerService.SaveCustomer(customerEntity))
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
        /// UpdateCustomer.
        /// </summary>
        private void UpdateCustomer()
        {
            customerEntity.id = Convert.ToInt32(lblId.Text);
            customerEntity.customer_name = txtCustomerName.Text.ToString();
            customerEntity.customer_description = txtCustomerDescription.Text.ToString();
            customerEntity.phone_no = txtCustomerPhoneNo.Text.ToString();
            customerEntity.email = txtCustomerEmail.Text.ToString();
            customerEntity.address = txtCustomerAddress.Text.ToString();
            customerEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            customerEntity.updated_datetime = DateTime.Now;
            if (customerService.UpdateCustomer(customerEntity))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.I0002, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Messages.B0040, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ShowCustomerListForm();
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
        /// ShowCustomerListForm.
        /// </summary>
        private void ShowCustomerListForm()
        {
            UCCustomerList uc = new UCCustomerList();
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

        #region==========Initialization=========
        /// <summary>
        /// initial
        /// </summary>
        public UCCustomer()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCCustomer_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCustomer_Load(object sender, EventArgs e)
        {
            UCCustomer uCCustomer = new UCCustomer();
            txtCustomerName.KeyPress += TextBox_KeyPress;
            txtCustomerAddress.KeyPress += TextBox_KeyPress;
            txtCustomerDescription.KeyPress += TextBox_KeyPress;
            txtCustomerPhoneNo.KeyPress += TextBox_KeyPress;
            //txtSupplierName.Focus();
            txtCustomerName.KeyPress -= TextBox_KeyPress;
            txtCustomerAddress.KeyPress -= TextBox_KeyPress;
            txtCustomerDescription.KeyPress -= TextBox_KeyPress;
            txtCustomerPhoneNo.KeyPress -= TextBox_KeyPress;
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCCustomer);
        }

        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.ToString();
            if (lblFormTitle.Text.Equals(Messages.I0041) || lblFormTitle.Text.Equals(Messages.I0042))
            {
                if (Validation())
                {
                    bool isExistCustomerName = customerService.IsExistCustomerName(customerName);
                    if (isExistCustomerName)
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {
                            MessageBox.Show(Messages.W0032, Messages.I0041, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0017, Messages.F0009, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        this.txtCustomerName.Text = string.Empty;
                        this.txtCustomerName.Focus();
                    }
                    else
                    {
                        this.SaveCustomer();
                    }
                }
            }
            else
            {
                if (Validation())
                {
                    string oldCustomerName = lblOldCustomer.Text.ToString();
                    if (customerName.Equals(oldCustomerName))
                    {
                        this.UpdateCustomer();
                    }
                    else
                    {
                        bool isExistCustomerName = customerService.IsExistCustomerName(customerName);
                        if (isExistCustomerName)
                        {
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(Messages.W0032, Messages.I0043, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0017, Messages.F0010, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            this.txtCustomerName.Text = string.Empty;
                        }
                        else
                        {
                            this.UpdateCustomer();
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
            this.ShowCustomerListForm();
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
            if (!char.IsDigit(e.KeyChar) && !string.Equals(txtbox.Name, txtCustomerName.Name)
                && !string.Equals(txtbox.Name, txtCustomerAddress.Name) && !string.Equals(txtbox.Name, txtCustomerDescription.Name)
                && !string.Equals(txtbox.Name, txtCustomerEmail.Name))
            {
                e.Handled = true;         //Just Digits
            }
            else if ((txtbox.Text.Length >= txtCustomerPhoneNo.MaxLength) && !string.Equals(txtbox.Name, txtCustomerAddress.Name)
                && !string.Equals(txtbox.Name, txtCustomerName.Name) && !string.Equals(txtbox.Name, txtCustomerDescription.Name)
                && !string.Equals(txtbox.Name, txtCustomerEmail.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtCustomerPhoneNo.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtCustomerPhoneNo.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtCustomerName.MaxLength) && !string.Equals(txtbox.Name, txtCustomerAddress.Name) && !string.Equals(txtbox.Name, txtCustomerDescription.Name) && !string.Equals(txtbox.Name, txtCustomerEmail.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtCustomerName.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtCustomerName.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtCustomerAddress.MaxLength) && !string.Equals(txtbox.Name, txtCustomerDescription.Name) && !string.Equals(txtbox.Name, txtCustomerEmail.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtCustomerAddress.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtCustomerAddress.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtCustomerDescription.MaxLength) && !string.Equals(txtbox.Name, txtCustomerEmail.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtCustomerDescription.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtCustomerDescription.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
                e.Handled = false;   //Allow Backspace
        }

        /// <summary>
        /// txtCustomerEmail_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerEmail_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCustomerEmail.Text))
            {
                if (Regex.IsMatch(this.txtCustomerEmail.Text, patternEmail))
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
                    txtCustomerEmail.Focus();
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

        /// <summary>
        /// TxtBox_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if ((txtbox.Text.Length > txtCustomerAddress.MaxLength))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtCustomerAddress.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtCustomerAddress.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
            if ((txtbox.Text.Length > txtCustomerDescription.MaxLength))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtCustomerDescription.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtCustomerDescription.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
        }
        #endregion

    }
}
