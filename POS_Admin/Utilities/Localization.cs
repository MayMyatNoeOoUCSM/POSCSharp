using POS_Admin.Properties;
using POS_Admin.Views.Dashboard;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DAO.Common;

namespace POS_Admin.Utilities
{
    /// <summary>
    /// Defines the <see cref="Localization" />.
    /// </summary>
    public class Localization
    {
        /// <summary>
        /// UCChangeLanguageText
        /// </summary>
        /// <param name="languageId"></param>
        /// <param name="frm"></param>
        /// <param name="uc"></param>
        public void UCChangeLanguageText(int languageId, UserControl frm, UserControl uc)
        {
            foreach (Control c in frm.Controls)
            {
                ChangeControlText(c);
                if (c.HasChildren)
                {
                    foreach (Control child in c.Controls)
                    {
                        ChangeControlText(child);
                    }
                }
            }

            ChangeLanguageUserControl(languageId, uc);
        }    

        /// <summary>
        /// The ChangeLanguageText.
        /// </summary>
        /// <param name="languageId">The languageId<see cref="int"/>.</param>
        /// <param name="frm">The frm<see cref="Form"/>.</param>
        public void ChangeLanguageText(int languageId, Form frm, UserControl uc)
        {
            foreach (Control c in frm.Controls)
            {
                ChangeControlText(c);
                if (c.HasChildren)
                {
                    foreach (Control child in c.Controls)
                    {
                        ChangeControlText(child);
                    }
                }
            }
            if (uc == null)
            {
                return;
            }
            ChangeLanguageUserControl(languageId, uc);
        }

        /// <summary>
        /// ChangeLanguageUserControl
        /// </summary>
        /// <param name="languageId"></param>
        /// <param name="uc"></param>
        public void ChangeLanguageUserControl(int languageId, UserControl uc)
        {
            foreach (Control c in uc.Controls)
            {
                ChangeControlText(c);
                if (c.HasChildren)
                {
                    foreach (Control child in c.Controls)
                    {
                        ChangeControlText(child);
                    }
                }
            }
        }

        /// <summary>
        /// The ChangeControlText.
        /// </summary>
        /// <param name="ctrl">The ctrl<see cref="Control"/>.</param>
        public void ChangeControlText(Control ctrl)
        {
            if (ctrl is Label || ctrl is Button || ctrl is RadioButton || ctrl is CheckBox)
            {
                ChangeLabelText(ctrl);
            }
            if (ctrl is Panel)
            {
                foreach (Control c in ((Control)ctrl).Controls)
                {
                    //for right panel label
                    if (c is Label)
                    {
                        ChangeLabelText(c);
                    }

                    if (c is Panel)
                    {
                        foreach (Control cp in ((Control)c).Controls)
                        {
                            if (cp is Label)
                            {
                                ChangeLabelText(cp);
                            }
                        }
                    }
                    if (c is DataGridView)
                    {
                        ChangeDatagridText(c);
                    }
                    if (ctrl is FlowLayoutPanel)
                    {
                        foreach (Control cp in ((Control)ctrl).Controls)
                        {
                            //for right panel label
                            if (cp is Label)
                            {
                                ChangeLabelText(cp);
                            }

                        }
                    }

                }
            }
        }

        /// <summary>
        /// The ChangeLabelText.
        /// </summary>
        /// <param name="ctrl">The ctrl<see cref="Control"/>.</param>
        public void ChangeLabelText(Control ctrl)
        {
            var nameList = LanguageSetting.nameList();
            if (DAO.Common.Consts.LANGUAGEID == 2)
            {
                var res = nameList.Where(r => r.English.Trim().ToLower().Equals(ctrl.Text.Trim().ToLower())).ToList();

                if (res.Count > 0)
                {                   
                    ctrl.Font = new Font("Myanmar Text", 10);
                    ctrl.Text = res[0].Myanmar.ToString();                 
                }

            }
            else
            {
                var res = nameList.Where(r => r.Myanmar.Trim().ToLower().Equals(ctrl.Text.Trim().ToLower())).ToList();
                if (res.Count > 0)
                {
                    if (res.Count > 0)
                    {
                        ctrl.Font = new Font("Microsoft Sans Serif", 12);
                        if (ctrl.Text == res[0].Myanmar.ToString())
                        {
                            ctrl.Text = res[0].English.ToString();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The ChangeDatagridText.
        /// </summary>
        /// <param name="ctrl">The ctrl<see cref="Control"/>.</param>
        public void ChangeDatagridText(Control ctrl)
        {
            var nameList = LanguageSetting.nameList();
            if (DAO.Common.Consts.LANGUAGEID == 2)
            {
                Font f = new Font("Myanmar Text", 10);              
                foreach (DataGridViewColumn dcol in ((DataGridView)ctrl).Columns)
                {
                    var res = nameList.Where(r => r.English.Trim().ToLower().Equals(dcol.HeaderText.Trim().ToLower())).ToList();

                    if (res.Count > 0)
                    {
                        dcol.HeaderText = res[0].Myanmar.ToString();
                        dcol.DataGridView.ColumnHeadersDefaultCellStyle.Font = f;
                        dcol.DataGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(1, 0, 1, 0);
                    }
                }
            }
            else
            {
                foreach (DataGridViewColumn dcol in ((DataGridView)ctrl).Columns)
                {
                    var res = nameList.Where(r => r.Myanmar.Trim().ToLower().Equals(dcol.HeaderText.Trim().ToLower())).ToList();

                    if (res.Count > 0)
                    {
                        if (dcol.HeaderText == res[0].Myanmar.ToString())
                        {
                            dcol.HeaderText = res[0].English.ToString();
                        }
                    }
                }
            }
        }
    }
}
