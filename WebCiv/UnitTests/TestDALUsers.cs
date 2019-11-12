using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebCiv.DAL;
using WebCiv.Engine;

namespace EngineUnitTest
{
    public class TestDALUsers
    {
        [SetUp]
        public void Setup()
        {
            ApplicationDbContext.IsRunningOnMemory = true;
        }

        [Test]
        public void CreateNewUser()
        {
            using (IDAL_User dal = new DAL_User())
            {
                var users = dal.GetAllUsers();
                int OriginalCount = users.Count;
                Assert.IsTrue(dal.CreatePlayer("FirstUser"));
                users = dal.GetAllUsers();

                Assert.IsNotNull(users);
                Assert.AreEqual(OriginalCount + 1, users.Count);
                Assert.AreEqual("FirstUser", users[users.Count-1].GameName);
            }
        }

        [Test]
        public void CreateSameUser_CheckSecondWasnt()
        {
            using (IDAL_User dal = new DAL_User())
            {
                var users = dal.GetAllUsers();
                int OriginalCount = users.Count;
                Assert.IsTrue(dal.CreatePlayer("Double"));
                Assert.IsFalse(dal.CreatePlayer("Double"));
                users = dal.GetAllUsers();

                Assert.IsNotNull(users);
                Assert.AreEqual(OriginalCount + 1, users.Count);
                Assert.AreEqual("Double", users[users.Count - 1].GameName);
            }
        }

        [Test]
        public void CreateCivilization()
        {
            using (IDAL_User dal = new DAL_User())
            {
                Assert.IsTrue(dal.CreatePlayer("NewUserWithCiv"));
                var users = dal.GetAllUsers();
                var user = users.Find(x => x.GameName == "NewUserWithCiv");
                
                Assert.IsNotNull(user);

                Assert.IsTrue(dal.CreateCivilization(user.Id));

                var bdd_user = dal.GetUser(user.Id);

                Assert.IsNotNull(bdd_user?.UserCiv?.Population);
            }
        }
    }
}
