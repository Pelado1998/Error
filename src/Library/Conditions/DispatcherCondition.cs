namespace Bankbot
{
    public class DispatcherCondition : ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return request.State == State.Dispatcher;
        }
    }
}