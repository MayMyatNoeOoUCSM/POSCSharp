namespace Services.Supplier

{
    using DAO.Supplier;
    using Entities.Supplier;
    using System;
    using System.Data;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="SupplierService" />.
    /// </summary>
    public class SupplierService
    {
        /// <summary>
        /// define categoryDao..
        /// </summary>
        private SupplierDao supplierDao = new SupplierDao();

        /// <summary>
        /// Defines the existCount.
        /// </summary>
        private int existCount;

        /// <summary>
        /// SetCategory.
        /// </summary>
        /// <param name="supplierEntity">.</param>
        public bool SaveSupplier(SupplierEntity supplierEntity)
        {
            return supplierDao.CreateSupplier(supplierEntity);
        }

        /// <summary>
        /// UpdateCategory.
        /// </summary>
        /// <param name="supplierEntity">.</param>
        public bool UpdateSupplier(SupplierEntity supplierEntity)
        {
            return supplierDao.Update(supplierEntity);
        }

        /// <summary>
        /// DeleteCategory.
        /// </summary>
        /// <param name="supplierId">.</param>
        public bool DeleteSupplier(Int64 supplierId)
        {
            return supplierDao.Delete(supplierId);
        }

        public int GetSupplierId(int supplierId)
        {
            var resultValue = supplierDao.GetSupplierId(supplierId);
            int supplierID = resultValue != DBNull.Value ? Convert.ToInt32(resultValue) : 0;
            return supplierID;
        }

        /// <summary>
        /// GetCategoryList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetSupplierList()
        {
            return supplierDao.GetSupplierList();
        }

        /// <summary>
        /// CheckExistCategoryName.
        /// </summary>
        /// <param name="supplierName">.</param>
        /// <returns>.</returns>
        public bool IsExistSupplierName(string supplierName)
        {
            existCount = supplierDao.IsExistSupplierName(supplierName);
            if (existCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetSearchResult(string supplierName)
        {
            return supplierDao.GetSearchResult(supplierName);
        }

        public int GetSupplierCountInProduct(Int64 supplierId)
        {
            int supplierCount = supplierDao.GetSupplierCountInProduct(supplierId);
            return supplierCount;
        }

        public DataTable GetSupplierName()
        {
            return supplierDao.GetSupplierName();
        }
        public DataTable GetSupplierPayment(List<object> filterlist)
        {
            return supplierDao.GetSupplierPayment(filterlist);
        }
        public DataTable GetSupplierPaymentList()
        {
            return supplierDao.GetSupplierPaymentList();
        }

        public DataTable GetSupplierPaymentXLSX()
        {
            return supplierDao.GetSupplierPaymentXLSX();
        }

        public DataSet GetSupplierPaymentReport()
        {
            return supplierDao.GetSupplierPaymentReport();
        }

    }
}
