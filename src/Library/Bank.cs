using System.Collections.Generic;
using System.Text;

namespace Bankbot
{
    /*La clase Bank consta de un Singleton para no generar mas de una instancia del mismo ya que solo queremos
    almacenar los objetos Currency creados en una lista global.
    Dicha clase también cumple con el principio OCP ya que se encuentra abierta a la extensión y cerrada a la modificación,
    como también con el patrón Expert y Creator de los principios GRASP, esto se debe a que esta clase es experta en información
    relacionada con el objeto Currency, por lo que es la que se encarga de crear instancias del mismo y almacenarlas.
    A su vez es la encargada de realizar las conversiones monetarias requeridas entre sus elementos.*/

    /// <summary>
    /// Se encarga de realizar conversiones entre tipos de divisas.
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

        /// <summary>
        /// Se agrega una moneda con su códigoISO en caso que le solicitemos.
        /// </summary>
        /// <param name="codeISO"></param>
        /// <param name="symbol"></param>
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
        /// <summary>
        /// Remueve una divisa(tipo de moneda).
        /// </summary>
        /// <param name="codeISO"></param>
        /// <param name="symbol"></param>
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

        /// <summary>
        /// Realiza la conversión entre divisas.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public double Convert(double amount, Currency from, Currency to)
        {
            switch (to.CodeISO)
            {
                case "USS":
                    switch (from.CodeISO)
                    {
                        case "UYU":
                            return amount * 42.74;
                        case "ARG":
                            return amount * 79.38;
                    }
                    break;
                case "UYU":
                    switch (from.CodeISO)
                    {
                        case "USS":
                            return amount * 0.023;
                        case "ARG":
                            return amount * 1.86;
                    }
                    break;
                case "ARG":
                    switch (from.CodeISO)
                    {
                        case "UYU":
                            return amount * 0.54;
                        case "USS":
                            return amount * 0.013;
                    }
                    break;
                default:
                    return amount;
            }
            return amount;
        }

        /// <summary>
        /// Muestra la lista de divisas.
        /// </summary>
        /// <returns></returns>
        public string ShowCurrencyList()
        {
            StringBuilder currencies = new StringBuilder();
            foreach (Currency currency in Bank.Instance.CurrencyList)
            {
                currencies.Append($"{Bank.Instance.CurrencyList.IndexOf(currency) + 1} - {currency.CodeISO}\n");
            }
            return currencies.ToString();
        }
    }
}
