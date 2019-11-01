using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebCiv.Configuration;

namespace WebCiv.DAL
{
    /// <summary>
    /// context about the user
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// users
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
