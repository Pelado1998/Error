using System;

namespace Bankbot
{
    public interface IObservable
    {
        Money amount {get;set;}
        Money objective{get;set;}
    }
}