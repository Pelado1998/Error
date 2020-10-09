using System;
using System.Collections.Generic;
using System.Security;

namespace Bankbot
{
    public class Person
    {
        public Person(string name, long id, SecureString password, List<Channel> channels)
        {
            this.name = name;
            this.password = password;
            this.channels = channels;
            this.acounts = new List<Account>{};
        }
        public Person(string name, long id, SecureString password, Channel channel)
        {
            this.name = name;
            this.password = password;
            this.channels = new List<Channel> {channel};
            this.acounts = new List<Account>{};
        }
        public string name {get;set;}
        public long id {get; set;}
        public List<Account> acounts {get; set;}
        public SecureString password {get; set;}
        List<Channel> channels {get; set;}
        public void Status()
        {
            System.Console.WriteLine("--- Status de " + this.name +" ---\n");
            if (acounts.Count !=0)
            {
                foreach (Account accont in this.acounts)
                {
                    accont.Status();
                }
            }
            else
            {
                System.Console.WriteLine("Thera are no accounts.");
            }
        }
        public void AddAcount(Account account)
        {
            this.acounts.Add(account);
        }
        public void AddChannel(Channel channel)
        {
            this.channels.Add(channel);
        }
        public void RemoveAcount(Account account)
        {
            this.acounts.Remove(account);
        }
        public void RemoveChannel(Channel channel)
        {
            this.channels.Remove(channel);
        }
        public void ChangeName(string newName)
        {
            this.name = newName;
        }
        public void ChangePassword(SecureString newPassword)
        {
            this.password = newPassword;
        }
        public void ShowAccounts()
        {
            string accounts = "";
            if (this.acounts.Count == 0)
            {
                accounts = "There are no accounts";
            }
            else
            {
                foreach (Account account in this.acounts)
                {
                    accounts += (this.acounts.IndexOf(account))+" - "+ account.name+"\n";
                }
            }
                System.Console.WriteLine(accounts);
        }
    }
}
