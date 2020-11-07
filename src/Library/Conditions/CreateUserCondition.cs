namespace Bankbot
{
    public class CreateUserCondition : ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return request.State == State.CreateUser;
        }
    }
}