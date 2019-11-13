using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCiv.DAL;

namespace WebCiv.Engine.PopAction
{
    /// <summary>
    /// class action to repop the population
    /// </summary>
    public class PopActionReproduce : BasePopAction
    {
        /// <summary>
        /// name of the population action
        /// </summary>
        public const string Name = "Reproduce";

        /// <summary>
        /// create the action pop action reproduce
        /// </summary>
        public PopActionReproduce()
        {
            this.ActionName = Name;
            this.Description = "Increase population";
        }

        /// <summary>
        /// execute the action
        /// </summary>
        /// <param name="civID">Id of the civilization</param>
        public override void ExecuteAction(int civID)
        {
            using (IDAL_Civ dal = new DAL_Civ())
            {
                var civ = dal.GetCivilizationAndPopulation(civID);
                dal.IncreasePopulation(civ, (int)Math.Max(1,((double)civ.Population.TotalPop*0.1f)));
            }
        }

        /// <summary>
        /// get the delay to execute the action
        /// </summary>
        /// <param name="civID">id of the civ</param>
        /// <returns>delay of the action</returns>
        public override TimeSpan GetDelay(int civID)
        {
            return TimeSpan.FromSeconds(3);
        }
    }
}
