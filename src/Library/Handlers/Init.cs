using System;
using System.Collections.Generic;

namespace Bankbot
{
    //Implementacion
    public class Init : AbstractHandler<Chats>
    {
        public Init(InitCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Chats request)
        {
            if (request.User == null)
            {
                TelegramBot.Instance.SendMessage(request.Id, "Elija una de las siguientes opciones:\n\t1-Login\n\t2-CreateUser");
            }
            else
            {
                TelegramBot.Instance.SendMessage(request.Id, "Elija una de las siguientes opciones:\n\t1-CreateUser\n\t2-CreateUser");
            }
        }
    }
}