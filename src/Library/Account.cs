using System;
using System.Collections.Generic;

namespace Bankbot
{
    public enum AccountType 
    {
    CuentaDeAhorro,
    Debito,
    Credito
    }
    public class Account: IObservable
    {
        public Account(string name, string history, AccountType accountType, Coin coin, Money objective)
        {
            this.name = name;
            this.history = history;
            this.accountType = accountType;
            this.coin = coin;
            this.amount = new Money(coin,0);
            this.objective = objective;
            this.items = new List<IItems>{};
        }
        public Account(string name, AccountType accountType, Coin coin, Money objective)
        {
            this.name = name;
            this.history = history;
            this.accountType = accountType;
            this.coin = coin;
            this.amount = new Money(coin,0);
            this.objective = objective;
            this.items = new List<IItems>{};
        }
        public Account(string name, AccountType accountType, Coin coin)
        {
            this.name = name;
            this.history = history;
            this.accountType = accountType;
            this.coin = coin;
            this.amount = new Money(coin,0);
            this.objective = new Money(coin,0);
            this.items = new List<IItems>{};
        }
        public string name {get;set;}
        public string history {get;set;}
        public AccountType accountType {get;set;}
        public Coin coin {get;set;}
        public Money amount {get;set;}
        public Money objective {get;set;}
        public List<IItems> items {get;set;}
        public void Accredit(Money money, IItems item)
        {
            if(this.ItemExists(item))
            {
                this.amount = this.amount + money; 
                (this.items[this.items.IndexOf(item)]).Acredit(money);
                //TODO: REGISTRAR EN EL HISTORIAL
            }
            else 
            {
                System.Console.WriteLine("Item does not exists.");
            }
        }
        public void Debit(Money money, IItems item)
        {
            if(this.ItemExists(item))
            {
                this.amount = this.amount - money; 
                (this.items[this.items.IndexOf(item)]).Debit(money);
                //TODO: REGISTRAR EN EL HISTORIAL  
            }
            else 
            {
                System.Console.WriteLine("Item does not exists.");
            }
        }
        public void AddItem(IItems item)
        {
            if(this.ItemExists(item))
            {
                System.Console.WriteLine("Item already exists.");   
            }
            else 
            {
                this.items.Add(item);
                if(item.amount.amount != 0 && typeof(Income)==item.GetType())
                {
                    this.amount+=item.amount;
                }
                else
                {
                   this.amount-=item.amount; 
                }
            }
        }
        public void RemoveItem(IItems item)
        {
            if(this.ItemExists(item))
            {
                   this.items.Remove(item);
                   if(item.amount.amount != 0 && typeof(Income)==item.GetType())
                {
                    this.amount-=amount;
                }
                else
                {
                   this.amount+=amount; 
                }
            }
            else 
            {
                System.Console.WriteLine("Item does not exists.");
            }
        }
        public void ChangeObjective(Money newObjective)
        {
            this.objective = newObjective;
        }
        public void Status()
        {
            string status = "--- Status de la cuenta " + this.name +" ---\n";
            if (this.items.Count !=0)
            {
                foreach (IItems item in this.items)
                {
                    status +=item.name+": "+ (item.amount.amount).ToString()+" $"+item.coin.ToString()+"\n";
                }
            }
            else
            {
                status+=new String(' ', (status.Length-1)/4)+"This account is empty.\n";
                status += "----------------------------" + new String('-', this.name.Length);
                System.Console.WriteLine(status);
                return;
            }
                status += "Total: " + (this.amount.amount).ToString()+"/"+(this.objective.amount).ToString();
                if (this.amount.amount >= this.objective.amount)
                    {
                        status += " ➕ 😁"+"\n";
                    }
                    else
                    {
                        status += " ➖ 🥺"+"\n";
                    }
                status += "----------------------------" + new String('-', this.name.Length);
                System.Console.WriteLine(status);
        }
        private bool ItemExists(IItems item)
        {
            return this.items.Contains( item);
        }
    }
}
