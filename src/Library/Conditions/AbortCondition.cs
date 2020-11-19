namespace Bankbot
{
    /*Cumple con EXPERT y SRP*/
    public class ExitCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);
            return data.State == State.HandlingCommand && data.Command.ToLower() == "/exit";
        }
    }
}