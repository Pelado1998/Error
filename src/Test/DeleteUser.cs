using NUnit.Framework;
using Bankbot;

namespace Test.Delete
{
    [TestFixture]
    public class Delete
    {
        private User _user;
        [SetUp]
        public void Setup()
        {
            Session.Instance.AddUser("user", "user");
        }

        [Test]
        public void DeleteUser()
        {
            Session.Instance.RemoveUser("user", "user");
            Assert.IsTrue(Session.Instance.GetUser("user", "user") == null);
        }

        [Test]
        public void DeleteUserFail()
        {
            Session.Instance.RemoveUser("user2", "user2");
            Assert.IsTrue(Session.Instance.GetUser("user", "user") != null);
        }
        
    }
}