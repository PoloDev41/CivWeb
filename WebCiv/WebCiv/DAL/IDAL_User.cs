using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        /// create a civilization for a user
        /// </summary>
        /// <param name="gameName">name of the user</param>
        /// <param name="userId">Id of the user</param>
        /// <returns>true: user was created</returns>
        public bool CreateCivilization(int userId, string gameName);

        /// <summary>
        /// create a new civilization for a user which has already a name
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>true: user was created</returns>
        public bool CreateCivilization(int userId);

        /// <summary>
        /// create a player profil with no user and no civilization (mainly for test purpose only)
        /// </summary>
        /// <param name="gameName">name of the user</param>
        /// <returns>true: user was created</returns>
        public bool CreatePlayer(string gameName);

        /// <summary>
        /// return the user with the maximum of population
        /// </summary>
        /// <returns>user with the maximum of pop</returns>
        public AppUser GetUserMaxPop();

        /// <summary>
        /// return the user on the given Id
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <returns>user</returns>
        public AppUser GetUser(int id);

        /// <summary>
        /// return the user on the given Id
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <returns>user</returns>
        public AppUser GetUser(string id);

        /// <summary>
        /// return the ID of the user
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>id</returns>
        public static int GetUserId(ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
