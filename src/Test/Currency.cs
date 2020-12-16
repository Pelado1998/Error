// using NUnit.Framework;
// using Bankbot;
// using System.Collections.Generic;

// namespace Test.CreateCurrency
// {
//     [TestFixture]
//     public class CreateCurrency
//     {
//         [SetUp]
//         public void Setup()
//         {

//         }

//         [Test]
//         public void CreateCurrency_Complete()
//         {
//             Bank.Instance.AddCurrency("iso", "symbol", 1);
//             Assert.IsTrue(Bank.Instance.CurrencyExists("iso", "symbol"));
//         }

//         [Test]
//         public void CreateCurrency_Exists()
//         {
//             Bank.Instance.AddCurrency("iso", "symbol", 1);
//             int count = 0;
//             foreach (var item in Bank.Instance.CurrencyList)
//             {
//                 if (item.CodeISO == "iso") count++;
//             }
//             Assert.IsFalse(count == 2);
//         }
//     }
// }