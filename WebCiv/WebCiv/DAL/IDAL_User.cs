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
        List<AppUser> GetAllUsers();

        /// <summary>
        /// create a player profil to a user
        /// </summary>
        /// <param name="gameName">name of the user</param>
        /// <param name="userId">Id of the user</param>
        /// <returns>true: user was created</returns>
        public bool CreatePlayer(int userId, string gameName);

        /// <summary>
        /// create a player profil with no user (mainly for test purpose only)
        /// </summary>
        /// <param name="gameName">name of the user</param>
        /// <returns>true: user was created</returns>
        public bool CreatePlayer(string gameName);

        /// <summary>
        /// return the user with the maximum of population
        /// </summary>
        /// <returns>user with the maximum of pop</returns>
        public AppUser GetUserMaxPop();
    }
}
