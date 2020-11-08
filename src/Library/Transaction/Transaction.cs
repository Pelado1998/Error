using System;

namespace Bankbot
{
    /// <summary>
    /// Esta clase cumple con el patrón Expert del principio GRASP ya que es la que contiene toda la información
    /// sobre Transaction, pero tambien con el patrón SRP por tener una unica razón de cambio.
    /// </summary>
    public abstract class Transaction
    {
        public float Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        protected Transaction(float amount, Currency currency, DateTime date, string description)
        {
            this.Amount = amount;
            this.Currency = currency;
            this.Date = date;
            this.Description = description;
        }
    }
}
