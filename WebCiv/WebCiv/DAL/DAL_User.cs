using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCiv.Configuration;

namespace WebCiv.DAL
{
    /// <summary>
    /// DAL about user
    /// </summary>
    public class DAL_User : IDAL_User
    {
        /// <summary>
        /// context of the users
        /// </summary>
        private UserContext BDD_user;

        /// <summary>
        /// Create a new DAL user, use to get information about the user
        /// </summary>
        public DAL_User()
        {
            this.BDD_user = new UserContext();
        }

        /// <summary>
        /// dispose
        /// </summary>
        public void Dispose()
        {
            this.BDD_user.Dispose();
        }

        /// <summary>
        /// return the list of all users
        /// </summary>
        /// <returns>list of users</returns>
        public List<User> GetAllUsers()
        {
            return this.BDD_user.Users.ToList();
        }

        /// <summary>
        /// create a new user
        /// </summary>
        /// <param name="name">name of the user</param>
        /// <returns>true: user was created</returns>
        public bool CreateUser(string name)
        {
            try
            {
                this.BDD_user.Users.Add(new User { Name = name });
                this.BDD_user.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// return the user with the maximum of population
        /// </summary>
        /// <returns>user with the maximum of pop</returns>
        public User GetUserMaxPop()
        {
            return this.BDD_user.Users
                .Where(x => x.UserCiv.Population.TotalPop != 0 &&
                        x.UserCiv.Population.TotalPop == BDD_user.Users.Max(p => p.UserCiv.Population.TotalPop)).SingleOrDefault();
        }
    }
}
