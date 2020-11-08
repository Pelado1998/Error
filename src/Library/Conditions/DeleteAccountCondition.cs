namespace Bankbot
{
    public class DeleteAccountCondition : ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return request.State == State.DeleteAccount;
        }
    }
}