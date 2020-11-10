using System;

namespace Bankbot
{
    public class DefaultCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            Data data = Data.Empty;
            return AllChats.Instance.ChatsDictionary.TryGetValue(request.id,out data)
                && (!AllCommands.Instance.CommandsList.Contains(request.message)
                && (String) data.DataDictionary["LastCommand"] == "/Init")
                && request.message!="Aborted"
            ;
        }
    }
}