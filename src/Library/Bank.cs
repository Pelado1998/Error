using System;
using System.Collections.Generic;

namespace Bankbot
{
    /// <summary>
    /// Esta clase implementa el patrón de diseño Singletone, ya que en la esta desamos
    /// que se cree una unica instancia de la misma y si se desea agregar un nuevo tipo de moneda.
    /// Dicha clase también cumple con el principio OCP abierto a extensión y cerrado a modificación.
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
            this.CurrencyList = new List<Currency>(){new Currency("UYU","U$"),new Currency("USS","US$"),new Currency("ARG","AR$")};
        }
        public void AddCurrency(Currency currency)
        {
            if (!this.CurrencyList.Contains(currency))
            {
                this.CurrencyList.Add(currency);
            }
            else
            {
                System.Console.WriteLine("Esta moneda ya existe");
            }
        }
        public void RemoveCurrency(Currency currency)
        {
            if (this.CurrencyList.Contains(currency))
            {
                this.CurrencyList.Remove(currency);
            }
            else
            {
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
   }
}
