using System;
using System.Collections.Generic;

namespace Bankbot
{
    /*Cumple con ## SRP ## 
    Cumple con ## EXPERT ##*/
    /// <summary>
    /// Handler por defecto en caso que no se den las otras posibilidades.
    /// </summary>
    public class DefaultHandler : AbstractHandler<IMessage>
    {
        public DefaultHandler(DefaultCondition condition) : base(condition)
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