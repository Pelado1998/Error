using System;

namespace Bankbot
{
    public class DispatcherCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            Data data = Data.Empty;
            return AllChats.Instance.ChatsDictionary.TryGetValue(request.id,out data)
                && (String) data.DataDictionary["LastCommand"] == "/Init"
                && AllCommands.Instance.CommandsList.Contains(request.message)
            ;
        }
    }
}