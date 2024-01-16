using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Category;
using DAO.Common;
using Services.Category;
using POS_Admin.Views.Auth;
using POS_Admin.Utilities;

namespace POS_Admin.Views.Category
{
    public partial class UCCategory : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        ///  Defines the categoryEntity
        /// </summary>
        private CategoryEntity categoryEntity = new CategoryEntity();

        /// <summary>
        ///  Defines the categoryService
        /// </summary>
        private CategoryService categoryService = new CategoryService();

        /// <summary>
        ///  Defines the dtParentCategory
        /// </summary>
        private DataTable dtParentCategory = new DataTable();

        private Localization localization = new Localization();
        #endregion

        #region==========Bind ComboData==========
        /// <summary>
        /// BindcboParentCategory
        /// </summary>
        private void BindcboParentCategory()
        {
            dtParentCategory = categoryService.GetParentCategoryList();
            DataRow dr = dtParentCategory.NewRow(); //Create New Row
            dr["id"] = "0";
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                dr["name"] = "Select Parent Category";
            }
            else
            {
                dr["name"] = "ပထမအမျိုးအစားအမည်ကို ရွေးပါ";
                cboParentCategory.Font = new Font("Myanmar Text", 10);
            }         
            dtParentCategory.Rows.InsertAt(dr, 0);
            cboParentCategory.DataSource = dtParentCategory;
            cboParentCategory.DisplayMember = "name";
            cboParentCategory.ValueMember = "id";
            cboParentCategory.SelectedIndex = 0;
            if (lblFormTitle.Text.Equals(Messages.I0008))
            {
                string parentId = lblParentId.Text.ToString();
                cboParentCategory.SelectedValue = string.IsNullOrEmpty(parentId) ? 0 : Convert.ToInt32(parentId);
            }
            else if (lblFormTitle.Text.Equals(Messages.M0002))
            {
                string parentId = lblParentId.Text.ToString();
                cboParentCategory.SelectedValue = string.IsNullOrEmpty(parentId) ? 0 : Convert.ToInt32(parentId);
            }
        }
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// SaveCategory
        /// </summary>
        private void SaveCategory()
        {
            categoryEntity.name = txtCategoryName.Text.ToString();
            categoryEntity.description = txtDescription.Text.ToString();
            categoryEntity.parent_category_id = Convert.ToInt64(cboParentCategory.SelectedValue.ToString());
            categoryEntity.created_user_id = Convert.ToInt32(Consts.STAFFID);
            categoryEntity.created_datetime = DateTime.Now;
            categoryEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            categoryEntity.updated_datetime = DateTime.Now;
            if(categoryService.SaveCategory(categoryEntity))
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
                    MessageBox.Show(Messages.B0041, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
        }

        /// <summary>
        /// UpdateCategory
        /// </summary>
        private void UpdateCategory()
        {
            Int64 selectParentCategoryId = Convert.ToInt64(cboParentCategory.SelectedValue.ToString());
            Int64 previousParentCategoryId = Convert.ToInt64(lblId.Text);
            categoryEntity.id = Convert.ToInt32(lblId.Text);
            categoryEntity.name = txtCategoryName.Text.ToString();
            categoryEntity.description = txtDescription.Text.ToString();
            categoryEntity.parent_category_id = selectParentCategoryId;
            categoryEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            categoryEntity.updated_datetime = DateTime.Now;
            if (previousParentCategoryId == selectParentCategoryId)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0008, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0039, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if(categoryService.UpdateCategory(categoryEntity))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.I0002, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0040, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                    ShowCategoryListForm();
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
        }

        /// <summary>
        /// ShowCategoryListForm
        /// </summary>
        public void ShowCategoryListForm()
        {
            this.Controls.Clear();
            UCCategoryList ucCategoryList = new UCCategoryList();
            this.Controls.Add(ucCategoryList);
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
        public UCCategory()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Data Clear==========
        /// <summary>
        /// Clear Data
        /// </summary>
        private void Clear()
        {
            this.txtCategoryName.Text = string.Empty;
            this.cboParentCategory.SelectedIndex = 0;
            this.txtDescription.Text = string.Empty;
            txtCategoryName.Focus();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCCategory_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCategory_Load(object sender, EventArgs e)
        {
            //txtCategoryName.Focus();
            BindcboParentCategory();
            UCCategory ucCategory = new UCCategory();
            txtCategoryName.KeyPress += TextBox_KeyPress;
            txtDescription.KeyPress += TextBox_KeyPress;
            txtCategoryName.TextChanged += TxtBox_TextChanged;
            txtDescription.TextChanged += TxtBox_TextChanged;
            Localization localization = new Localization();
            txtCategoryName.KeyPress -= TextBox_KeyPress;
            txtDescription.KeyPress -= TextBox_KeyPress;
            txtCategoryName.TextChanged -= TxtBox_TextChanged;
            txtDescription.TextChanged -= TxtBox_TextChanged;
            localization.UCChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, ucCategory);
        }

        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.ToString();
            if (lblFormTitle.Text.Equals(Messages.I0007) || lblFormTitle.Text.Equals(Messages.M0001))
            {
                if (string.IsNullOrEmpty(categoryName))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0003, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0016, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                }
                else
                {
                    bool isExistCategoryName = categoryService.IsExistCategoryName(categoryName);
                    if (isExistCategoryName)
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {
                            MessageBox.Show(Messages.W0032, Messages.I0007, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0017, Messages.F0004, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                        this.txtCategoryName.Text = string.Empty;
                        this.txtCategoryName.Focus();
                    }
                    else
                    {
                        if (cboParentCategory.SelectedValue == null)
                        {
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(Messages.W0083, Messages.I0007, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0018, Messages.F0004, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            this.SaveCategory();
                            cboParentCategory.DataSource = null;
                            this.BindcboParentCategory();
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(categoryName))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0003, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0016, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    string oldCategoryName = lblOldCategory.Text.ToString();
                    if (categoryName.Equals(oldCategoryName))
                    {
                        this.UpdateCategory();
                    }
                    else
                    {
                        bool isExistCategoryName = categoryService.IsExistCategoryName(categoryName);
                        if (isExistCategoryName)
                        {
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(Messages.W0032, Messages.I0007, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(Messages.B0017, Messages.F0004, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            this.txtCategoryName.Text = string.Empty;
                        }
                        else
                        {
                            this.UpdateCategory();
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
            UCCategoryList ucCategoryList = new UCCategoryList();
            this.Controls.Clear();
            this.Controls.Add(ucCategoryList);
        }

        /// <summary>
        /// Clear Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
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
        /// btnBack_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnBack_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnClear_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnClear_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }


        /// <summary>
        /// The TextBox_KeyPress.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/>.</param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && !string.Equals(txtbox.Name, txtCategoryName.Name) && !string.Equals(txtbox.Name, txtDescription.Name))
            {
                e.Handled = true;         //Just Digits
            }
            else if ((txtbox.Text.Length >= txtCategoryName.MaxLength) && !string.Equals(txtbox.Name, txtDescription.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtCategoryName.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtCategoryName.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtDescription.MaxLength) && !string.Equals(txtbox.Name, txtCategoryName.Name))
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

        /// TxtBox_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if ((txtbox.Text.Length > txtCategoryName.MaxLength) && !string.Equals(txtbox.Name, txtDescription.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtCategoryName.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtCategoryName.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
            if ((txtbox.Text.Length > txtDescription.MaxLength) && !string.Equals(txtbox.Name, txtCategoryName.Name))
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
