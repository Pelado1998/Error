using System;
using System.Text;
using System.Collections.Generic;
using static System.Math;

namespace Bankbot
{
    /// <summary>
    /// 
    /// </summary>
    
    public enum AccountType
    {
        CuentaDeAhorro = 1,
        Debito = 2,
        Credito = 3
    }
    public class Account : IObservable
    {
        public string Name { get; set; }
        public List<Transaction> History { get; set; }
        public AccountType AccountType { get; set; }
        public Currency Currency { get; set; }
        public double Amount { get; set; }
        public double Objective { get; set; }
        public Account(string name, AccountType type, Currency currency, double amount, double objective)
        {
            this.Name = name;
            this.History = new List<Transaction>();
            this.AccountType = type;
            this.Currency = currency;
            this.Amount = amount;
            this.Objective = objective;
        }

        public void ChangeObjective(double newObjective)
        {
            this.Objective = newObjective;
        }
        /// <summary>
        /// El método MakeTransaction cumple con el patrón creator.Tiene la información necesaria para la
        /// creación del objeto transaction.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public string MakeTransaction(double amount, Currency currency, String item)
        {
            if (amount+this.Amount<0)
            {
                return "Saldo insuficiente.";
            }
            else if (amount+this.Amount>0)
            {
                double convertedAmount = Bank.Convert(amount, currency, this.Currency);
                Transaction transaction = new Transaction(convertedAmount,this.Currency, DateTime.Now,item);
                this.Amount+=convertedAmount;
                this.History.Add(transaction);
                return "Trasferencia existosa.";
            }
            else
            {
                return "Valor inválido.";
            }
        }

        public string ShowHistory()
        {
            StringBuilder status = new StringBuilder();
            status.Append("--- Historial de la cuenta " + this.Name + " ---\n");
            if (this.History.Count != 0)
            {
                foreach (Transaction transaction in this.History)
                {
                    var type = Sign(transaction.Amount) == 1 ? "Ingreso" : "Egreso";
                    status.Append($"{type}: {transaction.Currency} {transaction.Amount} {transaction.Date.ToString("dd/MM/yyyy H:mm")} \n");
                }
            }
            else
            {
                status.Append("Esta cuenta está vacía.\n");
                System.Console.WriteLine(status);
                // status += new String(' ', (status.Length - 1) / 4) + "Esta cuenta está vacía.\n";
                // status += "----------------------------" + new String('-', this.Name.Length);
                // System.Console.WriteLine(status);
                // return;
            }
            status.Append($"Total: {this.Amount} / {this.Objective}");
            if (this.Amount >= this.Objective)
            {
                status.Append("'😁'\n");
            }
            else
            {
                status.Append("'🥺'\n");
            }
            status.Append("-----------------------------------------");
            System.Console.WriteLine(status);
            return status.ToString();
        }
        
    }
}
