namespace Bankbot
{
    public class CreateAccountCondition : Bankbot.ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
                return request.User != null
                &&
                (
                   request.State == State.CreateAccountName
                || request.State == State.CreateAccountType
                || request.State == State.CreateAccountCurrency
                || request.State == State.CreateAccountAmount
                || request.State == State.CreateAccountObjective
                );
        }
    }
}