using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_Admin.Views.Stock;
using DAO.Common;
using Entities.Category;
using Entities.Product;
using Entities.Supplier;
using Entities.Stock;
using Services.Category;
using Services.Product;
using Services.Supplier;
using Services.Stock;
using POS_Admin.Utilities;
using Entities.Payment;
using Services.Payment;

namespace POS_Admin.Views.Stock
{
    public partial class UCStock : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the stockEntity.
        /// </summary>
        private StockEntity stockEntity = new StockEntity();

        /// <summary>
        /// Defines the stockDetailEntity.
        /// </summary>
        private StockDetailEntity stockDetailEntity = new StockDetailEntity();

        /// <summary>
        /// Defines the paymentEntity.
        /// </summary>
        private PaymentEntity paymentEntity = new PaymentEntity();

        /// <summary>
        /// Defines the supplierService.
        /// </summary>
        private SupplierService supplierService = new SupplierService();

        /// <summary>
        /// Defines the categoryService.
        /// </summary>
        private CategoryService categoryService = new CategoryService();

        /// <summary>
        /// Defines the productService.
        /// </summary>
        private ProductService productService = new ProductService();

        /// <summary>
        /// Defines the purchaseService.
        /// </summary>
        private StockService stockService = new StockService();

        /// <summary>
        /// Defines the paymentService.
        /// </summary>
        private PaymentService paymentService = new PaymentService();

        /// <summary>
        /// Defines the stockSaleEntity.
        /// </summary>
        private StockSaleEntity stockSaleEntity = new StockSaleEntity();

        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the purchaseDetailEntityList.
        /// </summary>
        private List<StockDetailEntity> stockDetailEntityList;


        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the DataTable.
        /// </summary>
        private DataTable dtProductData = new DataTable(),
                          dtTemp = new DataTable(),
                          dtSupplier = new DataTable(),
                          dtCategory = new DataTable();

        private int changeMFDate = 0,
                    changeExpiredDate = 0;

        //private string MFDate = null,
        //               ExpiredDate = null;

        /// <summary>
        /// Gets or sets the paymentDate.
        /// </summary>
        private DateTime paymentDate { get; set; }

        /// <summary>
        /// Gets or sets the MFDate.
        /// </summary>
        private DateTime? MFDate { get; set; }

        /// <summary>
        /// Gets or sets the ExpiredDate.
        /// </summary>
        private DateTime? ExpiredDate { get; set; }

        /// <summary>
        /// Gets or sets the startDate.
        /// </summary>
        private DateTime? startDate { get; set; }

        /// <summary>
        /// Gets or sets the endDate.
        /// </summary>
        private DateTime? endDate { get; set; }

        /// <summary>
        /// Gets or sets the purchaseDate.
        /// </summary>
        private DateTime? purchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the dueDate.
        /// </summary>
        private DateTime? dueDate { get; set; }

        /// <summary>
        /// detailIdList
        /// </summary>
        private List<string> lstDetailId=new List<string>();

        /// <summary>
        /// oldDetailIdList
        /// </summary>
        public List<string> lstOldDetailId = new List<string>();

        /// <summary>
        /// Defines the dtPurchaseDetailList
        /// </summary>
        private DataTable dtPurchaseDetailList = new DataTable();
        #endregion

        #region==========Bind ComboData==========
        /// <summary>
        /// The BindCombo.
        /// </summary>
        private void BindcboPayment()
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
        /// <summary>
        /// BindData
        /// </summary>
        private void BindData()
        {
            BindcboPayment();
            dtSupplier = supplierService.GetSupplierList();
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
            dtProductData = categoryService.GetCategory(-1);
            ShowCategory(dtProductData);
            dtProductData = categoryService.GetSubCategory(-1);
            ShowSubCategory(dtProductData);
            dtProductData = productService.GetProduct(-1, -1);
            ShowProductData(dtProductData);
            this.dtpPurchaseDate.Value = DateTime.Now;
            this.dtpPaymentDate.Value = DateTime.Now;
            this.dtpPurchaseDate.CustomFormat = Consts.DATEFORMAT;
            this.dtpPaymentDate.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// ShowCategory
        /// </summary>
        /// <param name="dtCategory"></param>
        private void ShowCategory(DataTable dtCategory)
        {
            DataRow dr = dtCategory.NewRow(); //Create New Row
            dr["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                dr["name"] = "Select Category Name";
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
        /// ShowSubCategory
        /// </summary>
        /// <param name="dtSubCategory"></param>
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
        /// ShowProductData
        /// </summary>
        /// <param name="dtProduct"></param>
        private void ShowProductData(DataTable dtProduct)
        {
            DataRow dr = dtProductData.NewRow(); //Create New Row
            dr["id"] = "0";
            if (Consts.LANGUAGEID == 1)
            {
                dr["product_name"] = "Select Product";
            }
            else
            {
                dr["product_name"] = "ကုန်ပစ္စည်းအမည်ကို ရွေးပါ";
                cboProduct.Font = new Font("Myanmar Text", 10);
            }
            dtProductData.Rows.InsertAt(dr, 0);
            cboProduct.DataSource = dtProductData;
            cboProduct.DisplayMember = "product_name";
            cboProduct.ValueMember = "id";
        }
        #endregion

        #region==========Fill Data==========

        /// <summary>
        /// CalculateTotalAmount
        /// </summary>
        private void CalculateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow dr in dgvStock.Rows)
            {
                string detailId = dr.Cells["id"].Value.ToString();
                stockDetailEntity.purchase_price = Convert.ToDecimal(dr.Cells["purchase_price"].Value);
                stockDetailEntity.purchase_quantity = Convert.ToInt32(dr.Cells["purchase_qty"].Value);
                int qty = Convert.ToInt32(dr.Cells["purchase_qty"].Value);
                decimal price = Convert.ToDecimal(dr.Cells["purchase_price"].Value);
                decimal multiplyAmount = qty * price;          
                totalAmount += multiplyAmount;            
            }

            txtTotalAmount.Text = totalAmount.ToString();
        }
        /// <summary>
        /// CreateStock
        /// </summary>
        private void CreateStock()
        {
            DateTime? date = null;
            stockEntity = new StockEntity();
            stockEntity.purchase_date = this.dtpPurchaseDate.Value;
            stockEntity.total_amount = Convert.ToInt32(this.txtTotalAmount.Text);
            stockEntity.payment_due_date = dtpPaymentDueDate.Text == " " ? date : Convert.ToDateTime(dtpPaymentDueDate.Value.ToString());    
            stockEntity.remark = this.txtRemark.Text;
            stockEntity.is_deleted = 0;
            stockEntity.updated_user_id = 1;
            stockEntity.updated_datetime = DateTime.Now;
            if (stockId.Text != "")
            {
                stockEntity.id = Convert.ToInt16(stockId.Text);
                stockService.UpdateStock(stockEntity);
            }
            else
            {
                stockEntity.created_user_id = 1;
                stockEntity.created_datetime = DateTime.Now;
                stockService.InsertStock(stockEntity);
            }            
        }

        /// <summary>
        /// CreateStockDetail
        /// </summary>
        private void CreateStockDetail()
        {
            DateTime? date = null;
            int stock_id;
            stockDetailEntityList = new List<StockDetailEntity>();
            stockDetailEntity = new StockDetailEntity();
            if (stockId.Text == "")
            {
                stock_id = stockService.GetLastId();
            }
            else
            {
                stock_id = Convert.ToInt16(stockId.Text);
            }
            foreach (DataGridViewRow dr in dgvStock.Rows)
            {
                string detailId= dr.Cells["id"].Value.ToString();
                string oldQty = dr.Cells["old_purchase_qty"].Value.ToString();
                stockDetailEntity.stock_id = stock_id;
                stockDetailEntity.product_id = Convert.ToInt32(dr.Cells["product_id"].Value);
                stockDetailEntity.purchase_price = Convert.ToDecimal(dr.Cells["purchase_price"].Value);
                stockDetailEntity.purchase_quantity = Convert.ToInt32(dr.Cells["purchase_qty"].Value);
                stockDetailEntity.selling_price = Convert.ToDecimal(dr.Cells["selling_price"].Value);
                stockDetailEntity.is_active = Convert.ToInt16(dr.Cells["is_active"].Value);
                stockDetailEntity.is_deleted = 0;

                stockDetailEntity.updated_user_id = 1;
                stockDetailEntity.updated_datetime = DateTime.Now;
                stockDetailEntity.remark = Convert.ToString(dr.Cells["remark"].Value);
                string newQty = stockDetailEntity.purchase_quantity.ToString();
                if (dr.Cells["mfd_date"].Value == null)
                {
                    stockDetailEntity.mfd_date = date;

                }
                else
                {
                    stockDetailEntity.mfd_date = dr.Cells["mfd_date"].Value.ToString() == "" ? date : Convert.ToDateTime(dr.Cells["mfd_date"].Value);

                }
                if (dr.Cells["expire_date"].Value == null)
                {
                    stockDetailEntity.expired_date = date;

                }
                else
                {
                    stockDetailEntity.expired_date = dr.Cells["expire_date"].Value.ToString() == "" ? date : Convert.ToDateTime(dr.Cells["expire_date"].Value);
                }
                if (string.IsNullOrEmpty(detailId))
                {
                    //insert
                    //stockDetailEntity.mfd_date = changeMFDate == 0 ? date : Convert.ToDateTime(dr.Cells["mfd_date"].Value);
                    //stockDetailEntity.expired_date = changeExpiredDate == 0 ? date : Convert.ToDateTime(dr.Cells["expire_date"].Value);
                    stockDetailEntity.created_user_id = 1;
                    stockDetailEntity.created_datetime = DateTime.Now;
                    stockService.Insert(stockDetailEntity);
                }
                else
                {
                    lstDetailId.Add(detailId);
                    //update
                    //if (dr.Cells["mfd_date"].Value == null)
                    //{
                    //    stockDetailEntity.mfd_date = date;

                    //}
                    //else
                    //{
                    //    stockDetailEntity.mfd_date = dr.Cells["mfd_date"].Value.ToString() == "" ? date : Convert.ToDateTime(dr.Cells["mfd_date"].Value);

                    //}
                    //if (dr.Cells["expire_date"].Value == null)
                    //{
                    //    stockDetailEntity.expired_date = date;

                    //}
                    //else
                    //{
                    //    stockDetailEntity.expired_date = dr.Cells["expire_date"].Value.ToString() == "" ? date : Convert.ToDateTime(dr.Cells["expire_date"].Value);
                    //}
                    stockDetailEntity.id = Convert.ToInt16(detailId);
                    stockService.Update(stockDetailEntity);
                }
                // insert or update in t_stock_sale
                if (stockDetailEntity.is_active == 0)
                {
                    stockSaleEntity.product_id = stockDetailEntity.product_id;
                    stockSaleEntity.quantity = stockDetailEntity.purchase_quantity;
                    stockSaleEntity.selling_price = stockDetailEntity.selling_price;

                    if (dr.Cells["expire_date"].Value == null)
                    {
                        stockSaleEntity.expired_date = date;

                    }
                    else
                    {
                        stockSaleEntity.expired_date = dr.Cells["expire_date"].Value.ToString() == "" ? date : Convert.ToDateTime(dr.Cells["expire_date"].Value);
                    }
                    stockSaleEntity.is_active = 0;
                    var count = stockService.GetProductExist(stockDetailEntity.product_id);
                    if (count > 0)
                    {
                       
                        // update qty in t_stock_sale table
                        if (stockDetailEntity.is_active == 0)
                        {
                            if (newQty != oldQty)
                            {
                                if (Consts.CHKACTIVE != stockDetailEntity.is_active)
                                {
                                    stockDetailEntity.purchase_quantity = stockDetailEntity.purchase_quantity;
                                }
                                else
                                {
                                    stockDetailEntity.purchase_quantity = stockDetailEntity.purchase_quantity - Convert.ToInt32(oldQty == "" ? "0" : oldQty);
                                }
                            }
                            else
                            {
                                if (Consts.CHKACTIVE != stockDetailEntity.is_active)
                                {
                                    stockDetailEntity.purchase_quantity = stockDetailEntity.purchase_quantity;
                                }
                                else
                                {
                                    stockDetailEntity.purchase_quantity = 0;
                                }
                            }
                            stockSaleEntity.product_id = stockDetailEntity.product_id;
                            stockSaleEntity.quantity = stockDetailEntity.purchase_quantity;
                            stockSaleEntity.selling_price = stockDetailEntity.selling_price;
                            stockSaleEntity.expired_date = stockDetailEntity.expired_date;
                           // purchaseDetailService.UpdateSaleStockQty(stockSaleEntity);
                        }
                        else
                        {
                            stockSaleEntity.product_id = stockDetailEntity.product_id;
                            stockDetailEntity.purchase_quantity = -stockDetailEntity.purchase_quantity;
                            stockSaleEntity.quantity = stockDetailEntity.purchase_quantity;
                            stockSaleEntity.selling_price = stockDetailEntity.selling_price;
                            stockSaleEntity.expired_date = dtpExpiredDate.Value;
                           // purchaseDetailService.UpdateSaleStockQty(stockSaleEntity);
                        }
                        stockService.UpdateStockSale(stockSaleEntity);
                    }
                    else
                    {
                        stockService.InsertStockSale(stockSaleEntity);
                    }
                }

            }

            if (stockId.Text == "")
            {
                MessageBox.Show(POS_Admin.Properties.Messages.I0001, POS_Admin.Properties.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(POS_Admin.Properties.Messages.I0002, POS_Admin.Properties.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /// <summary>
        /// CreatePayment
        /// </summary>
        private void CreatePayment()
        {
            paymentEntity = new PaymentEntity();
            int purchase_id;
            int oldTotalAmount = Convert.ToInt32(this.txtOldTotalAmount.Text == "" ? "0":this.txtOldTotalAmount.Text) ;
            int newTotalAmount = Convert.ToInt32(this.txtTotalAmount.Text);

            if (stockId.Text == "")
            {
                purchase_id = stockService.GetLastId();
            }
            else
            {
                purchase_id = Convert.ToInt32(stockId.Text);
            }
            paymentEntity.stock_id = purchase_id;
            paymentEntity.sale_id = null;
            paymentEntity.paid_amount =Convert.ToInt32(this.txtPaidAmount.Text);
            paymentEntity.payment_type =Convert.ToInt32(cboPaymentType.SelectedValue);
            paymentDate= this.dtpPaymentDate.Value;
            paymentEntity.payment_date = paymentDate;


            paymentEntity.is_active = 0;
            paymentEntity.remark = this.txtRemark.Text;

            paymentEntity.updated_user_id = 1;
            paymentEntity.updated_datetime = DateTime.Now;

            //update condition
            if (stockId.Text != "")
            {
                paymentEntity.id = Convert.ToInt16(txtPaymentId.Text);
                if (newTotalAmount == oldTotalAmount)
                {                    
                    paymentService.Update(paymentEntity);
                }
                else
                {
                    paymentService.UpdateStockIsActive(purchase_id);
                    paymentEntity.created_user_id = 1;
                    paymentEntity.created_datetime = DateTime.Now;
                    paymentService.Insert(paymentEntity);
                }
            }
            else
            {
                paymentEntity.created_user_id = 1;
                paymentEntity.created_datetime = DateTime.Now;
                paymentService.Insert(paymentEntity);
            }
        }

        /// <summary>
        /// UpdateIsDeleteStatus
        /// </summary>
        /// <param name="stockId"></param>
        private void UpdateIsDeleteStatus(int stockId)
        {
            stockService.UpdateIsDelete(stockId, lstDetailId,lstOldDetailId);
        }

        /// <summary>
        /// Update qty in t_stock_sale where is_delete 1
        /// </summary>
        /// <param name="stockId"></param>
        private void UpdateQty(int stockId)
        {
            DataTable dtDeleteQty = new DataTable();

            if (dtPurchaseDetailList.Rows.Count > 0)
            {
                for (int i = 0; i < dtPurchaseDetailList.Rows.Count; i++)
                {
                    string detailId = dtPurchaseDetailList.Rows[i]["id"].ToString();
                    lstDetailId.Add(detailId);
                }
            }
            dtDeleteQty = stockService.GetProductIdWithTotalQty(lstDetailId, stockId, 1);
            if (dtDeleteQty.Rows.Count > 0)
            {
                for (int i = 0; i < dtDeleteQty.Rows.Count; i++)
                {
                    int productId = Convert.ToInt32(dtDeleteQty.Rows[i]["product_id"].ToString());
                    int totalQty = Convert.ToInt32(dtDeleteQty.Rows[i]["total"].ToString());
                    stockService.SubstractStockQty(productId, totalQty);
                }
            }
        }
        /// <summary>
        /// CreateStock
        /// </summary>
        //private void CreateStock()
        //{
        //    DateTime? date = null;
        //    stockEntityList = new List<StockEntity>();
        //    stockEntity = new StockEntity();
        //    foreach (DataGridViewRow dr in dgvStock.Rows)
        //    {
        //        stockEntity.product_id = Convert.ToInt32(dr.Cells["product_id"].Value);
        //        stockEntity.purchase_price = Convert.ToDecimal(dr.Cells["purchase_price"].Value);
        //        stockEntity.purchase_quantity = Convert.ToInt32(dr.Cells["purchase_qty"].Value);
        //        stockEntity.selling_price = Convert.ToDecimal(dr.Cells["selling_price"].Value);
        //        stockEntity.mfd_date = changeMFDate == 0 ? date : Convert.ToDateTime(dr.Cells["mfd_date"].Value);
        //        stockEntity.expired_date = changeExpiredDate == 0 ? date : Convert.ToDateTime(dr.Cells["expire_date"].Value);
        //        stockEntity.is_active = Convert.ToInt16(dr.Cells["is_active"].Value);
        //        stockEntity.is_deleted = 0;
        //        stockEntity.created_user_id = 1;
        //        stockEntity.created_datetime = DateTime.Now;
        //        stockEntity.updated_user_id = 1;
        //        stockEntity.updated_datetime = DateTime.Now;
        //        stockEntity.remark = Convert.ToString(dr.Cells["remark"].Value);
        //        stockService.Insert(stockEntity);
        //        if (stockEntity.is_active == 0)
        //        {
        //            stockSaleEntity.product_id = stockEntity.product_id;
        //            stockSaleEntity.quantity = stockEntity.purchase_quantity;
        //            stockSaleEntity.selling_price = stockEntity.selling_price;
        //            //stockSaleEntity.expired_date = dtpExpiredDate.Value.Date;
        //            stockSaleEntity.expired_date = changeExpiredDate == 0 ? date : Convert.ToDateTime(dr.Cells["expire_date"].Value);
        //            stockSaleEntity.is_active = 0;
        //            var count = stockService.GetProductExist(stockEntity.product_id);
        //            if (count > 0)
        //            {
        //                stockService.UpdateStockSale(stockSaleEntity);
        //            }
        //            else
        //            {
        //                stockService.InsertStockSale(stockSaleEntity);
        //            }
        //        }
        //    }
        //    MessageBox.Show(POS_Admin.Properties.Messages.I0001, POS_Admin.Properties.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        #endregion

        #region==========Data Clear==========
        /// <summary>
        /// Clear Data
        /// </summary>
        private void Clear()
        {
            UCStockList uc = new UCStockList();
            this.Controls.Clear();
            this.Controls.Add(uc);
        }
        #endregion

        #region==========Validation==========
        /// <summary>
        /// The Validation.
        /// </summary>
        /// <returns></returns>
        private Boolean Validation()
        {
            try
            {                
                if (((stockId.Text=="" && dgvStock.Rows.Count>0 && this.rowId.Text=="") || (stockId.Text!="")) && cboSupplier.SelectedIndex != 0)
                {
                    //check supplier id
                    string supplierId = Convert.ToString(cboSupplier.SelectedValue);
                    string dgvSupplierId = dgvStock.Rows[0].Cells["supplier_id"].Value.ToString();
                    if (!supplierId.Equals(dgvSupplierId))
                    {
                        MessageBox.Show("Please choose same supplier.", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                
                if (changeMFDate == 1)
                {
                    MFDate = dtpMFDate.Value;// Convert.ToString(dtpMFDate.Value);
                    startDate = dtpMFDate.Value;
                }
                if (changeExpiredDate == 1)
                {
                    ExpiredDate = dtpExpiredDate.Value;///Convert.ToString(dtpExpiredDate.Value);
                    endDate = dtpExpiredDate.Value;
                }
                if (cboSupplier.SelectedIndex == 0 || string.IsNullOrEmpty(cboSupplier.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0093, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0012, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cboSupplier.Focus();
                    return false;
                }
                if (cboCategory.SelectedIndex == 0 || string.IsNullOrEmpty(cboCategory.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0084, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0014, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cboCategory.Focus();
                    return false;
                }
                if (cboProduct.SelectedIndex == 0 || string.IsNullOrEmpty(cboProduct.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0094, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0019, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cboProduct.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtQuantity.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0057, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0020, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtQuantity.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtPurchasePrice.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W00106, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0069, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtPurchasePrice.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtSellingPrice.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0061, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0022, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtSellingPrice.Focus();
                    return false;
                }
                if (!startDate.Equals(null) && !endDate.Equals(null))
                {
                    if (startDate >= endDate)
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {

                            MessageBox.Show(DAO.Common.Messages.W0020, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0035, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        return false;
                    }
                }
                if (dtpPurchaseDate.Value > DateTime.Now)
                {
                    if (Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0116, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0100, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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

        /// <summary>
        /// PaymentValidation.
        /// </summary>
        /// <returns></returns>
        private Boolean PaymentValidation()
        {
            try
            {
                DateTime? date = null;
                purchaseDate = dtpPurchaseDate.Value;
                paymentDate = dtpPaymentDate.Value;
                DateTime purchaseDateTime= dtpPurchaseDate.Value;
                int compare = DateTime.Compare(purchaseDateTime, paymentDate);
                string strDueDate = dtpPaymentDueDate.Text.Trim();
                dueDate =strDueDate==""?date:Convert.ToDateTime(strDueDate);
                if (dtpPaymentDate.Value.Equals(null))
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
                if (dtpPaymentDate.Value > DateTime.Now)
                {
                    if (Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0115, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0099, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return false;
                }
                //if payment date is less than purchase date
                if (compare>0)
                {
                    if (Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0117, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0101, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return false;
                }
                if (cboPaymentType.SelectedIndex == 0)
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
                if (string.IsNullOrEmpty(txtPaidAmount.Text.Trim()))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W00109, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0085, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtPaidAmount.Focus();
                    return false;
                }
                if(Convert.ToInt32(txtPaidAmount.Text) == Convert.ToInt32(txtTotalAmount.Text))
                {
                    return true;
                }
                if (Convert.ToInt32(txtPaidAmount.Text) > Convert.ToInt32(txtTotalAmount.Text))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W00108, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0083, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtPaidAmount.Focus();
                    return false;
                }
                else if(Convert.ToInt32(txtPaidAmount.Text) < Convert.ToInt32(txtTotalAmount.Text) && dueDate.Equals(null))
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0113, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0087, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    dtpPaymentDueDate.Focus();
                    return false;
                }

                if (!dueDate.Equals(null))
                {
                    if (purchaseDate > dueDate)
                    {
                        if (DAO.Common.Consts.LANGUAGEID == 1)
                        {

                            MessageBox.Show(DAO.Common.Messages.W0114, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(Messages.B0093, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        return false;
                    }
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

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            pnlHeader.BackColor = Properties.Settings.Default.BackColor;
            btnAdd.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
            btnSubmit.BackColor = Properties.Settings.Default.BackColor;
            btnBack.BackColor = Properties.Settings.Default.BackColor;
            dgvStock.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCStock()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion    

        #region==========Design Generated Code==========  
        /// <summary>
        /// UCStock_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCStock_Load(object sender, EventArgs e)
        {
            UCStock uCStock = new UCStock();
            chkActive.Checked = true;
            cboSupplier.SelectedIndexChanged -= cboSupplier_SelectedIndexChanged;
            cboCategory.SelectedIndexChanged -= cboCategory_SelectedIndexChanged;
            cboSubCategory.SelectedIndexChanged -= cboSubCategory_SelectedIndexChanged;
            txtRemark.KeyPress += TextBox_KeyPress;
            txtPurchasePrice.KeyPress += TextBox_KeyPress;
            txtQuantity.KeyPress += TextBox_KeyPress;
            txtPaidAmount.KeyPress += TextBox_KeyPress;
            txtRemark.TextChanged += txtRemark_TextChanged;
            this.BindData();
            cboSupplier.SelectedIndexChanged += cboSupplier_SelectedIndexChanged;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            cboSubCategory.SelectedIndexChanged += cboSubCategory_SelectedIndexChanged;
            txtRemark.KeyPress -= TextBox_KeyPress;
            txtPurchasePrice.KeyPress -= TextBox_KeyPress;
            txtQuantity.KeyPress -= TextBox_KeyPress;
            txtPaidAmount.KeyPress -= TextBox_KeyPress;
            txtSellingPrice.KeyPress -= TextBox_KeyPress;
            txtRemark.TextChanged -= txtRemark_TextChanged;
            localization.UCChangeLanguageText(Consts.LANGUAGEID, this, uCStock);
            localization.ChangeDatagridText(dgvStock);
            txtTotalAmount.Text = "0";

        }

        /// <summary>
        /// The TextBox_KeyPress.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/>.</param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && !string.Equals(txtbox.Name, cboSupplier.Name) && !string.Equals(txtbox.Name, cboCategory.Name) && !string.Equals(txtbox.Name, cboProduct.Name) && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, dtpMFDate.Name) && !string.Equals(txtbox.Name, dtpExpiredDate.Name))
            {
                e.Handled = true;         //Just Digits
            }
            else if ((txtbox.Text.Length >= txtQuantity.MaxLength) && !string.Equals(txtbox.Name, txtPurchasePrice.Name) && !string.Equals(txtbox.Name, txtSellingPrice.Name) && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, txtPaidAmount.Name))
            {
                MessageBox.Show(Messages.W0068 + txtQuantity.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtPurchasePrice.MaxLength) && !string.Equals(txtbox.Name, txtQuantity.Name) && !string.Equals(txtbox.Name, txtSellingPrice.Name) && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, txtPaidAmount.Name))
            {
                MessageBox.Show(Messages.W0068 + txtPurchasePrice.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtSellingPrice.MaxLength) && !string.Equals(txtbox.Name, txtQuantity.Name) && !string.Equals(txtbox.Name, txtPurchasePrice.Name) && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, txtPaidAmount.Name))
            {
                MessageBox.Show(Messages.W0068 + txtSellingPrice.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtPaidAmount.MaxLength) && !string.Equals(txtbox.Name, txtQuantity.Name) && !string.Equals(txtbox.Name, txtSellingPrice.Name) && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, txtPurchasePrice.Name))
            {
                MessageBox.Show(Messages.W0068 + txtPaidAmount.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            else if ((txtbox.Text.Length >= txtRemark.MaxLength) && !string.Equals(txtbox.Name, txtQuantity.Name) && !string.Equals(txtbox.Name, txtPurchasePrice.Name) && !string.Equals(txtbox.Name, txtSellingPrice.Name) && !string.Equals(txtbox.Name, txtPaidAmount.Name))
            {
                MessageBox.Show(Messages.W0068 + txtRemark.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            if (e.KeyChar == (char)8)
                e.Handled = false;   //Allow Backspace
        }

        /// <summary>
        /// cboSupplier_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            var supplierId = Convert.ToInt32(cboSupplier.SelectedValue);
            dtProductData = categoryService.GetCategory(supplierId);
            this.ShowCategory(dtProductData);
        }

        /// <summary>
        /// cboCategory_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtProductData = categoryService.GetSubCategory(Convert.ToInt32(cboCategory.SelectedValue));
            this.ShowSubCategory(dtProductData);
        }

        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //update state
            if (stockId.Text != "")
            {               
                if (dgvStock.Rows.Count == 0)
                {
                    //set is_delete to 1 in purchase table , when there is no purchase detail
                    stockService.DeleteStock(Convert.ToInt32(stockId.Text));
                    paymentService.DeleteByStockId(Convert.ToInt32(stockId.Text));
                    MessageBox.Show(POS_Admin.Properties.Messages.I0002, POS_Admin.Properties.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Clear();
                }
            }
            //insert state
            else
            {          
                if (dgvStock.Rows.Count == 0)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show("Please add purchase detail.", POS_Admin.Properties.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ကျေးဇူးပြု၍၀ယ်ယူမှုအသေးစိတ်ကိုထည့်ပါ။", POS_Admin.Properties.Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
            }
            if (dgvStock.Rows.Count > 0)
            {
                if (PaymentValidation())
                {
                    this.dtpPaymentDate.CustomFormat = Consts.DATEFORMAT;
                    this.dtpPurchaseDate.CustomFormat = Consts.DATEFORMAT;
                    this.CreateStock();
                    this.CreateStockDetail();
                    this.CreatePayment();
                    if (stockId.Text != "")
                    {
                        dtPurchaseDetailList = new DataTable();
                        dtPurchaseDetailList = stockService.GetStockDetailListById(Convert.ToInt32(stockId.Text));
                        UpdateIsDeleteStatus(Convert.ToInt32(stockId.Text));
                        UpdateQty(Convert.ToInt32(stockId.Text));
                    }
                    this.Clear();
                }     
                
            }
        
        }

        /// <summary>
        /// dgvSupplier_CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      
        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MFdate = Convert.ToString(dgvStock.Rows[e.RowIndex].Cells["mfd_date"].Value);
            string ExpiredDate = Convert.ToString(dgvStock.Rows[e.RowIndex].Cells["expire_date"].Value);
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dgvStock.Columns["edit"].Index)
                {
                    this.txtDetailId.Text = dgvStock.Rows[e.RowIndex].Cells["id"].Value!=null?dgvStock.Rows[e.RowIndex].Cells["id"].Value.ToString():"";
                    this.txtOldQty.Text = dgvStock.Rows[e.RowIndex].Cells["old_purchase_qty"].Value.ToString();
                    this.rowId.Text = Convert.ToString(e.RowIndex);
                    this.cboSupplier.Text = dgvStock.Rows[e.RowIndex].Cells["supplier_name"].Value.ToString();
                    this.cboSupplier.SelectedValue = dgvStock.Rows[e.RowIndex].Cells["supplier_id"].Value.ToString();
                    this.cboCategory.Text = dgvStock.Rows[e.RowIndex].Cells["category_name"].Value.ToString();
                    this.cboCategory.SelectedValue = dgvStock.Rows[e.RowIndex].Cells["category_id"].Value.ToString();
                    this.cboSubCategory.Text = dgvStock.Rows[e.RowIndex].Cells["sub_category_name"].Value.ToString();
                    this.cboSubCategory.SelectedValue = dgvStock.Rows[e.RowIndex].Cells["sub_category_id"].Value.ToString();
                    this.cboProduct.Text = dgvStock.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                    this.cboProduct.SelectedValue = dgvStock.Rows[e.RowIndex].Cells["product_id"].Value.ToString();
                    this.txtQuantity.Text = dgvStock.Rows[e.RowIndex].Cells["purchase_qty"].Value.ToString();
                    this.txtPurchasePrice.Text = dgvStock.Rows[e.RowIndex].Cells["purchase_price"].Value.ToString();
                    if (MFdate == "")
                    {
                        this.dtpMFDate.CustomFormat = " ";
                    }
                    else
                    {
                        this.dtpMFDate.Value = Convert.ToDateTime(dgvStock.Rows[e.RowIndex].Cells["mfd_date"].Value.ToString());
                        this.dtpMFDate.CustomFormat = this.dtpMFDate.Value.ToString("yyyy-MM-dd");
                    }
                    if (ExpiredDate == "")
                    {
                        this.dtpExpiredDate.CustomFormat = " ";
                    }
                    else
                    {
                        this.dtpExpiredDate.Value = Convert.ToDateTime(dgvStock.Rows[e.RowIndex].Cells["expire_date"].Value.ToString());
                        this.dtpExpiredDate.CustomFormat = this.dtpExpiredDate.Value.ToString("yyyy-MM-dd");
                    }
                    this.txtSellingPrice.Text = dgvStock.Rows[e.RowIndex].Cells["selling_price"].Value.ToString();
                    this.txtRemark.Text = dgvStock.Rows[e.RowIndex].Cells["remark"].Value.ToString();
                    
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {

                        btnAdd.Text = "Update";
                    }
                    else
                    {
                        btnAdd.Text = "ပြင်ဆင်ပါ";
                    }
                }
                if (e.ColumnIndex == dgvStock.Columns["delete"].Index)
                {
                    DialogResult res = DialogResult.None;
                    res = MessageBox.Show(POS_Admin.Properties.Messages.I0004, POS_Admin.Properties.Messages.T0001, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        dgvStock.Rows.RemoveAt(e.RowIndex);
                    }                   
                    
                }
            }
        }

        /// <summary>
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            cboSupplier.SelectedIndex = 0;
            cboCategory.SelectedIndex = 0;
            cboSubCategory.SelectedIndex = 0;
            cboProduct.SelectedIndex = 0;
            txtQuantity.Text = "";
            txtPurchasePrice.Text = "";
            dtpMFDate.CustomFormat = " ";
            dtpExpiredDate.CustomFormat = " ";
            txtSellingPrice.Text = "";
            txtRemark.Text = "";
            //btnAdd.Text = "Add";
            chkActive.Checked = true;
            dtpPurchaseDate.CustomFormat = DateTime.Now.ToString("yyyy-MM-dd");
            dtpPaymentDate.CustomFormat = DateTime.Now.ToString("yyyy-MM-dd");
            txtDetailId.Text = "";
            txtOldQty.Text = "";
            changeMFDate = 0;
            MFDate = null;
            changeExpiredDate = 0;
            ExpiredDate = null;
            rowId.Text = "";
        }

        /// <summary>
        /// cboSubCategory_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int supplier_id = 0;
            if (cboSupplier.SelectedIndex > 0)
            {
                supplier_id = Convert.ToInt32(cboSupplier.SelectedValue);
            }
            dtProductData = productService.GetProduct(Convert.ToInt32(cboCategory.SelectedValue), Convert.ToInt32(cboSubCategory.SelectedValue), supplier_id);
            this.ShowProductData(dtProductData);
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

        private void txtSellingPrice_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// dgvStock_CellMouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStock_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int currentColumn = e.ColumnIndex;
                if (dgvStock.Columns[currentColumn].ReadOnly == true)
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
        /// dgvStock_CellFormatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvStock.CurrentCell.Selected = false;
        }

        private void dtpPurchaseDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpPurchaseDate.CustomFormat = Consts.DATEFORMAT;
        }
        private void dtpPaymentDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpPaymentDate.CustomFormat = Consts.DATEFORMAT;
        }
        private void dtpPaymentDueDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpPaymentDueDate.CustomFormat = Consts.DATEFORMAT;
        }
        private void dgvStock_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotalAmount();
        }

        private void dgvStock_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateTotalAmount();
        }



        /// <summary>
        /// txtRemark_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRemark_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (txtbox.Text.Length > txtRemark.MaxLength)
            {
                MessageBox.Show(Messages.W0068 + txtRemark.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// dtpMFDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpMFDate_ValueChanged(object sender, EventArgs e)
        {
            changeMFDate = 1;
            this.dtpMFDate.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// dtpExpiredDate_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpExpiredDate_ValueChanged(object sender, EventArgs e)
        {
            changeExpiredDate = 1;
            this.dtpExpiredDate.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// btnAdd_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                string supplier = Convert.ToString(cboSupplier.Text);
                string supplierId = Convert.ToString(cboSupplier.SelectedValue);
                string product = Convert.ToString(cboProduct.Text);
                string productId = Convert.ToString(cboProduct.SelectedValue);
                string qty = txtQuantity.Text;
                string oldQty = txtOldQty.Text;
                string purchase_price = txtPurchasePrice.Text;
                string selling_price = txtSellingPrice.Text;
                string is_active = Convert.ToString(0);
                string category = Convert.ToString(cboCategory.Text);
                string categoryId = Convert.ToString(cboCategory.SelectedValue);
                string subCategory = Convert.ToString(cboSubCategory.Text);
                string subCategoryId = Convert.ToString(cboSubCategory.SelectedValue);
                if (chkActive.Checked)
                {
                    is_active = Convert.ToString(0);
                }
                else
                {
                    is_active = Convert.ToString(1);
                }
                string remark = txtRemark.Text;
                if (btnAdd.Text == "Add" || btnAdd.Text == "ထည့်ပါ")
                {
                    string[] row = { "",supplier, product, qty, oldQty, selling_price, purchase_price, remark, supplierId, productId, MFDate.ToString(), ExpiredDate.ToString(), is_active, categoryId, category, subCategoryId, subCategory };
                    dgvStock.Rows.Add(row);
                }
                else
                {
                    dgvStock.Rows.RemoveAt(Convert.ToInt16(this.rowId.Text));
                    string[] row = { txtDetailId.Text, supplier, product, qty, oldQty, selling_price, purchase_price, remark, supplierId, productId, MFDate.ToString(), ExpiredDate.ToString(), is_active, categoryId, category, subCategoryId, subCategory };
                    dgvStock.Rows.Add(row);
                    btnAdd.Text = "Add";
                }
                btnClear_Click(sender, e);
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
            UCStockList ucStockList = new UCStockList();
            this.Controls.Add(ucStockList);
        }
        #endregion
    }
}
