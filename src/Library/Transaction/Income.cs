using System;

namespace Bankbot
{
    public class Income : Transaction
    {
        public Income(float amount, Currency currency, DateTime date, string description) : base(amount, currency, date, description)
        {
        }
    }
}