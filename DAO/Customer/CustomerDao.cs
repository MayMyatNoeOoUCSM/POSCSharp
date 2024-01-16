using System.Data.SQLite;
using DAO.Common;
using Entities.Customer;
using System;
using System.Data;
using System.Collections.Generic;

namespace DAO.Customer
{
    public class CustomerDao
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
        /// CreateCustomer.
        /// </summary>
        /// <param name="customerEntity">.</param>
        public bool CreateCustomer(CustomerEntity customerEntity)
        {
            strSql = "INSERT INTO m_customer(customer_name, customer_description, phone_no, email, address, remark, is_deleted," +
                     "created_user_id,updated_user_id,created_datetime,updated_datetime) " +
                     "VALUES(@customer_name,@customer_description, @phone_no, @email, @address, @remark, @is_deleted," +
                     "@created_user_id,@updated_user_id,@created_datetime,@updated_datetime)";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@customer_name", customerEntity.customer_name),
                    new SQLiteParameter("@customer_description", customerEntity.customer_description),
                    new SQLiteParameter("@phone_no", customerEntity.phone_no),
                    new SQLiteParameter("@email", customerEntity.email),
                    new SQLiteParameter("@address", customerEntity.address),
                    new SQLiteParameter("@remark" , customerEntity.remark),
                    new SQLiteParameter("@is_deleted", customerEntity.is_deleted),
                    new SQLiteParameter("@created_user_id",customerEntity.created_user_id),
                    new SQLiteParameter("@updated_user_id",customerEntity.updated_user_id),
                    new SQLiteParameter("@created_datetime",customerEntity.created_datetime),
                    new SQLiteParameter("@updated_datetime",customerEntity.updated_datetime)
                };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// GetCustomerList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetCustomerList()
        {
            strSql = "SELECT ROW_NUMBER()  OVER (ORDER BY  id) AS sr, id, customer_name, customer_description, " +
                "phone_no, email, address FROM m_customer WHERE is_deleted = 0 ORDER BY id, customer_name ASC;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetCustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public object GetCustomerId(int customerId)
        {
            strSql = " SELECT id from m_customer WHERE id = @id;";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", customerId)
                                             };
            return connection.ExecuteScalar(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="customerEntity">.</param>
        public bool Update(CustomerEntity customerEntity)
        {
            strSql = "UPDATE m_customer SET customer_name = @customer_name, customer_description = @customer_description, " +
                     "phone_no = @phone_no, email = @email, address = @address, is_deleted = @is_deleted, " +
                     " updated_user_id = @updated_user_id, updated_datetime = @updated_datetime " +
                     " WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@id", customerEntity.id),
                    new SQLiteParameter("@customer_name", customerEntity.customer_name),
                    new SQLiteParameter("@customer_description", customerEntity.customer_description),
                    new SQLiteParameter("@phone_no", customerEntity.phone_no),
                    new SQLiteParameter("@email", customerEntity.email),
                    new SQLiteParameter("@address", customerEntity.address),
                    new SQLiteParameter("@is_deleted", customerEntity.is_deleted),
                    new SQLiteParameter("@updated_user_id",customerEntity.updated_user_id),
                    new SQLiteParameter("@updated_datetime",customerEntity.updated_datetime)
                };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="customerId">.</param>
        public bool Delete(Int64 customerId)
        {
            strSql = "UPDATE m_customer SET is_deleted = 1 WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", customerId)
                                             };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// CheckExistCustomerName.
        /// </summary>
        /// <param name="customerName">.</param>
        /// <returns>.</returns>
        public int IsExistCustomerName(string customerName)
        {
            strSql = "SELECT COUNT(*) FROM m_customer " +
                     "WHERE is_deleted == 0 AND LOWER(customer_name) = (SELECT LOWER('" + customerName + "'));";
            existCount = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
            return existCount;
        }

        /// <summary>
        /// GetRptCustPayment
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptCustPayment()
        {
            strSql = "SELECT c.customer_name as Customer_Name, date(p.payment_date) as Payment_Date, date(s.payment_due_date) as Payment_Due_Date, " +
                     "s.amount as Total_Amount, p.paid_amount as Paid_Amount, (s.amount - p.paid_amount) " +
                     "as Left_Amount FROM m_customer c JOIN t_sale s ON s.customer_id = c.id " +
                     "JOIN m_payment p ON p.sale_id = s.id WHERE(c.id = 0 OR 0 = 0) AND c.is_deleted = 0; ";
            return connection.ExecuteDataSet(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSearchResult
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public DataTable GetSearchResult(string customerName)
        {
            strSql = "SELECT ROW_NUMBER()  OVER (ORDER BY  id) AS sr, id, customer_name, customer_description, phone_no, email, address " +
                "FROM m_customer WHERE (customer_name like '%" + customerName + "%' OR customer_name = '' OR customer_name IS NULL) " +
                "AND is_deleted = 0 ORDER BY id;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetCustomerCountInSale
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public int GetCustomerCountInSale(Int64 customerId)
        {
            strSql = "SELECT count(*) FROM t_sale WHERE customer_id = @customer_id;";
            SQLiteParameter[] SqliteParams = {
                                               new SQLiteParameter("@customer_id", customerId)
                                              };

            int customerListCount = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, SqliteParams));

            SqliteParams = null;
            return customerListCount;
        }

        #region==========Customer Payment Report========== 

        /// <summary>
        /// GetCustomerName
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomerName()
        {
            strSql = "Select id, customer_name FROM m_customer WHERE is_deleted = 0 ORDER BY customer_name ASC;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetCustPayment
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustPayment(List<object> filterList)
        {
            //strSql = "SELECT ROW_NUMBER() OVER (ORDER by c.id ASC) AS sr, c.customer_name, p.payment_date as payment_date, s.amount as total_amt, " +
            //    "p.paid_amount as paid_amt, p.paid_amount as left_amt FROM m_customer c LEFT JOIN t_sale s ON s.customer_id = c.id " +
            //    "LEFT JOIN m_payment p ON p.tran_id = s.id WHERE (c.id = " + filterList[3] + " OR 0 = " + filterList[3] + ") AND " +
            //    "c.is_deleted = 0 AND (date(s.payment_due_date) = '" + filterList[2] + "') " +
            //    "AND (date(s.sale_date) between COALESCE(NULLIF('" + filterList[0] + "',''),'" + Consts.DEFAULTDATE + "') " +
            //    "AND COALESCE(NULLIF('" + filterList[1] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "'))) ;  ";
            
            strSql = "SELECT ROW_NUMBER() OVER (ORDER by c.id ASC) AS sr, c.customer_name, date(p.payment_date) as payment_date, s.amount as total_amt, " +
                "p.paid_amount as paid_amt, date(s.payment_due_date) as payment_due_date, coalesce(s.amount, 0) - coalesce(p.paid_amount, 0) left_amt FROM m_customer c LEFT JOIN t_sale s ON s.customer_id = c.id " +
                "LEFT JOIN m_payment p ON p.sale_id = s.id WHERE (c.id = " + filterList[3] + " OR 0 = " + filterList[3] + ") AND " +
                "c.is_deleted = 0 AND (date(s.sale_date) between COALESCE(NULLIF('" + filterList[0] + "',''),'" + Consts.DEFAULTDATE + "') " +
                "AND COALESCE(NULLIF('" + filterList[1] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "')));  ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetCustPayment
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustPaymentList()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER by c.id ASC) AS sr, c.customer_name, p.payment_date as payment_date, s.payment_due_date as payment_due_date, s.amount as total_amt, " +
                "p.paid_amount as paid_amt, coalesce(s.amount, 0) - coalesce(p.paid_amount, 0) left_amt FROM m_customer c LEFT JOIN t_sale s ON s.customer_id = c.id " +
                "LEFT JOIN m_payment p ON p.sale_id = s.id WHERE c.is_deleted = 0; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        #endregion

    }
}
