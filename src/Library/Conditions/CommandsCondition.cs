using System;

namespace Bankbot
{
    public class CommandsCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            Data data = Data.Empty;
            return  AllChats.Instance.ChatsDictionary.TryGetValue(request.id,out data) 
            &&      (string)  AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LastCommand"] == "/Commands"
                ;
        }
    }
}