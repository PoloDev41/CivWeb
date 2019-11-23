using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebCiv.DAL;
using WebCiv.Engine;

namespace UnitTests
{
    class TestRoutine
    {
        [SetUp]
        public void Setup()
        {
            ApplicationDbContext.IsRunningOnMemory = true;
        }

        [Test]
        public void IncreasePopulationByRoutine()
        {
            int civID = 0;
            using (IDAL_User dal = new DAL_User())
            {
                Assert.IsTrue(dal.CreatePlayer("NewUserIncreasePop"));
                var users = dal.GetAllUsers();
                var user = users.Find(x => x.GameName == "NewUserIncreasePop");

                Assert.IsNotNull(user);
                Assert.IsTrue(dal.CreateCivilization(user.Id));

                var bdd_user = dal.GetUser(user.Id);
                civID = bdd_user.UserCiv.Id;
            }
            double startPop = 0;
            using (var dal = new DAL_Civ(null))
            {
                var civ = dal.GetCivilizationAndPopulation(civID);
                startPop = civ.Population.TotalPop;
                Assert.AreNotEqual(0, startPop);
            }
            
            Population.RoutineGrowAllPopulations(null);

            using (var dal = new DAL_Civ(null))
            {
                var civ = dal.GetCivilizationAndPopulation(civID);
                var total = dal.GetAllCivilizationAndPopulation();
                Assert.AreNotEqual(startPop, civ.Population.TotalPop);
            }
        }
    }
}
