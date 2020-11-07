namespace Bankbot
{
    public class DeleteAccountCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.DeleteAccount || request.State == State.DeleteAccountConfirmation;
        }
    }
}