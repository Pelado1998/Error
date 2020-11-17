using System.Collections.Generic;

namespace Bankbot
{
    public interface IPrinter
    {
        void Print(List<Transaction> list);
    }
}