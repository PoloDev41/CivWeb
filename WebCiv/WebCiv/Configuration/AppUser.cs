using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebCiv.Engine;

namespace WebCiv.Configuration
{
    /// <summary>
    /// handle all information about the user
    /// </summary>
    public class AppUser : IdentityUser<int>
    {
        /// <summary>
        /// name of the user
        /// </summary>
        /// Index(IsUnique = true),
        [Required, MaxLength(24),  Column(Order = 100)]
        public string GameName { get; set; }

        /// <summary>
        /// civization of the user
        /// </summary>
        public Civilization UserCiv { get; set; }
    }
}
