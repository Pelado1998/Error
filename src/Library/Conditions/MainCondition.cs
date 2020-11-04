namespace Bankbot
{
    public class MainCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.Idle && request.User == null;
        }
    }
}