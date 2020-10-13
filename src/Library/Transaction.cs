using System;
using System.Collections.Generic;

namespace Bankbot
{

    public class Transaction
    {
        public double Amount { get; set; }
        public Enums.Coin Coin { get; set; }
        public DateTime Date { get; set; }
        public Enums.AccountType Account { get; set; }
        public Enums.TransactionType Type { get; set; }
        public Enums.Item Item { get; set; }

        public Transaction(double amount, Enums.Coin coin, DateTime date, Enums.AccountType account, Enums.TransactionType type, Enums.Item item)
        {
            this.Amount = amount;
            this.Coin = coin;
            this.Date = date;
            this.Account = account;
            this.Type = type;
            this.Item = item;
        }
    }
}
