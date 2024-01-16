using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Entities.SaleReturn;
using System.Data;
using DAO.Common;
using static Entities.SaleReturn.SaleReturnEntity;

namespace DAO.SaleReturn
{
    /// <summary>
    /// Defines the <see cref="SaleReturnDao" />.
    /// </summary>
    public class SaleReturnDao
    {
        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// The Confirm.
        /// </summary>
        /// <param name="info">The info<see cref="SaleReturnEntity"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object Confirm(SaleReturnEntity info)
        {
            strSql = "INSERT INTO t_return(return_invoice_number, sale_id, return_date, " +
                      "is_deleted, remark, created_user_id, updated_user_id, created_datetime, updated_datetime) " +
                      "VALUES(@return_invoice_number, @sale_id, @return_date, " +
                      "@is_deleted, @remark, @created_user_id, @updated_user_id, @created_datetime, " +
                      "@updated_datetime); SELECT LAST_INSERT_ROWID();";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@return_invoice_number", info.return_invoice_number),
                                                new SQLiteParameter("@sale_id", info.sale_id),
                                                new SQLiteParameter("@return_date", info.return_date),
                                                new SQLiteParameter("@is_deleted", info.is_deleted),
                                                new SQLiteParameter("@remark", info.remark),
                                                new SQLiteParameter ("@created_user_id", info.created_user_id),
                                                new SQLiteParameter ("@created_datetime", info.created_datetime),
                                                new SQLiteParameter ("@updated_user_id", info.updated_user_id),
                                                new SQLiteParameter ("@updated_datetime", info.updated_datetime)
                                            };
            return connection.ExecuteScalar(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// The AddSaleProduct.
        /// </summary>
        /// <param name="eachDetails">The eachDetails<see cref="SaleEntryDetails"/>.</param>
        public void AddDetails(SaleReturnEntityDetails eachDetails)
        {
            strSql = "INSERT INTO t_return_details(return_id, product_id, price, quantity, remark) " +
                "VALUES(@return_id, @product_id, @price, @quantity, @remark)";
            SQLiteParameter[] sqliteDetailParams = {
                                                new SQLiteParameter("@return_id", Consts.RETURNID),
                                                new SQLiteParameter("@product_id",  eachDetails.product_id),
                                                new SQLiteParameter("@price", eachDetails.price),
                                                new SQLiteParameter("@quantity",  eachDetails.quantity),
                                                new SQLiteParameter ("@remark", eachDetails.remark),
                                            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, sqliteDetailParams);
            sqliteDetailParams = null;
        }

        /// <summary>
        /// The GetSaleDetail.
        /// </summary>
        /// <param name="saleId">The saleId<see cref="Int64"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSaleDetail(Int64 saleId)
        {
            strSql = " SELECT p.product_name AS product_name , d.price , MAX(d.quantity) qty , " +
                     "MAX(date(h.sale_date)) AS sale_date, " +
                     "h.invoice_number, " +
                     "s.name AS staffname, MAX(h.amount) amount, MAX(h.amount + h.amount_tax) total, " +
                     " h.id ,d.product_id, '' AS damage_quantity, " +
                     "SUM(td.quantity) AS total_return_quantity, h.id as sale_id " +
                     "FROM t_sale h " +
                     "JOIN t_sale_details d ON h.id = d.sale_id " +
                     "LEFT JOIN t_return r ON r.sale_id = h.id " +
                     "LEFT JOIN t_return_details td ON r.id = td.return_id AND d.product_id = td.product_id " +
                     "JOIN m_product p ON d.product_id = p.id " +
                     "JOIN m_staff s ON h.created_user_id = s.id  WHERE h.id = " + saleId +
                     " GROUP BY p.product_name, d.price, h.invoice_number, " +
                     " d.remark, h.id , d.product_id; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSearchResult.
        /// </summary>
        /// <param name="invoice_number">The invoice_number<see cref="string"/>.</param>
        /// <param name="fromDate">The fromDate<see cref="string"/>.</param>
        /// <param name="toDate">The toDate<see cref="string"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchResult(string invoice_number, string fromDate, string toDate)
        {
            strSql = "SELECT Row_Number() OVER(ORDER BY t.id) AS sr, date(t.return_date) as return_date, t.return_invoice_number, st.name AS staff_name, " +
                "SUM(sd.quantity) total_sale_quantity, SUM(td.quantity) return_quantity, t.id  " +
                     "FROM t_sale s " +
                     "JOIN t_sale_details sd ON s.id = sd.sale_id " +
                     "JOIN t_return t ON t.return_invoice_number = s.invoice_number " +
                     "LEFT JOIN t_return_details td ON t.id = td.return_id " +
                     "AND sd.product_id = td.product_id " +
                     "JOIN m_staff st ON t.created_user_id = st.id " +
                     "WHERE (t.return_invoice_number LIKE  '%" + invoice_number + "%' OR st.name = '' " +
                     "OR t.return_invoice_number IS NULL) " +
                     "AND (date(t.return_date) between COALESCE(NULLIF('" + fromDate + "',''),'" + Consts.DEFAULTDATE + "') " +
                     "AND COALESCE(NULLIF('" + toDate + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "')))"+
                     " GROUP BY t.sale_id, t.id, return_invoice_number, t.return_date, st.name " +
                     " ORDER BY t.id ASC; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSaleReturnDetail.
        /// </summary>
        /// <param name="returnId">The invoice_number<see cref="string"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSaleReturnDetail(int returnId)
        {
            strSql = "SELECT t_return.return_invoice_number AS invoice_number, date(t_return.return_date) as return_date, t_return_details.price, " +
                "ROUND(SUM(t_return_details.price) OVER()) AS totalprice, t_return_details.quantity, SUM(quantity) OVER() AS totalqty, " +
                "t_return_details.remark, m_product.product_name AS product_name FROM t_return " +
                "JOIN t_return_details ON t_return_details.return_id = t_return.id " +
                "JOIN m_product ON m_product.id = t_return_details.product_id " +
                 "WHERE t_return.id = " + returnId + " ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The CheckReturn.
        /// </summary>
        /// <param name="saleId">The saleId<see cref="Int64"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object CheckReturn(Int64 saleId)
        {
            strSql = "SELECT * FROM t_return " +
                     "WHERE sale_id = " + saleId + " ;";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }
    }
}
