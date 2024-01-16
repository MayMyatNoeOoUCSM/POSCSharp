using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using DAO.Common;
using DAO.Stock;
using Entities.Stock;
using System.Data;

namespace DAO.Stock
{
    public class PurchaseDetailDao
    {
        /// <summary>
        /// Defines the Database Connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        public void Insert(PurchaseDetailEntity purchaseDetailEntity)
        {
            strSql = "insert into t_purchase_detail (purchase_id,product_id, purchase_price, purchase_quantity, selling_price," +
                     " mfd_date, expired_date, is_active, is_deleted,created_user_id, updated_user_id, created_datetime, updated_datetime, remark) " +
                     "VALUES(@purchase_id,@product_id, @purchase_price, @purchase_quantity, @selling_price," +
                     "@mfd_date, @expired_date, @is_active, @is_deleted, @created_user_id, @updated_user_id, @created_datetime, @updated_datetime, @remark);";
            SQLiteParameter[] SqliteParams = {
                                               new SQLiteParameter("@purchase_id", purchaseDetailEntity.purchase_id),
                                               new SQLiteParameter("@product_id", purchaseDetailEntity.product_id),
                                               new SQLiteParameter("@purchase_price", purchaseDetailEntity.purchase_price),
                                               new SQLiteParameter("@purchase_quantity", purchaseDetailEntity.purchase_quantity),
                                               new SQLiteParameter("@selling_price", purchaseDetailEntity.selling_price),
                                               new SQLiteParameter("@mfd_date", purchaseDetailEntity.mfd_date),
                                               new SQLiteParameter("@expired_date", purchaseDetailEntity.expired_date),
                                               new SQLiteParameter("@is_active", purchaseDetailEntity.is_active),
                                               new SQLiteParameter("@is_deleted", purchaseDetailEntity.is_deleted),
                                               new SQLiteParameter("@created_user_id", purchaseDetailEntity.created_user_id),
                                               new SQLiteParameter("@updated_user_id", purchaseDetailEntity.updated_user_id),
                                               new SQLiteParameter("@created_datetime", purchaseDetailEntity.created_datetime),
                                               new SQLiteParameter("@updated_datetime", purchaseDetailEntity.updated_datetime),
                                               new SQLiteParameter("@remark", purchaseDetailEntity.remark)
                                              };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
            SqliteParams = null;
        }

        #region==========Stock List==========   
        /// <summary>
        /// GetStockList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetStockList()
        {
            strSql = "select ROW_NUMBER() OVER (ORDER BY  st.id) AS sr,st.id, s.supplier_name,p.product_name,p.product_code,st.purchase_quantity,st.purchase_price,st.selling_price,date(st.expired_date) as expired_date," +
                   "s.id As supplier_id,p.id As product_id,st.mfd_date,st.is_active,st.remark,p.category_id,p.sub_category_id from t_purchase_detail As st " +
                   "join m_product As p on st.product_id = p.id join m_supplier As s on p.supplier_id = s.id where st.is_deleted=0";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetPurchaseDetailListById.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetPurchaseDetailListById(int purchaseId)
        {

            strSql = "select pd.id, " +
                "s.supplier_name," +
                "p.product_name," +
                 // "p.product_code," +
                "pd.purchase_quantity as purchase_qty," +
                "pd.purchase_price," +
                "pd.selling_price," +
                "date(pd.expired_date) as expire_date," +
                "s.id As supplier_id," +
                "p.id As product_id," +
                "pd.mfd_date," +
                "pd.is_active," +
                "pd.remark," +
                "p.category_id," +
                "p.sub_category_id " +
                "from t_purchase_detail As pd " +
                "join m_product As p on pd.product_id = p.id " +
                "join m_supplier As s on p.supplier_id = s.id " +
                "join t_purchase on pd.purchase_id = t_purchase.id " +
                "where t_purchase.is_deleted=0 and pd.is_deleted=0 and pd.purchase_id=" + purchaseId;
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSearchStockList.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchStockList(List<object> filterList)
        {
            strSql = "select ROW_NUMBER() OVER (ORDER BY  st.id) AS sr,st.id, s.supplier_name,P.product_name,P.product_code,st.purchase_quantity,st.purchase_price,st.selling_price,date(st.expired_date) as expired_date," +
                     "s.id As supplier_id,P.id As product_id,st.mfd_date,st.is_active,st.remark,P.category_id,P.sub_category_id from t_purchase_detail st " +
                     "join m_product As P on st.product_id = P.id join m_supplier As S on P.supplier_id = s.id where " +
                     "(P.product_name LIKE '%" + filterList[0] + "%' OR P.product_name = '' OR P.product_name IS NULL) " +
                     "AND st.is_deleted = 0 AND (S.supplier_name LIKE '%" + filterList[1] + "%' OR S.supplier_name = '' OR S.supplier_name IS NULL) " +
                     "AND (date(st.created_datetime) between COALESCE(NULLIF(date('" + filterList[2] + "'),''),date('" + DateTime.Now.ToString(Consts.DEFAULTDATE) + "'))  " +
                     "AND COALESCE(NULLIF(date('" + filterList[3] + "'),''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "')));";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        #endregion
        /// <summary>
        /// delete details record by  id 
        /// </summary>
        /// <param name="purchaseId"></param>
        public void Delete(Int64 id)
        {
            strSql = "UPDATE t_purchase_detail SET is_deleted = 1 WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", id)
                                             };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// delete details records by purchase id 
        /// </summary>
        /// <param name="purchaseId"></param>
        public void DeleteDetailsByPurchaseId(Int64 purchaseId)
        {
            strSql = "UPDATE t_purchase_detail SET is_deleted = 1 WHERE purchase_id = @purchase_id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@purchase_id", purchaseId)
                                             };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// update is_delete to 1 in t_purchase_detail
        /// </summary>
        /// <param name="purhcaseId"></param>
        /// <param name="lstDetailId"></param>
        public void UpdateIsDelete(Int64 purhcaseId, List<string> lstDetailId,List<string> lstOldDetailId)
        {
            strSql = "UPDATE t_purchase_detail SET is_deleted = 1 WHERE purchase_id = @purchase_id AND id NOT IN (" + String.Join(",", lstDetailId) + ") and id IN ("+String.Join(",",lstOldDetailId)+")";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@purchase_id", purhcaseId)
                                             };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        #region==========Update Stock==========   
        /// <summary>
        /// Update Stock
        /// </summary>
        /// <param name="PurchaseDetailEntity"></param>
        public void Update(PurchaseDetailEntity purchaseDetailEntity)
        {
            strSql = "UPDATE t_purchase_detail SET  purchase_id = @purchase_id, " +
                     "product_id = @product_id, " +
                     "purchase_price = @purchase_price, purchase_quantity= @purchase_quantity, selling_price = @selling_price," +
                     "mfd_date = @mfd_date, expired_date=@expired_date, is_active=@is_active, is_deleted = @is_deleted, " +
                     "updated_user_id = @updated_user_id, updated_datetime = @updated_datetime, remark=@remark " +
                     "WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@id", purchaseDetailEntity.id),
                      new SQLiteParameter("@purchase_id", purchaseDetailEntity.purchase_id),
                    new SQLiteParameter("@product_id", purchaseDetailEntity.product_id),
                    new SQLiteParameter("@purchase_price", purchaseDetailEntity.purchase_price),
                    new SQLiteParameter("@purchase_quantity", purchaseDetailEntity.purchase_quantity),
                    new SQLiteParameter("@selling_price", purchaseDetailEntity.selling_price),
                    new SQLiteParameter("@mfd_date", purchaseDetailEntity.mfd_date),
                    new SQLiteParameter("@expired_date", purchaseDetailEntity.expired_date),
                    new SQLiteParameter("@is_active", purchaseDetailEntity.is_active),
                    new SQLiteParameter("@is_deleted", purchaseDetailEntity.is_deleted),
                    new SQLiteParameter ("@updated_user_id",purchaseDetailEntity.updated_user_id),
                    new SQLiteParameter("@updated_datetime",purchaseDetailEntity.updated_datetime),
                    new SQLiteParameter("@remark",purchaseDetailEntity.remark)
                };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }
        #endregion

        public int GetProductExist(Int64 productId)
        {
            strSql = "SELECT Count(*) FROM t_purchase_detail " +
                     "WHERE product_id = " + productId + ";";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        #region==========Damage and loss==========  
        /// <summary>
        /// The UpdateSaleStockCount.
        /// </summary>
        /// <param name="shopId">The shopId<see cref="Int64?"/>.</param>
        /// <param name="warehouseId">The warehouseId<see cref="Int64?"/>.</param>
        /// <param name="productId">The productId<see cref="Int64"/>.</param>
        /// <param name="quantity">The quantity<see cref="int"/>.</param>
        /// <param name="isReturn">The isReturn<see cref="int"/>.</param>
        public void UpdateSaleStockCount(
            Int64 productId,
            int quantity,
            int isReturn)
        {
            strSql = "UPDATE t_stock_sale SET quantity = " +
                     "CASE WHEN 0 = " + isReturn + " THEN " +
                     "quantity - ( " + quantity + " ) ELSE quantity + (" + quantity + ") END " +
                     "WHERE product_id = " + productId + ";";
            connection.ExecuteNonQuery(CommandType.Text, strSql, null);

        }

        /// <summary>
        /// The UpdateStockCount.
        /// </summary>
        /// <param name="shopId">The shopId<see cref="Int64?"/>.</param>
        /// <param name="warehouseId">The warehouseId<see cref="Int64?"/>.</param>
        /// <param name="productId">The productId<see cref="Int64"/>.</param>
        /// <param name="quantity">The quantity<see cref="int"/>.</param>
        /// <param name="isReturn">The isReturn<see cref="int"/>.</param>
        public void UpdateStockCount(
            Int64 productId,
            int quantity,
            int isReturn) // only stock quantity => isReturn =1 is from return form
        {
            strSql = "UPDATE t_stock_sale SET quantity = " +
                     "CASE WHEN 0 = " + isReturn + " THEN " +
                     "quantity - ( " + quantity + " ) ELSE quantity + (" + quantity + ") END " +
                     "WHERE product_id = " + productId + ";";
            connection.ExecuteNonQuery(CommandType.Text, strSql, null);

        }

        #endregion

        #region==========Insert/Update t_sale_stock table==========  
        public void InsertStockSale(StockSaleEntity stockSaleEntity)
        {
            strSql = "insert into t_stock_sale (product_id, quantity, selling_price, expired_date,is_active) " +
                     "VALUES(@product_id, @quantity, @selling_price, @expired_date,@is_active);";
            SQLiteParameter[] SqliteParams = {
                                               new SQLiteParameter("@product_id", stockSaleEntity.product_id),
                                               new SQLiteParameter("@quantity", stockSaleEntity.quantity),
                                               new SQLiteParameter("@selling_price", stockSaleEntity.selling_price),
                                               new SQLiteParameter("@expired_date", stockSaleEntity.expired_date),
                                               new SQLiteParameter("@is_active", stockSaleEntity.is_active)
                                              };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
            SqliteParams = null;
        }

        /// <summary>
        /// UpdateStockSale
        /// </summary>
        /// <param name="stockSaleEntity"></param>
        public void UpdateStockSale(StockSaleEntity stockSaleEntity)
        {
            //strSql = "UPDATE t_stock_sale SET quantity = " +
            //         "quantity + " + stockSaleEntity.quantity + ", " +
            //         "selling_price = " + stockSaleEntity.selling_price + ", " +
            //         "expired_date = '" + stockSaleEntity.expired_date + "' " +
            //         " WHERE product_id = " + stockSaleEntity.product_id + ";";
            //connection.ExecuteNonQuery(CommandType.Text, strSql, null);
            strSql = "UPDATE t_stock_sale SET quantity = quantity + @quantity, " +
                    "selling_price = @selling_price, expired_date= @expired_date WHERE product_id = @product_id";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@product_id", stockSaleEntity.product_id),
                      new SQLiteParameter("@quantity", stockSaleEntity.quantity),
                    new SQLiteParameter("@selling_price", stockSaleEntity.selling_price),
                    new SQLiteParameter("@expired_date", stockSaleEntity.expired_date)
                };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }
        #endregion

        #region==========Sale Stock List==========   
        /// <summary>
        /// GetSaleStockList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetSaleStockList()
        {
            strSql = "select ROW_NUMBER() OVER (ORDER BY  st.id) AS sr, s.supplier_name,p.product_name,p.product_code," +
                "st.quantity,st.selling_price,Case WHEN(st.is_active = 0)THEN 'Active' ELSE 'In_Active' END As Is_Active, " +
                "date(st.expired_date)As expired_date, s.id As supplier_id,p.id As product_id,st.id from t_stock_sale As st " +
                "join m_product As p on st.product_id = p.id join m_supplier As s on p.supplier_id = s.id ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSearchStockSaleList.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchStockSaleList(List<object> filterList)
        {
            string date = GetMaxExpiredDate() == null ? "" : GetMaxExpiredDate();
            if (string.IsNullOrWhiteSpace(date))
            {
                date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            DateTime dateTime = Convert.ToDateTime(date);
            strSql = "select ROW_NUMBER() OVER (ORDER BY  SS.id) AS sr, s.supplier_name,P.product_name,P.product_code,SS.quantity,SS.selling_price, Case WHEN (SS.is_active = 0 )THEN 'Active' ELSE 'In_Active' END As Is_Active, " +
                "date(SS.expired_date) as expired_date, s.id As supplier_id,P.id As product_id,SS.id from t_stock_sale SS join m_product As P on SS.product_id = P.id " +
                "join m_supplier As S on P.supplier_id = s.id where (P.product_name LIKE '%" + filterList[0] + "%' OR P.product_name = '' OR P.product_name IS NULL) " +
                "AND(S.supplier_name LIKE '%" + filterList[1] + "%' OR S.supplier_name = '' OR S.supplier_name IS NULL) " +
                "AND (SS.is_active LIKE '%" + filterList[2] + "%' OR SS.is_active = '' OR SS.is_active IS NULL)" +
                "AND (date(SS.expired_date) IS NULL or date(SS.expired_date) == '' or  date(SS.expired_date) between COALESCE(NULLIF(date('" + filterList[3] + "'),''),date('" + DateTime.Now.ToString(Consts.DEFAULTDATE) + "'))  " +
                "AND COALESCE(NULLIF(date('" + filterList[4] + "'),''),date('" + dateTime.ToString(Consts.DATEFORMAT) + "')));";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// UpdateSaleStockList
        /// </summary>
        /// <param name="stockdiscountEntity"></param>
        /// <returns></returns>
        public bool UpdateSaleStockList(int productid, string str)
        {
            if (str == "Active")
            {
                strSql = "UPDATE t_stock_sale SET " +
                    "is_active = " + 1 + " " +
                    " WHERE product_id = " + productid + ";";
            }
            else
            {
                strSql = "UPDATE t_stock_sale SET " +
                    "is_active = " + 0 + " " +
                    " WHERE product_id = " + productid + ";";
            }
            return connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }
        #endregion

        #region==========Stock Discount==========    
        /// <summary>
        /// InsetStockDiscount
        /// </summary>
        /// <param name="stockdiscountEntity"></param>
        /// <returns></returns>
        public bool InsetStockDiscount(StockDiscountEntity stockdiscountEntity)
        {
            strSql = "INSERT INTO t_stock_discount(product_id, quantity, selling_price, discount_percent, discount_amount," +
                     "created_user_id,updated_user_id,created_datetime,updated_datetime,is_active,remark) " +
                     "VALUES(@product_id,@quantity, @selling_price, @discount_percent, @discount_amount," +
                     "@created_user_id,@updated_user_id,@created_datetime,@updated_datetime,@is_active,@remark)";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@product_id", stockdiscountEntity.product_id),
                    new SQLiteParameter("@quantity", stockdiscountEntity.quantity),
                    new SQLiteParameter("@selling_price", stockdiscountEntity.selling_price),
                    new SQLiteParameter("@discount_percent", stockdiscountEntity.discount_percent),
                    new SQLiteParameter("@discount_amount", stockdiscountEntity.discount_amount),
                    new SQLiteParameter ("@created_user_id",stockdiscountEntity.created_user_id),
                    new SQLiteParameter ("@updated_user_id",stockdiscountEntity.updated_user_id),
                    new SQLiteParameter ("@created_datetime",stockdiscountEntity.created_datetime),
                    new SQLiteParameter ("@updated_datetime",stockdiscountEntity.updated_datetime),
                    new SQLiteParameter ("@is_active",stockdiscountEntity.is_active),
                    new SQLiteParameter ("@remark",stockdiscountEntity.remark)
                };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// UpdateSaleStock
        /// </summary>
        /// <param name="stockdiscountEntity"></param>
        public bool UpdateSaleStock(StockDiscountEntity stockdiscountEntity)
        {
            strSql = "UPDATE t_stock_sale SET " +
                     "selling_price = " + stockdiscountEntity.discount_amount + " " +
                     " WHERE product_id = " + stockdiscountEntity.product_id + ";";
            return connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// to get product_id with qty from purchase detail to substract qty in t_stock_sale when the purchase is delete
        /// </summary>
        /// <param name="lstDeleteDetailId"></param>
        /// <returns></returns>
        public DataTable GetProductIdWithTotalQty(List<string> lstDeleteDetailId,int purchaseId,int is_deleted)
        {
            strSql = "SELECT product_id,SUM(purchase_quantity)as total FROM t_purchase_detail WHERE is_deleted="+ is_deleted + " AND purchase_id="+purchaseId+" AND id in ("+String.Join(",",lstDeleteDetailId)+") GROUP BY product_id;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }


        ///// <summary>
        ///// get product id and qty to substract in t_stock_sale  where is_delete 1 
        ///// </summary>
        ///// <param name="purchaseId"></param>
        ///// <returns></returns>
        //public DataTable GetDeletedQty(int purchaseId)
        //{
        //    strSql = "SELECT product_id,SUM(purchase_quantity)as total FROM t_purchase_detail WHERE is_deleted=1 AND purchase_id=" + purchaseId + "  GROUP BY product_id;";
        //    return connection.ExecuteDataTable(CommandType.Text, strSql);
        //}

        /// <summary>
        /// SubstractStockQty
        /// </summary>
        /// <param name="minus"></param>
        /// <param name="product_id"></param>
        public void SubstractStockQty(int product_id,int substractQty)
        {
            strSql = "UPDATE t_stock_sale set quantity = quantity - " + substractQty + " WHERE product_id = " + product_id;
            connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// UpdateSaleStockQty
        /// </summary>
        /// <param name="stockSaleEntity"></param>
        public void UpdateSaleStockQty(StockSaleEntity stockSaleEntity)
        {
            strSql = "UPDATE t_stock_sale SET quantity = quantity + @quantity, " +
                     "selling_price = @selling_price, expired_date= @expired_date WHERE product_id = @product_id";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@product_id", stockSaleEntity.product_id),
                      new SQLiteParameter("@quantity", stockSaleEntity.quantity),
                    new SQLiteParameter("@selling_price", stockSaleEntity.selling_price),
                    new SQLiteParameter("@expired_date", stockSaleEntity.expired_date)
                };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }



        /// <summary>
        /// UpdateStockDiscount
        /// </summary>
        /// <param name="stockdiscountEntity"></param>
        public bool UpdateStockDiscount(StockDiscountEntity stockdiscountEntity)
        {
            strSql = "UPDATE t_stock_discount SET " +
                     "is_active = " + 1 + " " +
                     " WHERE id <> (SELECT max(id) FROM t_stock_discount) and product_id = " + stockdiscountEntity.product_id + ";";
            return connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }
        #endregion

        #region==========Dashboard==========    
        public int GetTotalStock()
        {
            strSql = "SELECT Count(*) FROM t_stock_sale ";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        public int GetActiveStock()
        {
            strSql = "SELECT Count(*) FROM t_stock_sale " +
                     "WHERE is_active = 0 ;";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        public int GetInactiveStock()
        {
            strSql = "SELECT Count(*) FROM t_stock_sale " +
                     "WHERE is_active = 1 ;";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        public int GetDamageLossStock()
        {
            strSql = "select SUM(quantity) As total_damageloss_qty from t_damage_loss;";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        public int GetSaleReturnStock()
        {
            strSql = "select SUM(quantity) As total_salereturn_qty from t_return_details ;";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        public int GetMinStock()
        {
            strSql = "select SUM(quantity) As total_salereturn_qty from t_return_details ;";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }
        #endregion

        #region==========Report========== 
        /// <summary>
        /// GetRptSaleStockList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetSaleStockLists()
        {
            strSql = "select ROW_NUMBER() OVER (ORDER BY  st.id) AS sr, s.supplier_name,c.name,p.product_name,p.product_code,st.quantity ,st.selling_price,date(st.expired_date) as expired_date from t_stock_sale As st  " +
                   "join m_product As p on st.product_id = p.id  " +
                    "join m_supplier As s on p.supplier_id = s.id   " +
                   "join m_category As c on p.category_id = c.id where st.is_active =0  ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSearchResultForStockSaleReportList
        /// </summary>
        /// <param name="filterList"></param>
        /// <returns></returns>
        public DataTable GetSearchResultForStockSaleReportList(List<object> filterList)
        {
            string date = GetMaxExpiredDate() == null ? "" : GetMaxExpiredDate();
            if (string.IsNullOrWhiteSpace(date))
            {
                date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            DateTime dateTime = Convert.ToDateTime(date);
            strSql = "select ROW_NUMBER() OVER (ORDER BY st.id) AS sr, s.supplier_name,c.name,p.product_name,p.product_code,st.quantity ,st.selling_price,date(st.expired_date) as expired_date from t_stock_sale As st  " +
                     "join m_product As p on st.product_id = p.id  " +
                     "join m_supplier As s on p.supplier_id = s.id   " +
                     "join m_category As c on p.category_id = c.id where st.is_active =0  " +
                     "AND (date(st.expired_date) IS NULL or date(st.expired_date) == '' or date(st.expired_date) between COALESCE(NULLIF(date('" + filterList[0] + "'),''),date('" + DateTime.Now.ToString(Consts.DEFAULTDATE) + "'))  " +
                     "AND COALESCE(NULLIF(date('" + filterList[1] + "'),''),date('" + dateTime.ToString(Consts.DATEFORMAT) + "')));";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetMaxExpiredDate
        /// </summary>
        /// <returns></returns>
        public string GetMaxExpiredDate()
        {
            strSql = "SELECT MAX (date(ss.expired_date)) FROM t_stock_sale ss;";
            return Convert.ToString(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        /// <summary>
        /// GetXLSXData.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetXLSXData()
        {
            strSql = "select ROW_NUMBER () OVER (ORDER BY st.quantity DESC) AS Sr, s.supplier_name,c.name,p.product_name,st.quantity ,st.selling_price,date(st.expired_date) as expired_date from t_stock_sale As st  " +
                   "join m_product As p on st.product_id = p.id  " +
                    "join m_supplier As s on p.supplier_id = s.id   " +
                   "join m_category As c on p.category_id = c.id where st.is_active =0  ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetRptTotalSale
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptSaleStockList()
        {
            strSql = "select s.supplier_name,c.name,p.product_name,p.product_code,st.quantity ,st.selling_price,date(st.expired_date) as expired_date from t_stock_sale As st  " +
                  "join m_product As p on st.product_id = p.id  " +
                   "join m_supplier As s on p.supplier_id = s.id   " +
                  "join m_category As c on p.category_id = c.id where st.is_active =0  ";
            return connection.ExecuteDataSet(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetMinStock
        /// </summary>
        /// <returns></returns>
        public int GetMinStockCount()
        {
            strSql = "SELECT Count(*) FROM t_stock_sale As s join m_product  As p on s.product_id = p.id where p.stock_level = s.quantity;";
            //return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }
        #endregion
    }
}
