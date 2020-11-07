using System;

namespace Bankbot
{
    public class Outcome : Transaction
    {
        public string Item { get; set; }
        public Outcome(float amount, Currency currency, DateTime date, string item, string description) : base(amount, currency, date, description)
        {
            this.Item = item;
        }

    }
}