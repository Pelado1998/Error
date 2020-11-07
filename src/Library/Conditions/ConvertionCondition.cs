namespace Bankbot
{
    public class ConvertionCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.ConvertAmount|| request.State == State.ConvertFrom || request.State == State.ConvertTo ;
        }
    }
}