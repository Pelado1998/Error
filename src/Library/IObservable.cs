namespace Bankbot
{
    /// <summary>
    /// La interface representa un objeto IObservable(observado) que notifica sus cambios a objetos observadores 
    /// (IAlert en este caso). Cumple con el patrón Observer ya que no conoce al observador sino que es éste último 
    /// el que le pide los datos y es de esa manera como colabora con el mismo. 
    /// </summary>
    public interface IObservable
    {
        float Amount { get; set; }
        float Objective { get; set; }
    }
}