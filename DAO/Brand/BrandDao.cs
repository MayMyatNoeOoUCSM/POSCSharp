using System.Data.SQLite;
using DAO.Common;
using Entities.Brand;
using System;
using System.Data;

namespace DAO.Brand
{
    public class BrandDao
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
        /// Defines the existCount.
        /// </summary>
        private int existCount;

        /// <summary>
        /// CreateBrand.
        /// </summary>
        /// <param name="brandEntity">.</param>
        public bool CreateBrand(BrandEntity brandEntity)
        {
            strSql = "INSERT INTO m_brand(brand_name, brand_description, is_deleted," +
                     "created_user_id,updated_user_id,created_datetime,updated_datetime) " +
                     "VALUES(@brand_name,@brand_description, @is_deleted," +
                     "@created_user_id,@updated_user_id,@created_datetime,@updated_datetime)";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@brand_name", brandEntity.brand_name),
                    new SQLiteParameter("@brand_description", brandEntity.brand_description),
                    new SQLiteParameter("@is_deleted", brandEntity.is_deleted),
                    new SQLiteParameter("@created_user_id",brandEntity.created_user_id),
                    new SQLiteParameter("@updated_user_id",brandEntity.updated_user_id),
                    new SQLiteParameter("@created_datetime",brandEntity.created_datetime),
                    new SQLiteParameter("@updated_datetime",brandEntity.updated_datetime)
                };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// GetBrandList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetBrandList()
        {
            strSql = "SELECT ROW_NUMBER()  OVER (ORDER BY  id) AS sr, id, brand_name, brand_description " +
                "FROM m_brand WHERE is_deleted = 0 ORDER BY id, brand_name ASC;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetBrandId
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public object GetBrandId(int brandId)
        {
            strSql = "SELECT id from m_brand WHERE id = @id;";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", brandId)
                                             };
            return connection.ExecuteScalar(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="brandEntity">.</param>
        public bool Update(BrandEntity brandEntity)
        {
            strSql = "UPDATE m_brand SET brand_name = @brand_name, brand_description = @brand_description, " +
                     " is_deleted = @is_deleted, updated_user_id = @updated_user_id, updated_datetime = @updated_datetime " +
                     " WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@id", brandEntity.id),
                    new SQLiteParameter("@brand_name", brandEntity.brand_name),
                    new SQLiteParameter("@brand_description", brandEntity.brand_description),
                    new SQLiteParameter("@is_deleted", brandEntity.is_deleted),
                    new SQLiteParameter("@updated_user_id",brandEntity.updated_user_id),
                    new SQLiteParameter("@updated_datetime",brandEntity.updated_datetime)
                };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="brandId">.</param>
        public bool Delete(Int64 brandId)
        {
            strSql = "UPDATE m_brand SET is_deleted = 1 WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", brandId)
                                             };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// IsExistBrandName.
        /// </summary>
        /// <param name="brandName">.</param>
        /// <returns>.</returns>
        public int IsExistBrandName(string brandName)
        {
            strSql = "SELECT COUNT(*) FROM m_brand " +
                     "WHERE is_deleted == 0 AND LOWER(brand_name) = (SELECT LOWER('" + brandName + "'));";
            existCount = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
            return existCount;
        }

        /// <summary>
        /// GetSearchResult
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public DataTable GetSearchResult(string brandName)
        {
            strSql = "SELECT ROW_NUMBER()  OVER (ORDER BY  id) AS sr, id, brand_name, brand_description " +
                "FROM m_brand WHERE (brand_name like '%" + brandName + "%' OR brand_name = '' OR brand_name IS NULL) " +
                "AND is_deleted = 0 ORDER BY id;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetBrandCountInProduct
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandCountInProduct(Int64 brandId)
        {
            strSql = "SELECT count(*) FROM m_product WHERE brand_id = @brand_id;";
            SQLiteParameter[] SqliteParams = {
                                               new SQLiteParameter("@brand_id", brandId)
                                              };

            int brandListCount = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, SqliteParams));

            SqliteParams = null;
            return brandListCount;
        }
    }
}
