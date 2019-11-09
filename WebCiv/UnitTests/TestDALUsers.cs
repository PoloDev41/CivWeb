using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebCiv.DAL;

namespace EngineUnitTest
{
    public class TestDALUsers
    {
        [SetUp]
        public void Setup()
        {
            IDatabaseInitializer<ApplicationDbContext> init = new DropCreateDatabaseAlways<ApplicationDbContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new ApplicationDbContext());
        }

        [Test]
        public void CreateNewUser()
        {
            using (IDAL_User dal = new DAL_User())
            {
                var users = dal.GetAllUsers();
                int OriginalCount = users.Count;
                //Assert.IsTrue(dal.CreatePlayer("FirstUser", "password"));
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
                //Assert.IsTrue(dal.CreatePlayer("Double", "password"));
                //Assert.IsFalse(dal.CreatePlayer("Double", "password"));
                users = dal.GetAllUsers();

                Assert.IsNotNull(users);
                Assert.AreEqual(OriginalCount + 1, users.Count);
                Assert.AreEqual("Double", users[users.Count - 1].GameName);
            }
        }
    }
}
