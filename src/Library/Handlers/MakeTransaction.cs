using System;

namespace Bankbot
{
    public class MakeTransaction : AbstractHandler<IMessage>
    {
        public MakeTransaction(TransactionCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Entro a transaccion");
        }
    }
}
