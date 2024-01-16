using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Stock;
using Entities.Stock;
using System.Data;

namespace Services.Stock
{
    public class StockService
    {
        /// <summary>
        /// define stockDao..
        /// </summary>
        private StockDao stockDao = new StockDao();
        private StockSaleEntity stockSaleEntity = new StockSaleEntity();

        #region Stock

        public void InsertStock(StockEntity stockEntity)
        {
            stockDao.InsertStock(stockEntity);
        }
        #region==========Stockl List==========   
        /// <summary>
        /// GetStockList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetStockList()
        {
            return stockDao.GetStockList();
        }
        #endregion

        #region==========Update Stock==========   
        public void UpdateStock(StockEntity stockEntity)
        {
            stockDao.UpdateStock(stockEntity);
        }
        public void DeleteStock(int id)
        {
            stockDao.DeleteStock(id);
        }

        #endregion

        /// <summary>
        /// GetLastId
        /// </summary>
        /// <returns></returns>
        public int GetLastId()
        {
            var resultValue = stockDao.GetLastId();
            int purchaseID = resultValue != DBNull.Value ? Convert.ToInt32(resultValue) : 0;
            return purchaseID;
        }
        #endregion

        public void Insert(StockDetailEntity stockDetailEntity)
        {
            stockDao.Insert(stockDetailEntity);
        }

        #region==========Purchase List==========   


        /// <summary>
        /// GetStockDetailListById.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetStockDetailListById(int stockId)
        {
            return stockDao.GetStockDetailListById(stockId);
        }

        /// <summary>
        /// The GetSearchStockList.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchStockList(List<object> filterList)
        {
            return stockDao.GetSearchStockList(filterList);
        }
        #endregion

        #region==========Stock List========== 
        /// <summary>
        /// The UpdateStockCount.
        /// </summary>
        /// <param name="shopId">The shopId<see cref="int"/>.</param>
        /// <param name="warehouseId">The warehouseId<see cref="int"/>.</param>
        /// <param name="productId">The productId<see cref="int"/>.</param>
        /// <param name="quantity">The quantity<see cref="int"/>.</param>
        /// <param name="isReturn">The isReturn<see cref="int"/>.</param>
        public void UpdateSaleStockCount(
            int productId,
            int quantity,
            int isReturn)
        {
            stockDao.UpdateSaleStockCount(productId, quantity, isReturn);
        }
        #endregion
        public void DeleteStockDetail(int id)
        {
            stockDao.DeleteStockDetail(id);
        }

        public void DeleteDetailsByStockId(int stockId)
        {
            stockDao.DeleteDetailsByStockId(stockId);
        }

        public void UpdateIsDelete(int stockId, List<string> lstDetailId, List<string> lstOldDetailId)
        {
            stockDao.UpdateIsDelete(stockId, lstDetailId, lstOldDetailId);
        }
        #region==========Update Stock==========   
        public void Update(StockDetailEntity stockDetailEntity)
        {
            stockDao.Update(stockDetailEntity);
        }
        #endregion

        public int GetProductExist(Int64 id)
        {
            return stockDao.GetProductExist(id);
        }

        #region==========Insert/Update t_sale_stock table==========  
        public void InsertStockSale(StockSaleEntity stockSaleEntity)
        {
            stockDao.InsertStockSale(stockSaleEntity);
        }

        public void UpdateStockSale(StockSaleEntity stockSaleEntity)
        {
            stockDao.UpdateStockSale(stockSaleEntity);
        }
        #endregion

        #region==========Sale Stock List========== 
        /// <summary>
        /// GetSaleStockList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetSaleStockList()
        {
            return stockDao.GetSaleStockList();
        }

        /// <summary>
        /// The GetSearchStockSaleList.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchStockSaleList(List<object> filterList)
        {
            return stockDao.GetSearchStockSaleList(filterList);
        }

        /// <summary>
        /// UpdateSaleStockList
        /// </summary>
        /// <param name="stockdiscountEntity"></param>
        public void UpdateSaleStockList(int productid, string str)
        {
            stockDao.UpdateSaleStockList(productid, str);
        }
        #endregion

        #region==========Stock Discount==========  
        /// <summary>
        /// InsetStockDiscount
        /// </summary>
        /// <param name="stockdiscountEntity"></param>
        /// <returns></returns>
        public bool InsetStockDiscount(StockDiscountEntity stockdiscountEntity)
        {
            return stockDao.InsetStockDiscount(stockdiscountEntity);
        }

        /// <summary>
        /// UpdateSaleStock
        /// </summary>
        /// <param name="stockdiscountEntity"></param>
        public void UpdateSaleStock(StockDiscountEntity stockdiscountEntity)
        {
            stockDao.UpdateSaleStock(stockdiscountEntity);
        }

        /// <summary>
        /// GetProductIdWithTotalQty
        /// </summary>
        /// <param name="lstDeleteDetailId"></param>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        public DataTable GetProductIdWithTotalQty(List<string> lstDeleteDetailId,int purchaseId,int is_deleted)
        {
            return stockDao.GetProductIdWithTotalQty(lstDeleteDetailId, purchaseId, is_deleted);
        }

        ///// <summary>
        ///// GetDeletedQty
        ///// </summary>
        ///// <param name="lstDeleteDetailId"></param>
        ///// <param name="purchaseId"></param>
        ///// <returns></returns>
        //public DataTable GetDeletedQty(int purchaseId)
        //{
        //    return stockDao.GetDeletedQty(purchaseId);
        //}
        /// <summary>
        /// SubstractStockQty
        /// </summary>
        /// <param name="product_id"></param>
        /// <param name="substractQty"></param>
        public void SubstractStockQty(int product_id,int substractQty)
        {
            stockDao.SubstractStockQty(product_id,substractQty);
        }

        /// <summary>
        /// UpdateSaleStockQuantity
        /// </summary>
        /// <param name="stockdiscountEntity"></param>
        public void UpdateSaleStockQty(StockSaleEntity stockSaleEntity)
        {
            stockDao.UpdateSaleStockQty(stockSaleEntity);
        }

        /// <summary>
        /// UpdateStockDiscount
        /// </summary>
        /// <param name="stockdiscountEntity"></param>
        public void UpdateStockDiscount(StockDiscountEntity stockdiscountEntity)
        {
            stockDao.UpdateStockDiscount(stockdiscountEntity);
        }
        #endregion

        #region==========Dashboard==========    
        public int GetTotalStock()
        {
            return stockDao.GetTotalStock();
        }

        public int GetActiveStock()
        {
            return stockDao.GetActiveStock();
        }

        public int GetInactiveStock()
        {
            return stockDao.GetInactiveStock();
        }

        public int GetDamageLossStock()
        {
            return stockDao.GetDamageLossStock();
        }

        public int GetSaleReturnStock()
        {
            return stockDao.GetSaleReturnStock();
        }

        public int GetMinStock()
        {
            return stockDao.GetMinStock();
        }

        /// <summary>
        /// GetExpireStockCount
        /// </summary>
        /// <returns></returns>
        public int GetExpireStockCount()
        {
            return stockDao.GetExpireStockCount();
        }
        #endregion

        #region==========Report========== 
        /// <summary>
        /// GetRptSaleStockList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetSaleStockLists()
        {
            return stockDao.GetSaleStockLists();
        }

        /// <summary>
        /// GetSearchResultForStockSaleReportList
        /// </summary>
        /// <param name="filterList"></param>
        /// <returns></returns>
        public DataTable GetSearchResultForStockSaleReportList(List<object> filterList)
        {
            return stockDao.GetSearchResultForStockSaleReportList(filterList);
        }

        /// <summary>
        /// GetXLSXData.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetXLSXData()
        {
            return stockDao.GetXLSXData();
        }

        /// <summary>
        /// GetRptSaleStockList
        /// </summary>
        /// <returns></returns>
        public DataSet GetRptSaleStockList()
        {
            return stockDao.GetRptSaleStockList();
        }

        /// <summary>
        /// GetRptSaleStockList
        /// </summary>
        /// <returns></returns>
        public int GetMinStockCount()
        {
            return stockDao.GetMinStockCount();
        }
        #endregion
    }
}
