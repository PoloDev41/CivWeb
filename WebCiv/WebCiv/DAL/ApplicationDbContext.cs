using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCiv.Configuration;

namespace WebCiv.DAL
{
    /// <summary>
    /// context about the user
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
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
