using System;
using System.Collections.Generic;

namespace Bankbot
{
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
        public void Convert(){} //Se implementara cuando se tenga la API
    }
}
