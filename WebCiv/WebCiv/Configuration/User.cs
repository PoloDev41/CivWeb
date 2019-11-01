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
    public class User
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        [Key, Column(Order = 1)]
        public int Id { get; set; }

        /// <summary>
        /// name of the user
        /// </summary>
        [Required, MaxLength(24), Index(IsUnique = true), Column(Order = 100)]
        public string Name { get; set; }

        /// <summary>
        /// civization of the user
        /// </summary>
        public Civilization UserCiv { get; set; }
    }
}
