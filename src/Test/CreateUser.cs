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
            List<User> userList = new List<User>();
            _user = new User("prueba", "prueba");
            userList.Add(_user);
        }

        [Test]
        public void CreateUser_Complete()
        {
            Session.Instance.AddUser("user", "user");
            Assert.IsTrue(Session.Instance.AllUsers.Contains(Session.Instance.GetUser("user", "user")));
        }

        // [Test]
        // public void CreateUser_Exists()
        // {
        //     var result = _user != null;
        //     Assert.IsTrue(result);
        // }

    }
}