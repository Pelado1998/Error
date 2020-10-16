using System;
using System.Text;
using System.Collections.Generic;

namespace Bankbot
{
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
        public CurrencyType CurrencyType { get; set; }
        public double Amount { get; set; }
        public double Objective { get; set; }

        public Account(string name, AccountType type, CurrencyType currencyType, double amount, double objective)
        {
            this.Name = name;
            this.History = new List<Transaction>();
            this.AccountType = type;
            this.CurrencyType = currencyType;
            this.Amount = amount;
            this.Objective = objective;
        }


        /// <summary>
        /// Metodo para probar por consola creacion de cuentas
        /// </summary>
        /// <returns></returns>
        public static Account CreateAccount()
        {
            System.Console.WriteLine("Ingresa un nombre de cuenta: \n");
            var user = System.Console.ReadLine();
            System.Console.WriteLine("Ingresa un tipo de cuenta 1 2 3: \n");
            var type = System.Console.ReadLine();
            System.Console.WriteLine("Ingresa un tipo de moneda 1 2 3: \n");
            var coin = System.Console.ReadLine();
            System.Console.WriteLine("Ingresa un valor: \n");
            var amount = Convert.ToDouble(System.Console.ReadLine());
            System.Console.WriteLine("Ingresa un objetivo: \n");
            var objective = Convert.ToDouble(System.Console.ReadLine());
            return new Account(user, AccountType.CuentaDeAhorro, CurrencyType.URU, amount, objective);
        }
        public string MakeTransaction(double amount, CurrencyType currencyType, TransactionType transactionType)
        {
            if (transactionType == TransactionType.Outcome && amount > this.Amount)
            {
                return "Saldo insuficiente.";
            }
            else if (amount > 0)
            {
                var transaction = Transaction.MakeTransaction(amount, currencyType, DateTime.Now, this.AccountType, transactionType);
                var convertedAmount = Currency.Converter(amount, currencyType, this.CurrencyType);
                if (transaction != null)
                {
                    if (transactionType == TransactionType.Income)
                    {
                        this.Amount += convertedAmount;
                    }
                    else
                    {
                        this.Amount -= convertedAmount;
                    }
                    this.History.Add(transaction);
                }
                return "Trasferencia existosa.";
            }
            else
            {
                return "Valor inválido.";
            }
        }
        public void ChangeObjective(double newObjective)
        {
            this.Objective = newObjective;
        }
        public string ShowHistory()
        {
            StringBuilder status = new StringBuilder();
            status.Append("--- Historial de la cuenta " + this.Name + " ---\n");
            if (this.History.Count != 0)
            {
                foreach (Transaction transaction in this.History)
                {
                    System.Console.WriteLine(transaction.Type);
                    var type = transaction.Type == TransactionType.Income ? "Ingreso" : "Egreso";
                    status.Append($"{type}: {transaction.CurrencyType} {transaction.Amount} {transaction.Date.ToString("dd/MM/yyyy H:mm")} \n");
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
