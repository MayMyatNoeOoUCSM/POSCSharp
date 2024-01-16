﻿using DAO.Common;
using Entities.Sale;
using POS_Admin.Utilities;
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
    public partial class PaymentDetail : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the damageLossService.
        /// </summary>
        private SaleService saleService = new SaleService();


        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the id
        /// </summary>
        private Int64 Id = 0,
            changeFromDate = 0;

        /// <summary>
        /// Gets or sets the joinFromDate.
        /// </summary>
        private DateTime? paymentDate { get; set; }

        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            pnlHeader.BackColor = Properties.Settings.Default.BackColor;
            btnSubmit.BackColor = Properties.Settings.Default.BackColor;
            btnBack.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// PaymentDetail
        /// </summary>
        /// <param name="saleId"></param>
        public PaymentDetail(Int64 saleId)
        {
            InitializeComponent();
            this.CustomizeThemes();
            Id = saleId;
            BindCombo();

        }
        #endregion

        #region==========Filling Data==========
        /// <summary>
        /// The BindCombo.
        /// </summary>
        private void BindCombo()
        {
            Dictionary<int, string> paymentType = new Dictionary<int, string>();
            if (Consts.LANGUAGEID == 1)
            {
                paymentType.Add(1, "Select Payment Type");
            }
            else
            {
                paymentType.Add(1, "ငွေပေးချေမှု");
                cboPaymentType.Font = new Font("Myanmar Text", 10);
            }
            paymentType.Add(2, "AYA Pay");
            paymentType.Add(3, "CB Pay");
            paymentType.Add(4, "Wave Pay");
            paymentType.Add(5, "KBZ Pay");
            paymentType.Add(6, "Cash");
            cboPaymentType.DataSource = new BindingSource(paymentType, null);
            cboPaymentType.DisplayMember = "Value";
            cboPaymentType.ValueMember = "Key";
        }

        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// btnBack_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            ShowSaleList();
        }

        /// <summary>
        /// ShowSaleList
        /// </summary>
        private void ShowSaleList()
        {
            this.Controls.Clear();
            UCSaleList saleListForm = new UCSaleList();
            this.Controls.Add(saleListForm);
            saleListForm.Show();
        }

        /// <summary>
        /// PaymentDetail_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaymentDetail_Load(object sender, EventArgs e)
        {
            PaymentDetail paymentDetail = new PaymentDetail(Id);
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, paymentDetail);
        }

        /// <summary>
        /// dtpPaymentDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpPaymentDate_ValueChanged(object sender, EventArgs e)
        {
            changeFromDate = 1;
            this.dtpPaymentDate.CustomFormat = Consts.DATEFORMAT;
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
                if (Convert.ToInt32(txtPayAmount.Text) > Convert.ToInt32(txtLeftAmount.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W00108, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0083, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }
                saleService.AddPaidAmount(txtPayAmount.Text, Convert.ToInt64(lblid.Text), paymentDate, cboPaymentType.SelectedIndex);
                ShowSaleList();
            }
        }

        /// <summary>
        /// txtPayAmount_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;         //Just Digits
            }
            if (e.KeyChar == (char)8)
                e.Handled = false;   //Allow Backspace
        }

        #endregion

        #region==========Data Validation==========
        /// <summary>
        /// The Validation.
        /// </summary>
        private bool Validation()
        {
            if (changeFromDate == 1)
            {
                paymentDate = dtpPaymentDate.Value;
            }
            if (paymentDate.Equals(null))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W00111, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0087, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            else if (cboPaymentType.SelectedIndex == 0)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W00110, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0086, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            else if (String.IsNullOrEmpty(txtPayAmount.Text))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W00109, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0085, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }
        #endregion
    }
}
