using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.SaleReturn;
using DAO.Stock;
using Entities.SaleReturn;
using DAO.Common;
using System.Data;
using DAO.Sale;

namespace Services.SaleReturn
{
    /// <summary>
    /// Defines the <see cref="SaleReturnService" />.
    /// </summary>
    public class SaleReturnService
    {
        /// <summary>
        /// Defines the saleReturnDao.
        /// </summary>
        private SaleReturnDao saleReturnDao = new SaleReturnDao();

        /// <summary>
        /// Defines the saleService.
        /// </summary>
        private SaleDao saleDao = new SaleDao();

        /// <summary>
        /// Defines the stockDao.
        /// </summary>
        private StockDao stockDao = new StockDao();

        /// <summary>
        /// The Confirm.
        /// </summary>
        /// <param name="saleReturnEntity">The saleReturnEntity<see cref="SaleReturnEntity"/>.</param>
        public void Confirm(SaleReturnEntity saleReturnEntity)
        {
            Consts.RETURNID = Convert.ToInt64(saleReturnDao.Confirm(saleReturnEntity));
            foreach (var saleReturnDet in saleReturnEntity.SaleReturnDetails)
            {
                saleReturnDao.AddDetails(saleReturnDet);
                saleDao.UpdateSaleDetailQuantity(saleReturnDet.sale_id, saleReturnDet.product_id, saleReturnDet.quantity);
                stockDao.UpdateSaleStockCount(saleReturnDet.product_id, saleReturnDet.quantity, 1);
            }
        }

        /// <summary>
        /// The GetSaleDetail.
        /// </summary>
        /// <param name="saleId">The saleId<see cref="Int64"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSaleDetail(Int64 saleId)
        {
            return saleReturnDao.GetSaleDetail(saleId);
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
            return saleReturnDao.GetSearchResult(invoice_number, fromDate, toDate);
        }

        /// <summary>
        /// The GetSaleReturnDetail.
        /// </summary>
        /// <param name="returnId">The invoice_number<see cref="string"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSaleReturnDetail(int returnId)
        {
            return saleReturnDao.GetSaleReturnDetail(returnId);
        }

        /// <summary>
        /// The CheckReturn.
        /// </summary>
        /// <param name="saleId">The saleId<see cref="Int64"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object CheckReturn(Int64 saleId)
        {
            return saleReturnDao.CheckReturn(saleId);
        }
    }
}
