using ExcelDataReader;
using DAO.Common;
using Entities.Category;
using Entities.Product;
using Services.Category;
using Services.Product;
using Services.Supplier;
using POS_Admin.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using POS_Admin.Properties;
using Services.Sale;

namespace POS_Admin.Views.Product
{
    public partial class UCProductList : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        ///  Defines the productEntity
        /// </summary>
        private ProductEntity productEntity = new ProductEntity();

        /// <summary>
        ///  Defines the productService
        /// </summary>
        private ProductService productService = new ProductService();

        /// <summary>
        ///  Defines the categoryService
        /// </summary>
        private CategoryService categoryService = new CategoryService();

        /// <summary>
        ///  Defines the supplierService
        /// </summary>
        private SupplierService supplierService = new SupplierService();

        /// <summary>
        /// Defines the damageLossService.
        /// </summary>
        private SaleService saleService = new SaleService();

        /// <summary>
        ///  Defines the connection
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        ///  Defines the pagination
        /// </summary>
        private Pagination pagination = new Pagination();

        /// <summary>
        ///  Defines the DataTable
        /// </summary>
        private DataTable dtProduct = new DataTable(),
                          dtTemp = new DataTable(),
                          dtSupplier = new DataTable(),
                          dtProductCategory = new DataTable(),
                          dtSubCategory = new DataTable(),
                          dtProductList = new DataTable(),
                          dtSearchResult = new DataTable();

        /// <summary>
        ///  Defines the CategoryEntity
        /// </summary>
        private List<CategoryEntity> csvCategoryList = new List<CategoryEntity>(),
                                     productCategoryList = new List<CategoryEntity>(),
                                     resultList = new List<CategoryEntity>(),
                                     noExistList = new List<CategoryEntity>();

        /// <summary>
        ///  Defines the csvProductList
        /// </summary>
        private List<ProductEntity> csvProductList = new List<ProductEntity>(),
                                    importList = new List<ProductEntity>();

        /// <summary>
        ///  Defines the pagination
        /// </summary>
        private int pageSize = 0,
                    totalPageCount = 0,
                    currentPage = 1,
                    count = 0;

        /// <summary>
        /// Defines the getFilterList.
        /// </summary>
        internal List<object> getFilterList = new List<object>();

        /// <summary>
        ///  Defines the path
        /// </summary>
        private string imgPath,
                       basePath;
       
        #endregion

        #region==========Bind ComboData==========
        /// <summary>
        /// BindCboProduct
        /// </summary>
        private void BindCboCategory()
        {
            DataRow dr = dtProductCategory.NewRow(); //Create New Row
            dr["distinct_id"] = "0";        
            if (Consts.LANGUAGEID == 1)
            {
                dr["category_name"] = "Select Category Name";
            }
            else
            {
                dr["category_name"] = "အမျိုးအစားအမည်ကို ရွေးပါ";
                cboCategory.Font = new Font("Myanmar Text", 10);
            }
            dtProductCategory.Rows.InsertAt(dr, 0);
            cboCategory.DataSource = dtProductCategory;
            cboCategory.DisplayMember = "category_name";
            cboCategory.ValueMember = "distinct_id";
            cboCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// GetProductSource
        /// </summary>
        private void BindCboProduct()
        {
            dtProductList = productService.GetAllProduct();
            DataRow dr = dtProductList.NewRow(); //Create New Row
            dr["id"] = "0";        
            if (Consts.LANGUAGEID == 1)
            {
                dr["product_name"] = "Select Product Name";
            }
            else
            {
                dr["product_name"] = "ကုန်ပစ္စည်းအမည်ကို ရွေးပါ";
                cboProduct.Font = new Font("Myanmar Text", 10);
            }
            dtProductList.Rows.InsertAt(dr, 0);
            cboProduct.DataSource = dtProductList;
            cboProduct.DisplayMember = "product_name";
            cboProduct.ValueMember = "id";
            cboProduct.SelectedIndex = 0;
            cboProduct.SelectedIndex = 0;
        }

        /// <summary>
        /// BindCboSupplier
        /// </summary>
        private void BindCboSupplier()
        {
            DataRow dr1 = dtSupplier.NewRow(); //Create New Row
            dr1["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                dr1["supplier_name"] = "Select Supplier Name";
            }
            else
            {
                dr1["supplier_name"] = "ကုန်သွင်းသူအမည်ကို ရွေးပါ";
                cboSupplier.Font = new Font("Myanmar Text", 10);
            }
            dtSupplier.Rows.InsertAt(dr1, 0);
            cboSupplier.DataSource = dtSupplier;
            cboSupplier.DisplayMember = "supplier_name";
            cboSupplier.ValueMember = "id";
            cboSupplier.SelectedIndex = 0;
            cboShowItem.SelectedIndex = 0;
        }
        #endregion

        #region==========Fill Data==========  
        /// <summary>
        /// The GetFilter.
        /// </summary>
        /// <returns>The <see cref="List{object}"/>.</returns>
        private List<object> GetFilter()
        {
            Int64 searchProductId = Convert.ToInt64(cboProduct.SelectedValue);
            Int64 searchSupplierId = Convert.ToInt64(cboSupplier.SelectedValue);
            Int64 searchCategoryId = Convert.ToInt64(cboCategory.SelectedValue);
            List<object> filterList = new List<object>();
            filterList.Add(searchSupplierId);
            filterList.Add(searchProductId);
            filterList.Add(searchCategoryId);
            return filterList;
        }

        /// <summary>
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            cboCategory.SelectedIndex = 0;
            cboProduct.SelectedIndex = 0;
            cboSupplier.SelectedIndex = 0;
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// dtgProduct_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dtgProduct.CurrentCell.Selected = false;
            if (dtgProduct.Columns[e.ColumnIndex].Name == "image" && e.RowIndex >= 0)
            {
                basePath = connection.GetIniString("ImageFolder", "PRODUCT_IMAGE_PATH", Consts.FILEPATH);
                imgPath = dtgProduct.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                imgPath = dtgProduct.Rows[e.RowIndex].Cells["product_image_path"].Value.ToString();
                imgPath = basePath + imgPath;
                if (File.Exists(imgPath))
                {
                    Image img = Image.FromFile(imgPath);
                    e.Value = img;
                }
                else
                    e.Value = Resources.no_product_image;
            }
        }

        /// <summary>
        /// dtgProduct_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgProduct_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dtgProduct.Columns[currentColumn].ReadOnly == true)
                {
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Hand;
                }
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

        /// <summary>
        /// ShowDetails
        /// </summary>
        private void ShowDetails()
        {
            dtgProduct.Visible = true;
            cboShowItem.Visible = true;
            lblPage.Visible = true;
            lblShowItemText.Visible = true;
            btnFirst.Visible = true;
            btnNext.Visible = true;
            btnLast.Visible = true;
            btnPrevious.Visible = true;
            lblPage.Visible = true;
            lblNoProductText.Visible = false;
        }

        /// <summary>
        /// HideDetails
        /// </summary>
        private void HideDetails()
        {
            cboShowItem.Visible = false;
            lblPage.Visible = false;
            lblShowItemText.Visible = false;
            btnFirst.Visible = false;
            btnNext.Visible = false;
            btnLast.Visible = false;
            btnPrevious.Visible = false;
            lblPage.Visible = false;
            lblNoProductText.Visible = true;
        }

        /// <summary>
        /// GetCurrentPageRecords
        /// </summary>
        /// <param name="currentPage"></param>
        private void GetCurrentPageRecords(int currentPage)
        {
            dtProduct = productService.GetProductList();
            DataTable dtResult = dtSearchResult.Rows.Count == 0 ? dtProduct : dtSearchResult;

            if (dtResult.Rows.Count == 0)
            {
                dtgProduct.DataSource = dtResult;
                HideDetails();
                return;
            }
            totalPageCount = pagination.CalculateTotalPages(dtResult, count);
            int previousPageOffSet = (currentPage - 1) * count;
            dtResult = dtResult.Select().Skip(previousPageOffSet).Take(count).CopyToDataTable();
            lblPage.Text = currentPage + "/" + totalPageCount;
            dtgProduct.DataSource = dtResult;
            pagination.PaginationButtonAction(
                dtProduct,
                btnFirst,
                btnPrevious,
                btnNext,
                btnLast,
                currentPage);
            pagination.PaginationButtonPaint(
                btnFirst,
                btnPrevious,
                btnNext,
                btnLast);
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            btnSearch.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            btnAdd.BackColor = Properties.Settings.Default.BackColor;
            dtgProduct.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Defines the genderId, mstautusId,changeFromDate,changeToDate...........
        /// </summary>
        public UCProductList()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCProductList_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCProductList_Load(object sender, EventArgs e)
        {
            UCProduct uCProduct = new UCProduct();
            dtgProduct.AutoGenerateColumns = false;
            dtProduct = productService.GetProductList();
            if (dtProduct.Rows.Count > 0)
            {
                lblNoProductText.Visible = false;
                dtgProduct.DataSource = dtProduct;
                ShowDetails();
            }
            else
            {
                HideDetails();
            }
            dtProductCategory = productService.GetProductCategoryList();
            dtSupplier = supplierService.GetSupplierList();
            this.BindCboSupplier();
            this.BindCboCategory();
            this.BindCboProduct();
            dtgProduct.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 250);
            localization.UCChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, uCProduct);
            localization.ChangeDatagridText(dtgProduct);
        }

        /// <summary>
        /// dtgProduct_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {                
                if (e.ColumnIndex == 6)
                {
                    this.Controls.Clear();
                    UCProduct ucProduct = new UCProduct();
                    if (Consts.LANGUAGEID == 1)
                    {
                        ucProduct.lblProductTitle.Text = POS_Admin.Properties.Messages.I0010;
                    }
                    else
                    {
                        ucProduct.lblProductTitle.Text = POS_Admin.Properties.Messages.M0005;
                        ucProduct.lblProductTitle.Font = new Font("Myanmar Text", 10);
                    }
                    //ucProduct.cboSupplier.Focus();
                    this.Controls.Add(ucProduct);
                    ucProduct.cboSupplier.SelectedValue = dtgProduct.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString();
                    ucProduct.cboSupplier.Text = dtgProduct.Rows[e.RowIndex].Cells["supplier_name"].Value.ToString();
                    ucProduct.cboCategory.SelectedValue = dtgProduct.Rows[e.RowIndex].Cells["category_id"].Value.ToString();
                    ucProduct.cboSubCategory.SelectedValue = dtgProduct.Rows[e.RowIndex].Cells["sub_category_id"].Value.ToString();
                    ucProduct.lblProductCode.Text = dtgProduct.Rows[e.RowIndex].Cells["product_code"].Value.ToString();
                    ucProduct.txtProductName.Text = dtgProduct.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                    ucProduct.lblOldProductName.Text = dtgProduct.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                    ucProduct.lblCategory.Text = dtgProduct.Rows[e.RowIndex].Cells["category_id"].Value.ToString();
                    ucProduct.lblSubCategory.Text = dtgProduct.Rows[e.RowIndex].Cells["sub_category_id"].Value.ToString();
                    ucProduct.lblBarCode.Text = dtgProduct.Rows[e.RowIndex].Cells["barcode"].Value.ToString();
                    ucProduct.txtBarCode.Text = dtgProduct.Rows[e.RowIndex].Cells["barcode"].Value.ToString();
                    ucProduct.txtProductLevel.Text = dtgProduct.Rows[e.RowIndex].Cells["stock_level"].Value.ToString();
                    ucProduct.cboBrand.SelectedValue = dtgProduct.Rows[e.RowIndex].Cells["brand_id"].Value.ToString();
                    ucProduct.lblBrand.Text = dtgProduct.Rows[e.RowIndex].Cells["brand_id"].Value.ToString();
                    ucProduct.chkAuto.Enabled = false;
                    ucProduct.chkInput.Enabled = false;
                    ucProduct.btnClear.Visible = false;
                    var dateValue = DateTime.Now;                    
                    ucProduct.txtDescription.Text = dtgProduct.Rows[e.RowIndex].Cells["product_description"].Value.ToString();
                    //ucProduct.chkActive.Checked = Convert.ToInt32(dtgProduct.Rows[e.RowIndex].Cells["is_deleted"].Value) == 0 ? true : false;
                    var imagePath = dtgProduct.Rows[e.RowIndex].Cells["product_image_path"].Value.ToString();
                    if (String.IsNullOrEmpty(imagePath))
                    {
                        ucProduct.lblImage.Text = DAO.Common.Messages.W0022;
                        ucProduct.productImage.Visible = false;
                    }
                    else
                    {
                        string imageName = imagePath.Substring(imagePath.LastIndexOf('/') + 1);
                        ucProduct.lblImage.Text = imageName;
                        ucProduct.lblImagePath.Text = imagePath.ToString();
                        basePath = connection.GetIniString("ImageFolder", "PRODUCT_IMAGE_PATH", DAO.Common.Consts.FILEPATH);
                        imgPath = dtgProduct.Rows[e.RowIndex].Cells["product_image_path"].Value.ToString();
                        imgPath = basePath + imgPath;
                        Image img, scaleImage;
                        if (File.Exists(imgPath))
                        {
                            img = Image.FromFile(imgPath);
                            scaleImage = FormUtility.ScaleImage(img, 108, 105);
                            ucProduct.productImage.Image = scaleImage;
                            ucProduct.productImage.Visible = true;
                        }
                        else
                        {
                            ucProduct.productImage.Image = FormUtility.ScaleImage(Resources.no_product_image, 108, 105);
                        }
                    }
                    ucProduct.lblId.Text = dtgProduct.Rows[e.RowIndex].Cells["id"].Value.ToString();
                }
                if (e.ColumnIndex == 7)
                {
                    DialogResult res = DialogResult.None;
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        res = MessageBox.Show(POS_Admin.Properties.Messages.I0004, POS_Admin.Properties.Messages.T0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    else
                    {
                        res = MessageBox.Show(POS_Admin.Properties.Messages.B0004, POS_Admin.Properties.Messages.F0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    if (res == DialogResult.OK)
                    {
                        var productId = dtgProduct.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        var count = saleService.GetSaleDetailsByProductId(Convert.ToInt16(productId));
                        if(count > 0)
                        {
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(Properties.Messages.W0017, Properties.Messages.I0011, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(Properties.Messages.B0005, Properties.Messages.F0004, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }                            
                        }
                        else
                        {
                            productService.Delete(Convert.ToInt64(productId));
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(POS_Admin.Properties.Messages.I0003, POS_Admin.Properties.Messages.I0011, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(POS_Admin.Properties.Messages.B0003, POS_Admin.Properties.Messages.F0004, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            dtProduct.Rows.RemoveAt(e.RowIndex);
                            ((DataTable)dtgProduct.DataSource).AcceptChanges();
                            dtgProduct.EndEdit(DataGridViewDataErrorContexts.Commit);
                            this.Validate();
                            dtgProduct.Focus();
                            if (currentPage > 1)
                            {
                                currentPage = 1;
                            }
                            this.GetCurrentPageRecords(currentPage);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// btnSearch_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getFilterList = GetFilter();
            dtSearchResult = productService.GetSearchResult(getFilterList);
            if (dtSearchResult.Rows.Count > 0)
            {
                currentPage = 1;
                GetCurrentPageRecords(currentPage);
                ShowDetails();
            }
            else
            {
                dtgProduct.DataSource = dtSearchResult;
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W0098, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0029, DAO.Common.Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                HideDetails();
            }
        }

        /// <summary>
        /// btnAdd_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UCProduct ucProduct = new UCProduct();
            this.Controls.Add(ucProduct);
            if (Consts.LANGUAGEID == 1)
            {
                ucProduct.lblProductTitle.Text = POS_Admin.Properties.Messages.I0009;
            }
            else
            {
                ucProduct.lblProductTitle.Text = POS_Admin.Properties.Messages.M0004;
                ucProduct.lblProductTitle.Font = new Font("Myanmar Text", 10);
            }
        }     

        /// <summary>
        /// cboShowItem_SelectedIndexChanged_1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboShowItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(cboShowItem.GetItemText(cboShowItem.SelectedItem));
            if (currentPage > 1)
            {
                currentPage = 1;
            }
            this.GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// btnFirst_Click_1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click_1(object sender, EventArgs e)
        {
            currentPage = 1;
            this.GetCurrentPageRecords(currentPage);
        }

        /// <summary>
        /// btnPrevious_Click_1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                this.GetCurrentPageRecords(currentPage);
            }
        }

        /// <summary>
        /// btnNext_Click_1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (currentPage < totalPageCount)
            {
                currentPage++;
                this.GetCurrentPageRecords(currentPage);
            }
            dtgProduct.Focus();
        }

        /// <summary>
        /// btnLast_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPageCount;
            this.GetCurrentPageRecords(currentPage);
            dtgProduct.Focus();
        }
        #endregion

    }
}
