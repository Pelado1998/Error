using System.Collections.Generic;

namespace Bankbot
{
    public class PipeNull : IPipe
    {
        public List<Transaction> Send(List<Transaction> list)
        {
            return list;
        }
    }
}