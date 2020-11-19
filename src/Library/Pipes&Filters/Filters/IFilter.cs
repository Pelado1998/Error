using System.Collections.Generic;

namespace Bankbot
{
    public interface IFilter
    {
        List<Transaction> Filter(List<Transaction> list);
    }
}