using DAO.Payment;
using Entities.Payment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Payment
{
    public class PaymentService
    {
        /// <summary>
        /// define paymentDao..
        /// </summary>
        private PaymentDao paymentDao = new PaymentDao();
        public void Insert(PaymentEntity paymentEntity)
        {
            paymentDao.Insert(paymentEntity);
        }
        public void Update(PaymentEntity paymentEntity)
        {
            paymentDao.Update(paymentEntity);
        }
        
        public void UpdateStockIsActive(int stock_id)
        {
            paymentDao.UpdateStockIsActive(stock_id);
        }
        public void DeleteByStockId(int stock_id)
        {
            paymentDao.DeleteByStockId(stock_id);
        }

        public DataTable GetPaymentByStockId(int stock_id)
        {
            return paymentDao.GetPaymentByStockId(stock_id);
        }
    }
}
