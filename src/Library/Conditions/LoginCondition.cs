namespace Bankbot
{
    public class LoginCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.LoginUsername || request.State == State.LoginPassword;
        }
    }
}