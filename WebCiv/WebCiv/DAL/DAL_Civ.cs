using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCiv.Engine;

namespace WebCiv.DAL
{
    /// <summary>
    /// class to get civilization information
    /// </summary>
    public class DAL_Civ : IDAL_Civ
    {
        /// <summary>
        /// context of the civilization
        /// </summary>
        private ApplicationDbContext BDContext;

        /// <summary>
        /// Create a new DAL civilization, use to get information about the user
        /// </summary>
        public DAL_Civ()
        {
            if (ApplicationDbContext.IsRunningOnMemory)
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
               .Options;
                this.BDContext = new ApplicationDbContext(options);
            }
            else
            {
                this.BDContext = new ApplicationDbContext();
            }
        }

        /// <summary>
        /// dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        /// <summary>
        /// dispose ressource
        /// </summary>
        /// <param name="disposing">isDisposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.BDContext?.Dispose();
            }
        }

        /// <summary>
        /// return the civilization from the id
        /// </summary>
        /// <param name="civId">civ id</param>
        /// <returns>civilization</returns>
        public Civilization GetCivilizationAndPopulation(int civId)
        {
            var civ = this.BDContext.Civilizations
                .Where(x => x.Id == civId)
                .Include(x => x.Population)
                .SingleOrDefault();

            return civ;
        }

        /// <summary>
        /// increase the population
        /// </summary>
        /// <param name="civ">civilization to update</param>
        /// <param name="amount">amount to add</param>
        public void IncreasePopulation(Civilization civ, int amount)
        {
            if(civ?.Population?.TotalPop == null)
            {
                return;
            }

            civ.Population.TotalPop += amount;
            this.BDContext.SaveChanges();
        }
    }
}
