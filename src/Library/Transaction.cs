using System;

namespace Bankbot
{
    /// <summary>
    /// Esta clase cumple con el patrón Expert del principio GRASP ya que es la que contiene toda la información
    /// sobre Transaction, pero tambien con el patrón SRP por tener una unica razón de cambio.
    /// </summary>
    public class Transaction
    {
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public Transaction(double amount, Currency currency, DateTime date, String type)
        {
            this.Amount = amount;
            this.Currency = currency;
            this.Date = date;
            this.Type = type;
            this.Description = string.Empty;
        }
        public Transaction(double amount, Currency currency, DateTime date, String type, String description)
        {
            this.Amount = amount;
            this.Currency = currency;
            this.Date = date;
            this.Type = type;
            this.Description = description;
        }
    }
}
