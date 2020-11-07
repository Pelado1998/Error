namespace Bankbot
{
    public class InitCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.Idle;
        }
    }
}