using System;
using System.Collections.Generic;
using System.Security;

namespace Bankbot
{
    public class Person
    {
        //TODO: Ver como asignamos el ID
        public Person()
        {
            this.name = null;
            this.password = new SecureString();
            this.id =-1; //Ver como lo generamos
            this.acounts = null;
            this.channels = null; //Ver como lo generamos
        }
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
        public SecureString password {get; set;}
        public long id {get; set;}
        public List<Account> acounts {get; set;}
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
            if (this.acounts==null)
            {
                this.acounts = new List<Account>{};
                this.acounts.Add(account);
            }
            else
            {
                this.acounts.Add(account);
            }
        }
        public void AddChannel(Channel channel)
        {
            if (this.channels==null)
            {
                this.channels = new List<Channel>{};
                this.channels.Add(channel);
            }
            else
            {
                this.channels.Add(channel); 
            }
        }
        public void RemoveAcount(Account account)
        {
            if(this.acounts.Contains(account))
            {
                this.acounts.Remove(account);
            }
            else
            {
                System.Console.WriteLine("No se ha encontrado la cuenta "+account.name);
            }
        }
        public void RemoveChannel(Channel channel)
        {
            if(this.channels.Contains(channel))
            {
                this.channels.Remove(channel);
            }
            else
            {
                System.Console.WriteLine("No se ha encontrado la cuenta "+channel.ToString());
            }
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
                accounts = "No hay cuentas";
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
        public void ShowChannels()
        {
            string channels = "";
            if (this.channels.Count == 0)
            {
                channels = "No hay canales";
            }
            else
            {
                foreach (Channel channel in this.channels)
                {
                    channels += (this.channels.IndexOf(channel))+" - "+ channel.ToString()+"\n";
                }
            }
                System.Console.WriteLine(channels);
        }
        public void AddItem(IItems item)
        {
            System.Console.Clear();
            System.Console.WriteLine("Seleccione una cuenta para agregar un item\n");
            ShowAccounts();
            string option = (Console.ReadKey()).KeyChar.ToString();

            foreach (Account account in this.acounts)
            {
                if (account == this.acounts[Int32.Parse(option)])
                {
                    if (this.acounts[Int32.Parse(option)].coin==item.coin)
                    {
                        this.acounts[Int32.Parse(option)].AddItem(item);
                    }
                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("El item debe ser de la misma moneda que la cuenta");
                        Console.ReadKey();
                    }
                }
            }
            if(!(this.acounts[Int32.Parse(option)].ItemExists(item)) && this.acounts[Int32.Parse(option)].coin==item.coin)
            {
                System.Console.Clear();
                System.Console.WriteLine("No se encontró una cuentas para agregar el item");
                Console.ReadKey();
            }
        }
    }
}
