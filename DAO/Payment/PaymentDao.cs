using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using DAO.Common;
using System.Data;
using Entities.Payment;
namespace DAO.Payment
{
    public class PaymentDao
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
        /// insert payment
        /// </summary>
        /// <param name="paymentEntity"></param>
        public void Insert(PaymentEntity paymentEntity)
        {
            strSql = "insert into m_payment(stock_id,sale_id,paid_amount,payment_type,payment_date,is_active,remark,created_user_id,updated_user_id,created_datetime,updated_datetime) " +
                     "values(@stock_id,@sale_id,@paid_amount,@payment_type,@payment_date,@is_active,@remark,@created_user_id,@updated_user_id,@created_datetime,@updated_datetime);";

            SQLiteParameter[] SqliteParams = {     

                                               new SQLiteParameter("@stock_id",(object)paymentEntity.stock_id ?? DBNull.Value),
                                               new SQLiteParameter("@sale_id",(object)paymentEntity.sale_id ?? DBNull.Value),
                                               new SQLiteParameter("@paid_amount", paymentEntity.paid_amount),
                                               new SQLiteParameter("@payment_type", paymentEntity.payment_type),
                                               new SQLiteParameter("@payment_date", paymentEntity.payment_date),
                                               new SQLiteParameter("@status","purchase"),
                                               new SQLiteParameter("@is_active", paymentEntity.is_active),
                                               new SQLiteParameter("@remark", paymentEntity.remark),
                                               new SQLiteParameter("@created_user_id", paymentEntity.created_user_id),
                                               new SQLiteParameter("@updated_user_id", paymentEntity.updated_user_id),
                                               new SQLiteParameter("@created_datetime", paymentEntity.created_datetime),
                                               new SQLiteParameter("@updated_datetime", paymentEntity.updated_datetime)
                                              };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
            SqliteParams = null;
        }

        /// <summary>
        /// Update Payment
        /// </summary>
        /// <param name="paymentEntity"></param>
        public void Update(PaymentEntity paymentEntity)
        {
            strSql = "UPDATE m_payment SET " +
                     "stock_id = @stock_id, " +
                     "sale_id = @sale_id, " +
                     "paid_amount = @paid_amount, " +
                     "payment_type = @payment_type," +
                     "payment_date = @payment_date, " +               
                     "is_active = @is_active, " +
                     "remark=@remark " +
                     "updated_user_id = @updated_user_id, " +
                     "updated_datetime=@updated_datetime " +
                     "WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                                               new SQLiteParameter("@id", paymentEntity.id),
                                               new SQLiteParameter("@stock_id",(object)paymentEntity.stock_id ?? DBNull.Value),
                                               new SQLiteParameter("@sale_id",(object)paymentEntity.sale_id ?? DBNull.Value),
                                               new SQLiteParameter("@paid_amount", paymentEntity.paid_amount),
                                               new SQLiteParameter("@payment_type", paymentEntity.payment_type),
                                               new SQLiteParameter("@payment_date", paymentEntity.payment_date),                                            
                                               new SQLiteParameter("@is_active", paymentEntity.is_active),
                                               new SQLiteParameter("@remark", paymentEntity.remark),
                                              // new SQLiteParameter("@created_user_id", paymentEntity.created_user_id),
                                               new SQLiteParameter("@updated_user_id", paymentEntity.updated_user_id),
                                               //new SQLiteParameter("@created_datetime", paymentEntity.created_datetime),
                                               new SQLiteParameter("@updated_datetime", paymentEntity.updated_datetime)
                                              };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        public void UpdateStockIsActive(Int64 stock_id)
        {
            strSql = "UPDATE m_payment SET is_active = 1 WHERE stock_id = @stock_id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@stock_id", stock_id)
                                             };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }
        public void DeleteByStockId(Int64 stock_id)
        {
            strSql = "UPDATE m_payment SET is_deleted = 1 WHERE stock_id = @stock_id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@stock_id", stock_id)
                                             };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }
        /// <summary>
        /// GetPaymentByTranId
        /// </summary>
        /// <param name="stock_id"></param>
        public DataTable GetPaymentByStockId(int stock_id)
        {
            strSql = "SELECT id,stock_id,sale_id,paid_amount,payment_type,payment_date,is_active,remark,created_user_id,updated_user_id,created_datetime,updated_datetime FROM m_payment WHERE stock_id=" + stock_id+";";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
    }
}
