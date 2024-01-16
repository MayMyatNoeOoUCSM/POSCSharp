using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Product;
using Entities.Product;
using System.Data;

namespace Services.Product
{
    /// <summary>
    /// Defines the <see cref="ProductService" />.
    /// </summary>
    public class ProductService
    {
        /// <summary>
        /// Define product Dao..
        /// </summary>
        private ProductDao productDao = new ProductDao();

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
            int productCount = productDao.GetProductCountByCategoryId(categoryId);
            return productCount;
        }
        #endregion
        /// <summary>
        /// SaveProduct.
        /// </summary>
        /// <param name="productEntity">.</param>
        public void Insert(ProductEntity productEntity)
        {
            productDao.Insert(productEntity);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="productEntity">.</param>
        public void Update(ProductEntity productEntity)
        {
            productDao.Update(productEntity);
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">.</param>
        public void Delete(Int64 id)
        {
            productDao.Delete(id);
        }

        /// <summary>
        /// GetLastProductCode.
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public Int64 GetLastProductCode(int id)
        {
            Int64 lastProductCode = productDao.GetLastProductCode(id);
            return lastProductCode;
        }

        /// <summary>
        /// The GetProductList.
        /// </summary>
        public DataTable GetProductList()
        {
            return productDao.GetProductList();
        }

        /// <summary>
        /// GetProductCategoryList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetProductCategoryList()
        {
            return productDao.GetProductCategoryList();
        }

        /// <summary>
        /// The IsExistBarcode.
        /// </summary>
        /// <param name="barCode">The barCode<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool IsExistBarcode(string barCode, string id)
        {
            existCount = productDao.CheckDuplicateBarcode(barCode, id);
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
        /// The IsExistProductname.
        /// </summary>
        /// <param name="productName">The productName<see cref="string"/>.</param>
        /// <param name="productTypeId">The productTypeId<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool IsExistProductName(string productName, int productTypeId, string pid)
        {
            existCount = productDao.CheckDuplicateProductName(productName, productTypeId, pid);
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
        /// GetProduct
        /// </summary>
        /// <param name="catgoryId"></param>
        /// <param name="subCategoryId"></param>
        /// <returns></returns>
        public DataTable GetProduct(int catgoryId, int subCategoryId,int supplierId=0)
        {
            var id = 0;
            DataTable dtProduct = new DataTable();
            if(subCategoryId != 0)
            {
                id = subCategoryId;
                dtProduct = productDao.GetProductSubCategory(id,supplierId); 
            }
            else
            {
                id = catgoryId;
                dtProduct = productDao.GetProductCategory(id, supplierId);
            }
            return dtProduct;
        }

        /// <summary>
        /// The GetAllProduct.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetAllProduct()
        {
            return productDao.GetAllProduct();
        }

        /// <summary>
        /// The GetSearchResult.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSearchResult(List<object> filterList)
        {
            return productDao.GetSearchResult(filterList);
        }

        #region==========Damage and loss==========  
        /// <summary>
        /// The GetAllProduct.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetDamageLossProduct(int supplierId, int categoryId, int subCategoryId, int productId)
        {
            return productDao.GetDamageLossProduct(supplierId, categoryId, subCategoryId, productId);
        }
        #endregion

        #region==========Brand==========  
        /// <summary>
        /// The GetAllBrand.
        /// </summary>
        /// <param name="filterList">The filterList<see cref="List{object}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetAllBrand()
        {
            return productDao.GetAllBrand();
        }
        #endregion


    }
}
