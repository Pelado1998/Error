namespace Bankbot
{
    public class TransactionCondition : ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return request.State == State.Transaction;
        }
    }
}