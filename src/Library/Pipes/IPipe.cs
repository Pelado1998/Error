using System.Collections.Generic;

namespace Bankbot
{
    public interface IPipe
    {
        List<Transaction> Send(List<Transaction> list);
    }
}