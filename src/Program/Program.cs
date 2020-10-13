using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using TelegramBot;

namespace Bankbot
{
    //Mejoras, implementar una clse password y Name, para que se determine si una contrasenia es valida y fuerte, y el nombre debe contener nombre y apellido
    //Ver como hacemos el historial
    //Tipos de cuenta como enums
    //IPrintable?

    class Program
    {
        // static Person CreateUser()
        // {
        //     System.Console.Clear();
        //     System.Console.WriteLine("Ingrese un nombre y apellido\n");
        //     string name = System.Console.ReadLine();
        //     System.Console.Clear();
        //     System.Console.WriteLine("Ingrese una contraseña\n");
        //     SecureString pass = new NetworkCredential("", String.Empty).SecurePassword;
        //     while (true)
        //     {
        //         ConsoleKeyInfo i = Console.ReadKey(true);
        //         if (i.Key == ConsoleKey.Enter)
        //         {
        //             break;
        //         }
        //         else
        //         {
        //             Console.Beep();
        //             if (i.Key == ConsoleKey.Backspace)
        //             {
        //                 if (pass.Length != 0)
        //                 {
        //                     pass.RemoveAt(pass.Length - 1);
        //                     Console.Write("\b \b");
        //                 }
        //             }
        //             else
        //             {
        //                 pass.AppendChar(i.KeyChar);
        //                 Console.Write("*");
        //             }
        //         }
        //     }
        //     System.Console.Clear();
        //     System.Console.WriteLine("Seleccione un canal\n");
        //     string chanels = "";
        //     List<Channel> chanelList = new List<Channel>((Channel[])Enum.GetValues(typeof(Channel)));
        //     foreach (Channel item in chanelList)
        //     {
        //         chanels += chanelList.IndexOf(item) + " - " + item.ToString() + "\n";
        //     }
        //     System.Console.WriteLine(chanels);
        //     string optionChanel = (Console.ReadKey()).KeyChar.ToString();
        //     System.Console.Clear();
        //     Channel channel;
        //     switch (optionChanel)
        //     {
        //         case "1":
        //             channel = (Channel)1;
        //             break;
        //         case "2":
        //             channel = (Channel)2;
        //             break;
        //         case "3":
        //             channel = (Channel)3;
        //             break;
        //         default:
        //             channel = (Channel)1;  ///Ver que hacemos en este caso TODO:
        //             break;
        //     }
        //     return new Person(name, 123, pass, channel);
        // }
        // static Account CreateAcount()
        // {
        //     System.Console.Clear();
        //     System.Console.WriteLine("Ingrese un nombre para la cuenta\n");
        //     string nameAccount = System.Console.ReadLine();
        //     System.Console.Clear();
        //     System.Console.WriteLine("Seleccione un tipo de cuenta\n");
        //     string types = string.Empty;
        //     List<AccountType> typeList = new List<AccountType>((AccountType[])Enum.GetValues(typeof(AccountType)));
        //     foreach (AccountType item in typeList)
        //     {
        //         types += typeList.IndexOf(item) + " - " + item.ToString() + "\n";
        //     }
        //     System.Console.WriteLine(types);
        //     AccountType type;
        //     string optionType = (Console.ReadKey()).KeyChar.ToString();
        //     System.Console.Clear();
        //     switch (optionType)
        //     {
        //         case "1":
        //             type = (AccountType)1;
        //             break;
        //         case "2":
        //             type = (AccountType)2;
        //             break;
        //         case "3":
        //             type = (AccountType)3;
        //             break;
        //         default:
        //             type = (AccountType)1;
        //             break;
        //     }
        //     System.Console.WriteLine("Seleccione una Moneda\n");
        //     string coins = "";
        //     List<Coin> coinList = new List<Coin>((Coin[])Enum.GetValues(typeof(Coin)));
        //     foreach (Coin item in coinList)
        //     {
        //         coins += coinList.IndexOf(item) + " - " + item.ToString() + "\n";
        //     }
        //     System.Console.WriteLine(coins);
        //     string optionCoin = (Console.ReadKey()).KeyChar.ToString();
        //     System.Console.Clear();
        //     Coin coinAccount;
        //     switch (optionCoin)
        //     {
        //         case "0":
        //             coinAccount = (Coin)0;
        //             break;
        //         case "1":
        //             coinAccount = (Coin)1;
        //             break;
        //         case "2":
        //             coinAccount = (Coin)2;
        //             break;
        //         default:
        //             coinAccount = (Coin)0;
        //             break;
        //     }
        //     System.Console.WriteLine("Seleccione valor para el objetivo de la cuenta\n");
        //     Double objectiveValue = Convert.ToDouble(System.Console.ReadLine());
        //     System.Console.Clear();
        //     return new Account(nameAccount, "", type, coinAccount, new Money(coinAccount, objectiveValue));
        // }
        // static IItems CreateItem()
        // {
        //     System.Console.Clear();
        //     System.Console.WriteLine("Ingrese un nombre para el item\n");
        //     string nameItem = System.Console.ReadLine();
        //     System.Console.Clear();
        //     System.Console.WriteLine("Seleccione un tipo de item\n");
        //     System.Console.WriteLine("1 - Ingreso \n2 - Gasto\n");
        //     string optionItem = (Console.ReadKey()).KeyChar.ToString();
        //     System.Console.Clear();
        //     System.Console.WriteLine("Seleccione una Moneda\n");
        //     string coins = "";
        //     List<Coin> coinList = new List<Coin>((Coin[])Enum.GetValues(typeof(Coin)));
        //     foreach (Coin item in coinList)
        //     {
        //         coins += coinList.IndexOf(item) + " - " + item.ToString() + "\n";
        //     }
        //     System.Console.WriteLine(coins);
        //     string optionCoin = (Console.ReadKey()).KeyChar.ToString();
        //     System.Console.Clear();
        //     Coin coinObjective;
        //     switch (optionCoin)
        //     {
        //         case "0":
        //             coinObjective = (Coin)0;
        //             break;
        //         case "1":
        //             coinObjective = (Coin)1;
        //             break;
        //         case "2":
        //             coinObjective = (Coin)2;
        //             break;
        //         default:
        //             coinObjective = (Coin)0;
        //             break;
        //     }
        //     System.Console.WriteLine("Seleccione valor para el objetivo del item\n");
        //     Double objectiveValue = Convert.ToDouble(System.Console.ReadLine());
        //     System.Console.Clear();
        //     switch (optionItem)
        //     {
        //         case "0":
        //             return new Income(nameItem, coinObjective, new Money(coinObjective, objectiveValue));
        //         case "1":
        //             return new Outcome(nameItem, coinObjective, new Money(coinObjective, objectiveValue));
        //         default:
        //             return new Income(nameItem, coinObjective, new Money(coinObjective, objectiveValue));
        //     }
        // }

        static void Main(string[] args)
        {
            BotHandler.BotStarter();

            // //Habria que poner estos métodos en los constructores?
            // Console.OutputEncoding = Encoding.Unicode;
            // /*
            // Person user = CrearUsuario();
            // user.AddAcount(CrearCuenta());
            // user.ShowAccounts();
            // user.AddItem(CrearItem());
            // user.ShowAccounts();
            // user.Status();
            // System.Console.ReadLine();
            // */
            // bool run = true;
            // Person user = new Person();
            // while (run)
            // {
            //     System.Console.Clear();
            //     System.Console.WriteLine("💰 Elija Una opción  💰\n");
            //     System.Console.WriteLine("1 - Crear una Persona 🙋🏻‍♀️ 🙋🏻‍♂️");
            //     System.Console.WriteLine("2 - Crear una Cuenta 👛");
            //     System.Console.WriteLine("3 - Crear un Item 🎁");
            //     System.Console.WriteLine("4 - Ver Status 📈");
            //     System.Console.WriteLine("5 - Agregar transacción 💲 💲 \n");
            //     System.Console.Write("\n\n❌ Escape para cerrar  ");
            //     ConsoleKeyInfo i = Console.ReadKey(true);
            //     string option = string.Empty;
            //     if (i.Key == ConsoleKey.Escape)
            //     {
            //         run = false;
            //     }
            //     else
            //     {
            //         option = i.KeyChar.ToString();
            //     }
            //     switch (option)
            //     {
            //         case "1":
            //             if (user.name != null)
            //             {
            //                 System.Console.WriteLine("Ya existe un usuario llamado " + user.name + ".\nDesea sobreescribirlo?\n");
            //                 System.Console.WriteLine("Si/No");
            //                 string overwrite = Console.ReadLine();
            //                 if (overwrite.ToLower() == "si")
            //                 {
            //                     user = CreateUser();
            //                 }
            //                 else
            //                 {
            //                     break;
            //                 }

            //             }
            //             else
            //             {
            //                 user = CreateUser();
            //             }

            //             break;
            //         case "2":
            //             if (user.name == null)
            //             {
            //                 System.Console.Clear();
            //                 System.Console.WriteLine("\nDebes crear una persona primero\n");
            //                 Console.ReadKey();
            //             }
            //             else
            //             {
            //                 user.AddAcount(CreateAcount());
            //             }
            //             break;
            //         case "3":
            //             if (user.name == null)
            //             {
            //                 System.Console.Clear();
            //                 System.Console.WriteLine("\nDebes crear una persona y una cuenta primero\n");
            //                 Console.ReadKey();
            //             }
            //             else
            //             {
            //                 if (user.acounts == null)
            //                 {
            //                     System.Console.Clear();
            //                     System.Console.WriteLine("\nDebes crear una cuenta primero\n");
            //                     Console.ReadKey();
            //                 }
            //                 else
            //                 {
            //                     user.AddItem(CreateItem());
            //                 }

            //             }
            //             break;
            //         case "4":
            //             if (user.name != null && user.acounts != null)
            //             {
            //                 System.Console.Clear();
            //                 user.Status();
            //                 Console.ReadKey();
            //             }
            //             else
            //             {
            //                 System.Console.Clear();
            //                 System.Console.WriteLine("\nDebes crear una persona y una cuenta primero\n");
            //                 Console.ReadKey();
            //             }
            //             break;
            //         case "5":
            //             if (user.name != null && user.acounts != null)
            //             {
            //                 user.Transaction();
            //             }
            //             else
            //             {
            //                 System.Console.Clear();
            //                 System.Console.WriteLine("\nDebes crear una persona y una cuenta primero\n");
            //                 Console.ReadKey();
            //             }

            //             break;
            //         default:
            //             run = false;
            //             break;
            //     }
            // }
        }
    }
}
