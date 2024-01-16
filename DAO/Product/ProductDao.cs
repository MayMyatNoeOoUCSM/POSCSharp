using System.Data.SQLite;
using DAO.Common;
using Entities.Product;
using System;
using System.Data;
using System.Collections.Generic;

namespace DAO.Product
{
    /// <summary>
    /// Defines the <see cref="ProductDao" />.
    /// </summary>
    public class ProductDao
    {
        /// <summary>
        /// Defines Database Connection..
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines strSql..
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the resultDataTable.
        /// </summary>
        private DataTable resultDataTable = new DataTable();

        /// <summary>
        /// Defines the existCount.
        /// </summary>
        private int existCount;

        #region==========Product========== 
        /// <summary>
        /// GetProductCountByCategoryId.
        /// </summary>
        /// <param name="categoryId">.</param>
        /// <returns>.</returns>
        public int GetProductCountByCategoryId(Int64 categoryId)
        {
            strSql = "SELECT count(*) FROM m_product " +
                     "WHERE category_id = @category_id OR sub_category_id = @category_id " +
                     "AND is_deleted != 1;";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@category_id", categoryId)
                                               };
            int productCount = Convert.ToInt32(connection.ExecuteScalar
                (CommandType.Text, strSql, SqliteParams));
            return productCount;
        }
        #endregion
        //public DataTable GetProduct(int id)
        //{
        //    strSql = "SELECT id, product_name FROM m_product " +
        //             "WHERE  category_id = " + id + " AND is_deleted = 0;";
        //    return connection.ExecuteDataTable(CommandType.Text, strSql);
        //}

        public DataTable GetProductCategory(int id, int supplierId)
        {
            strSql = "SELECT id, product_name FROM m_product " +
                   "WHERE  category_id = " + id + " AND supplier_id=" + supplierId + " OR 0=" + supplierId + " AND is_deleted = 0;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable GetProductSubCategory(int id,int supplierId)
        {
            strSql = "SELECT id, product_name FROM m_product " +
                     "WHERE  sub_category_id = " + id +" AND supplier_id="+supplierId+" OR 0="+ supplierId + " AND is_deleted = 0;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        /// <summary>
        /// CreateProduct.
        /// </summary>
        /// <param name="productEntity">.</param>
        public void Insert(ProductEntity productEntity)
        {
            strSql = "INSERT INTO m_product(supplier_id, category_id, sub_category_id, product_code, barcode, product_name," +
                     " product_description, product_image_path, " +
                     "is_deleted, created_user_id, updated_user_id," +
                     "created_datetime, updated_datetime, stock_level, brand_id)" +
                     "VALUES(@supplier_id, @category_id, @sub_category_id, @product_code, @barcode, @product_name," +
                     "@product_description, @product_image_path, " +
                     "@is_deleted, @created_user_id, @updated_user_id," +
                     "@created_datetime, @updated_datetime,@stock_level, @brand_id); ";
            SQLiteParameter[] SqliteParams = {
                                               new SQLiteParameter("@supplier_id", productEntity.supplier_id),
                                               new SQLiteParameter("@category_id", productEntity.category_id),
                                               new SQLiteParameter("@sub_category_id", productEntity.sub_category_id),
                                               new SQLiteParameter("@product_code", productEntity.product_code),
                                               new SQLiteParameter("@barcode", productEntity.barcode),
                                               new SQLiteParameter("@product_name", productEntity.product_name),
                                               new SQLiteParameter("@product_description", productEntity.product_description),
                                               new SQLiteParameter("@product_image_path", productEntity.product_image_path),
                                               new SQLiteParameter("@is_deleted", productEntity.is_deleted),
                                               new SQLiteParameter("@created_user_id", productEntity.created_user_id),
                                               new SQLiteParameter("@updated_user_id", productEntity.updated_user_id),
                                               new SQLiteParameter("@created_datetime", productEntity.created_datetime),
                                               new SQLiteParameter("@updated_datetime", productEntity.updated_datetime),
                                               new SQLiteParameter("@stock_level", productEntity.stock_level),
                                               new SQLiteParameter("@brand_id", productEntity.brand_id)
                                              };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
            SqliteParams = null;
        }

        /// <summary>
        /// UpdateProduct.
        /// </summary>
        /// <param name="productEntity">.</param>
        public void Update(ProductEntity productEntity)
        {
            strSql = "UPDATE m_product SET supplier_id = @supplier_id, category_id = @category_id, sub_category_id = @sub_category_id, product_code = @product_code," +
                      "barcode = @barcode, product_name = @product_name, product_description = @product_description, " +
                      "product_image_path = @product_image_path, " +
                      "is_deleted = @is_deleted,updated_user_id = @updated_user_id, " +
                      "updated_datetime = @updated_datetime ,stock_level = @stock_level, brand_id = @brand_id " +
                      "WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", productEntity.id),
                                                new SQLiteParameter("@supplier_id", productEntity.supplier_id),
                                                new SQLiteParameter("@category_id", productEntity.category_id),
                                                new SQLiteParameter("@sub_category_id", productEntity.sub_category_id),
                                                new SQLiteParameter("@product_code", productEntity.product_code),
                                                new SQLiteParameter("@barcode", productEntity.barcode),
                                                new SQLiteParameter("@product_name", productEntity.product_name),
                                                new SQLiteParameter("@product_description", productEntity.product_description),
                                                new SQLiteParameter("@product_image_path", productEntity.product_image_path),
                                                new SQLiteParameter("@is_deleted", productEntity.is_deleted),
                                                new SQLiteParameter("@updated_user_id", productEntity.updated_user_id),
                                                new SQLiteParameter("@updated_datetime", DateTime.Now),
                                                new SQLiteParameter("@stock_level",productEntity.stock_level),
                                                new SQLiteParameter("@brand_id",productEntity.brand_id)
                                              };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
            SqliteParams = null;
        }

        /// <summary>
        /// GetLastProduct.
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public Int64 GetLastProductCode(int id)
        {
            strSql = "SELECT product_code FROM m_product " +
                     "WHERE category_id = @category_id " +
                     "ORDER BY m_product.product_code DESC  LIMIT 1;";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@category_id", id)
                                              };
            Int64 lastProduct = Convert.ToInt64(connection.ExecuteScalar
                (CommandType.Text, strSql, SqliteParams));
            return lastProduct;
        }

        /// <summary>
        /// GetProductList.
        /// </summary>
        public DataTable GetProductList()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  m_product.id) AS sr, m_product.supplier_id, s.supplier_name, m_product.id, m_product.category_id," +
                     "m_product.product_code, m_product.barcode, m_product.product_name," +
                     "m_product.product_description, m_product.product_image_path," +
                     "m_product.is_deleted," +
                     "c.name as product_category, 0 AS quantity, m_product.sub_category_id ,m_product.stock_level, m_product.brand_id" +
                     " FROM m_product " +
                     " LEFT JOIN m_category AS c ON c.id = m_product.category_id left join m_supplier as s on s.id = m_product.supplier_id " +
                     "LEFT join  m_brand AS b on b.id = m_product.brand_id " +
                     " WHERE m_product.is_deleted != 1 ; ";
            resultDataTable = connection.ExecuteDataTable(CommandType.Text, strSql);
            return resultDataTable;
        }

        /// <summary>
        /// GetProductCategoryList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetProductCategoryList()
        {
            strSql = "SELECT DISTINCT c.id AS distinct_id,c.parent_category_id," +
                     "c.name AS category_name " +
                     "FROM m_product LEFT JOIN m_category AS c " +
                     "ON c.id = m_product.category_id " +
                     "OR  c.parent_category_id IS NULL OR c.parent_category_id = 0 " +
                     "WHERE m_product.is_deleted != 1  and c.is_deleted = 0 " +
                     "ORDER BY c.name;";
            resultDataTable = connection.ExecuteDataTable(CommandType.Text, strSql);
            return resultDataTable;
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">.</param>
        public void Delete(Int64 id)
        {
            strSql = "UPDATE m_product SET is_deleted = 1 WHERE id =@id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", id)
                                              };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
            SqliteParams = null;
        }

        /// <summary>
        /// CheckDuplicateBarcode.
        /// </summary>
        /// <param name="barCode">.</param>
        /// <returns>.</returns>
        public int CheckDuplicateBarcode(string barCode, string id)
        {
            strSql = "SELECT COUNT(*) FROM m_product " +
                     "WHERE is_deleted == 0 AND m_product.barcode ='" + barCode + "' AND (m_product.id != '" + id + "' OR m_product.id = '' OR m_product.id IS NULL)";
            existCount = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
            return existCount;
        }

        /// <summary>
        /// The CheckDuplicateProductname.
        /// </summary>
        /// <param name="productName">The productName<see cref="string"/>.</param>
        /// <param name="productTypeId">The productTypeId<see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int CheckDuplicateProductName(string productName, int productTypeId, string pid)
        {
            strSql = "SELECT COUNT(*) from m_product " +
                     "WHERE m_product.is_deleted = 0 AND LOWER(product_name) = (SELECT LOWER('" + productName + "')) " +
                     "AND m_product.category_id = " + productTypeId + " AND (m_product.id != '" + pid + "' OR m_product.id = '' OR m_product.id IS NULL)";
            existCount = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
            return existCount;
        }

        /// <summary>
        /// The GetAllProduct.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetAllProduct()
        {
            strSql = "SELECT id, product_name FROM m_product WHERE is_deleted = 0 ;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetProduct.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetDamageLossProduct(int supplierId, int categoryId, int subCategoryId, int productId)
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  m_product.id) AS sr, m_product.supplier_id, s.supplier_name, m_product.id, m_product.category_id," +
                     "m_product.product_code, m_product.barcode, m_product.product_name," +
                     "m_product.product_description, m_product.product_image_path," +
                     "m_product.is_deleted," +
                     "c.name as product_category, 0 AS quantity " +
                     " FROM m_product " +
                     " LEFT JOIN m_category AS c ON c.id = m_product.category_id left join m_supplier as s on s.id = m_product.supplier_id" +
                     " WHERE m_product.is_deleted != 1 " +
                     "AND (m_product.id = " + productId + " OR 0 = " + productId + ") " +
                     "AND(m_product.category_id = " + categoryId + " OR 0 = " + categoryId + ") " +
                        "AND(m_product.sub_category_id = " + subCategoryId + " OR 0 = " + subCategoryId + ") " +
                     "AND c.is_deleted = 0 and s.is_deleted =0 " +
                     " ORDER BY m_product.product_name ASC;";
            resultDataTable = connection.ExecuteDataTable(CommandType.Text, strSql);
            return resultDataTable;
        }

        /// <summary>
        /// The GetSearchResult.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchResult(List<object> filterList)
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  P.id) as sr, P.supplier_id, P.barcode, P.sub_category_id, P.category_id, S.supplier_name, P.product_name, P.product_code, P.product_description, P.id, P.product_image_path, P.stock_level, P.is_deleted " +
                     "FROM m_product P JOIN m_supplier S on S.id = P.supplier_id " +
                     " JOIN m_category C on C.id = P.category_id " +
                     "WHERE (S.id = " + filterList[0] + " OR 0 = " + filterList[0] + ") " +
                     "AND P.is_deleted = 0 " +
                     "AND (P.id = " + filterList[1] + " OR 0 = " + filterList[1] + ") " +
                     "AND (C.id = " + filterList[2] + " OR 0 = " + filterList[2] + ")  ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        #region==========Brand==========  
        /// <summary>
        /// The GetAllBrand.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetAllBrand()
        {
            strSql = "SELECT id, brand_name FROM m_brand WHERE is_deleted = 0 ;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        #endregion


    }
}
