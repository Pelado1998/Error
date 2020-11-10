using System;


namespace Bankbot
{
    //Implementacion
    public class Abort : AbstractHandler<IMessage>
    {
        public Abort(AbortCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            AllChats.Instance.ChatsDictionary[request.id].Abort();
            request.message = "Aborted";
            ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"La operación se ha abortado.");
        }
    }
}