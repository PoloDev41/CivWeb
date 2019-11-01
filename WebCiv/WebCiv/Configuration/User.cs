using System;
using System.Collections.Generic;
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
        public int Id { get; set; }

        /// <summary>
        /// name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// civization of the user
        /// </summary>
        public virtual Civilization UserCiv { get; set; }
    }
}
