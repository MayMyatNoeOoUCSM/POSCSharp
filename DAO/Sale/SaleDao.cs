using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Entities.DamageLoss;
using System.Data;
using static Entities.Sale.SaleEntity;
using DAO.Common;

namespace DAO.Sale
{
    public class SaleDao
    {
        /// <summary>
        /// Defines the Database Connection..
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        #region==========Sale List and Cancel invoice==========
        /// <summary>
        /// The GetSaleCount.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetSaleCount()
        {
            strSql = "SELECT COUNT (*) FROM t_sale WHERE invoice_status != 1 ;";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        /// <summary>
        /// The GetDetail.
        /// </summary>
        /// <param name="saleId">The saleId<see cref="Int64"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetDetail(Int64 saleId)
        {
            strSql = "SELECT ROW_NUMBER () OVER (ORDER BY h.invoice_number DESC) AS sr, p.product_name AS product_name , d.price AS price , d.quantity AS quantity ," +
                     "h.sale_date AS sale_date, " +
                     "h.invoice_number AS invoice_number, " +
                     "s.name AS staff_name, " +
                     "amount, (amount + amount_tax) total,d.remark , h.id, p.id AS product_id " +
                     "FROM t_sale h " +
                     "JOIN t_sale_details d ON h.id = d.sale_id " +
                     "JOIN m_product p ON d.product_id = p.id " +
                     "JOIN m_staff s ON h.staff_id = s.id " +
                     "WHERE d.sale_id = " + saleId;
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSaleList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSaleList(int startCount, int count)
        {
            strSql = "SELECT ROW_NUMBER () OVER (ORDER BY h.invoice_number DESC) AS sr, " +
                     "date(h.sale_date) AS sale_date, " +
                     "h.invoice_number AS invoice_number, s.name AS staff_name," +
                     "amount_tax, amount, (amount + amount_tax) total, p.paid_amount as paid_amount, h.remark ,h.id , h.invoice_status " +
                     "FROM t_sale h " +
                     "Left JOIN m_payment p ON h.id = p.sale_id " +
                     "JOIN m_staff s ON h.staff_id = s.id " +
                     "WHERE h.invoice_status != 1 " +
                     "ORDER BY invoice_number DESC " + ";";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSaleListCSV.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSaleListCSV()
        {
            strSql = "SELECT ROW_NUMBER () OVER (ORDER BY h.invoice_number DESC) AS sr, " +
                     "date(h.sale_date) AS sale_date, " +
                     "h.invoice_number AS invoice_number, s.name AS staff_name," +
                     "amount_tax, amount, (amount + amount_tax) total, h.remark " +
                     "FROM t_sale h " +
                     "JOIN m_staff s ON h.staff_id = s.id " +
                     "WHERE h.invoice_status != 1 " +
                     "ORDER BY invoice_number DESC; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// UpdateSaleDetailQuantity
        /// </summary>
        /// <param name="sale_id"></param>
        /// <param name="product_Id"></param>
        /// <param name="quantiy"></param>
        public void UpdateSaleDetailQuantity(Int64 sale_id,Int64 product_Id, int quantiy)
        {
            strSql = "Update t_sale_details Set quantity = quantity" + (-quantiy) + " where sale_id =" + sale_id + " AND product_id =" + product_Id + ";";
            connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetDetailCSV.
        /// </summary>
        /// <param name="saleId">The saleId<see cref="Int64"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetDetailCSV(Int64 saleId)
        {
            strSql = "SELECT invoice_number AS invoice_number," +
                     "Date(h.sale_date) AS sale_date," +
                     "s.name AS staff_name,CAST(amount as integer)As amount," +
                     "CAST((amount + amount_tax) as integer) total,  " +
                     "'' AS No,p.product_name AS product_name, CAST(d.price as integer) As price , " +
                     "d.quantity," +
                     "d.remark , h.id  " +
                     " FROM t_sale h " +
                     "JOIN t_sale_details d ON h.id = d.sale_id " +
                     "JOIN m_product p ON d.product_id = p.id " +
                     "JOIN m_staff s ON h.created_user_id = s.id " +
                     "WHERE h.id = " + saleId;
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The UpdateVoucher.
        /// </summary>
        /// <param name="saleId">The saleId<see cref="Int64"/>.</param>
        /// <param name="reason">The reason<see cref="string"/>.</param>
        public void UpdateVoucher(Int64 saleId, string reason)
        {
            strSql = "UPDATE t_sale SET invoice_status = 3 , reason= '" + reason + "'  " +
                     "WHERE id = " + saleId + ";";
            connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// UpdateStockCount
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public void UpdateStockCount(
            Int64 productId,
            int quantity)
        {
            strSql = "UPDATE t_stock_sale SET quantity = " +
                     "quantity + " + quantity +
                     " WHERE product_id = " + productId + ";";
            connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetSearchCount.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetSearchCount(List<object> filterList)
        {
            strSql = "SELECT COUNT(*) FROM t_sale h JOIN m_staff s ON h.created_user_id = s.id " +
                     "WHERE (h.invoice_number LIKE '%" + filterList[0] + "%' OR h.invoice_number = '' OR h.invoice_number IS NULL) " +
                     "AND (h.invoice_status = " + filterList[1] + " OR 0 = " + filterList[1] + " ) " +
                     "AND h.invoice_status != 1 " +
                     "AND (date(h.sale_date) between COALESCE(NULLIF('" + filterList[2] + "',''),'" + Consts.DEFAULTDATE + "') " +
                     "AND COALESCE(NULLIF('" + filterList[3] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "')));";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }
        /// <summary>
        /// The GetSearchResult.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchResult(List<object> filterList)
        {
            strSql = "SELECT ROW_NUMBER () OVER (ORDER BY h.invoice_number DESC) AS sr, " +
                     "date(h.sale_date) AS sale_date, " +
                     "invoice_number, " +
                     "s.name AS staff_name, amount_tax AS amount_tax, amount, " +
                     "(amount + amount_tax) total, h.remark , h.id, h.invoice_status, p.paid_amount as paid_amount " +
                     "FROM t_sale h " +
                     "Left JOIN m_payment p ON h.id = p.sale_id " +
                     "JOIN m_staff s ON h.staff_id = s.id " +
                     "WHERE (h.invoice_number LIKE '%" + filterList[0] + "%' OR h.invoice_number = '' OR h.invoice_number IS NULL) " +
                     "AND (h.invoice_status = " + filterList[1] + " OR 0 = " + filterList[1] + ") " +
                     "AND h.invoice_status != 1 " +
                     "AND (date(h.sale_date) between COALESCE(NULLIF('" + filterList[2] + "',''),'" + Consts.DEFAULTDATE + "') " +
                     "AND COALESCE(NULLIF('" + filterList[3] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "')))" +
                     " ORDER BY invoice_number DESC " + " ;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        #region==========Sale Return Confrim List==========
        /// <summary>
        /// The GetSearchResult.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchConfirmResult(List<object> filterList)
        {
            strSql = "SELECT ROW_NUMBER () OVER (ORDER BY h.invoice_number DESC) AS sr, " +
                     "date(h.sale_date) AS sale_date, " +
                     "invoice_number, " +
                     "s.name AS staff_name, amount_tax AS amount_tax, amount, " +
                     "(amount + amount_tax) total, h.remark , h.id, h.invoice_status " +
                     "FROM t_sale h " +
                     "JOIN m_staff s ON h.staff_id = s.id " +
                     "WHERE (h.invoice_number LIKE '%" + filterList[0] + "%' OR h.invoice_number = '' OR h.invoice_number IS NULL) " +
                     "AND (h.invoice_status = " + filterList[1] + " OR 0 = " + filterList[1] + ") " +
                     "AND h.invoice_status == 2 " +
                     "AND (date(h.sale_date) between COALESCE(NULLIF('" + filterList[2] + "',''),'" + Consts.DEFAULTDATE + "') " +
                     "AND COALESCE(NULLIF('" + filterList[3] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "')))" +
                     " ORDER BY invoice_number DESC " + " ;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSaleConfirmCount.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetSaleConfirmCount()
        {
            strSql = "SELECT COUNT (*) FROM t_sale WHERE invoice_status == 2 ;";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        /// <summary>
        /// The GetSaleConfirmList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSaleConfirmList(int startCount, int count)
        {
            strSql = "SELECT ROW_NUMBER () OVER (ORDER BY h.invoice_number DESC) AS sr, " +
                     "date(h.sale_date) AS sale_date, " +
                     "h.invoice_number AS invoice_number, s.name AS staff_name," +
                     "amount_tax, amount, (amount + amount_tax) total, h.remark ,h.id , h.invoice_status " +
                     "FROM t_sale h " +
                     "JOIN m_staff s ON h.staff_id = s.id " +
                     "WHERE h.invoice_status == 2 " +
                     "ORDER BY invoice_number DESC " + ";";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSearchConfirmCount.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetSearchConfirmCount(List<object> filterList)
        {
            strSql = "SELECT COUNT(*) FROM t_sale h JOIN m_staff s ON h.created_user_id = s.id " +
                     "WHERE (h.invoice_number LIKE '%" + filterList[0] + "%' OR h.invoice_number = '' OR h.invoice_number IS NULL) " +
                     "AND (h.invoice_status = " + filterList[1] + " OR 0 = " + filterList[1] + " ) " +
                     "AND h.invoice_status != 1 " +
                     "AND (date(h.sale_date) between COALESCE(NULLIF('" + filterList[2] + "',''),'" + Consts.DEFAULTDATE + "') " +
                     "AND COALESCE(NULLIF('" + filterList[3] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "')));";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        #endregion
        #endregion

        #region==========Dashboard==========    
        /// <summary>
        /// The GetTodaySaleAmount.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetTodaySaleAmount()
        {
            strSql = "SELECT sum(price* quantity) amount " +
                     " FROM t_sale s " +
                     " JOIN t_sale_details det ON s.id = det.sale_id " +
                     " WHERE s.invoice_status = 2 AND date(s.sale_date) = '" + DateTime.Now.ToString(Consts.DATEFORMAT) + "';";          
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetMonthlyYearlySaleAmount.
        /// </summary>
        /// <param name="startDate">The startDate<see cref="DateTime"/>.</param>
        /// <param name="endDate">The endDate<see cref="DateTime"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetMonthlyYearlySaleAmount(DateTime startDate, DateTime endDate)
        {
            strSql = "SELECT COALESCE(SUM(price* quantity), 0) amount " +
                     "FROM t_sale s " +
                     "JOIN t_sale_details det ON s.id = det.sale_id " +
                     "WHERE s.sale_date >= '" + startDate.ToString(Consts.DATEFORMAT) + "' " +
                     "AND s.sale_date <= '" + endDate.ToString(Consts.DATEFORMAT) + "' " +
                     "AND s.invoice_status = 2 ;";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetTotallySaleAmount.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetTotallySaleAmount()
        {
            strSql = "SELECT COALESCE(sum(price* quantity), 0) amount " +
                    " FROM t_sale s " +
                    " JOIN t_sale_details det ON s.id = det.sale_id " +
                    " WHERE s.invoice_status = 2 ;";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetMonthlySaleReport.
        /// </summary>
        /// <param name="startDate">The startDate<see cref="DateTime"/>.</param>
        /// <param name="endDate">The endDate<see cref="DateTime"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetMonthlySaleReport(DateTime startDate, DateTime endDate)
        {
            strSql = "BEGIN TRANSACTION;" + " DROP TABLE IF EXISTS month;" +
                     "CREATE TABLE month AS SELECT COALESCE(SUM(jan), 0) Jan, " +
                     "COALESCE(SUM(feb),0) Feb, " +
                     "COALESCE(SUM(mar),0) Mar, " +
                     "COALESCE(SUM(apr), 0) Apr, " +
                     "COALESCE(SUM(may), 0) May, " +
                     "COALESCE(SUM(jun), 0) Jun, " +
                     "COALESCE(SUM(jul), 0) Jul, " +
                     "COALESCE(SUM(aug),0) Aug, " +
                     "COALESCE(SUM(sep), 0) Sep, " +
                     "COALESCE(SUM(oct), 0) Oct, " +
                     "COALESCE(SUM(nov), 0) Nov, " +
                     "COALESCE(SUM(dec), 0) Dec , " +
                     "COALESCE((SUM(jan) " +
                     "+ SUM(feb) " +
                     "+ SUM(mar) " +
                     "+ SUM(apr) " +
                     "+ SUM(may) " +
                     "+ SUM(jun) " +
                     "+ SUM(jul) " +
                     "+ SUM(aug) " +
                     "+ SUM(sep) " +
                     "+ SUM(oct) " +
                     "+ SUM(nov) " +
                     "+ SUM(dec)), 0) total " +
                     " From(SELECT " +
                     " CASE WHEN strftime('%m', sale_date) = '01' Then amount End jan," +
                     " CASE WHEN strftime('%m', sale_date) = '02' Then amount End feb," +
                     " CASE WHEN strftime('%m', sale_date) = '03' Then amount End mar," +
                     " CASE WHEN strftime('%m', sale_date) = '04' Then amount End apr," +
                     " CASE WHEN strftime('%m', sale_date) = '05' Then amount End may," +
                     " CASE WHEN strftime('%m', sale_date) = '06' Then amount End jun," +
                     " CASE WHEN strftime('%m', sale_date) = '07' Then amount End jul," +
                     " CASE WHEN strftime('%m', sale_date) = '08' Then amount End aug," +
                     " CASE WHEN strftime('%m', sale_date) = '09' Then amount End sep," +
                     " CASE WHEN strftime('%m', sale_date) = '10' Then amount End oct," +
                     " CASE WHEN strftime('%m', sale_date) = '11' Then amount End nov," +
                     " CASE WHEN strftime('%m', sale_date) = '12' Then amount End dec" +
                     " FROM t_sale WHERE invoice_status = 2 AND date(sale_date >= '" +
                     startDate.ToString(Consts.DATEFORMAT) + "') AND date(sale_date <= '" +
                     endDate.ToString(Consts.DATEFORMAT) + "')) ts;" +
                     "select 'Jan' as month,Jan amount from month " +
                    "UNION ALL " +
                    "select 'Feb' as month,Feb amount from month " +
                    "UNION ALL " +
                    "select 'Mar' as month,Mar amount from month " +
                    "UNION ALL " +
                    "select 'Apr' as month,Apr amount from month " +
                    "UNION ALL " +
                    "select 'May' as month,May amount from month " +
                    "UNION ALL " +
                    "select 'Jun' as month,Jun amount from month " +
                    "UNION ALL " +
                    "select 'Jul' as month,Jul amount from month " +
                    "UNION ALL " +
                    "select 'Aug' as month,Aug amount from month " +
                    "UNION ALL " +
                    "select 'Sep' as month,Sep amount from month " +
                    "UNION ALL " +
                    "select 'Oct' as month,Oct amount from month " +
                    "UNION ALL " +
                    "select 'Nov' as month,Nov amount from month " +
                    "UNION ALL " +
                    "select 'Dec' as month,Dec amount from month;" +
                    "COMMIT TRANSACTION;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }


        #endregion

        #region==========Report========== 
        /// <summary>
        /// GetTotalSale
        /// </summary>
        /// <returns></returns>
        public DataTable GetTotalSale()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  s.id) AS sr, date(s.sale_date)As Sale_Date,st.name As Name ,SUM(det.price * det.quantity)As Total_Amount, " +
                     "SUM(det.quantity )As Sale_Quantity , SUM(det.quantity )As Sale_Return_Quantity , SUM(det.quantity )As Sale_Cancel_Process FROM t_sale s  " +
                     "JOIN t_sale_details det ON s.id = det.sale_id  " +
                     "JOIN m_staff st on s.staff_id = st.id  " +
                     "WHERE s.invoice_status = 2 group by s.sale_date;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSearchResultForReportList
        /// </summary>
        /// <returns></returns>
        public DataTable GetSearchResultForReportList(List<object> filterList)
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  s.id) AS sr, date(s.sale_date)As Sale_Date,st.name As Name ,SUM(det.price * det.quantity)As Total_Amount, " +
                     "SUM(det.quantity )As Sale_Quantity , SUM(det.quantity )As Sale_Return_Quantity , SUM(det.quantity )As Sale_Cancel_Process FROM t_sale s  " +
                     "JOIN t_sale_details det ON s.id = det.sale_id  " +
                     "JOIN m_staff st on s.staff_id = st.id  " +
                     "WHERE s.invoice_status = 2 " +
                     "AND (date(s.sale_date) between COALESCE(NULLIF('" + filterList[0] + "',''),'" + Consts.DEFAULTDATE + "') " +
                     "AND COALESCE(NULLIF('" + filterList[1] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "'))) group by s.sale_date" + " ;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSearchCountReport
        /// </summary>
        /// <param name="filterList"></param>
        /// <returns></returns>
        public int GetSearchCountReport(List<object> filterList)
        {
            strSql = "SELECT count(*) FROM t_sale s  " +
                     "JOIN t_sale_details det ON s.id = det.sale_id  " +
                     "JOIN m_staff st on s.staff_id = st.id  " +
                     "WHERE s.invoice_status = 2 " +
                     "AND (date(s.sale_date) between COALESCE(NULLIF('" + filterList[0] + "',''),'" + Consts.DEFAULTDATE + "') " +
                     "AND COALESCE(NULLIF('" + filterList[1] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "'))) group by s.sale_date" + " ;";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        ///// <summary>
        ///// GetXLSXData
        ///// </summary>
        ///// <returns></returns>
        //public DataTable GetXLSXData()
        //{
        //    strSql = "SELECT ROW_NUMBER () OVER (ORDER BY s.invoice_number DESC) AS Sr, date(s.sale_date)As Sale_Date,st.name As Name ,SUM(det.price * det.quantity)As Total_Amount, " +
        //             "SUM(det.quantity )As Sale_Quantity , SUM(det.quantity )As Sale_Return_Quantity , SUM(det.quantity )As Sale_Cancel_Process FROM t_sale s  " +
        //             "JOIN t_sale_details det ON s.id = det.sale_id  " +
        //             "JOIN m_staff st on s.staff_id = st.id  " +
        //             "WHERE s.invoice_status = 2 group by s.sale_date;";
        //    return connection.ExecuteDataTable(CommandType.Text, strSql);
        //}

        /// <summary>
        /// GetXLSXData
        /// </summary>
        /// <returns></returns>
        public DataTable GetXLSXData()
        {
            strSql = "SELECT ROW_NUMBER () OVER (ORDER BY s.invoice_number DESC) AS Sr, date(s.sale_date)As Sale_Date,st.name As Name ,SUM(det.price * det.quantity)As Total_Amount, " +
                     "SUM(det.quantity )As Sale_Quantity  FROM t_sale s  " +
                     "JOIN t_sale_details det ON s.id = det.sale_id  " +
                     "JOIN m_staff st on s.staff_id = st.id  " +
                     "WHERE s.invoice_status = 2 group by s.sale_date;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetTopTenSaleProductList
        /// </summary>
        /// <returns></returns>
        public DataTable GetTopTenSaleProductList() // Dashboard
        {
            strSql = " SELECT p.product_code,p.product_name as name,p.product_image_path,c.name as category_name,st.name as shop_name,p.product_description as description,date(t.mfd_date) as mfd_date,date(t.expired_date) as expire_date, " +
                      " SUM(det.quantity )As total_quantity  FROM t_sale s   " +
                      "JOIN t_sale_details det ON s.id = det.sale_id  " +
                      "JOIN m_staff st on s.staff_id = st.id " +
                      "join m_product p on det.product_id = p.id " +
                      "join m_category c on p.category_id = c.id " +
                      "left join t_stock_details t on p.id = t.product_id " +
                      "WHERE s.invoice_status = 2 group by det.product_id ,c.name   ORDER BY total_quantity DESC LIMIT 10 ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSearchResultForTopTenSaleProductList
        /// </summary>
        /// <param name="filterList"></param>
        /// <returns></returns>
        public DataTable GetSearchResultForTopTenSaleProductList(List<object>filterList)
        {
            strSql = " SELECT ROW_NUMBER() OVER (ORDER by SUM(det.quantity) DESC) AS sr, p.product_code,p.product_name as name,c.name as category_name,st.name as shop_name,p.product_description as description,date(t.mfd_date) as mfd_date,date(t.expired_date) as expire_date, " +
                     " SUM(det.quantity )As total_quantity  FROM t_sale s   " +
                     "LEFT JOIN t_sale_details det ON s.id = det.sale_id  " +
                     "LEFT JOIN m_staff st on s.staff_id = st.id " +
                     "LEFT join m_product p on det.product_id = p.id " +
                     "LEFT join m_category c on p.category_id = c.id " +
                     "LEFT join t_stock_details t on p.id = t.product_id " +
                     "WHERE s.invoice_status = 2 " +
                     "AND (date(s.sale_date) between COALESCE(NULLIF('" + filterList[0] + "',''),'" + Consts.DEFAULTDATE + "') " +
                     "AND COALESCE(NULLIF('" + filterList[1] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "'))) group by det.product_id ,c.name   ORDER BY total_quantity DESC LIMIT " + filterList[4] + " ;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSearchResultForProfitLossList
        /// </summary>
        /// <param name="filterList"></param>
        /// <returns></returns>
        public DataTable GetSearchResultForProfitLossList(List<object>filterList)
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER by v_stock.product_id ASC) AS sr, m_category.name AS category_name, m_product.product_name AS name, v_stock.product_id, v_stock.total_purchase_price AS purchase_price, " +
                "v_stock.p_qty AS purchase_qty, SUM(v_sale.total_sale_price) AS sale_price,SUM( v_sale.s_qty )AS sale_qty, " +
                "(SUM(v_sale.total_sale_price) - v_stock.total_purchase_price) as profitandloss  " +
                "FROM v_stock JOIN v_sale ON v_stock.product_id = v_sale.product_id " +
                "JOIN m_product ON v_stock.product_id = m_product.id JOIN m_category ON m_product.category_id = m_category.id " +
                "WHERE (m_category.id = " + filterList[2] + " OR 0 = " + filterList[2] + ") " +
                "AND (m_product.id = " + filterList[3] + " OR 0 = " + filterList[3] + ") " +
                "AND (date(v_sale.sale_date) between COALESCE(NULLIF('" + filterList[0] + "',''),'" + Consts.DEFAULTDATE + "') " +
                "AND COALESCE(NULLIF('" + filterList[1] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "'))) " +
                "group by m_category.name,m_product.product_name,v_stock.product_id,v_stock.total_purchase_price,v_stock.p_qty";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetTopTenSaleProductXLSX
        /// </summary>
        /// <returns></returns>
        public DataTable GetTopTenSaleProductXLSX(int pageCount)
        {
            strSql = " SELECT ROW_NUMBER() OVER (ORDER by SUM(det.quantity) DESC) AS sr,p.product_code,p.product_name as name,date(t.mfd_date) as mfd_date,date(t.expired_date) as expire_date, " +
                      " SUM(det.quantity )As total_quantity  FROM t_sale s   " +
                      "LEFT JOIN t_sale_details det ON s.id = det.sale_id  " +
                      "LEFT JOIN m_staff st on s.staff_id = st.id " +
                      "LEFT join m_product p on det.product_id = p.id " +
                      "LEFT join m_category c on p.category_id = c.id " +
                      "LEFT join t_stock_details t on p.id = t.product_id " +
                      "WHERE s.invoice_status = 2 group by det.product_id ,c.name ORDER BY total_quantity DESC LIMIT " + pageCount + ";";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        
        /// <summary>
        /// GetTopTenSaleProductXLSX
        /// </summary>
        /// <returns></returns>
        public DataTable GetProfitLossXLSX()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER by v_stock.product_id ASC) AS sr, m_category.name AS category_name, m_product.product_name AS name, v_stock.product_id, v_stock.total_purchase_price AS purchase_price, " +
                "v_stock.p_qty AS purchase_qty, v_sale.total_sale_price AS sale_price, v_sale.s_qty AS sale_qty, " +
                "(v_sale.total_sale_price - v_stock.total_purchase_price) as profitandloss " +
                "FROM v_stock JOIN v_sale ON v_stock.product_id = v_sale.product_id " +
                "JOIN m_product ON v_stock.product_id = m_product.id JOIN m_category ON m_product.category_id = m_category.id; ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetRptTotalSale
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptTotalSale()
        {
            strSql = "SELECT date(s.sale_date)As Sale_Date,st.name As Name ,SUM(det.price * det.quantity)As Total_Amount, " +
                     "SUM(det.quantity )As Sale_Quantity , SUM(det.quantity )As Sale_Return_Quantity , SUM(det.quantity )As Sale_Cancel_Process  FROM t_sale s  " +
                     "JOIN t_sale_details det ON s.id = det.sale_id  " +
                     "JOIN m_staff st on s.staff_id = st.id  " +
                     "WHERE s.invoice_status = 2 group by s.sale_date;";
            return connection.ExecuteDataSet(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetRptTopTenSaleProductList
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptTopTenSaleProductList(int pageCount)
        {
            strSql = " SELECT p.product_code,p.product_name as name,c.name as category_name,st.name as shop_name,p.product_description as description,date(t.mfd_date) as mfd_date,date(t.expired_date) as expire_date, " +
                      " SUM(det.quantity )As total_quantity  FROM t_sale s   " +
                      "LEFT JOIN t_sale_details det ON s.id = det.sale_id  " +
                      "LEFT JOIN m_staff st on s.staff_id = st.id " +
                      "LEFT join m_product p on det.product_id = p.id " +
                      "LEFT join m_category c on p.category_id = c.id " +
                      "LEFT join t_stock_details t on p.id = t.product_id " +
                      "WHERE s.invoice_status = 2 group by det.product_id ,c.name   ORDER BY total_quantity DESC LIMIT " + pageCount + ";";

            return connection.ExecuteDataSet(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetTopTenSaleProductList
        /// </summary>
        /// <returns></returns>
        public DataTable GetTopTenSaleProductLists()
        {
            //strSql = " SELECT ROW_NUMBER() OVER (ORDER by SUM(det.quantity) DESC) AS sr, p.product_code,p.product_name as name,c.name as category_name,st.name as shop_name,p.product_description as description,date(t.mfd_date) as mfd_date,date(t.expired_date) as expire_date, " +
            //          " SUM(det.quantity )As total_quantity  FROM t_sale s   " +
            //          "JOIN t_sale_details det ON s.id = det.sale_id  " +
            //          "JOIN m_staff st on s.staff_id = st.id " +
            //          "join m_product p on det.product_id = p.id " +
            //          "join m_category c on p.category_id = c.id " +
            //          "join t_stock_details t on p.id = t.product_id " +
            //          "WHERE s.invoice_status = 2 group by det.product_id ,c.name   ORDER BY total_quantity DESC LIMIT 10 "; 

            strSql = "   SELECT ROW_NUMBER() OVER (ORDER by SUM(det.quantity) DESC) AS sr, p.product_code,p.product_name as name, " +
                "c.name as category_name,st.name as shop_name,p.product_description as description,date(t.mfd_date) as mfd_date," +
                " date(t.expired_date) as expire_date,  SUM(det.quantity)As total_quantity FROM t_sale s " +
                "Left JOIN t_sale_details det ON s.id = det.sale_id Left JOIN m_staff st on s.staff_id = st.id " +
                "Left join m_product p on det.product_id = p.id Left join m_category c on p.category_id = c.id " +
                "Left join t_stock_details t on p.id = t.product_id " +
                "WHERE s.invoice_status = 2 group by det.product_id ,c.name " +
                "ORDER BY total_quantity DESC --LIMIT 10";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetProfitLossReport
        /// </summary>
        /// <returns></returns>
        public DataTable GetProfitLossReport()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER by v_stock.product_id ASC) AS sr, m_category.name AS category_name, m_product.product_name AS name, v_stock.product_id, v_stock.total_purchase_price AS purchase_price, " +
                "v_stock.p_qty AS purchase_qty, v_sale.total_sale_price AS sale_price, v_sale.s_qty AS sale_qty, " +
                "(v_sale.total_sale_price - v_stock.total_purchase_price) as profitandloss " +
                "FROM v_stock JOIN v_sale ON v_stock.product_id = v_sale.product_id " +
                "JOIN m_product ON v_stock.product_id = m_product.id JOIN m_category ON m_product.category_id = m_category.id; ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }


        /// <summary>
        /// GetRptProfitLossReport
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptProfitLossReport(List<object> filterList)
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER by v_stock.product_id ASC) AS sr, m_category.name AS category_name, m_product.product_name AS name, v_stock.product_id, v_stock.total_purchase_price AS purchase_price, " +
                "v_stock.p_qty AS purchase_qty, SUM(v_sale.total_sale_price) AS sale_price,SUM( v_sale.s_qty )AS sale_qty, " +
                "(SUM(v_sale.total_sale_price) - v_stock.total_purchase_price) as profitandloss  " +
                "FROM v_stock JOIN v_sale ON v_stock.product_id = v_sale.product_id " +
                "JOIN m_product ON v_stock.product_id = m_product.id JOIN m_category ON m_product.category_id = m_category.id " +
                "WHERE (m_category.id = " + filterList[2] + " OR 0 = " + filterList[2] + ") " +
                "AND (m_product.id = " + filterList[3] + " OR 0 = " + filterList[3] + ") " +
                "AND (date(v_sale.sale_date) between COALESCE(NULLIF('" + filterList[0] + "',''),'" + Consts.DEFAULTDATE + "') " +
                "AND COALESCE(NULLIF('" + filterList[1] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "'))) " +
                "group by m_category.name,m_product.product_name,v_stock.product_id,v_stock.total_purchase_price,v_stock.p_qty";

            return connection.ExecuteDataSet(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetYearlySale.
        /// </summary>
        /// <returns>The <see cref="DataSet"/>.</returns>
        public DataSet GetYearlySale()
        {
            strSql = "SELECT sale_year, " +
                     "SUM(jan)Jan, " +
                     "SUM(feb)Feb, " +
                     "SUM(mar)Mar, " +
                     "SUM(apr)Apr, " +
                     "SUM(may)May, " +
                     "SUM(jun)Jun, " +
                     "SUM(jul)Jul, " +
                     "SUM(aug)Aug, " +
                     "SUM(sep)Sep, " +
                     "SUM(oct)Oct, " +
                     "SUM(nov)Nov, " +
                     "SUM(dece)Dece , " +
                     "(SUM(COALESCE(jan, '0')) " +
                     "+ SUM(COALESCE(feb, '0')) " +
                     "+ SUM(COALESCE(mar, '0')) " +
                     "+ SUM(COALESCE(apr, '0')) " +
                     "+ SUM(COALESCE(may, '0')) " +
                     "+ SUM(COALESCE(jun, '0')) " +
                     "+ SUM(COALESCE(jul, '0')) " +
                     "+ SUM(COALESCE(aug, '0')) " +
                     "+ SUM(COALESCE(sep, '0')) " +
                     "+ SUM(COALESCE(oct, '0')) " +
                     "+ SUM(COALESCE(nov, '0')) " +
                     "+ SUM(COALESCE(dece, '0'))) total " +
                     " From(SELECT " +
                     " strftime('%Y', sale_date) sale_year," +
                     " CASE WHEN strftime('%m', sale_date) = '01' Then amount End jan," +
                     " CASE WHEN strftime('%m', sale_date) = '02' Then amount End feb," +
                     " CASE WHEN strftime('%m', sale_date) = '03' Then amount End mar," +
                     " CASE WHEN strftime('%m', sale_date) = '04' Then amount End apr," +
                     " CASE WHEN strftime('%m', sale_date) = '05' Then amount End may," +
                     " CASE WHEN strftime('%m', sale_date) = '06' Then amount End jun," +
                     " CASE WHEN strftime('%m', sale_date) = '07' Then amount End jul," +
                     " CASE WHEN strftime('%m', sale_date) = '08' Then amount End aug," +
                     " CASE WHEN strftime('%m', sale_date) = '09' Then amount End sep," +
                     " CASE WHEN strftime('%m', sale_date) = '10' Then amount End oct," +
                     " CASE WHEN strftime('%m', sale_date) = '11' Then amount End nov," +
                     " CASE WHEN strftime('%m', sale_date) = '12' Then amount End dece" +
                     " FROM t_sale where invoice_status = 2 ) ts  Group by sale_year;";
            return connection.ExecuteDataSet(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetYearlyXLSXData
        /// </summary>
        /// <returns></returns>
        public DataTable GetYearlyXLSXData()
        {
            strSql = "SELECT Sale_Year, " +
                     "SUM(jan)Jan, " +
                     "SUM(feb)Feb, " +
                     "SUM(mar)Mar, " +
                     "SUM(apr)Apr, " +
                     "SUM(may)May, " +
                     "SUM(jun)Jun, " +
                     "SUM(jul)Jul, " +
                     "SUM(aug)Aug, " +
                     "SUM(sep)Sep, " +
                     "SUM(oct)Oct, " +
                     "SUM(nov)Nov, " +
                     "SUM(dece)Dece , " +
                     "(SUM(COALESCE(jan, '0')) " +
                     "+ SUM(COALESCE(feb, '0')) " +
                     "+ SUM(COALESCE(mar, '0')) " +
                     "+ SUM(COALESCE(apr, '0')) " +
                     "+ SUM(COALESCE(may, '0')) " +
                     "+ SUM(COALESCE(jun, '0')) " +
                     "+ SUM(COALESCE(jul, '0')) " +
                     "+ SUM(COALESCE(aug, '0')) " +
                     "+ SUM(COALESCE(sep, '0')) " +
                     "+ SUM(COALESCE(oct, '0')) " +
                     "+ SUM(COALESCE(nov, '0')) " +
                     "+ SUM(COALESCE(dece, '0'))) Total " +
                     " From(SELECT " +
                     " strftime('%Y', sale_date) Sale_Year," +
                     " CASE WHEN strftime('%m', sale_date) = '01' Then amount End jan," +
                     " CASE WHEN strftime('%m', sale_date) = '02' Then amount End feb," +
                     " CASE WHEN strftime('%m', sale_date) = '03' Then amount End mar," +
                     " CASE WHEN strftime('%m', sale_date) = '04' Then amount End apr," +
                     " CASE WHEN strftime('%m', sale_date) = '05' Then amount End may," +
                     " CASE WHEN strftime('%m', sale_date) = '06' Then amount End jun," +
                     " CASE WHEN strftime('%m', sale_date) = '07' Then amount End jul," +
                     " CASE WHEN strftime('%m', sale_date) = '08' Then amount End aug," +
                     " CASE WHEN strftime('%m', sale_date) = '09' Then amount End sep," +
                     " CASE WHEN strftime('%m', sale_date) = '10' Then amount End oct," +
                     " CASE WHEN strftime('%m', sale_date) = '11' Then amount End nov," +
                     " CASE WHEN strftime('%m', sale_date) = '12' Then amount End dece" +
                     " FROM t_sale where invoice_status = 2 ) ts  Group by Sale_Year;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetYearlySaleTotal
        /// </summary>
        /// <returns></returns>
        public DataTable GetYearlySaleTotal()
        {
            strSql = "SELECT sale_year, " +
                     "SUM(jan)Jan, " +
                     "SUM(feb)Feb, " +
                     "SUM(mar)Mar, " +
                     "SUM(apr)Apr, " +
                     "SUM(may)May, " +
                     "SUM(jun)Jun, " +
                     "SUM(jul)Jul, " +
                     "SUM(aug)Aug, " +
                     "SUM(sep)Sep, " +
                     "SUM(oct)Oct, " +
                     "SUM(nov)Nov, " +
                     "SUM(dece)Dece , " +
                     "(SUM(COALESCE(jan, '0')) " +
                     "+ SUM(COALESCE(feb, '0')) " +
                     "+ SUM(COALESCE(mar, '0')) " +
                     "+ SUM(COALESCE(apr, '0')) " +
                     "+ SUM(COALESCE(may, '0')) " +
                     "+ SUM(COALESCE(jun, '0')) " +
                     "+ SUM(COALESCE(jul, '0')) " +
                     "+ SUM(COALESCE(aug, '0')) " +
                     "+ SUM(COALESCE(sep, '0')) " +
                     "+ SUM(COALESCE(oct, '0')) " +
                     "+ SUM(COALESCE(nov, '0')) " +
                     "+ SUM(COALESCE(dece, '0'))) total " +
                     " From(SELECT " +
                     " strftime('%Y', sale_date) sale_year," +
                     " CASE WHEN strftime('%m', sale_date) = '01' Then amount End jan," +
                     " CASE WHEN strftime('%m', sale_date) = '02' Then amount End feb," +
                     " CASE WHEN strftime('%m', sale_date) = '03' Then amount End mar," +
                     " CASE WHEN strftime('%m', sale_date) = '04' Then amount End apr," +
                     " CASE WHEN strftime('%m', sale_date) = '05' Then amount End may," +
                     " CASE WHEN strftime('%m', sale_date) = '06' Then amount End jun," +
                     " CASE WHEN strftime('%m', sale_date) = '07' Then amount End jul," +
                     " CASE WHEN strftime('%m', sale_date) = '08' Then amount End aug," +
                     " CASE WHEN strftime('%m', sale_date) = '09' Then amount End sep," +
                     " CASE WHEN strftime('%m', sale_date) = '10' Then amount End oct," +
                     " CASE WHEN strftime('%m', sale_date) = '11' Then amount End nov," +
                     " CASE WHEN strftime('%m', sale_date) = '12' Then amount End dece" +
                     " FROM t_sale where invoice_status = 2 ) ts  Group by sale_year;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetTotalYearlyAmount
        /// </summary>
        /// <returns></returns>
        public int GetTotalYearlyAmount()
        {
            strSql = "SELECT (SUM(COALESCE(jan, '0')) " +
                     "+ SUM(COALESCE(feb, '0')) " +
                     "+ SUM(COALESCE(mar, '0')) " +
                     "+ SUM(COALESCE(apr, '0')) " +
                     "+ SUM(COALESCE(may, '0')) " +
                     "+ SUM(COALESCE(jun, '0')) " +
                     "+ SUM(COALESCE(jul, '0')) " +
                     "+ SUM(COALESCE(aug, '0')) " +
                     "+ SUM(COALESCE(sep, '0')) " +
                     "+ SUM(COALESCE(oct, '0')) " +
                     "+ SUM(COALESCE(nov, '0')) " +
                     "+ SUM(COALESCE(dece, '0'))) total " +
                     " From(SELECT " +
                     " CASE WHEN strftime('%m', sale_date) = '01' Then amount End jan," +
                     " CASE WHEN strftime('%m', sale_date) = '02' Then amount End feb," +
                     " CASE WHEN strftime('%m', sale_date) = '03' Then amount End mar," +
                     " CASE WHEN strftime('%m', sale_date) = '04' Then amount End apr," +
                     " CASE WHEN strftime('%m', sale_date) = '05' Then amount End may," +
                     " CASE WHEN strftime('%m', sale_date) = '06' Then amount End jun," +
                     " CASE WHEN strftime('%m', sale_date) = '07' Then amount End jul," +
                     " CASE WHEN strftime('%m', sale_date) = '08' Then amount End aug," +
                     " CASE WHEN strftime('%m', sale_date) = '09' Then amount End sep," +
                     " CASE WHEN strftime('%m', sale_date) = '10' Then amount End oct," +
                     " CASE WHEN strftime('%m', sale_date) = '11' Then amount End nov," +
                     " CASE WHEN strftime('%m', sale_date) = '12' Then amount End dece" +
                     " FROM t_sale where invoice_status = 2 ) ts;";
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
        }

        #endregion

        #region==========Product========== 
        /// <summary>
        /// The GetSaleDetailsByProductId.
        /// </summary>
        /// <param name="productId">The productId<see cref="Int64"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetSaleDetailsByProductId(Int64 productId)
        {
            strSql = "SELECT count(*) FROM t_sale_details where product_id = @product_id;";

            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@product_id", productId)
                                               };

            int saleDetailsCount = Convert.ToInt32(connection.ExecuteScalar
                (CommandType.Text, strSql, SqliteParams));

            return saleDetailsCount;
        }
        #endregion

        #region==========Payment==========
        /// <summary>
        /// GetPaymentType
        /// </summary>
        /// <param name="saleId"></param>
        /// <returns></returns>
        public int GetPaymentType(Int64 saleId)
        {
            strSql = "SELECT payment_type from m_payment WHERE sale_id = @sale_id;";

            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@sale_id", saleId)
                                               };

            int paymentType = Convert.ToInt32(connection.ExecuteScalar
                (CommandType.Text, strSql, SqliteParams));

            return paymentType;
        }

        /// <summary>
        /// AddPaidAmount
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="saleId"></param>
        /// <param name="paymentDate"></param>
        /// <param name="paymentType"></param>
        public void AddPaidAmount(string amount,Int64 saleId, DateTime? paymentDate, int paymentType)
        {
            strSql = "UPDATE m_payment Set paid_amount = paid_amount + @amount, payment_date = @paymentDate" + 
                     ", payment_type = @paymentType WHERE sale_id = @saleId ";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@amount", amount),
                                                new SQLiteParameter("@paymentDate", paymentDate),
                                                new SQLiteParameter("@paymentType", paymentType),
                                                new SQLiteParameter("@saleId", saleId),
                                              };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }
        #endregion

        #region==========Monthly Sale Report========== 
        /// <summary>
        /// GetMonthlySale
        /// </summary>
        /// <returns></returns>
        public DataTable GetMonthlySale()
        {
            strSql = "SELECT 'Monthly Amount' monthly_amount, COALESCE(SUM(jan), 0) Jan, COALESCE(SUM(feb),0) Feb, COALESCE(SUM(mar),0) Mar, COALESCE(SUM(apr), 0) Apr, COALESCE(SUM(may), 0) May," +
                " COALESCE(SUM(jun), 0) Jun, COALESCE(SUM(jul), 0) Jul, COALESCE(SUM(aug), 0) Aug, COALESCE(SUM(sep), 0) Sep, COALESCE(SUM(oct), 0) Oct," +
                " COALESCE(SUM(nov), 0) Nov, COALESCE(SUM(dece), 0) Dece , (SUM(COALESCE(jan, '0')) + SUM(COALESCE(feb, '0')) + SUM(COALESCE(mar, '0')) + SUM(COALESCE(apr, '0')) + SUM(COALESCE(may, '0')) + SUM(COALESCE(jun, '0')) + SUM(COALESCE(jul, '0')) + SUM(COALESCE(aug, '0')) + SUM(COALESCE(sep, '0')) + SUM(COALESCE(oct, '0')) + SUM(COALESCE(nov, '0')) + SUM(COALESCE(dece, '0'))) total " +
                "From(SELECT  CASE WHEN strftime('%m', sale_date) = '01' Then amount End jan, CASE WHEN strftime('%m', sale_date) = '02' Then amount End feb," +
                " CASE WHEN strftime('%m', sale_date) = '03' Then amount End mar, CASE WHEN strftime('%m', sale_date) = '04' Then amount End apr, " +
                "CASE WHEN strftime('%m', sale_date) = '05' Then amount End may, CASE WHEN strftime('%m', sale_date) = '06' Then amount End jun, " +
                "CASE WHEN strftime('%m', sale_date) = '07' Then amount End jul, CASE WHEN strftime('%m', sale_date) = '08' Then amount End aug, " +
                "CASE WHEN strftime('%m', sale_date) = '09' Then amount End sep, CASE WHEN strftime('%m', sale_date) = '10' Then amount End oct, " +
                "CASE WHEN strftime('%m', sale_date) = '11' Then amount End nov, CASE WHEN strftime('%m', sale_date) = '12' Then amount End dece " +
                "FROM t_sale WHERE invoice_status = 2   AND sale_date BETWEEN date('now', 'start of year') AND date('now', '1 year')) ts;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetMonthlySale
        /// </summary>
        /// <returns></returns>
        public DataTable GetMonthlySaleMM()
        {
            strSql = "SELECT 'လစဥ်ရောင်းရပမာဏ' monthly_amount, COALESCE(SUM(jan), 0) Jan, COALESCE(SUM(feb),0) Feb, COALESCE(SUM(mar),0) Mar, COALESCE(SUM(apr), 0) Apr, COALESCE(SUM(may), 0) May," +
                " COALESCE(SUM(jun), 0) Jun, COALESCE(SUM(jul), 0) Jul, COALESCE(SUM(aug), 0) Aug, COALESCE(SUM(sep), 0) Sep, COALESCE(SUM(oct), 0) Oct," +
                " COALESCE(SUM(nov), 0) Nov, COALESCE(SUM(dece), 0) Dece , (SUM(COALESCE(jan, '0')) + SUM(COALESCE(feb, '0')) + SUM(COALESCE(mar, '0')) + SUM(COALESCE(apr, '0')) + SUM(COALESCE(may, '0')) + SUM(COALESCE(jun, '0')) + SUM(COALESCE(jul, '0')) + SUM(COALESCE(aug, '0')) + SUM(COALESCE(sep, '0')) + SUM(COALESCE(oct, '0')) + SUM(COALESCE(nov, '0')) + SUM(COALESCE(dece, '0'))) total " +
                "From(SELECT  CASE WHEN strftime('%m', sale_date) = '01' Then amount End jan, CASE WHEN strftime('%m', sale_date) = '02' Then amount End feb," +
                " CASE WHEN strftime('%m', sale_date) = '03' Then amount End mar, CASE WHEN strftime('%m', sale_date) = '04' Then amount End apr, " +
                "CASE WHEN strftime('%m', sale_date) = '05' Then amount End may, CASE WHEN strftime('%m', sale_date) = '06' Then amount End jun, " +
                "CASE WHEN strftime('%m', sale_date) = '07' Then amount End jul, CASE WHEN strftime('%m', sale_date) = '08' Then amount End aug, " +
                "CASE WHEN strftime('%m', sale_date) = '09' Then amount End sep, CASE WHEN strftime('%m', sale_date) = '10' Then amount End oct, " +
                "CASE WHEN strftime('%m', sale_date) = '11' Then amount End nov, CASE WHEN strftime('%m', sale_date) = '12' Then amount End dece " +
                "FROM t_sale WHERE invoice_status = 2   AND sale_date BETWEEN date('now', 'start of year') AND date('now', '1 year')) ts;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetRptTotalSale
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptMonthlySale()
        {
            strSql = "SELECT COALESCE(SUM(jan), 0) Jan, COALESCE(SUM(feb),0) Feb, COALESCE(SUM(mar),0) Mar, COALESCE(SUM(apr), 0) Apr, COALESCE(SUM(may), 0) May," +
                " COALESCE(SUM(jun), 0) Jun, COALESCE(SUM(jul), 0) Jul, COALESCE(SUM(aug), 0) Aug, COALESCE(SUM(sep), 0) Sep, COALESCE(SUM(oct), 0) Oct," +
                " COALESCE(SUM(nov), 0) Nov, COALESCE(SUM(dece), 0) Dece , (SUM(COALESCE(jan, '0')) + SUM(COALESCE(feb, '0')) + SUM(COALESCE(mar, '0')) + SUM(COALESCE(apr, '0')) + SUM(COALESCE(may, '0')) + SUM(COALESCE(jun, '0')) + SUM(COALESCE(jul, '0')) + SUM(COALESCE(aug, '0')) + SUM(COALESCE(sep, '0')) + SUM(COALESCE(oct, '0')) + SUM(COALESCE(nov, '0')) + SUM(COALESCE(dece, '0'))) total " +
                "From(SELECT  CASE WHEN strftime('%m', sale_date) = '01' Then amount End jan, CASE WHEN strftime('%m', sale_date) = '02' Then amount End feb," +
                " CASE WHEN strftime('%m', sale_date) = '03' Then amount End mar, CASE WHEN strftime('%m', sale_date) = '04' Then amount End apr, " +
                "CASE WHEN strftime('%m', sale_date) = '05' Then amount End may, CASE WHEN strftime('%m', sale_date) = '06' Then amount End jun, " +
                "CASE WHEN strftime('%m', sale_date) = '07' Then amount End jul, CASE WHEN strftime('%m', sale_date) = '08' Then amount End aug, " +
                "CASE WHEN strftime('%m', sale_date) = '09' Then amount End sep, CASE WHEN strftime('%m', sale_date) = '10' Then amount End oct, " +
                "CASE WHEN strftime('%m', sale_date) = '11' Then amount End nov, CASE WHEN strftime('%m', sale_date) = '12' Then amount End dece " +
                "FROM t_sale WHERE invoice_status = 2   AND sale_date BETWEEN date('now', 'start of year') AND date('now', '1 year')) ts;";
            return connection.ExecuteDataSet(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetXLSXMonthlyData
        /// </summary>
        /// <returns></returns>
        public DataTable GetXLSXMonthlyData()
        {
            strSql = "SELECT COALESCE(SUM(jan), 0) Jan, COALESCE(SUM(feb),0) Feb, COALESCE(SUM(mar),0) Mar, COALESCE(SUM(apr), 0) Apr, COALESCE(SUM(may), 0) May," +
                " COALESCE(SUM(jun), 0) Jun, COALESCE(SUM(jul), 0) Jul, COALESCE(SUM(aug), 0) Aug, COALESCE(SUM(sep), 0) Sep, COALESCE(SUM(oct), 0) Oct," +
                " COALESCE(SUM(nov), 0) Nov, COALESCE(SUM(dece), 0) Dece , (SUM(COALESCE(jan, '0')) + SUM(COALESCE(feb, '0')) + SUM(COALESCE(mar, '0')) + SUM(COALESCE(apr, '0')) + SUM(COALESCE(may, '0')) + SUM(COALESCE(jun, '0')) + SUM(COALESCE(jul, '0')) + SUM(COALESCE(aug, '0')) + SUM(COALESCE(sep, '0')) + SUM(COALESCE(oct, '0')) + SUM(COALESCE(nov, '0')) + SUM(COALESCE(dece, '0'))) total " +
                "From(SELECT  CASE WHEN strftime('%m', sale_date) = '01' Then amount End jan, CASE WHEN strftime('%m', sale_date) = '02' Then amount End feb," +
                " CASE WHEN strftime('%m', sale_date) = '03' Then amount End mar, CASE WHEN strftime('%m', sale_date) = '04' Then amount End apr, " +
                "CASE WHEN strftime('%m', sale_date) = '05' Then amount End may, CASE WHEN strftime('%m', sale_date) = '06' Then amount End jun, " +
                "CASE WHEN strftime('%m', sale_date) = '07' Then amount End jul, CASE WHEN strftime('%m', sale_date) = '08' Then amount End aug, " +
                "CASE WHEN strftime('%m', sale_date) = '09' Then amount End sep, CASE WHEN strftime('%m', sale_date) = '10' Then amount End oct, " +
                "CASE WHEN strftime('%m', sale_date) = '11' Then amount End nov, CASE WHEN strftime('%m', sale_date) = '12' Then amount End dece " +
                "FROM t_sale WHERE invoice_status = 2   AND sale_date BETWEEN date('now', 'start of year') AND date('now', '1 year')) ts;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        #endregion
    }
}
