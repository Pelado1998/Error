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
            if(request.User == null)
            {
                System.Console.WriteLine("Elija una de las siguientes opciones:\n\t0-Login\n\t1-Conversion\n\t2-CreateUser");
            }
            else if (request.User.Accounts.Count == 0)
            {
                System.Console.WriteLine("Elija una de las siguientes opciones:\n\t1-Conversion\n\t2-CreateUser\n\t3-Logout\n\t4-DeleteUser\n\t5-CreateAccount");
            }
            else if (request.User.Accounts.Count != 0)
            {
                System.Console.WriteLine("Elija una de las siguientes opciones:\n\t1-Conversion\n\t2-CreateUser\n\t3--Logout\n\t4-DeleteUser\n\t5-CreateAccount\n\t6-DeleteAccount\n\t7-MakeTransaction");
            }
        }
        public static void RenewState(Chats request)
        {
            if(request.User == null)
            {
                request.State = State.Dispatcher;
            }
            else if (request.User.Accounts.Count == 0)
            {
                request.State = State.Loged;
            }
            else if (request.User.Accounts.Count != 0)
            {
                request.State = State.LogedAccounts;    
            }
        }
    }
    public class InitCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.Idle;
        }
    }
}