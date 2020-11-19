using System;

namespace Bankbot
{
    /*Esta clase cumple con el patrón Expert del principio GRASP ya que es la que contiene toda la información
    sobre Transaction, pero tambien con el patrón SRP por tener una unica razón de cambio.*/

    /// <summary>
    /// Realiza las transacciones.
    /// </summary>
    public class Transaction
    {
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Crea objeto transacción.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="date"></param>
        /// <param name="description"></param>

        public Transaction(double amount, Currency currency, DateTime date, string description)
        {
            this.Amount = amount;
            this.Currency = currency;
            this.Date = date;
            this.Description = description;
        }

    }
}
