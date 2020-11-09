using System;

namespace Bankbot
{
    public class CreateUserCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            Data data = Data.Empty;
            bool condition = AllChats.Instance.ChatsDictionary.TryGetValue(request.id,out data);
            return condition && (String)  AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LastCommand"] == "/CreateUser"
            ;
        }
    }
}