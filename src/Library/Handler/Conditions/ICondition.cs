namespace Bankbot
{
    /*Cumple con EXPERT y SRP*/
    /// <summary>
    /// Intefaz de la condición.
    /// </summary>
    /// <typeparam name="IMessage"></typeparam>
    public interface ICondition<IMessage>
    {
        bool IsSatisfied(IMessage request);
    }
}