using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Account : IObservable
    {
        public string Name { get; set; }
        public List<Transaction> History { get; set; }
        public Enums.AccountType AccountType { get; set; }
        public Enums.Coin Coin { get; set; }
        public double Amount { get; set; }
        public double Objective { get; set; }

        public Account(string name, Enums.AccountType type, Enums.Coin coin, double amount, double objective)
        {
            this.Name = name;
            this.History = new List<Transaction>();
            this.AccountType = type;
            this.Coin = coin;
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
            return new Account(user, Enums.AccountType.CuentaDeAhorro, Enums.Coin.URU, amount, objective);
        }

        // public List<IItems> items { get; set; }
        // public Account(string name, string history, Enums.AccountType accountType, Enums.Coin coin, Money objective)
        // {
        //     this.name = name;
        //     this.history = new List<Transaction>();
        //     this.accountType = accountType;
        //     this.coin = coin;
        //     this.amount = new Money(coin, 0);
        //     this.objective = objective;
        //     this.items = new List<IItems> { };
        // }
        // public Account(string name, Enums.AccountType accountType, Enums.Coin coin, Money objective)
        // {
        //     this.name = name;
        //     this.history = history;
        //     this.accountType = accountType;
        //     this.coin = coin;
        //     this.amount = new Money(coin, 0);
        //     this.objective = objective;
        //     this.items = new List<IItems> { };
        // }
        // public Account(string name, Enums.AccountType accountType, Enums.Coin coin)
        // {
        //     this.name = name;
        //     this.history = history;
        //     this.accountType = accountType;
        //     this.coin = coin;
        //     this.amount = new Money(coin, 0);
        //     this.objective = new Money(coin, 0);
        //     this.items = new List<IItems> { };
        // }
        public void Accredit(double amount, Enums.Coin coin, Enums.Item item)
        {
            if (amount > 0)
            {
                var convertedAmount = Money.Converter(amount, coin, this.Coin);

                Transaction transaction = new Transaction(convertedAmount, coin, DateTime.Now, this.AccountType, Enums.TransactionType.Accredit, item);
                if (transaction != null)
                {
                    this.Amount += convertedAmount;
                    this.History.Add(transaction);
                }
            }
            else
            {
                System.Console.WriteLine("Valor inválido.");
            }
        }
        public void Debit(double amount, Enums.Coin coin, Enums.Item item)
        {
            if (this.Amount >= amount)
            {
                var convertedAmount = Money.Converter(amount, coin, this.Coin);

                Transaction transaction = new Transaction(convertedAmount, coin, DateTime.Now, this.AccountType, Enums.TransactionType.Debit, item);
                if (transaction != null)
                {
                    this.Amount -= convertedAmount;
                    this.History.Add(transaction);
                }
            }
            else
            {
                System.Console.WriteLine("No tienes suficiente dinero");
            }
        }
        // public void AddItem(IItems item)
        // {
        //     if (this.ItemExists(item))
        //     {
        //         System.Console.WriteLine("El item ya existe.");
        //     }
        //     else
        //     {
        //         this.items.Add(item);
        //         if (item.amount.amount != 0 && typeof(Income) == item.GetType())
        //         {
        //             this.amount += item.amount;
        //         }
        //         else
        //         {
        //             this.amount -= item.amount;
        //         }
        //     }
        // }
        // public void RemoveItem(IItems item)
        // {
        //     if (this.ItemExists(item))
        //     {
        //         this.items.Remove(item);
        //         if (item.amount.amount != 0 && typeof(Income) == item.GetType())
        //         {
        //             this.amount -= amount;
        //         }
        //         else
        //         {
        //             this.amount += amount;
        //         }
        //     }
        //     else
        //     {
        //         System.Console.WriteLine("El item no existe.");
        //     }
        // }
        public void ChangeObjective(double newObjective)
        {
            this.Objective = newObjective;
        }
        public void Status()
        {
            string status = "--- Status de la cuenta " + this.Name + " ---\n";
            if (this.History.Count != 0)
            {
                foreach (Transaction transaction in this.History)
                {
                    status += transaction.Type.ToString() + transaction.Coin.ToString() + transaction.Amount + transaction.Date.ToString("dd/MM/yyyy H:mm") + "\n";
                }
            }
            else
            {
                status += new String(' ', (status.Length - 1) / 4) + "Esta cuenta está vacía.\n";
                status += "----------------------------" + new String('-', this.Name.Length);
                System.Console.WriteLine(status);
                return;
            }
            status += "Total: " + (this.Amount).ToString() + "/" + (this.Objective).ToString();
            if (this.Amount >= this.Objective)
            {
                status += " ➕ 😁" + "\n";
            }
            else
            {
                status += " ➖ 🥺" + "\n";
            }
            status += "----------------------------" + new String('-', this.Name.Length);
            System.Console.WriteLine(status);
        }
    }
}
