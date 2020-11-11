using System;

namespace Bankbot
{
    public class AbortCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            Data data = Data.Empty;
            return AllChats.Instance.ChatsDictionary.TryGetValue(request.id,out data)
                && request.message == "/Abort"
            ;
        }
    }
}