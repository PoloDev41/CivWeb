using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebCiv.DAL;

namespace UnitTests
{
    class Test_PasswordHandler
    {
        [Test]
        public void CheckEncryption()
        {
            string password = "P@ssw0rd";
            var encrypted = Password_handler.Hash(password);
            bool verified = Password_handler.Check(encrypted, password);
            Assert.IsTrue(verified);
        }
    }
}
