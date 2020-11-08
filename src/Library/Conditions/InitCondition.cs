namespace Bankbot
{
    public class InitCondition : ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return AllCommands.Instance(request.Data.DataDictionary["LastCommand"])
        }
    }
}