using System.Collections.Generic;

namespace Bankbot
{
    public class TransactionItemFilter : IFilter
    {
        public string Param { get; set; }
        public TransactionItemFilter(string param)
        {
            this.Param = param;
        }

        public List<Transaction> Filter(List<Transaction> list)
        {
            var filteredList = new List<Transaction>();

            foreach (var item in list)
            {
                if (item.Description != Param) filteredList.Remove(item);
            }

            return filteredList;
        }
    }
}