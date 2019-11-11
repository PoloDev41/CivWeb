﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private ApplicationDbContext BDD_user;

        /// <summary>
        /// Create a new DAL user, use to get information about the user
        /// </summary>
        /// <param name="isInMemory">true, an option will be set to run the DB into memory</param>
        public DAL_User(bool isInMemory)
        {
            if(isInMemory)
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
               .Options;
               this.BDD_user = new ApplicationDbContext(options);
            }
            else
            {
                this.BDD_user = new ApplicationDbContext();
            }
        }

        /// <summary>
        /// Create a new DAL user, use to get information about the user
        /// </summary>
        public DAL_User()
        {
            this.BDD_user = new ApplicationDbContext();
        }

        /// <summary>
        /// dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            
        }
        /// <summary>
        /// dispose ressource
        /// </summary>
        /// <param name="disposing">isDisposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.BDD_user?.Dispose();
            }
        }

        /// <summary>
        /// return the list of all users
        /// </summary>
        /// <returns>list of users</returns>
        public List<AppUser> GetAllUsers()
        {
            return this.BDD_user.Users.ToList();
        }

        /// <summary>
        /// create a new user
        /// </summary>
        /// <param name="gameName">name of the user</param>
        /// <param name="userId">Id of the user</param>
        /// <returns>true: user was created</returns>
        public bool CreatePlayer(int userId, string gameName)
        {
            try
            {
                var user = BDD_user.Users.FirstOrDefault(u => u.Id == userId);
                if(user != null)
                {
                    var inBdd = BDD_user.Users.FirstOrDefault(u => u.GameName == gameName);
                    if(inBdd == null)
                    {
                        user.GameName = gameName;
                        this.BDD_user.SaveChanges();
                    }
                }
                else
                {
                    return false;
                }
                
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// create a player profil with no user (mainly for test purpose only)
        /// </summary>
        /// <param name="gameName">name of the user</param>
        /// <returns>true: user was created</returns>
        public bool CreatePlayer(string gameName)
        {
            try
            {
                var inBdd = BDD_user.Users.FirstOrDefault(u => u.GameName == gameName);
                if(inBdd == null)
                {
                    BDD_user.Users.Add(new AppUser() { GameName = gameName });
                    this.BDD_user.SaveChanges();
                    return true;
                }
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// return the user with the maximum of population
        /// </summary>
        /// <returns>user with the maximum of pop</returns>
        public AppUser GetUserMaxPop()
        {
            return this.BDD_user.Users
                .Where(x => x.UserCiv.Population.TotalPop != 0 &&
                        x.UserCiv.Population.TotalPop == BDD_user.Users.Max(p => p.UserCiv.Population.TotalPop)).SingleOrDefault();
        }
    }
}
