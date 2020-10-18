using System;
using System.Collections.Generic;

namespace Bankbot
{
    /// <summary>
    /// 
    /// </summary>
    public class Transaction
    {
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
        public String Item { get; set; }
        public String Description {get; set;}
        public Transaction(double amount, Currency currency, DateTime date, String item)
        {
            this.Amount = amount;
            this.Currency = currency;
            this.Date = date;
            this.Item = item;
            this.Description = string.Empty;
        }
        public Transaction(double amount, Currency currency, DateTime date, String item, String description)
        {
            this.Amount = amount;
            this.Currency = currency;
            this.Date = date;
            this.Item = item;
            this.Description = description;
        }
    }
}
