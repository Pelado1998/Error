using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Currency
    {
        public string CodeISO {get;set;}
        public string Symbol {get;set;}
        public Currency(string codeISO, string symbol)
        {
            this.CodeISO = codeISO;
            this.Symbol  = symbol;
        }

        // public static Money operator +(Money a, Money b) => new Money(a.coin, a.amount + (Converter(a.coin, b)).amount);
        // public static Money operator -(Money a, Money b) => new Money(a.coin, a.amount - (Converter(a.coin, b)).amount);
        // public Currency Currency { get; set; }
        // public double amount { get; set; }
        // public Money() { }
        // public Money(Currency coin, double amount)
        // {
        //     this.Currency = coin;
        //     this.amount = amount;
        // }


        /// <summary>
        /// Convertidor de monedas que recibe un monto, la moneda actual y la futura, devolviendo el monto final
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static double Converter(double amount, CurrencyType from, CurrencyType to)
        {
            switch (to)
            {
                case CurrencyType.USS:
                    switch (from)
                    {
                        case CurrencyType.URU:
                            return amount * 0.025;
                        case CurrencyType.ARG:
                            return amount * 5;
                    }
                    break;
                case CurrencyType.URU:
                    switch (from)
                    {
                        case CurrencyType.USS:
                            return amount * 40;
                        case CurrencyType.ARG:
                            return amount * 500;
                    }
                    break;
                case CurrencyType.ARG:
                    switch (from)
                    {
                        case CurrencyType.URU:
                            return amount * 0.2;
                        case CurrencyType.USS:
                            return amount * 0.04;
                    }
                    break;
                default:
                    return amount;

            }
            return amount;
        }
        // public static Money Convert(Coin coin, Money money)      //Ver cual es la mejor forma de implementarlo  ---- Se puede intentar usar api de cambio
        // {
        //     switch (coin)
        //     {
        //         case Coin.ARG:
        //             switch (money.coin)
        //             {
        //                 case Coin.ARG:
        //                     return new Money(money.coin, money.amount);
        //                 case Coin.URU:
        //                     return new Money(Coin.URU, money.amount * 0.2);
        //                 case Coin.USS:
        //                     return new Money(Coin.USS, money.amount * 0.04);
        //             }
        //             break;
        //         case Coin.URU:
        //             switch (money.coin)
        //             {
        //                 case Coin.ARG:
        //                     return new Money(Coin.ARG, money.amount * 5);
        //                 case Coin.URU:
        //                     return new Money(money.coin, money.amount);
        //                 case Coin.USS:
        //                     return new Money(Coin.USS, money.amount * 0.025);
        //             }
        //             break;
        //         case Coin.USS:
        //             switch (money.coin)
        //             {
        //                 case Coin.ARG:
        //                     return new Money(Coin.ARG, money.amount * 500);
        //                 case Coin.URU:
        //                     return new Money(Coin.URU, money.amount * 40);
        //                 case Coin.USS:
        //                     return new Money(money.coin, money.amount);
        //             }
        //             break;
        //         default:
        //             return new Money(money.coin, money.amount);
        //     }
        //     return new Money(money.coin, money.amount);
        // }
        // public void Convert(Coin coin)      //Ver cual es la mejor forma de implementarlo
        // {
        //     switch (coin)
        //     {
        //         case Coin.ARG:
        //             switch (this.coin)
        //             {
        //                 case Coin.ARG:
        //                     break;
        //                 case Coin.URU:
        //                     this.amount = this.amount * 0.2;
        //                     this.coin = Coin.URU;
        //                     break;
        //                 case Coin.USS:
        //                     this.amount = this.amount * 0.04;
        //                     this.coin = Coin.USS;
        //                     break;
        //             }
        //             break;
        //         case Coin.URU:
        //             switch (this.coin)
        //             {
        //                 case Coin.ARG:
        //                     this.amount = this.amount * 5;
        //                     this.coin = Coin.ARG;
        //                     break;
        //                 case Coin.URU:
        //                     break;
        //                 case Coin.USS:
        //                     this.amount = this.amount * 0.025;
        //                     this.coin = Coin.USS;
        //                     break;
        //             }
        //             break;
        //         case Coin.USS:
        //             switch (this.coin)
        //             {
        //                 case Coin.ARG:
        //                     this.amount = this.amount * 500;
        //                     this.coin = Coin.ARG;
        //                     break;
        //                 case Coin.URU:
        //                     this.amount = this.amount * 40;
        //                     this.coin = Coin.URU;
        //                     break;
        //                 case Coin.USS:
        //                     break;
        //             }
        //             break;
        //     }
        // }
    }
}