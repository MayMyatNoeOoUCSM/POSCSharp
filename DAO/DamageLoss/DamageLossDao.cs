//<copyright file ="DamageLossDao.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> MAYMYATTHAZIN_P\May Myat Thazin </author>
//<date>1/19/2021</date>

namespace DAO.DamageLoss
{
    using System.Data.SQLite;
    using Entities.DamageLoss;
    using System;
    using System.Data;
    using static Entities.DamageLoss.DamageLossEntity;
    using DAO.Common;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="DamageLossDao" />.
    /// </summary>
    public class DamageLossDao
    {
        /// <summary>
        /// Defines the Database Connection..
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

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
            strSql = "SELECT m_product.id , m_product.product_name, \"\" as dl_qty, max(t_stock_sale.selling_price) AS selling_price, max(t_stock_sale.quantity) AS qty " +
                "FROM m_product JOIN t_stock_sale On t_stock_sale.product_id = m_product.id " +
                "LEFT JOIN m_category on m_category.id = m_product.category_id " +
                "WHERE (m_product.supplier_id = " + supplierId + " OR 0 = " + supplierId + ") " +
                "AND (m_product.id = " + productId + " OR 0 = " + productId + ") AND (m_product.category_id = " + categoryId + " OR 0 = " + categoryId + ") " +
                "AND (m_product.sub_category_id = " + subCategoryId + " OR 0 = " + subCategoryId + ") AND m_product.is_deleted = 0 GROUP BY m_product.id; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The SaveDamageLossProduct.
        /// </summary>
        /// <param name="damagLossEntity">The damagLossEntity<see cref="DamageLossEntity"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public void SaveDamageLossProduct(DamageLossEntity damageLossEntity)
        {
            strSql = "INSERT INTO t_damage_loss(product_id, quantity, price, product_status, damageloss_date, remark, is_deleted, created_user_id, updated_user_id, created_datetime, updated_datetime) " +
             "VALUES (@product_id, @quantity, @price, @product_status, @damageloss_date, @remark, @is_deleted, @created_user_id, @updated_user_id, @created_datetime, @updated_datetime) ";
            SQLiteParameter[] SqliteParams = {
                                               new SQLiteParameter ("@product_id",damageLossEntity.product_id),
                                               new SQLiteParameter ("@quantity", damageLossEntity.quantity),
                                               new SQLiteParameter ("@price", damageLossEntity.price),
                                               new SQLiteParameter ("@product_status", damageLossEntity.product_status),
                                               new SQLiteParameter ("@damageloss_date", damageLossEntity.damageloss_date),
                                               new SQLiteParameter ("@remark", damageLossEntity.remark),
                                               new SQLiteParameter ("@is_deleted", damageLossEntity.is_deleted),
                                               new SQLiteParameter ("@created_user_id", damageLossEntity.created_user_id),
                                               new SQLiteParameter ("@updated_user_id", damageLossEntity.updated_user_id),
                                               new SQLiteParameter ("@created_datetime", damageLossEntity.created_datetime),
                                               new SQLiteParameter ("@updated_datetime", damageLossEntity.updated_datetime)
                                             };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }
        #endregion

        /// <summary>
        /// The GetDamageLossDetails.
        /// </summary>
        /// <param name="shopId">The shopId<see cref="int"/>.</param>
        /// <param name="warehouseId">The warehouseId<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetDamageLossDetails(int shopId, int warehouseId)
        {
            strSql = "SELECT m_shop.name AS shopname, " +
                     "CASE WHEN t_damage_loss.return_id IS NULL THEN '' ELSE 'Yes' END AS return, " +
                     "m_warehouse.name AS warehousename, m_product.name AS productname, " +
                     "t_damage_loss_details.quantity, SUM(quantity) OVER() AS total, " +
                     "CASE WHEN t_damage_loss_details.product_status = 1 THEN 'Damage' " +
                     "ELSE 'Loss' END AS status, t_damage_loss.damage_loss_date AS damage_loss_date " +
                     "FROM t_damage_loss " +
                     "JOIN t_damage_loss_details ON t_damage_loss.id = t_damage_loss_details.damage_loss_id " +
                     "JOIN m_product ON m_product.id = t_damage_loss_details.product_id " +
                     "LEFT JOIN m_shop ON t_damage_loss.shop_id = m_shop.id " +
                     "LEFT JOIN m_warehouse ON t_damage_loss.warehouse_id = m_warehouse.id " +
                     "WHERE CASE WHEN " + shopId + " != 0 THEN t_damage_loss.shop_id = " + shopId + " " +
                     "ELSE t_damage_loss.warehouse_id = " + warehouseId + " END ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        #region==========Damage and Loss List==========
        /// <summary>
        /// GetDamageLossList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetDamageLossList()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  D.id) AS sr, D.id AS id, D.product_id, S.supplier_name AS supplier_name, P.product_name AS product_name, P.product_code AS product_code, D.quantity AS quantity, D.price AS price," +
                     "'' AS damage_loss ,D.product_status AS product_status, date(D.damageloss_date) AS damageloss_date, D.remark AS remark FROM t_damage_loss D " +
                     "JOIN m_product P on D.product_id = P.id JOIN m_supplier S on P.supplier_id = S.id WHERE D.is_deleted = 0 ; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSearchResult.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchResult(List<object> filterList)
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  D.id) AS sr, D.id AS id, D.product_id, S.supplier_name AS supplier_name, P.product_name AS product_name, P.product_code AS product_code, D.quantity AS quantity, D.price AS price," +
                     "D.product_status AS product_status, date(D.damageloss_date) AS damageloss_date, D.remark AS remark FROM t_damage_loss D " +
                     "JOIN m_product P on D.product_id = P.id JOIN m_supplier S on P.supplier_id = S.id WHERE D.is_deleted = 0 " +
                     "AND (P.id = " + filterList[0] + " OR 0 = " + filterList[0] + ") " +
                     "AND (S.id = " + filterList[1] + " OR 0 = " + filterList[1] + ") " +
                     "AND (date(D.damageloss_date) between COALESCE(NULLIF('" + filterList[2] + "',''),'" + Consts.DEFAULTDATE + "') " +
                     "AND COALESCE(NULLIF('" + filterList[3] + "',''),date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "')))" + " ;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="Id">.</param>
        public void Delete(Int64 Id,  int productId, int quantity)
        {
            strSql = "UPDATE t_damage_loss SET is_deleted = 1 WHERE id = " + Id;
            
            connection.ExecuteNonQuery(CommandType.Text, strSql, null);

            strSql = "UPDATE t_sale_stock SET qty = qty + " + quantity + "  WHERE product_id =" + productId ;
            
            connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="damageLossEntity">.</param>
        public void Update(DamageLossEntity damageLossEntity)
        {
            string date = damageLossEntity.updated_datetime.ToString("yyyy-MM-dd");
            string damageLossDate = damageLossEntity.damageloss_date.ToString("yyyy-MM-dd");
            strSql = "UPDATE t_damage_loss SET product_status = " + damageLossEntity.product_status + ", price = " + damageLossEntity.price + ", " +
                     "quantity = " + damageLossEntity.quantity + ", damageloss_date = '" + damageLossDate + "', remark = ' " + damageLossEntity.remark + " ', is_deleted = " + damageLossEntity.is_deleted + ", " +
                     " updated_user_id = " + damageLossEntity.updated_user_id + ", updated_datetime = '" + date + "' " +
                     " WHERE id = " + damageLossEntity.id;

            connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// CheckSaleStockQuantity
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public bool CheckSaleStockQuantity(int quantity, int product_id)
        {
            strSql = "SELECT quantity FROM t_stock_sale where quantity >" + quantity + " and " + "product_id = " + product_id;
            var t =  connection.ExecuteDataTable(CommandType.Text, strSql);
            if(t.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// ReduceStockQuantity
        /// </summary>
        /// <param name="minus"></param>
        /// <param name="product_id"></param>
        public void ReduceStockQuantity(int minus, int product_id)
        {
            strSql = "UPDATE t_stock_sale set quantity = quantity + " + (minus) + " WHERE product_id = " + product_id;
            connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }
        #endregion
    }
}
