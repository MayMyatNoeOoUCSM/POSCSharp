using POS.Views;
using DAO.Common;
using Services.Auth;
using POS_Admin.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;
using POS_Admin.Functions;

namespace POS_Admin.Views.Auth
{
    /// <summary>
    /// Defines the <see cref="LoginForm" />.
    /// </summary>
    public partial class LoginForm : BaseForm
    {
        /// <summary>
        /// Defines the myPassword.
        /// </summary>
        private string myPassword;
        /// <summary>
        /// Defines the appSettings.
        /// </summary>
        private AppSettings appSettings = new AppSettings();

        private Localization localization = new Localization();

        /// <summary>
        /// Defines the authService.
        /// </summary>
        private AuthService authService = new AuthService();

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            Consts.LANGUAGEID = Convert.ToInt16(appSettings.GetSetting("languageId"));
            localization.ChangeLanguageText(Consts.LANGUAGEID, this, null);
        }

        /// <summary>
        /// The lblLogin_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void lblLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show(Messages.W0010, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show(Messages.W0011, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!String.IsNullOrEmpty(txtUserName.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                if (!CheckUserType())
                {
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtUserName.Focus();
                    return;
                }
                myPassword = authService.GetPassword(txtUserName.Text) == null ? string.Empty : authService.GetPassword(txtUserName.Text).ToString();               
                if (!String.IsNullOrEmpty(myPassword))
                {
                    if (Encryption.ValidatePassword(txtPassword.Text, myPassword))
                    {
                        object staffId = authService.CheckValidLogin(txtUserName.Text, myPassword);
                        if (staffId != null)
                        {
                            Consts.STAFFID = Convert.ToInt64(staffId);
                            //MainForm mainForm = new MainForm();
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(Messages.E0004, Messages.T0003, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Text = String.Empty;
                            txtUserName.Text = String.Empty;
                            txtUserName.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.E0002, Messages.T0003, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Text = String.Empty;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(Messages.E0004, Messages.T0003, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = String.Empty;
                    txtUserName.Text = String.Empty;
                    txtUserName.Focus();
                    return;
                }
            }
        }

        /// <summary>
        /// The lblClose_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// The txtPassword_KeyDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="KeyEventArgs"/>.</param>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblLogin_Click(sender, e);
            }
        }

        /// <summary>
        /// The CheckUserType.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool CheckUserType()
        {
            char c = txtUserName.Text.FirstOrDefault();
            if (!char.Equals(c, 'A'))
            {
                MessageBox.Show(Messages.W0081, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        /// <summary>
        /// The lblLogin_MouseHover.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            base.Label_MouseHover(sender, e);
            base.LabelColor_MouseHover(sender, e);
        }

        /// <summary>
        /// The lblLogin_MouseLeave.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            base.Label_MouseLeave(sender, e);
            base.LabelColor_MouseLeave(sender, e);
        }

        /// <summary>
        /// The lblClose_MouseHover.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void lblClose_MouseHover(object sender, EventArgs e)
        {
            base.Label_MouseHover(sender, e);
            base.LabelColor_MouseHover(sender, e);
        }

        /// <summary>
        /// The lblClose_MouseLeave.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            base.Label_MouseLeave(sender, e);
            base.LabelColor_MouseLeave(sender, e);
        }
    }
}
