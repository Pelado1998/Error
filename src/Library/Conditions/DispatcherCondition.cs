namespace Bankbot
{
    public class DispatcherCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.Dispatcher || request.State == State.Loged || request.State == State.LogedAccounts;
        }
    }
}