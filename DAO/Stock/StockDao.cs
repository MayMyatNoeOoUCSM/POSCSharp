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
    public class StockDao
    {
        /// <summary>
        /// Defines the Database Connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        #region Stock

        /// <summary>
        /// Insert purchase
        /// </summary>
        /// <param name="stockEntity"></param>
        public void InsertStock(StockEntity stockEntity)
        {
            strSql = "insert into t_stock (purchase_date,total_amount,payment_due_date, remark, is_deleted,created_user_id, updated_user_id, created_datetime, updated_datetime) " +
           "VALUES(@purchase_date,@total_amount,@payment_due_date, @remark,  @is_deleted,@created_user_id, @updated_user_id, @created_datetime, @updated_datetime);";
            SQLiteParameter[] SqliteParams = {
                                               new SQLiteParameter("@purchase_date", stockEntity.purchase_date),
                                               new SQLiteParameter("@total_amount", stockEntity.total_amount),
                                               new SQLiteParameter("@payment_due_date", stockEntity.payment_due_date),
                                               new SQLiteParameter("@remark", stockEntity.remark),
                                               new SQLiteParameter("@is_deleted", stockEntity.is_deleted),
                                               new SQLiteParameter("@created_user_id", stockEntity.created_user_id),
                                               new SQLiteParameter("@updated_user_id", stockEntity.updated_user_id),
                                               new SQLiteParameter("@created_datetime", stockEntity.created_datetime),
                                               new SQLiteParameter("@updated_datetime", stockEntity.updated_datetime),
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
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  p.id) AS sr," +
                "p.id," +
                "date(p.purchase_date) AS purchase_date," +
                "tblTemp2.supplier_id," +
                "tblTemp2.supplier_name," +
                "p.total_amount,tblTemp1.paid_amount," +
                "date(p.payment_due_date) AS payment_due_date," +
                "p.remark," +
                "p.created_user_id," +
                "p.updated_user_id," +
                "p.updated_datetime " +
                "FROM t_stock p " +
                "left JOIN " +
                "(SELECT SUM(paid_amount) AS paid_amount,stock_id FROM m_payment WHERE is_active=0 GROUP BY stock_id) AS tblTemp1 " +
                "ON tblTemp1.stock_id=p.id  " +
                "JOIN (SELECT stock.id,s.supplier_name,s.id as supplier_id FROM t_stock stock JOIN t_stock_details AS sd ON sd.stock_id=stock.id JOIN m_product p ON sd.product_id=p.id JOIN m_supplier s ON p.supplier_id=s.id WHERE sd.is_deleted=0 GROUP BY stock.id)AS tblTemp2 " +
                "ON tblTemp2.id=p.id " +
                " WHERE p.is_deleted=0";
            //strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  p.id) AS sr,p.id, date(p.purchase_date) AS purchase_date,p.total_amount,sum(m_payment.paid_amount) as paid_amount,date(p.payment_due_date) AS payment_due_date,p.remark,p.created_user_id,p.updated_user_id,p.updated_datetime FROM t_purchase p join m_payment on m_payment.tran_id=p.id WHERE p.is_deleted=0 and m_payment.is_active=0 GROUP BY m_payment.tran_id;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        #endregion

        #region==========Update Stock==========   
        /// <summary>
        /// Update Purchase
        /// </summary>
        /// <param name="stockEntity"></param>
        public void UpdateStock(StockEntity stockEntity)
        {
            strSql = "UPDATE t_stock SET  purchase_date = @purchase_date, " +
                     "total_amount = @total_amount, " +
                     "payment_due_date = @payment_due_date," +
                     "is_deleted = @is_deleted, " +
                     "updated_user_id = @updated_user_id, " +
                     "updated_datetime = @updated_datetime, " +
                     "remark=@remark " +
                     "WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@id", stockEntity.id),
                    new SQLiteParameter("@purchase_date", stockEntity.purchase_date),
                    new SQLiteParameter("@total_amount", stockEntity.total_amount),
                    new SQLiteParameter("@payment_due_date", stockEntity.payment_due_date),
                    new SQLiteParameter("@remark", stockEntity.remark),
                     new SQLiteParameter("@is_deleted", stockEntity.is_deleted),
                    new SQLiteParameter ("@updated_user_id",stockEntity.updated_user_id),
                    new SQLiteParameter("@updated_datetime",stockEntity.updated_datetime),

                };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        #endregion

        public void DeleteStock(Int64 id)
        {
            strSql = "UPDATE t_stock SET is_deleted = 1 WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", id)
                                             };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// GetLastId
        /// </summary>
        /// <returns></returns>
        public object GetLastId()
        {
            strSql = "SELECT MAX(id) FROM t_stock;";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }
        #endregion
        public void Insert(StockDetailEntity stockDetailEntity)
        {
            strSql = "insert into t_stock_details (stock_id, product_id, purchase_price, purchase_quantity, selling_price," +
                     " mfd_date, expired_date, is_active, is_deleted,created_user_id, updated_user_id, created_datetime, updated_datetime, remark) " +
                     "VALUES(@stock_id, @product_id, @purchase_price, @purchase_quantity, @selling_price," +
                     "@mfd_date, @expired_date, @is_active, @is_deleted, @created_user_id, @updated_user_id, @created_datetime, @updated_datetime, @remark);";
            SQLiteParameter[] SqliteParams = {
                                               new SQLiteParameter("@stock_id", stockDetailEntity.stock_id),
                                               new SQLiteParameter("@product_id", stockDetailEntity.product_id),
                                               new SQLiteParameter("@purchase_price", stockDetailEntity.purchase_price),
                                               new SQLiteParameter("@purchase_quantity", stockDetailEntity.purchase_quantity),
                                               new SQLiteParameter("@selling_price", stockDetailEntity.selling_price),
                                               new SQLiteParameter("@mfd_date", stockDetailEntity.mfd_date),
                                               new SQLiteParameter("@expired_date", stockDetailEntity.expired_date),
                                               new SQLiteParameter("@is_active", stockDetailEntity.is_active),
                                               new SQLiteParameter("@is_deleted", stockDetailEntity.is_deleted),
                                               new SQLiteParameter("@created_user_id", stockDetailEntity.created_user_id),
                                               new SQLiteParameter("@updated_user_id", stockDetailEntity.updated_user_id),
                                               new SQLiteParameter("@created_datetime", stockDetailEntity.created_datetime),
                                               new SQLiteParameter("@updated_datetime", stockDetailEntity.updated_datetime),
                                               new SQLiteParameter("@remark", stockDetailEntity.remark)
                                              };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
            SqliteParams = null;
        }

        #region==========Stock List==========   

        ///// <summary>
        ///// GetStockList.
        ///// </summary>
        ///// <returns>.</returns>
        //public DataTable GetStockList()
        //{
        //    strSql = "select ROW_NUMBER() OVER (ORDER BY  st.id) AS sr,st.id, s.supplier_name,p.product_name,p.product_code,st.purchase_quantity,st.purchase_price,st.selling_price,date(st.expired_date) as expired_date," +
        //           "s.id As supplier_id,p.id As product_id,st.mfd_date,st.is_active,st.remark,p.category_id,p.sub_category_id from t_purchase_detail As st " +
        //           "join m_product As p on st.product_id = p.id join m_supplier As s on p.supplier_id = s.id where st.is_deleted=0";
        //    return connection.ExecuteDataTable(CommandType.Text, strSql);
        //}

        /// <summary>
        /// GetStockDetailListById.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetStockDetailListById(int stockId)
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
                "from t_stock_details As pd " +
                "join m_product As p on pd.product_id = p.id " +
                "join m_supplier As s on p.supplier_id = s.id " +
                "join t_stock on pd.stock_id = t_stock.id " +
                "where t_stock.is_deleted=0 and pd.is_deleted=0 and pd.stock_id=" + stockId;
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSearchStockList.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchStockList(List<object> filterList)
        {
            //strSql = "select ROW_NUMBER() OVER (ORDER BY  st.id) AS sr," +
            //         "st.id," +
            //         " s.supplier_name," +
            //         "P.product_name," +
            //         "P.product_code," +
            //         "st.purchase_quantity," +
            //         "st.purchase_price," +
            //         "st.selling_price," +
            //         "date(st.expired_date) as expired_date," +
            //         "s.id As supplier_id," +
            //         "P.id As product_id," +
            //         "st.mfd_date," +
            //         "st.is_active," +
            //         "st.remark," +
            //         "P.category_id," +
            //         "P.sub_category_id " +
            //         "from t_stock_details st " +
            //         "join m_product As P on st.product_id = P.id " +
            //         "join m_supplier As S on P.supplier_id = s.id where " +
            //         "(P.product_name LIKE '%" + filterList[0] + "%' OR P.product_name = '' OR P.product_name IS NULL) " +
            //         "AND st.is_deleted = 0 AND (S.supplier_name LIKE '%" + filterList[1] + "%' OR S.supplier_name = '' OR S.supplier_name IS NULL) " +
            //         "AND (date(st.created_datetime) between COALESCE(NULLIF(date('" + filterList[2] + "'),''),date('" + DateTime.Now.ToString(Consts.DEFAULTDATE) + "'))  " +
            //         "AND COALESCE(NULLIF(date('" + filterList[3] + "'),''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "')));";
            strSql = "";
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  p.id) AS sr," +
                    "p.id," +
                    "date(p.purchase_date) AS purchase_date," +
                    "tblTemp2.supplier_id," +
                    "tblTemp2.supplier_name," +
                    "p.total_amount,tblTemp1.paid_amount," +
                    "date(p.payment_due_date) AS payment_due_date," +
                    "p.remark," +
                    "p.created_user_id," +
                    "p.updated_user_id," +
                    "p.updated_datetime " +
                    "FROM t_stock p " +
                    "left JOIN " +
                    "(SELECT SUM(paid_amount) AS paid_amount,stock_id FROM m_payment WHERE is_active=0 GROUP BY stock_id) AS tblTemp1 " +
                    "ON tblTemp1.stock_id=p.id  " +
                    "JOIN (SELECT stock.id,s.supplier_name,s.id as supplier_id FROM t_stock stock JOIN t_stock_details AS sd ON sd.stock_id=stock.id JOIN m_product p ON sd.product_id=p.id JOIN m_supplier s ON p.supplier_id=s.id WHERE sd.is_deleted=0 GROUP BY stock.id)AS tblTemp2 " +
                    "ON tblTemp2.id=p.id " +
                    " WHERE p.is_deleted=0";

    
            string strWhere = "";
            //supplier_name
            if (filterList[0].ToString()!="")
            {
                strWhere = strWhere == "" ? strWhere : (strWhere + " AND ");
                strWhere = strWhere + "tblTemp2.supplier_name Like '%" + filterList[0] + "%'";
            }
            //payment due date
            if (filterList[1].ToString() != "")
            {
                strWhere = strWhere == "" ? strWhere : (strWhere + " AND ");
                strWhere = strWhere + " date(p.payment_due_date)='" + filterList[1] + "'";
            }

            //purchase from date
            if (filterList[2].ToString() != "" && filterList[3].ToString() == "")
            {
                strWhere = strWhere == "" ? strWhere : (strWhere + " AND ");
                strWhere = strWhere + " date(p.purchase_date)>='"+ filterList[2] + "'";
            }

            //purchase to date
            else if (filterList[2].ToString() == "" && filterList[3].ToString() != "" )
            {
                strWhere = strWhere == "" ? strWhere : (strWhere + " AND ");
                strWhere = strWhere + " date(p.purchase_date)<'" + filterList[3] + "'";
            }

            //purchase from date and to date
            else if (filterList[2].ToString() != "" && filterList[3].ToString() != "")
            {
                strWhere = strWhere == "" ? strWhere : (strWhere + " AND ");
                strWhere = strWhere + "date(p.purchase_date) between '" + filterList[2] + "' AND '" + filterList[3] + "'";
            }
            if (!String.IsNullOrEmpty(strWhere))
            {
                strSql = strSql + " AND " + strWhere;
            }
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        #endregion
        /// <summary>
        /// delete details record by  id 
        /// </summary>
        /// <param name="purchaseId"></param>
        public void DeleteStockDetail(Int64 id)
        {
            strSql = "UPDATE t_stock_details SET is_deleted = 1 WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", id)
                                             };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// delete details records by purchase id 
        /// </summary>
        /// <param name="stockId"></param>
        public void DeleteDetailsByStockId(Int64 stockId)
        {
            strSql = "UPDATE t_stock_details SET is_deleted = 1 WHERE stock_id = @stock_id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@stock_id", stockId)
                                             };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// update is_delete to 1 in t_purchase_detail
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="lstDetailId"></param>
        public void UpdateIsDelete(Int64 stockId, List<string> lstDetailId,List<string> lstOldDetailId)
        {
            strSql = "UPDATE t_stock_details SET is_deleted = 1 WHERE stock_id = @stock_id AND id NOT IN (" + String.Join(",", lstDetailId) + ") and id IN ("+String.Join(",",lstOldDetailId)+")";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@stock_id", stockId)
                                             };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        #region==========Update Stock==========   
        /// <summary>
        /// Update Stock
        /// </summary>
        /// <param name="PurchaseDetailEntity"></param>
        public void Update(StockDetailEntity purchaseDetailEntity)
        {
            strSql = "UPDATE t_stock_details SET  stock_id = @stock_id, " +
                     "product_id = @product_id, " +
                     "purchase_price = @purchase_price, purchase_quantity= @purchase_quantity, selling_price = @selling_price," +
                     "mfd_date = @mfd_date, expired_date=@expired_date, is_active=@is_active, is_deleted = @is_deleted, " +
                     "updated_user_id = @updated_user_id, updated_datetime = @updated_datetime, remark=@remark " +
                     "WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@id", purchaseDetailEntity.id),
                      new SQLiteParameter("@stock_id", purchaseDetailEntity.stock_id),
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
            strSql = "SELECT Count(*) FROM t_stock_sale " +
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

        #region==========Insert/Update t_stock_sale table==========  
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
            string dateNull = "";
            string date = GetMaxExpiredDate() == null ? "" : GetMaxExpiredDate();
            if (string.IsNullOrWhiteSpace(date))
            {
                date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            DateTime dateTime = Convert.ToDateTime(date);
            if (Convert.ToString(filterList[3]) == "" || Convert.ToString(filterList[4]) == "")
            {
                dateNull = "date(SS.expired_date) IS NULL or date(SS.expired_date) == '' or";
            }
            strSql = "select ROW_NUMBER() OVER (ORDER BY  SS.id) AS sr, s.supplier_name,P.product_name,P.product_code,SS.quantity,SS.selling_price, Case WHEN (SS.is_active = 0 )THEN 'Active' ELSE 'In_Active' END As Is_Active, " +
                "date(SS.expired_date) as expired_date, s.id As supplier_id,P.id As product_id,SS.id from t_stock_sale SS join m_product As P on SS.product_id = P.id " +
                "join m_supplier As S on P.supplier_id = s.id where (P.product_name LIKE '%" + filterList[0] + "%' OR P.product_name = '' OR P.product_name IS NULL) " +
                "AND(S.supplier_name LIKE '%" + filterList[1] + "%' OR S.supplier_name = '' OR S.supplier_name IS NULL) " +
                "AND (SS.is_active LIKE '%" + filterList[2] + "%' OR SS.is_active = '' OR SS.is_active IS NULL)" +
                "AND ( " + dateNull + " date(SS.expired_date) between COALESCE(NULLIF(date('" + filterList[3] + "'),''),date('" + DateTime.Now.ToString(Consts.DEFAULTDATE) + "'))  " +
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
        public DataTable GetProductIdWithTotalQty(List<string> lstDeleteDetailId,int stockId,int is_deleted)
        {
            strSql = "SELECT product_id,SUM(purchase_quantity)as total FROM t_stock_details WHERE is_deleted=" + is_deleted + " AND stock_id="+stockId+" AND id in ("+String.Join(",",lstDeleteDetailId)+") GROUP BY product_id;";
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

        /// <summary>
        /// GetExpireStockCount
        /// </summary>
        /// <returns></returns>
        public int GetExpireStockCount()
        {
            DateTime date = DateTime.Now.AddDays(10);
            strSql = "SELECT Count(*) FROM t_stock_sale " +
                     "WHERE date(expired_date) = COALESCE(NULLIF(date(''),''),date('" + date.ToString(Consts.DATEFORMAT) + "'));";
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
            string dateNull = "";
            string date = GetMaxExpiredDate() == null ? "" : GetMaxExpiredDate();
            if (string.IsNullOrWhiteSpace(date))
            {
                date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            DateTime dateTime = Convert.ToDateTime(date);
            if (Convert.ToString(filterList[0]) == "" || Convert.ToString(filterList[1]) == "")
            {
                dateNull = "date(SS.expired_date) IS NULL or date(SS.expired_date) == '' or";
            }
            strSql = "select ROW_NUMBER() OVER (ORDER BY st.id) AS sr, s.supplier_name,c.name,p.product_name,p.product_code,st.quantity ,st.selling_price,date(st.expired_date) as expired_date from t_stock_sale As st  " +
                     "join m_product As p on st.product_id = p.id  " +
                     "join m_supplier As s on p.supplier_id = s.id   " +
                     "join m_category As c on p.category_id = c.id where st.is_active =0  " +
                     "AND (" + dateNull + " date(st.expired_date) between COALESCE(NULLIF(date('" + filterList[0] + "'),''),date('" + DateTime.Now.ToString(Consts.DEFAULTDATE) + "'))  " +
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
