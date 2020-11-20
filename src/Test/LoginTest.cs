using NUnit.Framework;
using Bankbot;

namespace Test.Login
{
    [TestFixture]
    public class Login
    {
        private User _user;
        [SetUp]
        public void Setup()
        {
            _user = new User("user", "pass");
        }

        [Test]
        public void Login_Complete()
        {
            Assert.IsTrue(_user.Login("pass"));
        }

        [Test]
        public void Login_Fail()
        {
            Assert.IsFalse(_user.Login("pss"));
        }
        
    }
}