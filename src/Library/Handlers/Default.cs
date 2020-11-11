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
            var data = Session.Instance.GetChat(request.Id);
            data.Channel.SendMessage(request.Id, "No te entendi, vuelve a intentarlo.");
            data.State = State.Dispatcher;
        }
    }
}