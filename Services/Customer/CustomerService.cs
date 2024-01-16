using DAO.Customer;
using Entities.Customer;
using System;
using System.Collections.Generic;
using System.Data;

namespace Services.Customer
{
    public class CustomerService
    {
        /// <summary>
        /// define customerDao..
        /// </summary>
        private CustomerDao customerDao = new CustomerDao();

        /// <summary>
        /// Defines the existCount.
        /// </summary>
        private int existCount;

        /// <summary>
        /// SetCustomer.
        /// </summary>
        /// <param name="customerEntity">.</param>
        public bool SaveCustomer(CustomerEntity customerEntity)
        {
            return customerDao.CreateCustomer(customerEntity);
        }

        /// <summary>
        /// UpdateCustomer.
        /// </summary>
        /// <param name="customerEntity">.</param>
        public bool UpdateCustomer(CustomerEntity customerEntity)
        {
            return customerDao.Update(customerEntity);
        }

        /// <summary>
        /// DeleteCustomer.
        /// </summary>
        /// <param name="customerId">.</param>
        public bool DeleteCustomer(Int64 customerId)
        {
            return customerDao.Delete(customerId);
        }

        /// <summary>
        /// GetCustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public int GetCustomerId(int customerId)
        {
            var resultValue = customerDao.GetCustomerId(customerId);
            int customerID = resultValue != DBNull.Value ? Convert.ToInt32(resultValue) : 0;
            return customerID;
        }

        /// <summary>
        /// GetCustomerList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetCustomerList()
        {
            return customerDao.GetCustomerList();
        }

        /// <summary>
        /// CheckExistCustomerName.
        /// </summary>
        /// <param name="customerName">.</param>
        /// <returns>.</returns>
        public bool IsExistCustomerName(string customerName)
        {
            existCount = customerDao.IsExistCustomerName(customerName);
            if (existCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// SearchCustomer
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public DataTable GetSearchResult(string customerName)
        {
            return customerDao.GetSearchResult(customerName);
        }

        public DataSet GetRptCustPayment()
        {
            return customerDao.GetRptCustPayment();
        }

        /// <summary>
        /// GetCustomerCountInSale
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public int GetCustomerCountInSale(Int64 customerId)
        {
            int customerCount = customerDao.GetCustomerCountInSale(customerId);
            return customerCount;
        }

        #region==========Customer Payment Report========== 

        /// <summary>
        /// GetCustomerName
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public DataTable GetCustomerName()
        {
            return customerDao.GetCustomerName();
        }

        /// <summary>
        /// GetCustPayment
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public DataTable GetCustPayment(List<object> filterlist)
        {
            return customerDao.GetCustPayment(filterlist);
        }

        /// <summary>
        /// GetCustPayment
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public DataTable GetCustPaymentList()
        {
            return customerDao.GetCustPaymentList();
        }
        #endregion
    }
}
