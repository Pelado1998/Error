using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Text;

namespace Bankbot
{
    //Mejoras, implementar una clse password y Name, para que se determine si una contrasenia es valida y fuerte, y el nombre debe contener nombre y apellido
    //Ver como hacemos el historial
    //Tipos de cuenta como enums
    //IPrintable?

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            string option = System.Console.ReadLine();
            System.Console.WriteLine("1 - Crear una persona");
            System.Console.WriteLine("2 - Crear una cuenta");
            switch (option)
            {
                case "1":
                    System.Console.WriteLine("Ingrese un nombre y apellido");
                    string name = System.Console.ReadLine();
                    System.Console.WriteLine("Ingrese una contraseña");
                    SecureString pass =  new NetworkCredential("", System.Console.ReadLine()).SecurePassword;
                    System.Console.WriteLine("Seleccione un canal\n");
                    string chanels = "";
                    List<Channel> chanelList = new List<Channel> ((Channel[])Enum.GetValues(typeof(Channel)));
                    foreach (Channel item in chanelList)
                    {
                        chanels += chanelList.IndexOf(item) +" - "+ item.ToString()+"\n";
                    }
                    System.Console.WriteLine(chanels);
                    string optionChanel = System.Console.ReadLine();
                    Channel channel;
                    switch (optionChanel)
                    {
                        case "1":
                            channel = Channel.Telegram;
                            break;
                        case "2":
                            channel = Channel.Whatsapp;
                            break;
                        case "3":
                            channel = Channel.Twitter;
                            break;
                        default:
                            channel = Channel.Whatsapp;  ///Ver que hacemos en este caso TODO:
                            break;
                    }
                    Person rafael = new Person(name,123,pass,channel);
                    break;
                case "2":
                    System.Console.WriteLine("Ingrese un nombre para la cuenta");
                    string nameAccount = System.Console.ReadLine();
                    System.Console.WriteLine("Seleccione un tipo de cuenta\n");
                    string types = "";
                    List<AccountType> typeList = new List<AccountType> ((AccountType[])Enum.GetValues(typeof(AccountType)));
                    foreach (AccountType item in typeList)
                    {
                        types += typeList.IndexOf(item) +" - "+ item.ToString()+"\n";
                    }
                    System.Console.WriteLine(types);
                    string optionType = System.Console.ReadLine();
                    switch (optionType)
                    {
                        case
                    }

                    System.Console.WriteLine("Seleccione una Moneda\n");
                    string coins = "";
                    List<Coin> coinList = new List<Coin> ((Coin[])Enum.GetValues(typeof(Coin)));
                    foreach (AccountType item in coinList)
                    {
                        coins += coinList.IndexOf(item) +" - "+ item.ToString()+"\n";
                    }
                    System.Console.WriteLine(coins);
                    string optionCoin = System.Console.ReadLine();

                    System.Console.WriteLine("Seleccione una Moneda para el objetivo\n");
                    string coins = "";
                    List<Coin> coinList = new List<Coin> ((Coin[])Enum.GetValues(typeof(Coin)));
                    foreach (AccountType item in coinList)
                    {
                        coins += coinList.IndexOf(item) +" - "+ item.ToString()+"\n";
                    }
                    System.Console.WriteLine(coins);
                    string optionCoin = System.Console.ReadLine();
                    
                    break;
            }
            /*
            SecureString password = new NetworkCredential("", "Password").SecurePassword;
            Person person = new Person("Rafael Rodriguez", 123456789,password,Channel.Whatsapp);
            Account accountUCU = new Account("CuentaUCU",AccountType.Debito,Coin.URU,new Money(Coin.URU,3000));
            Account accountSantander = new Account("CuentaSatander",AccountType.Credito,Coin.URU,new Money(Coin.URU,35000));
            person.AddAcount(accountUCU);
            person.AddAcount(accountSantander);
            //System.Console.WriteLine(person.acounts[0].name +'\t'+ person.acounts[1].name);
            IItems item1 = new Income("Sueldo",Coin.URU,new Money(Coin.URU,15000),new Money(Coin.URU,13000));
            IItems item2 = new Outcome("Impuestos",Coin.URU,new Money(Coin.URU,6000),new Money(Coin.URU,10000));
            person.acounts[0].AddItem(item1);
            person.acounts[0].AddItem(item2);
            double show = (person.acounts[0].items[0].amount.amount);
            System.Console.WriteLine(show);
            person.acounts[0].Status();
            person.acounts[1].Status();
            person.acounts[0].items[0].Status();
            person.acounts[0].items[1].Status();
            person.ShowAccounts();
            person.Status();
            //show password>> System.Console.WriteLine(System.Net.NetworkCredential(string.Empty, person.password).Password);
            */
        }
    }
}
