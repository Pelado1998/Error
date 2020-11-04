namespace Bankbot
{
    public class DefaultCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return true;
        }
    }
}