namespace Bankbot
{
    /*Esta clase cumple con el patrón Expert del principio GRASP ya que es la que contiene toda la información
    sobre Currency, pero tambien con el patrón SRP por tener una unica razón de cambio.*/
    
    /// <summary>
    /// Clase correspondiente a la moneda, la cual tiene un símbolo y un código.
    /// </summary>
    public class Currency
    {
        public string CodeISO { get; set; }
        public string Symbol { get; set; }
        public static object Empty { get; internal set; }

        public Currency(string codeISO, string symbol)
        {
            this.CodeISO = codeISO;
            this.Symbol = symbol;
        }
    }
}