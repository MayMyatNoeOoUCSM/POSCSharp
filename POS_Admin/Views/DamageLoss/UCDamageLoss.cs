using Entities.DamageLoss;
using DAO.Common;
using Services.Category;
using Services.DamageLoss;
using Services.Product;
using Services.Stock;
using Services.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_Admin.Utilities;

namespace POS_Admin.Views.DamageLoss
{
    public partial class UCDamageLoss : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the supplierService.
        /// </summary>
        private SupplierService supplierService = new SupplierService();

         /// <summary>
        /// Defines the supplierService.
        /// </summary>
        private CategoryService categoryService = new CategoryService();
        
         /// <summary>
        /// Defines the supplierService.
        /// </summary>
        private ProductService productService = new ProductService();

        /// <summary>
        /// Defines the supplierService.
        /// </summary>
        private DamageLossService damageLossService = new DamageLossService();

        /// <summary>
        /// Defines the stockService.
        /// </summary>
        private StockService stockService = new StockService();

        /// <summary>
        /// Defines the dtCategoryList, dtParentCategory, dtTemp.....
        /// </summary>
        private DataTable dtSupplier = new DataTable(),
                          dtDamageLoss = new DataTable(),
                          dtCategory = new DataTable(),
                          dtProductData = new DataTable();

        /// <summary>
        /// Defines the damageLossEntity.
        /// </summary>
        private DamageLossEntity damageLossEntity = new DamageLossEntity();

        #endregion

        #region==========Bind Data==========
        /// <summary>
        /// The GetHeaderSource.
        /// </summary>
        private void GetHeaderSource()
        {
            dtSupplier = supplierService.GetSupplierList();
            DataRow drShop = dtSupplier.NewRow(); //Create New Row
            drShop["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                drShop["supplier_name"] = "Select Supplier Name";
            }
            else
            {
                drShop["supplier_name"] = "ကုန်သွင်းသူအမည်ကို ရွေးပါ";
                cboSupplier.Font = new Font("Myanmar Text", 10);
            }
            dtSupplier.Rows.InsertAt(drShop, 0);
            cboSupplier.DataSource = dtSupplier;
            cboSupplier.DisplayMember = "supplier_name";
            cboSupplier.ValueMember = "id";
            cboSupplier.SelectedIndex = 0;

            dtCategory = categoryService.GetParentCategory();
            DataRow drCategory = dtCategory.NewRow(); //Create New Row
            drCategory["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                drCategory["name"] = "Select Category Name";
            }
            else
            {
                drCategory["name"] = "အမျိုးအစားအမည်ကို ရွေးပါ";
                cboCategory.Font = new Font("Myanmar Text", 10);
            }
            dtCategory.Rows.InsertAt(drCategory, 0);
            cboCategory.DataSource = dtCategory;
            cboCategory.DisplayMember = "name";
            cboCategory.ValueMember = "id";
            cboCategory.SelectedIndex = 0;

            dtProductData = productService.GetAllProduct();
            ShowProductData(dtProductData);

            dtProductData = categoryService.GetSubCategory(-1);
            ShowSubCategory(dtProductData);

        }

        /// <summary>
        /// The ShowSubCategory.
        /// </summary>
        /// <param name="dtSubCategory">The dtSubCategory<see cref="DataTable"/>.</param>
        private void ShowSubCategory(DataTable dtSubCategory)
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
        /// The ShowProductData.
        /// </summary>
        /// <param name="dtProduct">The dtProduct<see cref="DataTable"/>.</param>
        private void ShowProductData(DataTable dtProduct)
        {
            DataRow drProduct = dtProduct.NewRow(); //Create New Row
            drProduct["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                drProduct["product_name"] = "Select Product";
            }
            else
            {
                drProduct["product_name"] = "ကုန်ပစ္စည်းအမည်ကို ရွေးပါ";
                cboProduct.Font = new Font("Myanmar Text", 10);
            }
            dtProduct.Rows.InsertAt(drProduct, 0);
            cboProduct.DataSource = dtProduct;
            cboProduct.DisplayMember = "product_name";
            cboProduct.ValueMember = "id";
            cboProduct.SelectedIndex = 0;
        }

        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            pnlHeader.BackColor = Properties.Settings.Default.BackColor;
            btnAdd.BackColor = Properties.Settings.Default.BackColor;
            btnSubmit.BackColor = Properties.Settings.Default.BackColor;
            btnBack.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            dgvDamageLoss.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCDamageLoss()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCDamageLoss_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCDamageLoss_Load(object sender, EventArgs e)
        {
            UCDamageLoss uCDamageLoss = new UCDamageLoss();
            cboSupplier.SelectedIndexChanged -= cboSupplier_SelectedIndexChanged;
            cboCategory.SelectedIndexChanged -= cboCategory_SelectedIndexChanged;
            cboSubCategory.SelectedIndexChanged -= cboSubCategory_SelectedIndexChanged;
            GetHeaderSource();
            cboSupplier.SelectedIndexChanged += cboSupplier_SelectedIndexChanged;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            cboSubCategory.SelectedIndexChanged += cboSubCategory_SelectedIndexChanged;
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCDamageLoss);
            localization.ChangeDatagridText(dgvDamageLoss);
        }

        /// <summary>
        /// cboCategory_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtProductData = categoryService.GetSubCategory(Convert.ToInt32(cboCategory.SelectedValue));
            ShowSubCategory(dtProductData);
            dtProductData = productService.GetDamageLossProduct(Convert.ToInt32(cboSupplier.SelectedValue), Convert.ToInt32(cboCategory.SelectedValue), Convert.ToInt32(cboSubCategory.SelectedValue), Convert.ToInt32(cboProduct.SelectedValue));
            ShowProductData(dtProductData);
        }

        /// <summary>
        /// cboSubCategory_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtProductData = productService.GetDamageLossProduct(Convert.ToInt32(cboSupplier.SelectedValue), Convert.ToInt32(cboCategory.SelectedValue), Convert.ToInt32(cboSubCategory.SelectedValue), Convert.ToInt32(cboProduct.SelectedValue));
            ShowProductData(dtProductData);
        }

        /// <summary>
        /// btnAdd_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowDamageLossProduct();
        }

        /// <summary>
        /// The ShowDamageLossProduct.
        /// </summary>
        private void ShowDamageLossProduct()
        {
            int supplierId = Convert.ToInt32(cboSupplier.SelectedValue.ToString());
            int categoryId = Convert.ToInt32(cboCategory.SelectedValue.ToString());
            int subCategoryId = Convert.ToInt32(cboSubCategory.SelectedValue.ToString());
            int productId = Convert.ToInt32(cboProduct.SelectedValue.ToString());
            if(Validation())
            {
                dtDamageLoss = damageLossService.GetDamageLossProduct(supplierId, categoryId, subCategoryId, productId);
            }
            dgvDamageLoss.DataSource = dtDamageLoss;
            dgvDamageLoss.Columns["selling_price"].DefaultCellStyle.Format = Consts.ROUNDTO;
            ConfigureGrid();
            this.cboCategory.SelectedIndex = 0;
            this.cboProduct.SelectedIndex = 0;
            this.cboSupplier.SelectedIndex = 0;
            this.cboSubCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// The ConfigureGrid.
        /// </summary>
        private void ConfigureGrid()
        {
            if (dgvDamageLoss.Rows.Count > 3)
            {
                dgvDamageLoss.Columns["remark"].Width = 180;
            }
            else
            {
                dgvDamageLoss.Columns["remark"].Width = 200;
            }
        }

        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dtDamageLoss.Rows.Count > 0)
            {
                this.Validate();
                if (CheckValidation())
                {
                    SaveDamageLossInformation();
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
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0058, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0044, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// The CheckValidation.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool CheckValidation()
        {
            bool isValid = true;
            if (dgvDamageLoss.Rows.Count == 0)
            {
                isValid = false;
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0033, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0045, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
            else
            {
                for (int i = 0; i < (dgvDamageLoss.DataSource as DataTable).Rows.Count; i++)
                {
                    if (dgvDamageLoss.Rows[i].Cells["damageloss"].Value == null)
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {
                            MessageBox.Show(Messages.W0047, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0046, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        isValid = false;
                        break;
                    }
                    else if (dgvDamageLoss.Rows[i].Cells["dl_qty"].Value.ToString() == "" || dgvDamageLoss.Rows[i].Cells["dl_qty"].Value == null 
                        || dgvDamageLoss.Rows[i].Cells["dl_qty"].Value == DBNull.Value)
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {
                            MessageBox.Show(Messages.W0048, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0047, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                        isValid = false;
                        break;
                    }
                    else
                    {   if ((Convert.ToInt32(dgvDamageLoss.Rows[i].Cells["qty"].Value) < Convert.ToInt32(dgvDamageLoss.Rows[i].Cells["dl_qty"].Value)) 
                            || Convert.ToInt32(dgvDamageLoss.Rows[i].Cells["dl_qty"].Value) == 0)
                        {
                            if (DAO.Common.Consts.LANGUAGEID == 1)
                            {
                                MessageBox.Show(dtDamageLoss.Rows[0]["product_name"] + "(" + dtDamageLoss.Rows[0]["dl_qty"] + ")" + Messages.W0082, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(dtDamageLoss.Rows[0]["product_name"] + "(" + dtDamageLoss.Rows[0]["dl_qty"] + ")" + Messages.B0048, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            isValid = false;
                            break;
                        }
                    }
                }
            }
            return isValid;
        }

        /// <summary>
        /// Validation
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            if (cboSupplier.SelectedIndex == 0)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0093, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0012, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                return false;
            }
            if (cboProduct.SelectedIndex == 0)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0094, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0019, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                return false;
            }
            if (cboCategory.SelectedIndex == 0)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0084, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0014, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                return false;
            }
            return true;
        }

        /// <summary>
        /// The SaveDamageLossInformation.
        /// </summary>
        private void SaveDamageLossInformation()
        {
            this.Validate();
            DataTable dt = new DataTable();
            int stockId = 0;

            for (int i = 0; i < (dgvDamageLoss.DataSource as DataTable).Rows.Count; i++)
            {
                damageLossEntity.product_id = Convert.ToInt64(dgvDamageLoss.Rows[i].Cells["id"].Value);
                damageLossEntity.quantity = Convert.ToInt32(dgvDamageLoss.Rows[i].Cells["dl_qty"].Value);
                damageLossEntity.price = Convert.ToDecimal(dgvDamageLoss.Rows[i].Cells["selling_price"].Value);
                if (dgvDamageLoss.Rows[i].Cells["damageloss"].Value.Equals("Damage"))
                {
                    damageLossEntity.product_status = 1;
                }
                else
                {
                    damageLossEntity.product_status = 2;
                }
                damageLossEntity.damageloss_date = DateTime.Now;
                if (dgvDamageLoss.Rows[i].Cells["remark"].Value == null)
                {
                    damageLossEntity.remark = String.Empty;
                }
                else
                {
                    damageLossEntity.remark = dgvDamageLoss.Rows[i].Cells["remark"].Value.ToString();
                }
                damageLossEntity.is_deleted = 0;
                damageLossEntity.created_user_id = Convert.ToInt32(Consts.STAFFID);
                damageLossEntity.updated_user_id = Convert.ToInt32(Consts.STAFFID);
                damageLossEntity.created_datetime = DateTime.Now;
                damageLossEntity.updated_datetime = DateTime.Now;
                damageLossService.SaveDamageLossQuantity(damageLossEntity);
            }
        }

        /// <summary>
        /// btnBack_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UCDamageLossList ucDamageLossList = new UCDamageLossList();
            this.Controls.Add(ucDamageLossList);
        }

        /// <summary>
        /// The dtgDamageLoss_CellContentClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void dgvDamageLoss_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == dgvDamageLoss.Columns["delete"].Index)
            {
                DialogResult res = DialogResult.None;
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    res = MessageBox.Show(Messages.I0004, Messages.T0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    res = MessageBox.Show(Messages.B0042, Messages.F0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                if (res == DialogResult.OK)
                {
                    int rowIndex = dgvDamageLoss.CurrentCell.RowIndex;
                    dgvDamageLoss.Rows.RemoveAt(rowIndex);
                    ((DataTable)dgvDamageLoss.DataSource).AcceptChanges();
                    dgvDamageLoss.EndEdit(DataGridViewDataErrorContexts.Commit);
                    this.Validate();
                }
            }
        }

        /// <summary>
        /// The cboSupplier_SelectedIndexChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// dgvDamageLoss_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDamageLoss_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvDamageLoss.CurrentCell.Selected = false;
        }

        /// <summary>
        /// btnAddtoList_MouseHover.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// btnAddtoList_MouseLeave.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Clear.
        /// </summary>
        private void Clear()
        {
            int count = dgvDamageLoss.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                dgvDamageLoss.Rows.Remove(dgvDamageLoss.Rows[0]);
            }
            if(dgvDamageLoss.DataSource != null)
            {
                ((DataTable)dgvDamageLoss.DataSource).AcceptChanges();
            }
            this.cboCategory.SelectedIndex = 0;
            this.cboProduct.SelectedIndex = 0;
            this.cboSupplier.SelectedIndex = 0;
            this.cboSubCategory.SelectedIndex = 0;
        }
        #endregion
    }
}
