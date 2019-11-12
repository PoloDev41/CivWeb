using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCiv.Configuration;
using WebCiv.Engine;

namespace WebCiv.DAL
{
    /// <summary>
    /// context about the user
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        /// <summary>
        /// if you set this variable to "true", mean, all instance should be running in memory
        /// </summary>
        public static bool IsRunningOnMemory = false;

        /// <summary>
        /// set of the civilizations
        /// </summary>
        public DbSet<Civilization> Civilizations { get; set; }

        /// <summary>
        /// Create a new application DbContext with options
        /// </summary>
        /// <param name="options">options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        /// <summary>
        /// Create a new applciation DB context
        /// </summary>
        public ApplicationDbContext() 
        {

        }

    }
}
