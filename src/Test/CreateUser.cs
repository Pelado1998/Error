using NUnit.Framework;
using Bankbot;
using System.Collections.Generic;

namespace Test.Createuser
{
    [TestFixture]
    public class CreateUser
    {
        private User _user;
        [SetUp]
        public void Setup()
        {
            _user = new User("prueba", "prueba");
        }

        [Test]
        public void CreateUser_Complete()
        {
            Session.Instance.AddUser("user", "user");
            Assert.IsTrue(Session.Instance.AllUsers.Contains(Session.Instance.GetUser("user", "user")));
        }

        [Test]
        public void CreateUser_Exists()
        {
            Session.Instance.AddUser("user", "user");
            int count = 0;
            foreach (var item in Session.Instance.AllUsers)
            {
                if (item.Username == "user") count++;
            }
            Assert.IsFalse(count == 2);
        }

    }
}