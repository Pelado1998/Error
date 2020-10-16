using System;

namespace Bankbot
{
    public interface IObservable
    {
        double Amount { get; set; }
        double Objective { get; set; }
    }
}