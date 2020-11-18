using System;
using System.IO;
using System.Collections.Generic;

namespace Bankbot
{
    //Mejoras, implementar una clse password y Name, para que se determine si una contrasenia es valida y fuerte, y el nombre debe contener nombre y apellido
    //Ver como hacemos el historial
    //Tipos de cuenta como enums
    //IPrintable?
    //@BankerPII_bot

    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("a", "a");
            var currency = Bank.Instance.CurrencyList[0];
            user.AddAccount(AccountType.CuentaDeAhorro, "a", currency, 123123, new Objective(124554235432, 1000));

            for (int i = 0; i < 100; i++)
            {
                var amount = i % 2 == 0 ? i * 10 : -i * 10;
                user.Accounts[0].AddTransaction(currency, amount, i.ToString());
                user.Accounts[0].History[i].Date.AddDays(i);
            }

            Session.Instance.AllUsers.Add(user);

            TelegramBot.Instance.Start();
            ConsoleBot.Instance.Start();
        }
    }
}