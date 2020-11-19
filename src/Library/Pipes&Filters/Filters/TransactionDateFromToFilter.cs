using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class TransactionDateFromToFilter : IFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public TransactionDateFromToFilter(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }
        public List<Transaction> Filter(List<Transaction> list)
        {
            var filteredList = new List<Transaction>();

            foreach (var item in list)
            {
                if (item.Date.Date < From.Date && item.Date.Date > To.Date) filteredList.Remove(item);
            }

            return filteredList;
        }
    }
}