using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Init : AbstractHandler<Conversation>
    {
        public Init(InitCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {
            TelegramBot.Instance.SendMessage(request.Id,
                                             $@"Bienvenid@! Mi nombre es BankBot y estoy aquí para ayudarte con tus cuentas bancarias.
                                             Para comenzar puedes ingresar /comandos para ver todo loq ue puedo hacer por ti.");

            request.State = State.Dispatcher;
        }
    }
}