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
    public enum Item
    {
        Salario = 1,
        Comida = 2,
        Transporte = 3,
        Ocio = 4,
        Alquiler = 5,
        Impuestos = 6,
    }

    public class Transaction
    {
        public double Amount { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public DateTime Date { get; set; }
        public AccountType Account { get; set; }
        public TransactionType Type { get; set; }
        private Transaction(double amount, CurrencyType currencyType, DateTime date, AccountType account, TransactionType type)
        {
            this.Amount = amount;
            this.CurrencyType = currencyType;
            this.Date = date;
            this.Account = account;
            this.Type = type;
        }

        public static Transaction MakeTransaction(double amount, CurrencyType currencyType, DateTime date, AccountType accountType, TransactionType transactionType)
        {
            return new Transaction(amount, currencyType, date, accountType, transactionType);
        }
    }
}
