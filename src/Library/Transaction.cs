using System;
using System.Collections.Generic;

namespace Bankbot
{
    public enum TransactionType
    {
        Income = 1,
        Outcome = 2,
        Null = 3,
        // Este valor null lo estoy usando para probar!!!
    }
    public class Transaction
    {
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
        public AccountType Account { get; set; }
        public TransactionType Type { get; set; }
        public String Item { get; set; }
        public Transaction(double amount, Currency currency, DateTime date, AccountType account, TransactionType type, String item)
        {
            this.Amount = amount;
            this.Currency = currency;
            this.Date = date;
            this.Account = account;
            this.Type = type;
            this.Item = item;
        }
    }
}
