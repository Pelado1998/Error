namespace Bankbot
{
    /*Cumple con EXPERT y SRP*/
    /// <summary>
    /// Da la posibilidad de borrar cuentas.
    /// </summary>
    public class DeleteAccountCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);
            return data.State == State.HandlingCommand && data.Command.ToLower() == "/deleteaccount";
        }
    }
}