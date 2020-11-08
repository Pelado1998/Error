namespace Bankbot
{
    public class CreateAccountCondition : Bankbot.ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return request.User != null && request.State == State.CreateAccount;

        }
    }
}