namespace Bankbot
{
    public class DeleteUserCondition : ICondition<Conversation>
    {
        public bool IsSatisfied(Conversation request)
        {
            return request.State == State.DeleteUser;
        }
    }
}