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
            Options(request);
            request.State=State.Dispatcher;
        }
        public static void Options(Chats request)
        {
            if(request.State == State.Idle)
            {
                System.Console.WriteLine("Elija una de las siguientes opciones:\n\t0-Login\n\t1-Conversion\n\t2-CreateUser");
            }
            else if (request.State == State.Loged)
            {
                System.Console.WriteLine("Elija una de las siguientes opciones:\n\t1-Conversion\n\t2-CreateUser\n\t3-DeleteUser\n\t4-CreateAccount");
            }
            else if (request.State == State.LogedAccounts)
            {
                System.Console.WriteLine("Elija una de las siguientes opciones:\n\t1-Conversion\n\t2-CreateUser\n\t3-DeleteUser\n\t4-CreateAccount\n\t5-DeleteAccount\n\t6-MakeTransaction");
            }
        }
    }
    public class InitCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.Idle || request.State == State.Loged || request.State == State.LogedAccounts;
        }
    }
}