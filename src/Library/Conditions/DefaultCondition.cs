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
                && (string) data.DataDictionary["LastCommand"] == string.Empty)  //string INIT
                && request.message!="Aborted"
                && request.message!="/Commands"
            ;
        }
    }
}