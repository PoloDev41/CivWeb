using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCiv.Engine;

namespace WebCiv.DAL
{
    /// <summary>
    /// interface of the civilizations
    /// </summary>
    public interface IDAL_Civ : IDisposable
    {
        /// <summary>
        /// return the civilization from the id
        /// </summary>
        /// <param name="civId">civ id</param>
        /// <returns>civilization</returns>
        public Civilization GetCivilizationAndPopulation(int civId);

        /// <summary>
        /// increase the population
        /// </summary>
        /// <param name="civ">civilization to update</param>
        /// <param name="amount">amount to add</param>
        public void IncreasePopulation(Civilization civ, int amount);
    }
}
