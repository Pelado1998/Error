// using System;
// using System.Collections.Generic;

// namespace Bankbot
// {

//     public interface IItems
//     {
//         string name { get; set; }
//         string history { get; set; }
//         Enums.Coin coin { get; set; }
//         Money amount { get; set; }
//         Money objective { get; set; }
//         void Debit(Money amount);
//         void Acredit(Money amount);
//         void Status();
//     }

//     public class Income : IObservable, IItems
//     {
//         public Income(string name, string history, Enums.Coin coin, Money amount, Money objective)
//         {
//             this.name = name;
//             this.history = history;
//             this.coin = coin;
//             this.amount = amount;
//             this.objective = objective;
//         }
//         public Income(string name, Enums.Coin coin, Money amount, Money objective)
//         {
//             this.name = name;
//             this.history = "";
//             this.coin = coin;
//             this.amount = amount;
//             this.objective = objective;
//         }
//         public Income(string name, Enums.Coin coin, Money objective)
//         {
//             this.name = name;
//             this.history = "";
//             this.coin = coin;
//             this.amount = new Money(coin, 0);
//             this.objective = objective;
//         }
//         public string name { get; set; }
//         public string history { get; set; }
//         public Enums.Coin coin { get; set; }
//         public Money amount { get; set; }
//         public Money objective { get; set; }
//         public void Acredit(Money amount)
//         {
//             // if amount >= 0
//             this.amount = this.amount + amount;
//         }
//         public void Debit(Money amount)
//         {
//             // if amount >= 0 && this.amount > amount
//             this.amount = this.amount - amount;
//         }
//         public void Status()
//         {
//             string status = "--- Status del item " + this.name + " ---\n";
//             status += this.name + ": " + (this.amount.amount).ToString() + "/" + (this.objective.amount).ToString() + " $" + (this.coin).ToString();
//             if (this.amount.amount >= this.objective.amount)
//             {
//                 status += " ➕ 😁" + "\n";
//             }
//             else
//             {
//                 status += " ➖ 🥺" + "\n";
//             }
//             status += "------------------------" + new String('-', this.name.Length);
//             System.Console.WriteLine(status);
//         }
//     }
//     public class Outcome : IObservable, IItems
//     {
//         public Outcome(string name, string history, Enums.Coin coin, Money amount, Money objective)
//         {
//             this.name = name;
//             this.history = history;
//             this.coin = coin;
//             this.amount = amount;
//             this.objective = objective;
//         }
//         public Outcome(string name, Enums.Coin coin, Money amount, Money objective)
//         {
//             this.name = name;
//             this.history = "";
//             this.coin = coin;
//             this.amount = amount;
//             this.objective = objective;
//         }
//         public Outcome(string name, Enums.Coin coin, Money objective)
//         {
//             this.name = name;
//             this.history = "";
//             this.coin = coin;
//             this.amount = new Money(coin, 0);
//             this.objective = objective;
//         }
//         public string name { get; set; }
//         public string history { get; set; }
//         public Enums.Coin coin { get; set; }
//         public Money amount { get; set; }
//         public Money objective { get; set; }
//         public void Acredit(Money amount)
//         {
//             this.amount = this.amount + amount;
//         }
//         public void Debit(Money amount)
//         {
//             this.amount = this.amount - amount;
//         }
//         public void Status()
//         {
//             string status = "--- Status del item " + this.name + " ---\n";
//             status += this.name + ": " + this.amount.amount.ToString() + "/" + this.objective.amount.ToString() + " $" + this.coin.ToString();
//             if (this.amount.amount >= this.objective.amount)
//             {
//                 status += " ➖ 🥺" + "\n";
//             }
//             else
//             {
//                 status += " ➕ 😁" + "\n";
//             }
//             status += "------------------------" + new String('-', this.name.Length);
//             System.Console.WriteLine(status);
//         }
//     }
// }
