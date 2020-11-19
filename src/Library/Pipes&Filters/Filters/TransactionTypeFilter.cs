using System.Collections.Generic;

namespace Bankbot
{
    public class TransactionTypeFilter : IFilter
    {
        public string Param { get; set; }
        public TransactionTypeFilter(string param)
        {
            this.Param = param;
        }
        public List<Transaction> Filter(List<Transaction> list)
        {
            var filteredList = new List<Transaction>();

            foreach (var item in list)
            {
                if (Param == "income" && item.Amount > 0)
                {
                    filteredList.Add(item);
                }
                else if (Param == "outcome" && item.Amount < 0)
                {
                    filteredList.Add(item);
                }
            }

            System.Console.WriteLine(filteredList.Count);
            return filteredList;
        }
    }
}