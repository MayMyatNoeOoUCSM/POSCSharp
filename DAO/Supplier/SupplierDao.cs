using System.Data.SQLite;
using DAO.Common;
using Entities.Supplier;
using System;
using System.Data;
using System.Collections.Generic;

namespace DAO.Supplier
{
    public class SupplierDao
    {
        /// <summary>
        /// Defines the Database Connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the existCount.
        /// </summary>
        private int existCount;

        /// <summary>
        /// CreateSupplier.
        /// </summary>
        /// <param name="supplierEntity">.</param>
        public bool CreateSupplier(SupplierEntity supplierEntity)
        {
            strSql = "INSERT INTO m_supplier(supplier_name, supplier_description, phone_no, email, address, is_deleted," +
                     "created_user_id,updated_user_id,created_datetime,updated_datetime) " +
                     "VALUES(@supplier_name,@supplier_description, @phone_no, @email, @address, @is_deleted," +
                     "@created_user_id,@updated_user_id,@created_datetime,@updated_datetime)";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@supplier_name", supplierEntity.supplier_name),
                    new SQLiteParameter("@supplier_description", supplierEntity.supplier_description),
                    new SQLiteParameter("@phone_no", supplierEntity.phone_no),
                    new SQLiteParameter("@email", supplierEntity.email),
                    new SQLiteParameter("@address", supplierEntity.address),
                    new SQLiteParameter("@is_deleted", supplierEntity.is_deleted),
                    new SQLiteParameter ("@created_user_id",supplierEntity.created_user_id),
                    new SQLiteParameter ("@updated_user_id",supplierEntity.updated_user_id),
                    new SQLiteParameter ("@created_datetime",supplierEntity.created_datetime),
                    new SQLiteParameter ("@updated_datetime",supplierEntity.updated_datetime)
                };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// GetSupplierList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetSupplierList()
        {
            strSql = "SELECT ROW_NUMBER()  OVER (ORDER BY  id) AS sr, id, supplier_name, supplier_description, " +
                "phone_no, email, address FROM m_supplier WHERE is_deleted = 0 ORDER BY id, supplier_name ASC;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSupplierId
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public object GetSupplierId(int supplierId)
        {
            strSql = " SELECT id from m_supplier WHERE id = @id;";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", supplierId)
                                             };
            return connection.ExecuteScalar(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="supplierEntity">.</param>
        public bool Update(SupplierEntity supplierEntity)
        {
            strSql = "UPDATE m_supplier SET supplier_name = @supplier_name, supplier_description = @supplier_description, " +
                     "phone_no = @phone_no, email = @email, address = @address, is_deleted = @is_deleted, " +
                     " updated_user_id = @updated_user_id, updated_datetime = @updated_datetime " +
                     " WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@id", supplierEntity.id),
                    new SQLiteParameter("@supplier_name", supplierEntity.supplier_name),
                    new SQLiteParameter("@supplier_description", supplierEntity.supplier_description),
                    new SQLiteParameter("@phone_no", supplierEntity.phone_no),
                    new SQLiteParameter("@email", supplierEntity.email),
                    new SQLiteParameter("@address", supplierEntity.address),
                    new SQLiteParameter("@is_deleted", supplierEntity.is_deleted),
                    new SQLiteParameter ("@updated_user_id",supplierEntity.updated_user_id),
                    new SQLiteParameter("@updated_datetime",supplierEntity.updated_datetime)
                };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="supplierId">.</param>
        public bool Delete(Int64 supplierId)
        {
            strSql = "UPDATE m_supplier SET is_deleted = 1 WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", supplierId)
                                             };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// CheckExistCategoryName.
        /// </summary>
        /// <param name="supplierName">.</param>
        /// <returns>.</returns>
        public int IsExistSupplierName(string supplierName)
        {
            strSql = "SELECT COUNT(*) FROM m_supplier " +
                     "WHERE is_deleted == 0 AND LOWER(supplier_name) = (SELECT LOWER('" + supplierName + "'));";
            existCount = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
            return existCount;
        }

        /// <summary>
        /// GetSearchResult
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public DataTable GetSearchResult(string supplierName)
        {
            strSql = "SELECT ROW_NUMBER()  OVER (ORDER BY  id) AS sr, id, supplier_name, supplier_description, phone_no, email, address " +
                "FROM m_supplier WHERE (supplier_name like '%" + supplierName + "%' OR supplier_name = '' OR supplier_name IS NULL) " +
                "AND is_deleted = 0 ORDER BY id;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSupplierCountInProduct
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public int GetSupplierCountInProduct(Int64 supplierId)
        {
            strSql = "SELECT count(*) FROM m_product WHERE supplier_id = @supplier_id;";
            SQLiteParameter[] SqliteParams = {
                                               new SQLiteParameter("@supplier_id", supplierId)
                                              };

            int supplierListCount = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, SqliteParams));

            SqliteParams = null;
            return supplierListCount;
        }

        /// <summary>
        /// GetSupplierName
        /// </summary>
        /// <returns></returns>
        public DataTable GetSupplierName()
        {
            strSql = "Select s.supplier_name , p.id FROM m_supplier s join m_product p on s.id=p.supplier_id;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSupplierPayment
        /// </summary>
        /// <param name="filterList"></param>
        /// <returns></returns>
        public DataTable GetSupplierPayment(List<object> filterList)
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER by st.id ASC) AS sr, s.supplier_name, date(pay.payment_date) as payment_date, date(st.payment_due_date) as due_date, " +
            "st.total_amount as total_amount, pay.paid_amount as paid_amount ,(st.total_amount - pay.paid_amount)as left_amount FROM t_stock st LEFT JOIN m_payment pay ON st.id = pay.stock_id " +
            "JOIN t_stock_details std ON st.id = std.stock_id " +
            "join m_product product on std.product_id = product.id join m_supplier s ON s.id = product.supplier_id " +
            "WHERE st.is_deleted = 0 " +
            "AND (s.id = " + filterList[0] + " OR 0 = " + filterList[0] + ") " +
            "AND (date(st.purchase_date) between COALESCE(NULLIF('" + filterList[1] + "',''),'" + Consts.DEFAULTDATE + "') " +
            "AND COALESCE(NULLIF('" + filterList[2] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "'))) " +
            "AND (date(st.payment_due_date) = " + filterList[3] + " OR 0 = " + filterList[3] + ") " +
            "group by st.id;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSupplierPaymentList
        /// </summary>
        /// <returns></returns>
        public DataTable GetSupplierPaymentList()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER by st.id ASC) AS sr, s.supplier_name, date(pay.payment_date) as payment_date, " +
                "date(st.payment_due_date) as due_date, st.total_amount as total_amount, pay.paid_amount as paid_amount, (st.total_amount - pay.paid_amount)as left_amount " +
                "FROM t_stock st JOIN m_payment pay on st.id = pay.stock_id " +
                "JOIN t_stock_details std on st.id = std.stock_id " +
                "join m_product product on std.product_id = product.id join m_supplier s ON s.id = product.supplier_id " +
                "where st.is_deleted = 0 "+
                "group by st.id;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSupplierPaymentXLSX
        /// </summary>
        /// <returns></returns>
        public DataTable GetSupplierPaymentXLSX()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER by st.id ASC) AS sr, s.supplier_name, date(pay.payment_date) as payment_date, " +
                "date(st.payment_due_date) as due_date, st.total_amount as total_amount, pay.paid_amount as paid_amount, (st.total_amount - pay.paid_amount)as left_amount " +
                "FROM t_stock st JOIN m_payment pay on st.id = pay.stock_id " +
                "JOIN t_stock_details std on st.id = std.stock_id " +
                "join m_product product on std.product_id = product.id join m_supplier s ON s.id = product.supplier_id " +
                "where st.is_deleted = 0 " +
                "group by st.id;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSupplierPaymentReport
        /// </summary>
        /// <returns></returns>
        public DataSet GetSupplierPaymentReport()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER by st.id ASC) AS sr, s.supplier_name as Name, date(pay.payment_date) as Payment_Date, " +
                "date(st.payment_due_date) as Due_Date, st.total_amount as Total_Amount, pay.paid_amount as Paid_Amount, (st.total_amount - pay.paid_amount) as Left_Amount " +
                "FROM t_stock st JOIN m_payment pay on st.id = pay.stock_id " +
                "JOIN t_stock_details std on st.id = std.stock_id " +
                "join m_product product on std.product_id = product.id join m_supplier s ON s.id = product.supplier_id " +
                "where st.is_deleted = 0 " +
                "group by st.id;";
            return connection.ExecuteDataSet(CommandType.Text, strSql);
        }
    }
}
