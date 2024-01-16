using DAO.Common;
using POS_Admin.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.License;
using Services.License;

namespace POS_Admin.Views.Auth
{
    public partial class ExtendLicenseForm : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        /// <summary>
        /// Defines the categoryEntity.
        /// </summary>
        private LicenseEntity licenseEntity = new LicenseEntity();

        /// <summary>
        /// Defines the categoryService.
        /// </summary>
        private LicenseService licenseService = new LicenseService();

        /// <summary>
        /// ExtendLicenseForm
        /// </summary>
        public ExtendLicenseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// lblClose_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// btnCancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtFileName.Text = String.Empty;
        }

        /// <summary>
        /// btnActivate_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFileName.Text))
            {
                SKGL.Validate validate = new SKGL.Validate();
                validate.Key = txtFileName.Text;
                if(validate.IsValid)
                {             
                    Consts.DAYS = validate.DaysLeft;
                    if (Consts.DAYS > 0)
                    {
                        MessageBox.Show(Messages.I0018, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblStatus.Text = txtFileName.Text;
                        licenseEntity.license_key = txtFileName.Text.ToString();
                        licenseEntity.created_date = validate.CreationDate;
                        licenseEntity.expired_date =validate.ExpireDate;
                        licenseEntity.is_expired = 0;
                        licenseService.CreateLicenseKey(licenseEntity);
                        this.Hide();
                        //FormUtility.AppReloader();
                    }
                    else
                    {
                        MessageBox.Show(Messages.I0027, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFileName.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show(Messages.I0028, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = txtFileName.Text;
                }
            }  
            else
            {
                MessageBox.Show(Messages.I0026, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = txtFileName.Text;
            }
        }
    }
}
