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
                Assert.IsTrue(dal.CreateUser("FirstUser", "password"));
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
                Assert.IsTrue(dal.CreateUser("Double", "password"));
                Assert.IsFalse(dal.CreateUser("Double", "password"));
                users = dal.GetAllUsers();

                Assert.IsNotNull(users);
                Assert.AreEqual(OriginalCount + 1, users.Count);
                Assert.AreEqual("Double", users[users.Count - 1].Name);
            }
        }

        [Test]
        public void CreateUser_CheckPassword()
        {
            using (IDAL_User dal = new DAL_User())
            {
                Assert.IsTrue(dal.CreateUser("User2", "P@ssw0rd"));
                var user = dal.Authentify("User2", "P@ssw0rd");

                Assert.IsNotNull(user);

                user = dal.Authentify("User2", "NotGood");
                Assert.IsNull(user);

                user = dal.Authentify("UnknownUser", "P@ssw0rd");
                Assert.IsNull(user);
            }
        }
    }
}
