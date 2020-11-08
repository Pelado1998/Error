namespace Bankbot
{
    public class InitCondition : ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return request.State == State.Init;
        }
    }
}