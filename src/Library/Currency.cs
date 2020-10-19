using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Currency
    {
        public string CodeISO { get; set; }
        public string Symbol { get; set; }
        public Currency(string codeISO, string symbol)
        {
            this.CodeISO = codeISO;
            this.Symbol = symbol;
        }
    }
}