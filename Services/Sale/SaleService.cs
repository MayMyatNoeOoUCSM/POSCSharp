using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Sale;
using System.Data;

namespace Services.Sale
{
    /// <summary>
    /// Defines the <see cref="SaleService" />.
    /// </summary>
    public class SaleService
    {
        /// <summary>
        /// Defines the saleDao.
        /// </summary>
        private SaleDao saleDao = new SaleDao();

        /// <summary>
        /// The GetSaleCount.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetSaleCount()
        {
            return saleDao.GetSaleCount();
        }

        /// <summary>
        /// The GetSaleConfirmCount.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetSaleConfirmCount()
        {
            return saleDao.GetSaleConfirmCount();
        }

        /// <summary>
        /// The GetSaleList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSaleList(int startCount, int count)
        {
            return saleDao.GetSaleList(startCount, count);
        }

        /// <summary>
        /// The GetSaleConfirmList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSaleConfirmList(int startCount, int count)
        {
            return saleDao.GetSaleConfirmList(startCount, count);
        }

        /// <summary>
        /// The GetDetailCSV.
        /// </summary>
        /// <param name="saleId">The saleId<see cref="Int64"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetDetailCSV(Int64 saleId)
        {
            return saleDao.GetDetailCSV(saleId);
        }

        /// <summary>
        /// GetSaleListCSV
        /// </summary>
        /// <returns></returns>
        public DataTable GetSaleListCSV()
        {
            return saleDao.GetSaleListCSV();
        }

        /// <summary>
        /// The GetDetail.
        /// </summary>
        /// <param name="saleId">The saleId<see cref="Int64"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetDetail(Int64 saleId)
        {
            return saleDao.GetDetail(saleId);
        }

        /// <summary>
        /// The UpdatVoucher.
        /// </summary>
        /// <param name="saleId">The saleId<see cref="Int64"/>.</param>
        /// <param name="reason">The reason<see cref="string"/>.</param>
        public void UpdatVoucher(Int64 saleId, string reason)
        {
            saleDao.UpdateVoucher(saleId, reason);
        }

        /// <summary>
        /// UpdateStockCount
        /// </summary>
        /// <param name="dtSale"></param>
        public void UpdateStockCount(DataTable dtSale)
        {
            foreach (DataRow row in dtSale.Rows)
            {
                saleDao.UpdateStockCount(Convert.ToInt32(row["product_id"]), Convert.ToInt32(row["quantity"]));
            }
        }

        /// <summary>
        /// The GetSearchCount.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetSearchCount(List<object> filterList)
        {
            return saleDao.GetSearchCount(filterList);
        }

        /// <summary>
        /// The GetSearchConfirmCount.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetSearchConfirmCount(List<object> filterList)
        {
            return saleDao.GetSearchConfirmCount(filterList);
        }

        /// <summary>
        /// The GetSearchResult.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchResult(List<object> filterList)
        {
            return saleDao.GetSearchResult(filterList);
        }

        /// <summary>
        /// The GetSearchResult.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchConfirmResult(List<object> filterList)
        {
            return saleDao.GetSearchConfirmResult(filterList);
        }

        #region==========Dashboard========== 
        /// <summary>
        /// The GetTodaySaleAmount.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetTodaySaleAmount()
        {
            return saleDao.GetTodaySaleAmount();
        }

        /// <summary>
        /// The GetMonthlyYearlySaleAmount.
        /// </summary>
        /// <param name="startDate">The startDate<see cref="DateTime"/>.</param>
        /// <param name="endDate">The endDate<see cref="DateTime"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetMonthlyYearlySaleAmount(DateTime startDate, DateTime endDate)
        {
            return saleDao.GetMonthlyYearlySaleAmount(startDate, endDate);
        }

        /// <summary>
        /// The GetTotallySaleAmount.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetTotallySaleAmount()
        {
            return saleDao.GetTotallySaleAmount();
        }

        /// <summary>
        /// The GetMonthlySaleReport.
        /// </summary>
        /// <param name="startDate">The startDate<see cref="DateTime"/>.</param>
        /// <param name="endDate">The endDate<see cref="DateTime"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetMonthlySaleReport(DateTime startDate, DateTime endDate)
        {
            return saleDao.GetMonthlySaleReport(startDate, endDate);
        }
        #endregion

        #region==========Report========== 
        /// <summary>
        /// GetTotalSale
        /// </summary>
        /// <returns></returns>
        public DataTable GetTotalSale()
        {
            return saleDao.GetTotalSale();
        }

        /// <summary>
        /// GetYearlySaleTotal
        /// </summary>
        /// <returns></returns>
        public DataTable GetYearlySaleTotal()
        {
            return saleDao.GetYearlySaleTotal();
        }

        /// <summary>
        /// GetTotalYearlyAmount
        /// </summary>
        /// <returns></returns>
        public int GetTotalYearlyAmount()
        {
            return saleDao.GetTotalYearlyAmount();
        }

        /// <summary>
        /// GetSearchResultForReportList
        /// </summary>
        /// <param name="filterList"></param>
        /// <returns></returns>
        public DataTable GetSearchResultForReportList(List<object> filterList)
        {
            return saleDao.GetSearchResultForReportList(filterList);
        }

        /// <summary>
        /// GetSearchCountReport
        /// </summary>
        /// <param name="filterList"></param>
        /// <returns></returns>
        public int GetSearchCountReport(List<object> filterList)
        {
            return saleDao.GetSearchCountReport(filterList);
        }

        /// <summary>
        /// GetSearchResultForTopTenSaleProductList
        /// </summary>
        /// <param name="filterList"></param>
        /// <returns></returns>
        public DataTable GetSearchResultForTopTenSaleProductList(List<object> filterList)
        {
            return saleDao.GetSearchResultForTopTenSaleProductList(filterList);
        }

        /// <summary>
        /// GetSearchResultForProfitLossList
        /// </summary>
        /// <param name="filterList"></param>
        /// <returns></returns>
        public DataTable GetSearchResultForProfitLossList(List<object> filterList)
        {
            return saleDao.GetSearchResultForProfitLossList(filterList);
        }

        /// <summary>
        /// GetXLSXData
        /// </summary>
        /// <returns></returns>
        public DataTable GetXLSXData()
        {
            return saleDao.GetXLSXData();
        }

        /// <summary>
        /// GetTotalSale
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptTotalSale()
        {
            return saleDao.GetRptTotalSale();
        }

        /// <summary>
        /// GetYearlySale
        /// </summary>
        /// <returns></returns>
        public DataSet GetYearlySale()
        {
            return saleDao.GetYearlySale();
        }

        /// <summary>
        /// GetYearlyXLSXData
        /// </summary>
        /// <returns></returns>
        public DataTable GetYearlyXLSXData()
        {
            return saleDao.GetYearlyXLSXData();
        }

        /// <summary>
        /// GetTopTenSaleProductList
        /// </summary>
        /// <returns></returns>
        public DataTable GetTopTenSaleProductList()
        {
            return saleDao.GetTopTenSaleProductList();
        }

        /// <summary>
        /// GetTopTenSaleProductXLSX
        /// </summary>
        /// <returns></returns>
        public DataTable GetTopTenSaleProductXLSX(int pageCount)
        {
            return saleDao.GetTopTenSaleProductXLSX(pageCount);
        }

        /// <summary>
        /// GetProfitLossXLSX
        /// </summary>
        /// <returns></returns>
        public DataTable GetProfitLossXLSX()
        {
            return saleDao.GetProfitLossXLSX();
        }

        /// <summary>
        /// GetRptTopTenSaleProductList
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptTopTenSaleProductList(int pageCount)
        {
            return saleDao.GetRptTopTenSaleProductList(pageCount);
        }

        /// <summary>
        /// GetTopTenSaleProductList
        /// </summary>
        /// <returns></returns>
        public DataTable GetTopTenSaleProductLists()
        {
            return saleDao.GetTopTenSaleProductLists();
        }
        /// <summary>
        /// GetProfitLossReport
        /// </summary>
        /// <returns></returns>
        public DataTable GetProfitLossReport()
        {
            return saleDao.GetProfitLossReport();
        }

        /// <summary>
        /// GetRptProfitLossReport
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptProfitLossReport(List<object> filterList)
        {
            return saleDao.GetRptProfitLossReport(filterList); // to change
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
            int saleDetailsCount = saleDao.GetSaleDetailsByProductId(productId);

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
            return saleDao.GetPaymentType(saleId);
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
            saleDao.AddPaidAmount(amount,saleId, paymentDate, paymentType);
        }
        #endregion

        #region==========Monthly Sale Report========== 
        /// <summary>
        /// GetMonthlySale
        /// </summary>
        /// <returns></returns>
        public DataTable GetMonthlySale()
        {
            return saleDao.GetMonthlySale();
        }

         /// <summary>
        /// GetMonthlySale
        /// </summary>
        /// <returns></returns>
        public DataTable GetMonthlySaleMM()
        {
            return saleDao.GetMonthlySaleMM();
        }

        /// <summary>
        /// GetTotalSale
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptMonthlySale()
        {
            return saleDao.GetRptMonthlySale();
        }

        /// <summary>
        /// GetXLSXMonthlyData
        /// </summary>
        /// <returns></returns>
        public DataTable GetXLSXMonthlyData()
        {
            return saleDao.GetXLSXMonthlyData();
        }

        #endregion
    }
}
