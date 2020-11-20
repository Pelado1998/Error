using NUnit.Framework;
using Bankbot;

namespace Test.Login
{
    [TestFixture]
    public class CreateUser_Complete
    {
        private User _user;
        [SetUp]
        public void Setup()
        {
            _user = new User("prueba", "prueba");
        }

        [Test]
        public void CreateUser_ReturnTrue()
        {
            var result = _user != null;
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateUser_ReturnFalse()
        {
            var result = _user != null;
            Assert.IsTrue(result);
        }

    }
}