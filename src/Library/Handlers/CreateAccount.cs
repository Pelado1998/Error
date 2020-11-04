using System;
using System.Collections.Generic;
using System.Text;

namespace Bankbot
{
    public class CreateAccount : AbstractHandler<Chats>
    {
        public CreateAccount(CreateAccountCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Chats request)
        {
            // Create Account
        }
        private static string ShowAccountType()
        {
            StringBuilder enumToText = new StringBuilder();
            var accountType = Enum.GetNames(typeof(AccountType));
            foreach (var item in accountType)
            {
                enumToText.Append($"{Array.IndexOf(accountType, item) + 1 } - {item}\n");
            }
            return enumToText.ToString();
        }
        private static string ShowCurrencyList()
        {
            StringBuilder currencies = new StringBuilder();
            foreach (Currency currency in Bank.Instance.CurrencyList)
            {
                currencies.Append($"{Bank.Instance.CurrencyList.IndexOf(currency) + 1} - {currency.CodeISO}\n");
            }
            return currencies.ToString();
        }
    }
}