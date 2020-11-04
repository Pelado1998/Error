using System;
using System.Collections.Generic;

namespace Bankbot
{
    //Implementacion
    public class Default : AbstractHandler<Chats>
    {
        public Default(DefaultCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Chats request)
        {
            TelegramBot.Instance.SendMessage(request.Id, "No comprendo lo que dices. Para una lista de comandos disponibles ingresa /commands");
        }
    }
}