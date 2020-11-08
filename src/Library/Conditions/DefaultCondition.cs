namespace Bankbot
{
    public class DefaultCondition : ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return true;
        }
    }
}