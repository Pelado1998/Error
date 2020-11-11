namespace Bankbot
{
    public class DispatcherCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);
            return data.State == State.Dispatcher;
        }
    }
}