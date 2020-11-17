using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class FilterNull : IFilter
    {

        public FilterNull() { }
        public List<Transaction> Filter(List<Transaction> list)
        {
            return list;
        }
    }
}