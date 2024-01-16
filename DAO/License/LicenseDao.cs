using System;
using System.Data;
using System.Data.SQLite;
using DAO.Common;
using Entities.License;

namespace DAO.License
{
    /// <summary>
    /// Defines the <see cref="LicenseDao" />.
    /// </summary>
    public class LicenseDao
    {
        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// GetLicense.
        /// </summary>
        /// <returns>.</returns>
        public DataTable GetLicenseList()
        {
            strSql = " SELECT * from licensekey WHERE is_expired = 0; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// CreateLicenseKey.
        /// </summary>
        /// <param name="licenseEntity">.</param>
        public void CreateLicenseKey(LicenseEntity licenseEntity)
        {
            strSql = "INSERT INTO licensekey(license_key,created_date, expired_date,is_expired)" +
                     "VALUES(@license_key,@created_date,@expired_date,@is_expired)";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@license_key", licenseEntity.license_key),
                    new SQLiteParameter("@created_date", licenseEntity.created_date),
                    new SQLiteParameter("@expired_date", licenseEntity.expired_date),
                    new SQLiteParameter("@is_expired", licenseEntity.is_expired)
                };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }

        /// <summary>
        /// UpdateLicenseKey.
        /// </summary>
        /// <param name="categoryEntity">.</param>
        public void UpdateLicenseKey()
        {
            strSql = "UPDATE licensekey set is_expired = @is_expired";
            SQLiteParameter[] SqliteParams = {
                    new SQLiteParameter("@is_expired", 1 )
                };
            connection.ExecuteNonQuery(CommandType.Text, strSql, SqliteParams);
        }
    }
}
