using System;


namespace Bankbot
{
    //Implementacion
    public class Commands : AbstractHandler<IMessage>
    {
        public Commands(CommandsCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            Init.Options(request);
            Data data = Data.Empty;
            AllChats.Instance.ChatsDictionary.TryGetValue(request.id, out data);
            data.DataDictionary["LastCommand"] = "/Init";
        }
    }
}