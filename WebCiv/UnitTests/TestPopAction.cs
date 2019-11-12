using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.Factory;
using WebCiv.DAL;
using WebCiv.Engine;
using WebCiv.Engine.PopAction;

namespace UnitTests
{
    class TestPopAction
    {
        [SetUp]
        public void Setup()
        {
            ApplicationDbContext.IsRunningOnMemory = true;
        }

        [Test]
        public void TestPopActionMecanique()
        {
            var user = Factory_Player.CreateNewPlayer("newPLayerTestPopAction");
            double originalPop = user.UserCiv.Population.TotalPop;
            Assert.IsTrue(originalPop != 0);

            var actionReproduce = new PopActionReproduce();
            Assert.IsTrue(actionReproduce.GetDelay(user.UserCiv.Id).TotalSeconds > 0);
            actionReproduce.ExecuteAction(user.UserCiv.Id);

            using (IDAL_Civ dal = new DAL_Civ())
            {
                var updateCiv = dal.GetCivilizationAndPopulation(user.UserCiv.Id);
                Assert.Greater(updateCiv.Population.TotalPop, originalPop);
            }
        }
    }
}
