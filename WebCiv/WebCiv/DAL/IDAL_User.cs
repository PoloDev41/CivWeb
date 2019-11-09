using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCiv.Configuration;

namespace WebCiv.DAL
{
    /// <summary>
    /// interface to get information about user
    /// </summary>
    public interface IDAL_User : IDisposable
    {
        /// <summary>
        /// get all user
        /// </summary>
        /// <returns>users</returns>
        List<User> GetAllUsers();

        /// <summary>
        /// create a new user
        /// </summary>
        /// <param name="name">name of the user</param>
        /// <param name="password">password of the user</param>
        /// <returns>true: user was created</returns>
        bool CreateUser(string name, string password);

        /// <summary>
        /// authentify a user
        /// </summary>
        /// <param name="name">name of the user</param>
        /// <param name="password">password of the user</param>
        /// <returns>authentified user</returns>
        public User Authentify(string name, string password);

        /// <summary>
        /// return the user with the maximum of population
        /// </summary>
        /// <returns>user with the maximum of pop</returns>
        public User GetUserMaxPop();
    }
}
