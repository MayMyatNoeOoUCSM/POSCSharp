using DAO.Common;
using Entities.Product;
using POS_Admin.Utilities;
using Services.Category;
using Services.Product;
using Services.Supplier;
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

namespace POS_Admin.Views.Product
{
    public partial class UCProduct : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the productEntity.
        /// </summary>
        private ProductEntity productEntity = new ProductEntity();

        /// <summary>
        /// Defines the productService.
        /// </summary>
        private ProductService productService = new ProductService();

        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the categoryService.
        /// </summary>
        private CategoryService categoryService = new CategoryService();

        /// <summary>
        /// Defines the supplierService.
        /// </summary>
        private SupplierService supplierService = new SupplierService();

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the dtCategory.
        /// </summary>
        private DataTable dtCategory = new DataTable();

        /// <summary>
        /// Defines the dtsubcategory.
        /// </summary>
        private DataTable dtsubcategory = new DataTable();

        /// <summary>
        /// Defines the dtSupplier.
        /// </summary>
        private DataTable dtSupplier = new DataTable();
        
        /// <summary>
        /// Defines the dtSupplier.
        /// </summary>
        private DataTable dtBrand = new DataTable();

        /// <summary>
        /// Defines the imagePath, extension, basePath, productPath, destinationPath, productCodeValue, productCode, categoryId, subCategoryId...........
        /// </summary>
        private string imagePath = String.Empty,
                       extension = String.Empty,
                       basePath,
                       productPath,
                       destinationPath,
                       productCodeValue,
                       productCode = "0001",
                       categoryId = String.Empty,
                       subCategoryId = String.Empty,
                       brandId = String.Empty;

        /// <summary>
        /// Defines the pad.
        /// </summary>
        private char pad = '0';

        /// <summary>
        /// Defines the addOrEdit.
        /// </summary>
        private bool addOrEdit;

        /// <summary>
        /// Defines the open.
        /// </summary>
        OpenFileDialog open = new OpenFileDialog();
        #endregion

        #region==========Bind ComboData==========
        /// <summary>
        /// BindData
        /// </summary>
        private void BindData()
        {
            dtSupplier = supplierService.GetSupplierList();
            dtCategory = categoryService.GetParentCategoryList();
            DataRow dr = dtSupplier.NewRow(); //Create New Row
            dr["id"] = "0";        
            if (Consts.LANGUAGEID == 1)
            {
                dr["supplier_name"] = "Select Supplier Name";
            }
            else
            {
                dr["supplier_name"] = "ကုန်သွင်းသူအမည်ကို ရွေးပါ";
                cboSupplier.Font = new Font("Myanmar Text", 10);
            }
            dtSupplier.Rows.InsertAt(dr, 0);
            cboSupplier.DataSource = dtSupplier;
            cboSupplier.DisplayMember = "supplier_name";
            cboSupplier.ValueMember = "id";
            cboSupplier.SelectedIndex = 0;
            DataRow dr1 = dtCategory.NewRow(); //Create New Row
            dr1["id"] = "0";       
            if (Consts.LANGUAGEID == 1)
            {
                dr1["name"] = "Select Category Name";
            }
            else
            {
                dr1["name"] = "အမျိုးအစားအမည်ကို ရွေးပါ";
                cboCategory.Font = new Font("Myanmar Text", 10);
            }
            dtCategory.Rows.InsertAt(dr1, 0);
            cboCategory.DataSource = dtCategory;
            cboCategory.DisplayMember = "name";
            cboCategory.ValueMember = "id";
            cboCategory.SelectedIndex = 0;
            dtsubcategory = categoryService.GetSubCategory(-1);
            this.BindCboSubCategory(dtsubcategory);

            lblImage.Text = Messages.W0022;
            productImage.Visible = false;
            chkActive.Checked = false;
            chkAuto.Checked = true;
        }

        /// <summary>
        /// BindCboSubCategory
        /// </summary>
        /// <param name="dtSubCategory"></param>
        private void BindCboSubCategory(DataTable dtSubCategory)
        {
            DataRow dr = dtSubCategory.NewRow(); //Create New Row
            dr["id"] = "0";        
            if (Consts.LANGUAGEID == 1)
            {
                dr["name"] = "Select Sub Category";
            }
            else
            {
                dr["name"] = "ဒုတိယအမျိုးအစားအမည်ကို ရွေးပါ";
                cboSubCategory.Font = new Font("Myanmar Text", 10);
            }
            dtSubCategory.Rows.InsertAt(dr, 0);
            cboSubCategory.DataSource = dtSubCategory;
            cboSubCategory.DisplayMember = "name";
            cboSubCategory.ValueMember = "id";
        }

        /// <summary>
        /// BindcboCategory
        /// </summary>
        /// <param name="dtCategory"></param>
        private void BindcboCategory(DataTable dtCategory)
        {
            DataRow dr = dtCategory.NewRow(); //Create New Row
            dr["id"] = "0";       
            if (Consts.LANGUAGEID == 1)
            {
                dr["name"] = "Select Category";
            }
            else
            {
                dr["name"] = "အမျိုးအစားအမည်ကို ရွေးပါ";
                cboCategory.Font = new Font("Myanmar Text", 10);
            }
            dtCategory.Rows.InsertAt(dr, 0);
            cboCategory.DataSource = dtCategory;
            cboCategory.DisplayMember = "name";
            cboCategory.ValueMember = "id";
        }

        /// <summary>
        /// BindcboBrand
        /// </summary>
        /// <param name="dtCategory"></param>
        private void BindcboBrand()
        {
            dtBrand = productService.GetAllBrand();
            DataRow dr = dtBrand.NewRow(); //Create New Row
            dr["id"] = "0";       
            if (Consts.LANGUAGEID == 1)
            {
                dr["brand_name"] = "Select Brand";
            }
            else
            {
                dr["brand_name"] = "အမှတ်တံဆိပ်ကို ရွေးပါ";
                cboCategory.Font = new Font("Myanmar Text", 10);
            }
            dtBrand.Rows.InsertAt(dr, 0);
            cboBrand.DataSource = dtBrand;
            cboBrand.DisplayMember = "brand_name";
            cboBrand.ValueMember = "id";
            cboBrand.SelectedValue = 0;
        }
        #endregion

        #region==========Data Validation==========
        /// <summary>
        /// Validation
        /// </summary>
        private Boolean Validation()
        {
            try
            {
                if (cboSupplier.SelectedIndex == 0 || string.IsNullOrEmpty(cboSupplier.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0085, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0012, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cboSupplier.Focus();
                    return false;
                }
                if (cboCategory.SelectedIndex == 0 || string.IsNullOrEmpty(cboSupplier.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0084, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0014, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cboCategory.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txtProductName.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0096, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0015, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtProductName.Focus();
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
        /// ShowProductListForm
        /// </summary>
        private void ShowProductListForm()
        {
            this.Controls.Clear();
            UCProductList ucProductList = new UCProductList();
            this.Controls.Add(ucProductList);
        }

        /// <summary>
        /// SaveProduct
        /// </summary>
        private void SaveProduct()
        {
            productEntity.product_name = txtProductName.Text.ToString();
            productEntity.supplier_id = Convert.ToInt32(cboSupplier.SelectedValue);
            productEntity.category_id = Convert.ToInt32(cboCategory.SelectedValue);
            productEntity.sub_category_id = Convert.ToInt32(cboSubCategory.SelectedValue);
            string supplierId = (supplierService.GetSupplierId(Convert.ToInt32(cboSupplier.SelectedValue))).ToString();
            string parentCategoryId = (categoryService.GetParentCategoryId(Convert.ToInt32(cboCategory.SelectedValue))).ToString();
            categoryId = parentCategoryId == "0" ?
                                            (cboCategory.SelectedValue.ToString().PadLeft(2, pad)) :
                                            parentCategoryId.PadLeft(2, pad);
            subCategoryId = parentCategoryId == "0" ?
                                                "000" :
                                                (cboCategory.SelectedValue.ToString()).PadLeft(3, pad);
            if (lblCategory.Text.ToString() != cboCategory.SelectedValue.ToString())
            {
                var lastProductCode = productService.GetLastProductCode(Convert.ToInt32(cboCategory.SelectedValue));
                if (lastProductCode == 0)
                {
                    productCodeValue = Consts.COUNTRYCODE + categoryId + subCategoryId + productCode;
                }
                else
                {
                    productCodeValue = (lastProductCode + 1).ToString();
                }
            }
            else
            {
                productCodeValue = lblProductCode.Text;
            }
            productEntity.product_code = productCodeValue;
            productEntity.barcode = chkAuto.CheckState == CheckState.Checked ?
                                    productEntity.product_code :
                                    productEntity.barcode = txtBarCode.Text.ToString();
            productEntity.product_image_path = imagePath;
            productEntity.product_description = txtDescription.Text.ToString();
            //productEntity.is_deleted = Convert.ToInt16((chkActive.CheckState == CheckState.Checked) ? 0 : 1);
            productEntity.is_deleted =0;
            productEntity.created_user_id = Convert.ToInt32(Consts.STAFFID);
            productEntity.created_datetime = DateTime.Now;
            productEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
            productEntity.updated_datetime = DateTime.Now;
            productEntity.stock_level = (txtProductLevel.Text == ""? 0 : Convert.ToInt32(txtProductLevel.Text.ToString()));
            productEntity.brand_id = Convert.ToInt32(cboBrand.SelectedValue);

            if (!String.IsNullOrEmpty(imagePath))
            {
                string saveDirectory = Path.GetFullPath(basePath + productPath);
                CreateIfMissing(saveDirectory);
                string imageName = imagePath.Substring(imagePath.LastIndexOf('\\') + 1);
                imageName = productCodeValue.Substring(8, 4);
                destinationPath = Path.GetFullPath(saveDirectory + @"/" + categoryId + @"/" + subCategoryId);
                CreateIfMissing(destinationPath);
                productImage.Image = Image.FromFile(imagePath);
                Bitmap bm = new Bitmap(productImage.Image);
                string[] files = Directory.GetFiles(destinationPath, imageName + "*");
                if (files.Length > 0)
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(files[0]);
                }
                imageName += extension;
                bm.Save(destinationPath + @"\" + imageName);
                imagePath = productPath + "/" + categoryId + "/" + subCategoryId + "/" + imageName;
                productEntity.product_image_path = imagePath;
            }
            else
            {
                if (string.IsNullOrEmpty(lblImagePath.Text))
                    productEntity.product_image_path = null;
                else
                    productEntity.product_image_path = lblImagePath.Text;
            }
            var barCode = this.txtBarCode.Text.ToString();
            var isExistBarcode = productService.IsExistBarcode(barCode, lblId.Text );
            var proudctName = this.txtProductName.Text.ToString();
            var selectedCategoryId = this.cboCategory.SelectedValue.ToString();
            var isExistProductName = productService.IsExistProductName(proudctName, Convert.ToInt32(selectedCategoryId), lblId.Text);
            if (lblProductTitle.Text.Equals(Messages.I0009) || lblProductTitle.Text.Equals(Messages.I0033))
            {
                if (isExistBarcode)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0036, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0050, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    this.txtBarCode.Text = string.Empty;
                    this.txtBarCode.Focus();
                }
                if (isExistProductName)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0037, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0051, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                    this.txtProductName.Text = string.Empty;
                    this.lblImage.Text = Messages.W0022;
                    this.productImage.Visible = false;
                    imagePath = "";
                    this.txtProductName.Focus();
                }
                if (!(isExistBarcode || isExistProductName))
                {
                    productService.Insert(productEntity);
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
            }
            else
            {
                if (isExistBarcode)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0036, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0050, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    this.txtBarCode.Text = string.Empty;
                    this.txtBarCode.Focus();
                }
                if (isExistProductName)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0037, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0051, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    this.txtProductName.Text = string.Empty;
                    this.txtProductName.Focus();
                }
                if (!(isExistBarcode || isExistProductName))
                {
                    productEntity.id = Convert.ToInt32(lblId.Text);
                    productService.Update(productEntity);
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.I0002, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0040, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ShowProductListForm();
                }
            }
            txtProductName.Focus();
        }

        /// <summary>
        /// CreateIfMissing.
        /// </summary>
        /// <param name="path">.</param>
        private void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }
        #endregion

        #region==========Data Clear==========
        /// <summary>
        /// Clear
        /// </summary>
        private void Clear()
        {
            this.cboSupplier.SelectedIndex = 0;
            this.cboSubCategory.SelectedIndex = 0;
            this.cboCategory.SelectedIndex = 0;
            this.cboBrand.SelectedIndex = 0;
            this.txtProductName.Text = string.Empty;
            this.txtProductLevel.Text = string.Empty;
            this.chkActive.Checked = false;
            this.chkInput.Checked = false;
            this.chkAuto.Checked = true;
            this.txtBarCode.Text = string.Empty;
            this.lblBarCode.Text = string.Empty;
            this.lblImage.Text = Messages.W0022;
            this.productImage.Visible = false;
            this.txtDescription.Text = string.Empty;
            imagePath = string.Empty;
            txtProductName.Focus();
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
        public UCProduct()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }        
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCProduct_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCProduct_Load(object sender, EventArgs e)         
        {
            UCProduct uCProduct = new UCProduct();
            basePath = connection.GetIniString("ImageFolder", "PRODUCT_IMAGE_PATH", Consts.FILEPATH);
            productPath = connection.GetIniString("ProductImageFolder", "PRODUCT_PATH", Consts.FILEPATH);
            txtProductName.KeyPress += TextBox_KeyPress;
            txtDescription.KeyPress += TextBox_KeyPress;
            txtProductLevel.KeyPress += TextBox_KeyPress;
            txtBarCode.KeyPress += TextBox_KeyPress;
            txtProductName.TextChanged += TxtBox_TextChanged;
            txtDescription.TextChanged += TxtBox_TextChanged;
            cboCategory.SelectedIndexChanged -= cboCategory_SelectedIndexChanged;
            cboBrand.SelectedIndexChanged -= cboCategory_SelectedIndexChanged;
            this.BindData();
            this.BindcboBrand();
            //cboSupplier.Focus();
            //txtProductName.Focus();
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            //cboBrand.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            txtProductName.KeyPress -= TextBox_KeyPress;
            txtDescription.KeyPress -= TextBox_KeyPress;
            txtProductLevel.KeyPress -= TextBox_KeyPress;
            txtBarCode.KeyPress -= TextBox_KeyPress;
            txtProductName.TextChanged -= TxtBox_TextChanged;
            txtDescription.TextChanged -= TxtBox_TextChanged;
            localization.UCChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, uCProduct);
        }

        /// <summary>
        /// txtProductLevel_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProductLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;         //Just Digits
            }
            if (e.KeyChar == (char)8)
                e.Handled = false;   //Allow Backspace
        }

        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(Validation())
            {
                this.SaveProduct();
            }
        }

        /// <summary>
        /// btnBack_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.ShowProductListForm();
        }

        /// <summary>
        /// btnImage_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImage_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnImage_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImage_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// BarCodeCheckboxChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarCodeCheckboxChanged(object sender, EventArgs e)
        {
            if (sender == chkAuto)
            {
                chkInput.Checked = !chkAuto.Checked;
            }
            else if (sender == chkInput)
            {
                chkAuto.Checked = !chkInput.Checked;
            }
            if (chkInput.CheckState == CheckState.Checked)
            {
                lblBarCode.Visible = false;
                txtBarCode.Focus();
            }
            else
            {
                lblBarCode.Visible = true;
                txtBarCode.Text = String.Empty;
            }
        }

        /// <summary>
        /// btnImage_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImage_Click(object sender, EventArgs e)
        {
            open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.bmp, *.png) | *.jpg; *.jpeg; *.jpe; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                productImage.Image = new Bitmap(open.FileName);
                productImage.SizeMode = PictureBoxSizeMode.StretchImage; ;
                imagePath = open.FileName;
                string imageName = imagePath.Substring(imagePath.LastIndexOf('\\') + 1);
                extension = Path.GetExtension(open.FileName);
                lblImage.Text = imageName;
                productImage.Visible = true;
            }
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
        /// cboCategory_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtsubcategory = categoryService.GetSubCategory(Convert.ToInt32(cboCategory.SelectedValue));
            this.BindCboSubCategory(dtsubcategory);
        }

        /// <summary>
        /// The TextBox_KeyPress.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/>.</param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && !string.Equals(txtbox.Name, txtProductName.Name) && !string.Equals(txtbox.Name, txtDescription.Name))
            {
                e.Handled = true;         //Just Digits
            }
            else if ((txtbox.Text.Length >= txtProductLevel.MaxLength) && !string.Equals(txtbox.Name, txtProductName.Name) && !string.Equals(txtbox.Name, txtDescription.Name) && !string.Equals(txtbox.Name, txtBarCode.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtProductLevel.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtProductLevel.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtBarCode.MaxLength) && !string.Equals(txtbox.Name, txtProductName.Name) && !string.Equals(txtbox.Name, txtDescription.Name) && !string.Equals(txtbox.Name, txtProductLevel.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtBarCode.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtBarCode.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtProductName.MaxLength) && !string.Equals(txtbox.Name, txtDescription.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtProductName.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtProductName.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtDescription.MaxLength) && !string.Equals(txtbox.Name, txtProductName.Name))
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
            if ((txtbox.Text.Length > txtProductName.MaxLength) && !string.Equals(txtbox.Name, txtDescription.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtProductName.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtProductName.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
            if ((txtbox.Text.Length > txtDescription.MaxLength) && !string.Equals(txtbox.Name, txtProductName.Name))
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
