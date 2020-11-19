using System.Collections.Generic;

namespace Bankbot
{
    public interface IPrinter
    {
        string Print(List<Transaction> list, string path);
    }
}