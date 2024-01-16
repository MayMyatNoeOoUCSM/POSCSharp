using System.Data.SQLite;
using Entities.Category;
using System;
using System.Data;
using DAO.Common;

namespace DAO.Category
{
    /// <summary>
    /// Defines the <see cref="CategoryDao" />.
    /// </summary>
    public class CategoryDao
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
        /// CreateCategory.
        /// </summary>
        /// <param name="categoryEntity">.</param>
        public bool CreateCategory(CategoryEntity categoryEntity)
        {
            strSql = "INSERT INTO m_category(parent_category_id,name, description,is_deleted," +
                     "created_user_id,updated_user_id,created_datetime,updated_datetime) " +
                     "VALUES(@parent_category_id,@name,@description,@is_deleted," +
                     "@created_user_id,@updated_user_id,@created_datetime,@updated_datetime)";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@parent_category_id", categoryEntity.parent_category_id),
                    new SQLiteParameter("@name", categoryEntity.name),
                    new SQLiteParameter("@description", categoryEntity.description),
                    new SQLiteParameter("@is_deleted", categoryEntity.is_deleted),
                    new SQLiteParameter ("@created_user_id",categoryEntity.created_user_id),
                    new SQLiteParameter ("@updated_user_id",categoryEntity.updated_user_id),
                    new SQLiteParameter ("@created_datetime",categoryEntity.created_datetime),
                    new SQLiteParameter ("@updated_datetime",categoryEntity.updated_datetime)
                };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// GetParentCategoryList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetParentCategoryList()
        {
            strSql = "SELECT id, parent_category_id, name FROM m_category " +
                     "WHERE (parent_category_id = 0 OR parent_category_id IS NULL) " +
                     "AND is_deleted = 0 ORDER BY name ASC;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetSubCategoryList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSubCategoryList()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  m_category.id) AS sr, m_category.id, m_category.parent_category_id, " +
                     "m_category.name,m_category.description,c.name AS parent_category " +
                     "FROM m_category JOIN m_category c " +
                     "ON (c.id = m_category.parent_category_id) " +
                     "WHERE m_category.is_deleted = 0 " +
                     "ORDER BY m_category.id ASC;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetCategoryList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetCategoryList()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  m_category.id) AS sr, m_category.id, m_category.parent_category_id, " +
                     "m_category.name, m_category.description,c.name AS parent_category " +
                     "FROM m_category LEFT JOIN m_category c " +
                     "ON (c.id = m_category.parent_category_id) " +
                     "WHERE m_category.is_deleted = 0 ORDER BY m_category.id ASC;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSearchParentCategoryList.
        /// </summary>
        /// <param name="searchParentCategoryId">.</param>
        /// <returns>.</returns>
        public DataTable GetSearchParentCategoryList(Int64 searchParentCategoryId)
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  m_category.id) AS sr, m_category.id, m_category.parent_category_id, m_category.name, " +
                     "m_category.description,c.name AS parent_category " +
                     "FROM m_category LEFT JOIN m_category c " +
                     "ON(c.id= m_category.parent_category_id) " +
                     "WHERE (m_category.parent_category_id = " + searchParentCategoryId + " " +
                     "OR  m_category.id =" + searchParentCategoryId + " ) " +
                     "AND m_category.is_deleted = 0 " +
                     "ORDER BY m_category.id ASC;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="categoryEntity">.</param>
        public bool Update(CategoryEntity categoryEntity)
        {
            strSql = "UPDATE m_category SET parent_category_id = @parent_category_id, " +
                     " name = @name, description = @description, is_deleted = @is_deleted, " +
                     " updated_user_id = @updated_user_id, updated_datetime = @updated_datetime " +
                     " WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@id", categoryEntity.id),
                    new SQLiteParameter("@parent_category_id", categoryEntity.parent_category_id),
                    new SQLiteParameter("@name", categoryEntity.name),
                    new SQLiteParameter("@description", categoryEntity.description),
                    new SQLiteParameter("@is_deleted", categoryEntity.is_deleted),
                    new SQLiteParameter ("@updated_user_id",categoryEntity.updated_user_id),
                    new SQLiteParameter("@updated_datetime",categoryEntity.updated_datetime)
                };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="categoryId">.</param>
        public bool Delete(Int64 categoryId)
        {
            strSql = "UPDATE m_category SET is_deleted = 1 WHERE id = @id";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", categoryId)
                                             };
            return connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// GetChildCountByCategoryId.
        /// </summary>
        /// <param name="categoryId">.</param>
        /// <returns>.</returns>
        public int GetChildCountByCategoryId(Int64 categoryId)
        {
            strSql = "SELECT count(*) FROM m_category " +
                     " WHERE parent_category_id = @parent_category_id AND is_deleted = 0;";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@parent_category_id", categoryId)
                };
            int childCategoryListCount = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, SqliteParams));
            return childCategoryListCount;
        }

        /// <summary>
        /// GetProductCategoryList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetProductCategoryList()
        {
            strSql = " SELECT * from m_category WHERE is_deleted = 0; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetParentCategoryId.
        /// </summary>
        /// <param name="categoryId">.</param>
        /// <returns>.</returns>
        public object GetParentCategoryId(int categoryId)
        {
            strSql = " SELECT m_category.parent_category_id from m_category WHERE id = @id;";
            SQLiteParameter[] SqliteParams = {
                                                new SQLiteParameter("@id", categoryId)
                                             };
            return connection.ExecuteScalar(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// CheckExistCategoryName.
        /// </summary>
        /// <param name="categoryName">.</param>
        /// <returns>.</returns>
        public int IsExistCategoryName(string categoryName)
        {
            strSql = "SELECT COUNT(*) FROM m_category " +
                     "WHERE LOWER(name) = (SELECT LOWER('" + categoryName + "')) " +
                     "AND m_category.is_deleted = 0;";
            existCount = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, null));
            return existCount;
        }

        /// <summary>
        /// For Stock Entry
        /// The GetSubCategory.
        /// </summary>
        /// <param name="categoryId">The categoryId<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSubCategory(int categoryId)
        {
            strSql = "SELECT id, name FROM m_category " +
                     "WHERE parent_category_id = " + categoryId + " AND is_deleted = 0;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable GetSupplierCategory(int supplierId)
        {
            strSql = "SELECT m_category.id, m_category.name FROM m_category " +
                "LEFT JOIN m_product ON m_product.category_id = m_category.id " +
                " WHERE m_product.supplier_id = " + supplierId + " AND m_category.parent_category_id = 0 AND m_category.is_deleted = 0; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        public DataTable GetParentCategory()
        {
            strSql = "SELECT id, name from m_category WHERE is_deleted = 0 and parent_category_id = 0; ";
             return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        
        public DataTable GetCategory(int supplierId)
        {
            strSql = "select DISTINCT c.id, c.name from m_category c " +
                    "left join m_product p on p.category_id = c.id left join m_category on (c.id = m_category.parent_category_id)" +
                    "where (c.parent_category_id = 0 OR c.parent_category_id IS NULL) and supplier_id=" +supplierId+" and c.is_deleted=0;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable GetSelectedCategoryName(int categoryId)
        {
            strSql = "select c.name from m_category c " +
                    "where c.id=" + categoryId + " or (c.id = " +categoryId+" and c.parent_category_id = "+categoryId+") and c.is_deleted=0;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable GetSelectedSubCategory(int subCategoryId)
        {
            strSql = "select c.name from m_category c where (c.id = " + subCategoryId + " and c.parent_category_id <> 0) and c.is_deleted=0;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
    }
}
