using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Auth;

namespace Services.Auth
{
    /// <summary>
    /// Defines the <see cref="AuthService" />.
    /// </summary>
    public class AuthService
    {
        /// <summary>
        /// Defines the authDao.
        /// </summary>
        private AuthDao authDao = new AuthDao();

        /// <summary>
        /// The CheckValidLogin.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object CheckValidLogin(string username, string password)
        {
            return authDao.CheckValidLogin(username, password);
        }

        /// <summary>
        /// The GetPassword.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetPassword(string username)
        {
            return authDao.GetPassword(username);
        }

        /// <summary>
        /// The GetCompany.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetCompany()
        {
            return authDao.GetCompany();
        }
    }
}
