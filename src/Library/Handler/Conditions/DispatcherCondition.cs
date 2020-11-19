namespace Bankbot
{
    /*Cumple con EXPERT y SRP*/
    public class DispatcherCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);
            return data.State == State.Dispatcher && AllCommands.Instance.CommandExist(request.Text);
        }
    }
}