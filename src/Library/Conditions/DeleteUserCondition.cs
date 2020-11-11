using System;

namespace Bankbot
{
    public class DeleteUserCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            Data data = Data.Empty;
            return AllChats.Instance.ChatsDictionary.TryGetValue(request.id,out data)
                && (string) data.DataDictionary["LastCommand"] == "/DeleteUser"
            ;
        }
    }
}