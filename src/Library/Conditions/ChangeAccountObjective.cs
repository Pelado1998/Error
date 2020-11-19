namespace Bankbot
{
    public class ChangeAccountObjective : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);
            return data.State == State.HandlingCommand && data.Command.ToLower() == "/changeobjective";
        }
    }
}