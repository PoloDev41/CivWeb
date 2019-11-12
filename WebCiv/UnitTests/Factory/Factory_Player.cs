using System;
using System.Collections.Generic;
using System.Text;
using WebCiv.Configuration;
using WebCiv.DAL;

namespace UnitTests.Factory
{
    /// <summary>
    /// factory which generates player and civ
    /// </summary>
    public static class Factory_Player
    {
        /// <summary>
        /// create a new player and the civilization
        /// </summary>
        /// <param name="civName">name of the civ</param>
        /// <returns>user with civ</returns>
        public static AppUser CreateNewPlayer(string civName)
        {
            AppUser user;
            using (IDAL_User dal = new DAL_User())
            {
                dal.CreatePlayer(civName);
                var users = dal.GetAllUsers();
                user = users.Find(x => x.GameName == civName);
                dal.CreateCivilization(user.Id);
            }

            return user;
        }
    }
}
