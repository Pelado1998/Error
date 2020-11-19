using System;
using System.Collections.Generic;

namespace Bankbot
{
    /*Cumple con ## SRP ## 
    Cumple con ## EXPERT ##*/
    /// <summary>
    /// Handler de bienvenida.
    /// </summary>
    public class InitHandler : AbstractHandler<IMessage>
    {
        public InitHandler(InitCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);

            data.Channel.SendMessage(request.Id, "Bienvenido!");
            data.Channel.SendMessage(request.Id, "Elija un comando de la siguiente lista:\n" + AllCommands.Instance.CommandList(request.Id));
            data.Channel.SendMessage(request.Id, "También puedes utilizar el comando /Abort para abortar cualquier actividad que estés realizando o /Commands para ver los comandos disponibles");

            data.State = State.Dispatcher;
        }
    }
}