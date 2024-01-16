using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Common;

namespace DAO.Auth
{
    /// <summary>
    /// Defines the <see cref="AuthDao" />.
    /// </summary>
    public class AuthDao
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
        /// The CheckValidLogin.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public object CheckValidLogin(string username, string password)
        {
            strSql = "SELECT id FROM m_staff WHERE staff_id ='" + username + "' " +
                     "AND password = '" + password + "'" +
                     "AND active_status = 1 and role=1 and (date(join_to) is null or join_to > date('" + DateTime.Now.ToString(Consts.DATEFORMAT) + "'));";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetPassword.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetPassword(string username)
        {
            strSql = "SELECT password FROM m_staff WHERE staff_id = '" + username + "';";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetCompany.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetCompany()
        {
            strSql = "SELECT name FROM m_company where id = 1;";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }
    }
}
