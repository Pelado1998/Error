namespace Bankbot
{
    public class LoginCondition : ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return request.State == State.Login;
        }
    }
}