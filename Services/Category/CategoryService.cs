using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Category;
using Entities.Category;
using System.Data;

namespace Services.Category
{
    /// <summary>
    /// Defines the <see cref="CategoryService" />.
    /// </summary>
    public class CategoryService
    {
        /// <summary>
        /// define categoryDao..
        /// </summary>
        private CategoryDao categoryDao = new CategoryDao();

        /// <summary>
        /// Defines the existCount.
        /// </summary>
        private int existCount;

        /// <summary>
        /// SetCategory.
        /// </summary>
        /// <param name="categorEntity">.</param>
        public bool SaveCategory(CategoryEntity categorEntity)
        {
            return categoryDao.CreateCategory(categorEntity);
        }

        /// <summary>
        /// UpdateCategory.
        /// </summary>
        /// <param name="categoryEntity">.</param>
        public bool UpdateCategory(CategoryEntity categoryEntity)
        {
            return categoryDao.Update(categoryEntity);
        }

        /// <summary>
        /// DeleteCategory.
        /// </summary>
        /// <param name="categoryId">.</param>
        public bool DeleteCategory(Int64 categoryId)
        {
            return categoryDao.Delete(categoryId);
        }

        public DataTable GetCategory(int supplierId)
        {
            return categoryDao.GetCategory(supplierId);
        }

        public DataTable GetSelectedCategoryName(int categoryId)
        {
            return categoryDao.GetSelectedCategoryName(categoryId);
        }

        public DataTable GetSelectedSubCategory(int subcategoryId)
        {
            return categoryDao.GetSelectedSubCategory(subcategoryId);
        }

        /// <summary>
        /// GetParentCategoryList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetParentCategoryList()
        {
            return categoryDao.GetParentCategoryList();
        }

        /// <summary>
        /// GetCategoryList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetCategoryList()
        {
            return categoryDao.GetCategoryList();
        }

        /// <summary>
        /// For Damage And Loss MMTZ
        /// GetProductCategoryList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetSubCategoryList()
        {
            return categoryDao.GetSubCategoryList();
        }

        /// <summary>
        /// GetSearchParentCategoryList.
        /// </summary>
        /// <param name="searchParentCategoryId">.</param>
        /// <returns>.</returns>
        public DataTable GetSearchParentCategoryList(Int64 searchParentCategoryId)
        {
            return categoryDao.GetSearchParentCategoryList(searchParentCategoryId);
        }

        /// <summary>
        /// GetChildCountByCategoryId.
        /// </summary>
        /// <param name="categoryId">.</param>
        /// <returns>.</returns>
        public int GetChildCountByCategoryId(Int64 categoryId)
        {
            int childCategoryListCount = categoryDao.GetChildCountByCategoryId(categoryId);

            return childCategoryListCount;
        }

        /// <summary>
        /// GetProductCategoryList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetProductCategoryList()
        {
            return categoryDao.GetProductCategoryList();
        }

        /// <summary>
        /// GetParentCategoryId.
        /// </summary>
        /// <param name="categoryId">.</param>
        /// <returns>.</returns>
        public int GetParentCategoryId(int categoryId)
        {
            var resultValue = categoryDao.GetParentCategoryId(categoryId);
            int parentCategoryId = resultValue != DBNull.Value ? Convert.ToInt32(resultValue) : 0;
            return parentCategoryId;
        }

        /// <summary>
        /// CheckExistCategoryName.
        /// </summary>
        /// <param name="categoryName">.</param>
        /// <returns>.</returns>
        public bool IsExistCategoryName(string categoryName)
        {
            existCount = categoryDao.IsExistCategoryName(categoryName);
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
        /// For Stock Entry NZMLW
        /// The GetSubCategory.
        /// </summary>
        /// <param name="parentId">The parentId<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSubCategory(int parentId)
        {
            return categoryDao.GetSubCategory(parentId);
        }

        public DataTable GetSupplierCategory(int supplierId)
        {
            return categoryDao.GetSupplierCategory(supplierId);
        }
        public DataTable GetParentCategory()
        {
            return categoryDao.GetParentCategory();
        }
    }
}
