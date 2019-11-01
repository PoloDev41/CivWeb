using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using WebCiv.DAL;

namespace EngineUnitTest
{
    public class TestDALUsers
    {
        [SetUp]
        public void Setup()
        {
            IDatabaseInitializer<UserContext> init = new DropCreateDatabaseAlways<UserContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new UserContext());
        }

        [Test]
        public void CreateNewUser()
        {
            using (IDAL_User dal = new DAL_User())
            {
                var users = dal.GetAllUsers();
                int OriginalCount = users.Count;
                Assert.IsTrue(dal.CreateUser("FirstUser"));
                users = dal.GetAllUsers();

                Assert.IsNotNull(users);
                Assert.AreEqual(OriginalCount + 1, users.Count);
                Assert.AreEqual("FirstUser", users[users.Count-1].Name);
            }
        }

        [Test]
        public void CreateSameUser_CheckSecondWasnt()
        {
            using (IDAL_User dal = new DAL_User())
            {
                var users = dal.GetAllUsers();
                int OriginalCount = users.Count;
                Assert.IsTrue(dal.CreateUser("Double"));
                Assert.IsFalse(dal.CreateUser("Double"));
                users = dal.GetAllUsers();

                Assert.IsNotNull(users);
                Assert.AreEqual(OriginalCount + 1, users.Count);
                Assert.AreEqual("Double", users[users.Count - 1].Name);
            }
        }
    }
}
