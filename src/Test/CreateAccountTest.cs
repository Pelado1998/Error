using NUnit.Framework;
using Bankbot;
using System.Collections.Generic;

namespace Test.CreateAccount
{
    [TestFixture]
    public class CreateAccount
    {
        private User _user;
        [SetUp]
        public void Setup()
        {
            _user = new User("prueba", "prueba");
        }

        [Test]
        public void CreateAccount_Complete()
        {
            var account = _user.AddAccount(AccountType.Credito, "prueba", new Currency("UYU", "U$U", 1), 1, new Objective(2,1));
            Assert.IsTrue(account != null);
        }

        [Test]
        public void CreateAccount_Exists()
        {
            var account = _user.AddAccount(AccountType.Credito, "prueba", new Currency("UYU", "U$U", 1), 1, new Objective(2,1));
            Assert.IsFalse(account == null);
        }

    }
}