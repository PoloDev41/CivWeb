using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCiv.DAL;

namespace WebCiv.Engine
{
    /// <summary>
    /// Handle all information about population
    /// </summary>
    public class Population
    {
        /// <summary>
        /// Id of the population
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// number of total population
        /// </summary>
        public double TotalPop { get; set; }

        /// <summary>
        /// return the amount to increase the population
        /// </summary>
        /// <returns>number of population to increase</returns>
        public double IncreasePopulation()
        {
            return TotalPop * 0.1;
        }

        /// <summary>
        /// routine to cyclically execute to grow all populations of the game
        /// </summary>
        public static void RoutineGrowAllPopulations()
        {
            using (var dal = new DAL_Civ())
            {
                var civs = dal.GetAllCivilizationAndPopulation();
                foreach (var civ in civs)
                {
                    dal.IncreasePopulation(civ, civ.Population.IncreasePopulation());
                }
            }
        }
    }
}
