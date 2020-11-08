namespace Bankbot
{
    public class ConvertionCondition : ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return request.State == State.Converting;
        }
    }
}