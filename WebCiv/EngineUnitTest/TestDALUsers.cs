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
            
        }

        [Test]
        public void CreateNewUser()
        {
            using (IDAL_User dal = new DAL_User())
            {
                dal.CreateUser("FirstUser");
                var users = dal.GetAllUsers();

                Assert.IsNotNull(users);
                Assert.AreEqual(1, users.Count);
                Assert.AreEqual("FirstUser", users[0].Name);
            }
        }
    }
}
