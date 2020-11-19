namespace Bankbot
{
    /*Cumple con EXPERT y SRP*/
    /// <summary>
    /// Comando para realizar una búsqueda de transacciones mediante un filtro aplicado.
    /// </summary>
    public class FilterCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);
            return data.State == State.HandlingCommand && data.Command.ToLower() == "/filter";
        }
    }
}