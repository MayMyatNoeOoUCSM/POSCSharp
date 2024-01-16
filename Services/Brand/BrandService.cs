using DAO.Brand;
using Entities.Brand;
using System;
using System.Data;

namespace Services.Brand
{
    public class BrandService
    {
        /// <summary>
        /// define BrandDao..
        /// </summary>
        private BrandDao brandDao = new BrandDao();

        /// <summary>
        /// Defines the existCount.
        /// </summary>
        private int existCount;

        /// <summary>
        /// SetBrand.
        /// </summary>
        /// <param name="brandEntity">.</param>
        public bool SaveBrand(BrandEntity brandEntity)
        {
            return brandDao.CreateBrand(brandEntity);
        }

        /// <summary>
        /// UpdateBrand.
        /// </summary>
        /// <param name="brandEntity">.</param>
        public bool UpdateBrand(BrandEntity brandEntity)
        {
            return brandDao.Update(brandEntity);
        }

        /// <summary>
        /// DeleteBrand.
        /// </summary>
        /// <param name="brandId">.</param>
        public bool DeleteBrand(Int64 brandId)
        {
            return brandDao.Delete(brandId);
        }

        /// <summary>
        /// GetBrandId
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandId(int brandId)
        {
            var resultValue = brandDao.GetBrandId(brandId);
            int BrandId = resultValue != DBNull.Value ? Convert.ToInt32(resultValue) : 0;
            return BrandId;
        }

        /// <summary>
        /// GetBrandList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetBrandList()
        {
            return brandDao.GetBrandList();
        }

        /// <summary>
        /// IsExistBrandName.
        /// </summary>
        /// <param name="brandName">.</param>
        /// <returns>.</returns>
        public bool IsExistBrandName(string brandName)
        {
            existCount = brandDao.IsExistBrandName(brandName);
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
        /// SearchBrand
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public DataTable GetSearchResult(string brandName)
        {
            return brandDao.GetSearchResult(brandName);
        }

        /// <summary>
        /// GetBrandCountInProduct
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandCountInProduct(Int64 brandId)
        {
            int brandCount = brandDao.GetBrandCountInProduct(brandId);
            return brandCount;
        }
    }
}
