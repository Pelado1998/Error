namespace Bankbot
{
    /*Cumple con EXPERT y SRP*/

    /// <summary>
    /// Comando para realizar una transacción.
    /// </summary>
    public class TransactionCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);
            return data.State == State.HandlingCommand && data.Command.ToLower() == "/transaction";
        }
    }
}