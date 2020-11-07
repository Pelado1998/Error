namespace Bankbot
{
    public class DeleteUserCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.DeleteUser || request.State == State.DeleteUserConfirmation;
        }
    }
}