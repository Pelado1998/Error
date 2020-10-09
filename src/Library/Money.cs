using System;
using System.Collections.Generic;

namespace Bankbot
{
     public enum Coin
    {
    USS,
    URU,
    ARG,
    }
    
    public class Money
    {
        public static Money operator +(Money a,Money b) => new Money(a.coin,a.amount+(Convert(a.coin,b)).amount);
        public static Money operator -(Money a,Money b) => new Money(a.coin,a.amount-(Convert(a.coin,b)).amount);
        public Coin coin {get;set;}
        public double amount {get;set;}
        public Money(){}
        public Money(Coin coin, double amount)
        {
            this.coin = coin;
            this.amount = amount;
        }
        public static Money Convert(Coin coin, Money money)      //Ver cual es la mejor forma de implementarlo
        {
            switch (coin)
            {
                case Coin.ARG:
                    switch (money.coin)
                    {
                        case Coin.ARG:
                            return new Money(money.coin,money.amount);
                        case Coin.URU:
                            return new Money(Coin.URU,money.amount *0.2);
                        case Coin.USS:
                            return new Money(Coin.USS,money.amount* 0.04);
                    }
                    break;
                case Coin.URU:
                    switch (money.coin)
                    {
                        case Coin.ARG:
                            return new Money(Coin.ARG,money.amount*5);
                        case Coin.URU:
                            return new Money(money.coin,money.amount);
                        case Coin.USS:
                            return new Money(Coin.USS,money.amount* 0.025);
                    }
                    break;              
                case Coin.USS:
                    switch (money.coin)
                        {
                            case Coin.ARG:
                                return new Money(Coin.ARG,money.amount*500);
                            case Coin.URU:
                                return new Money(Coin.URU,money.amount*40);
                            case Coin.USS:
                                return new Money(money.coin,money.amount);
                        }
                    break;
                default:
                    return new Money(money.coin,money.amount);
            }
            return new Money(money.coin,money.amount);
        }
        public void Convert(Coin coin)      //Ver cual es la mejor forma de implementarlo
        {
            switch (coin)
            {
                case Coin.ARG:
                    switch (this.coin)
                    {
                        case Coin.ARG:
                            break;
                        case Coin.URU:
                            this.amount = this.amount*0.2;
                            this.coin = Coin.URU;
                            break;
                        case Coin.USS:
                            this.amount = this.amount *0.04;
                            this.coin = Coin.USS;
                            break;
                    }
                    break;
                case Coin.URU:
                    switch (this.coin)
                    {
                        case Coin.ARG:
                            this.amount = this.amount *5;
                            this.coin = Coin.ARG;
                            break;
                        case Coin.URU:
                            break;
                        case Coin.USS:
                            this.amount = this.amount *0.025;
                            this.coin = Coin.USS;
                            break;
                    }
                    break;              
                case Coin.USS:
                    switch (this.coin)
                        {
                            case Coin.ARG:
                                this.amount = this.amount *500;
                                this.coin = Coin.ARG;
                            break;
                            case Coin.URU:
                                this.amount = this.amount *40;
                                this.coin = Coin.URU;
                                break;
                            case Coin.USS:
                                break;
                        }
                    break;
            }
        }
    }
}