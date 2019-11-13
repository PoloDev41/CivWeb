using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCiv.Engine
{
    /// <summary>
    /// class to know which population action is running
    /// </summary>
    public class CivCurrentPopAction
    {
        /// <summary>
        /// name of the population action
        /// </summary>
        public string PopActionName { get; set; }

        /// <summary>
        /// date when to execute the population action
        /// </summary>
        public DateTime DateToExecute { get; set; }
    }
}
