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
    public partial class FrmLoginForm : Form
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the myPassword.
        /// </summary>
        private string myPassword;

        /// <summary>
        /// Defines the authService.
        /// </summary>
        private AuthService authService = new AuthService();

        /// <summary>
        /// Defines the appSettings.
        /// </summary>
        private AppSettings appSettings = new AppSettings();

        /// <summary>
        /// localization
        /// </summary>
        private Localization localization = new Localization();
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            pnlLeft.BackColor = Properties.Settings.Default.BackColor;
            picLogin.BackColor = Properties.Settings.Default.BackColor;
            picClose.BackColor = Properties.Settings.Default.BackColor;
            lblLogin.BackColor = Properties.Settings.Default.BackColor;
            lblClose.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public FrmLoginForm()
        {
            InitializeComponent();
            txtPwd.Focus();
            Consts.LANGUAGEID = Convert.ToInt16(appSettings.GetSetting("languageId"));
            localization.ChangeLanguageText(Consts.LANGUAGEID, this, null);
            this.CustomizeThemes();
        }
        #endregion

        #region==========Validation==========
        /// <summary>
        /// The CheckUserType.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool CheckUserType()
        {
            char c = txtPwd.Text.FirstOrDefault();
            if (!char.Equals(c, 'A'))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0081, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Messages.B0075, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return false;
            }
            return true;
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// FrmLoginForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLoginForm_Load(object sender, EventArgs e)
        {
            //txtStaffName.Focus();
            //////txtStaffName.Select(20, 100);
            ////txtStaffName.Select(txtStaffName.Text.Length, 0);
            //txtStaffName.Text ="                                                                                ";
            //txtStaffName.SelectionStart = 50;
            //txtStaffName.SelectionLength = 50;
        }

        /// <summary>
        /// lblLogin_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserID.Text))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0010, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Messages.B0076, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (String.IsNullOrEmpty(txtPwd.Text))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0011, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0077, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (!String.IsNullOrEmpty(txtUserID.Text) && !String.IsNullOrEmpty(txtPwd.Text))
            {
                if (!CheckUserType())
                {
                    txtUserID.Text = string.Empty;
                    txtPwd.Text = string.Empty;
                    txtUserID.Focus();
                    return;
                }
                myPassword = authService.GetPassword(txtUserID.Text) == null ? string.Empty : authService.GetPassword(txtUserID.Text).ToString();
                if (!String.IsNullOrEmpty(myPassword))
                {
                    if (Encryption.ValidatePassword(txtPwd.Text, myPassword))
                    {
                        object staffId = authService.CheckValidLogin(txtUserID.Text, myPassword);
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
                            
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(Messages.E0004, Messages.T0003, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0078, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            txtPwd.Text = String.Empty;
                            txtUserID.Text = String.Empty;
                            txtUserID.Focus();
                            return;
                        }
                    }
                    else
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {
                            MessageBox.Show(Messages.E0002, Messages.T0003, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0074, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                        txtPwd.Text = String.Empty;
                        return;
                    }
                }
                else
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.E0004, Messages.T0003, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0078, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    txtPwd.Text = String.Empty;
                    txtUserID.Text = String.Empty;
                    txtUserID.Focus();
                    return;
                }
            }
        }

        /// <summary>
        /// lblClose_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// txtPassword_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblLogin_Click(sender, e);
            }
        }

        /// <summary>
        /// lblLogin_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// lblLogin_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// lblClose_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// lblClose_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// txtPwd_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblLogin_Click(sender, e);
            }
        }

        /// <summary>
        /// picLogin_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picLogin_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// picLogin_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picLogin_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// picClose_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picClose_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// picClose_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        #endregion     
    }
}
