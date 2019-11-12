using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebCiv.DAL;
using WebCiv.Engine.TechnologyTree;

namespace UnitTests
{
    class TestCivTechno
    {
        [Test]
        public void TestTechnoOnCreation()
        {
            using (IDAL_User dal = new DAL_User(true))
            {
                Assert.IsTrue(dal.CreatePlayer("TestCiv"));
                var users = dal.GetAllUsers();
                var user = users.Find(x => x.GameName == "TestCiv");

                Assert.IsTrue(dal.CreateCivilization(user.Id));

                var techTree = dal.LoadAllTech(user.Id);
                Assert.IsNotNull(techTree?.TechnologyProgression);

                Assert.AreEqual(1, techTree.TechnologyProgression.Count);
                var tech = techTree.TechnologyProgression.Find(x => (x.TechnologyName == TechnoDiscovering.DiscoveringName));
                Assert.IsNotNull(tech);

                Assert.IsNotNull(tech);
                Assert.AreEqual(0, tech.CurrentProgression);
                Assert.AreEqual(100, tech.NextObjective);
            }
        }
    }
}
