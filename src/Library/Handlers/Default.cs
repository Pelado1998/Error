using System;
using System.Collections.Generic;

namespace Bankbot
{
    //Implementacion
    public class Default : AbstractHandler<IMessage>
    {
        public Default(DefaultCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"No te entendi. Vuelve a intentarlo.");
        }
    }
}