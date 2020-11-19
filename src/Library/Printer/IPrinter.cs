using System.Collections.Generic;

namespace Bankbot
{
    /*Cumple con  ## EXPERT ## ya que es quien mejor maneja el comando print para realizar una impresión.
    Cumple con ## SRP ## ya que la unica razón de cambio sería la de cambiar la impresión.*/

    /// <summary>
    /// Imprime la lista de transacciones.
    /// </summary>
    public interface IPrinter
    {
        string Print(List<Transaction> list, string path);
    }
}