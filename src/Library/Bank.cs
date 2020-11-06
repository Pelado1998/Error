using System.Collections.Generic;
using System.Text;

namespace Bankbot
{
    /// <summary>
    /// La clase Bank consta de un Singleton para no generar mas de una instancia del mismo ya que solo queremos
    /// almacenar los objetos Currency creados en una lista global.
    /// Dicha clase también cumple con el principio OCP ya que se encuentra abierta a la extensión y cerrada a la modificación,
    /// como también con el patrón Expert y Creator de los principios GRASP, esto se debe a que esta clase es experta en información
    /// relacionada con el objeto Currency, por lo que es la que se encarga de crear instancias del mismo y almacenarlas.
    /// A su vez es la encargada de realizar las conversiones monetarias requeridas entre sus elementos.
    /// </summary>
    public class Bank
    {
        public List<Currency> CurrencyList { get; set; }
        private static Bank instance;
        public static Bank Instance
        {
            get
            {
                if (instance == null) instance = new Bank();
                return instance;
            }
        }

        private Bank()
        {
            this.CurrencyList = new List<Currency>() { new Currency("UYU", "U$"), new Currency("USS", "US$"), new Currency("ARG", "AR$") };
        }
        public void AddCurrency(string codeISO, string symbol)
        {
            foreach (var currency in CurrencyList)
            {
                if (currency.CodeISO == codeISO || currency.Symbol == symbol)
                {

                    System.Console.WriteLine("Esta moneda ya existe");
                    return;
                }
            }
            Currency newCurrency = new Currency(codeISO, symbol);
            CurrencyList.Add(newCurrency);
        }
        public void RemoveCurrency(string codeISO, string symbol)
        {
            foreach (var currency in CurrencyList)
            {
                if (currency.CodeISO == codeISO && currency.Symbol == symbol)
                {
                    CurrencyList.Remove(currency);
                    return;
                }
                System.Console.WriteLine("Esta moneda no existe");
            }
        }
        public static double Convert(double amount, Currency from, Currency to)
        {
            switch (to.CodeISO)
            {
                case "USD":
                    switch (from.CodeISO)
                    {
                        case "UYU":
                            return amount * 0.025;
                        case "ARS":
                            return amount * 5;
                    }
                    break;
                case "UYU":
                    switch (from.CodeISO)
                    {
                        case "USD":
                            return amount * 40;
                        case "ARS":
                            return amount * 500;
                    }
                    break;
                case "ARS":
                    switch (from.CodeISO)
                    {
                        case "UYU":
                            return amount * 0.2;
                        case "USD":
                            return amount * 0.04;
                    }
                    break;
                default:
                    return amount;

            }
            return amount;
        }
        public static string ShowCurrencyList()
         {
             StringBuilder currencies = new StringBuilder();
             foreach (Currency currency in Bank.Instance.CurrencyList)
             {
                 System.Console.WriteLine(currency.CodeISO);
                 currencies.Append($"{Bank.Instance.CurrencyList.IndexOf(currency) + 1} - {currency.CodeISO}\n");
             }
             return currencies.ToString();
         }
    }
}
