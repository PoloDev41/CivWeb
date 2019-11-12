using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCiv.Engine.PopAction
{
    /// <summary>
    /// abstract class for action on population
    /// </summary>
    public abstract class BasePopAction
    {
        /// <summary>
        /// name of the action
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// description of the action
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// get the delay to execute the action
        /// </summary>
        /// <param name="civID">id of the civ</param>
        /// <returns>delay of the action</returns>
        public abstract TimeSpan GetDelay(int civID);

        /// <summary>
        /// execute the action
        /// </summary>
        /// <param name="civID">Id of the civilization</param>
        public abstract void ExecuteAction(int civID);
    }
}
