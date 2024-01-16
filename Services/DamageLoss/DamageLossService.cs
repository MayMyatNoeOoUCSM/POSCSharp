//<copyright file ="DamageLossService.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> MAYMYATTHAZIN_P\May Myat Thazin </author>
//<date>1/19/2021</date>

namespace Services.DamageLoss
{
    using System;
    using System.Data;
    using DAO.Common;
    using DAO.DamageLoss;
    using Services.Stock;
    using Entities.DamageLoss;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="DamageLossService" />.
    /// </summary>
    public class DamageLossService
    {
        /// <summary>
        /// Defines the damageLossDao.
        /// </summary>
        private DamageLossDao damageLossDao = new DamageLossDao();

        /// <summary>
        /// Defines the stockService.
        /// </summary>
        private StockService stockService = new StockService();

        #region==========Create Damage and Loss==========
        /// <summary>
        /// The GetDamageLossProduct.
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/>.</param>
        /// <param name="categoryId">The categoryId<see cref="int"/>.</param>
        /// <param name="subCategoryId">The subCategoryId<see cref="int"/>.</param>
        /// <param name="warehouseId">The warehouseId<see cref="int"/>.</param>
        /// <param name="shopId">The shopId<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetDamageLossProduct(
            int supplierId,
            int categoryId,
            int subCategoryId,
            int productId)
        {
            return damageLossDao.GetDamageLossProduct(
                supplierId,
                categoryId,
                subCategoryId,
                productId);
        }

        /// <summary>
        /// The SaveDamageLossQuantity.
        /// </summary>
        /// <param name="damageLossEntity">The damageLossEntity<see cref="DamageLossEntity"/>.</param>
        public void SaveDamageLossQuantity(DamageLossEntity damageLossEntity)
        {
            damageLossDao.SaveDamageLossProduct(damageLossEntity);
            
            int productId = Convert.ToInt32(damageLossEntity.product_id);
            int quantity = Convert.ToInt32(damageLossEntity.quantity);
            int isReturn = 0;
            stockService.UpdateSaleStockCount(productId, quantity, isReturn);
        }
        #endregion

        /// <summary>
        /// GetDamageLossList
        /// </summary>
        /// <returns></returns>
        public DataTable GetDamageLossList()
        {
            return damageLossDao.GetDamageLossList();
        }

        /// <summary>
        /// The GetDamageLossDetails.
        /// </summary>
        /// <param name="shopId">The shopId<see cref="int"/>.</param>
        /// <param name="warehouseId">The warehouseId<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetDamageLossDetails(int shopId, int warehouseId)
        {
            return damageLossDao.GetDamageLossDetails(shopId, warehouseId);
        }

        /// <summary>
        /// The GetSearchResult.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchResult(List<object> filterList)
        {
            return damageLossDao.GetSearchResult(filterList);
        }

        /// <summary>
        /// DeleteDamageLossList.
        /// </summary>
        /// <param name="Id">.</param>
        public void DeleteDamageLossList(Int64 Id, int productId, int quantity)
        {
            damageLossDao.Delete(Id, productId, quantity);
        }

        /// <summary>
        /// UpdateDamageLost
        /// </summary>
        /// <param name="damageLossEntity"></param>
        public void UpdateDamageLost(DamageLossEntity damageLossEntity)
        {
            damageLossDao.Update(damageLossEntity);
        }

        /// <summary>
        /// CheckSaleStockQuantity
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool CheckSaleStockQuantity(int quantity, int productId)
        {
            return damageLossDao.CheckSaleStockQuantity(quantity, productId);
        }

        /// <summary>
        /// ReduceStockQuantity
        /// </summary>
        /// <param name="minus"></param>
        /// <param name="productId"></param>
        public void ReduceStockQuantity(int minus, int productId)
        {
            damageLossDao.ReduceStockQuantity(minus, productId);
        }
    }
}
