using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.License;
using Entities.License;
using System.Data;

namespace Services.License
{
    /// <summary>
    /// Defines the <see cref="LicenseService" />.
    /// </summary>
    public class LicenseService
    {
        /// <summary>
        /// Defines the authDao.
        /// </summary>
        private LicenseDao licenseDao = new LicenseDao();

        /// <summary>
        /// GetLicenseList.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetLicenseList()
        {
            return licenseDao.GetLicenseList();
        }

        /// <summary>
        /// SaveLicenseKey.
        /// </summary>
        /// <param name="licenseEntity">.</param>
        public void CreateLicenseKey(LicenseEntity licenseEntity)
        {
            licenseDao.CreateLicenseKey(licenseEntity);
        }

        /// <summary>
        /// UpdateLicenseKey.
        /// </summary>
        public void UpdateLicenseKey()
        {
            licenseDao.UpdateLicenseKey();
        }
    }
}
