using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class TransactionDateFilter : IFilter
    {
        public DateTime Param { get; set; }

        public TransactionDateFilter(DateTime param)
        {
            this.Param = param;
        }
        public List<Transaction> Filter(List<Transaction> list)
        {
            var filteredList = new List<Transaction>();

            foreach (var item in list)
            {
                if (item.Date.Date != Param.Date) filteredList.Remove(item);
            }

            return filteredList;
        }
    }
}