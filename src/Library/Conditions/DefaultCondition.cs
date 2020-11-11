namespace Bankbot
{
    public class DefaultCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            return true;
        }
    }
}