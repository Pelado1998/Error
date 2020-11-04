namespace Bankbot
{
    public class CreateUserCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.CreateUsername || request.State == State.CreatePassword;
        }
    }
}